
using ApiClases_20270722_Proyecto.Modelos.Clientes;
using ApiClases_20270722_Proyecto.Repositorios;
using System.IdentityModel.Tokens.Jwt;

namespace ApiClases_20270722_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ClientesController : ControllerBase
    {
        private readonly IRepositorioGenerico<Cliente> _clienteRepositorio;
        private readonly IRepositorioGenerico<Pais> _paisRepositorio;
        private readonly IRepositorioGenerico<Contacto> _contactoRepositorio;
        private readonly IServicioToken _servicioToken;
        private readonly IMapper _mapper;
        private readonly UserManager<UsuarioAplicacion> _userManager;
        private readonly SignInManager<UsuarioAplicacion> _signInManager;

        public ClientesController(
            IRepositorioGenerico<Cliente> clienteRepositorio,
            IRepositorioGenerico<Pais> paisRepositorio,
            IRepositorioGenerico<Contacto> contactoRepositorio,
            IServicioToken servicioToken,
            IMapper mapper,
            UserManager<UsuarioAplicacion> userManager,
            SignInManager<UsuarioAplicacion> signInManager)
        {
            _clienteRepositorio = clienteRepositorio;
            _paisRepositorio = paisRepositorio;
            _contactoRepositorio = contactoRepositorio;
            _servicioToken = servicioToken;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteBaseDto>>> Get()
        {
            var clientes = await _clienteRepositorio.Obtener();
            var clientesDto = _mapper.Map<IEnumerable<ClienteBaseDto>>(clientes);
            return Ok(clientesDto);
        }

        [HttpGet("{id:int}", Name = "getClienteId")]
        public async Task<ActionResult<ClienteGetDto>> Get(int id)
        {
            var cliente =  _clienteRepositorio.ObtenerPorId(id);
            if (cliente == null) return NotFound();

            var finalClienteDto = _mapper.Map<ClienteGetDto>(cliente);
            return Ok(finalClienteDto);
        }

       
        [HttpGet("{valor}", Name = "getCliente")]
        public async Task<ActionResult<ClienteGetDto>> Get(string valor)
        {
            string nombre;

            // Intentar decodificar el token JWT
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var jwtToken = handler.ReadJwtToken(valor);
                nombre = jwtToken.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
            }
            catch(ArgumentException)
            {
                // Si no es un token JWT válido, asumir que es un nombre
                nombre = valor;
            }

            var cliente =  _clienteRepositorio.ObtenerPorNombre(nombre.ToString());
            if (cliente == null) return NotFound();

            var finalClienteDto = _mapper.Map<ClienteGetDto>(cliente);
            return Ok(finalClienteDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ClienteInicioSesion modelo)
        {
            var result = await _signInManager.PasswordSignInAsync(
                modelo.Usuario,
                modelo.Contrasena,
                modelo.Recuerdame,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(modelo.Usuario);
                var token = _servicioToken.GenerateJwtToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ClienteRegistro modelo)
        {
            var usuario = new UsuarioAplicacion
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                UserName = modelo.Email.Split('@')[0],
                Email = modelo.Email,
                FechaNacimiento = modelo.FechaNacimiento,
                Empleo = modelo.Empleo,
                PaisId = modelo.PaisId,
            };

            var result = await _userManager.CreateAsync(usuario, modelo.Contrasena);
            if (!result.Succeeded)
            {
                return BadRequest("1");
            }

            var cliente = _mapper.Map<Cliente>(modelo);
            cliente.Email = modelo.Email;  // Mapeo adicional de email
            cliente.Usuario = modelo.Email.Split('@')[0];

            _clienteRepositorio.Agregar(cliente);
            var addClienteResult = await _clienteRepositorio.GuardarCambios();

            if (!addClienteResult)
            {
                return BadRequest("2");
            }

            var addRoleResult = await _userManager.AddToRoleAsync(usuario, "Cliente");
            if (!addRoleResult.Succeeded)
            {
                return BadRequest(new { Message = "Fallo al añadir el nuevo rol." });
            }

            var token = _servicioToken.GenerateJwtToken(usuario);


            var numClientes = (await _clienteRepositorio.Obtener()).Count();
            Random random = new Random();
            for (var i = 0; i <= 6; i++)
            {
                _contactoRepositorio.Agregar(new Contacto
                {
                    Id = 0,
                    ClienteOrigenId = numClientes,
                    ClienteDestinoId = random.Next(1, numClientes),
                });
            }
            await _contactoRepositorio.GuardarCambios();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, ClientePutDto clienteDto)
        {
            var clienteExistente = _clienteRepositorio.ObtenerPorId(id);
            if (clienteExistente == null) return NotFound();

            clienteExistente.PaisId = clienteDto.PaisId;
            clienteExistente.Empleo = clienteDto.Empleo;

            _clienteRepositorio.Actualizar(id, clienteExistente);

            if (await _clienteRepositorio.GuardarCambios())
            {
                return NoContent();
            }

            return BadRequest("Error al actualizar el cliente");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var clienteExistente = _clienteRepositorio.ObtenerPorId(id);
            if (clienteExistente == null) return NotFound();

            _clienteRepositorio.Borrar(id);

            if (await _clienteRepositorio.GuardarCambios())
            {
                return NoContent();
            }

            return BadRequest("Error al borrar el cliente");
        }
    }
}
