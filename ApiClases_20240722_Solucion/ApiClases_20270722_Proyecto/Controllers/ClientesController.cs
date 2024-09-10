
using ApiClases_20270722_Proyecto.Entidades;
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
        private readonly IHubContext<SignalRHubNotificacion> _hubContext;
        //private readonly IMediator _mediator;

        public ClientesController(
            IRepositorioGenerico<Cliente> clienteRepositorio,
            IRepositorioGenerico<Pais> paisRepositorio,
            IRepositorioGenerico<Contacto> contactoRepositorio,
            IServicioToken servicioToken,
            IMapper mapper,
            UserManager<UsuarioAplicacion> userManager,
            SignInManager<UsuarioAplicacion> signInManager,
            IHubContext<SignalRHubNotificacion> hubContext
            /*IMediator mediator*/)
        {
            _clienteRepositorio = clienteRepositorio;
            _paisRepositorio = paisRepositorio;
            _contactoRepositorio = contactoRepositorio;
            _servicioToken = servicioToken;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager;
            _signInManager = signInManager;
            //_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _hubContext = hubContext;
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
            var cliente = _clienteRepositorio.ObtenerPorId(id);
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
            catch (ArgumentException)
            {
                // Si no es un token JWT válido, asumir que es un nombre
                nombre = valor;
            }

            var cliente = _clienteRepositorio.ObtenerPorNombre(nombre.ToString());
            if (cliente == null) return NotFound();

            var finalClienteDto = _mapper.Map<ClienteGetDto>(cliente);
            return Ok(finalClienteDto);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ClienteInicioSesion modelo)
        {
            // Verificar si el usuario existe en el servidor
            var searchInServer = await _userManager.FindByNameAsync(modelo.Usuario);
            if (searchInServer == null)
            {
                return NotFound(); // Usuario no encontrado
            }

            // Intentar iniciar sesión
            var result = await _signInManager.PasswordSignInAsync(
                modelo.Usuario,
                modelo.Contrasena,
                modelo.Recuerdame,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Obtener el usuario
                var user = await _userManager.FindByNameAsync(modelo.Usuario);
                var token = _servicioToken.GenerateJwtToken(user);

                // Obtener el cliente desde el repositorio
                var cliente = _clienteRepositorio.ObtenerPorNombre(modelo.Usuario);
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado.");
                }

                // Enviar los datos del cliente utilizando el Hub
                await _hubContext.Clients.All.SendAsync("newlogin", new
                {
                    Message = "Nuevo inicio sesion",
                    cliente.Nombre,
                    cliente.Apellido,
                    cliente.FechaNacimiento,
                    cliente.Empleo,
                    cliente.PaisId,
                    cliente.Email
                });

                return Ok(new { Token = token });
            }

            return Unauthorized(); // Contraseña incorrecta
        }




        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ClienteRegistro modelo)
        {
            var searchInServer = await _userManager.FindByEmailAsync(modelo.Email);
            if (searchInServer != null)
            {
                return Conflict(new { Message = "DuplicateUserName" }); // El username es el mismo que la primera parte del email
            }
            if (modelo.PaisId is null)
            {
                return Conflict(new { Message = "PaisId es nulo" });
            }
            var usuario = new UsuarioAplicacion
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                UserName = modelo.Email.Split('@')[0],
                Email = modelo.Email,
                FechaNacimiento = modelo.FechaNacimiento,
                Empleo = modelo.Empleo,
                PaisId = (int)modelo.PaisId,
            };


            var result = await _userManager.CreateAsync(usuario, modelo.Contrasena);
            if (!result.Succeeded) //Actualmente no deberia llegar a esta situación (con lo actualmente planteado),
                                   //por lo que deberia replantearse la logica en este lugar
            {
                foreach (var error in result.Errors)
                {
                    //System.Diagnostics.Debug.WriteLine($"Código de Error: {error.Code}, Descripción: {error.Description}");
                    if (error.Code.Equals("DuplicateUserName"))
                    { // Solo deberia existir este caso (username duplicado), pero en caso de ser necesario dejo el bad Request
                        System.Diagnostics.Debug.WriteLine("LLEGO AQUI");
                        return Conflict(new { Message = "DuplicateUserName" });

                    }
                }
                return BadRequest(new { Message = result.Errors });
            }

            var cliente = _mapper.Map<Cliente>(modelo);
            cliente.Email = modelo.Email;
            cliente.Usuario = modelo.Email.Split('@')[0];

            _clienteRepositorio.Agregar(cliente);
            var addClienteResult = await _clienteRepositorio.GuardarCambios();

            if (!addClienteResult)
            {
                return BadRequest(new { Message = "Error al guardar en la tabla Clientes" });
            }

            var addRoleResult = await _userManager.AddToRoleAsync(usuario, "Cliente");
            if (!addRoleResult.Succeeded)
            {
                return BadRequest(new { Message = "Fallo al añadir el nuevo rol." });
            }

            var token = _servicioToken.GenerateJwtToken(usuario);
            // Informamos de un nuevo registro
            await _hubContext.Clients.All.SendAsync("newregister", new
            {
                Message = "Nuevo registro",
                cliente.Nombre,
                cliente.Apellido,
                cliente.FechaNacimiento,
                cliente.Empleo,
                cliente.PaisId,
                cliente.Email
            });

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, ClientePutDto clienteDto)
        {
            var clienteExistente = _clienteRepositorio.ObtenerPorId(id);
            if (clienteExistente == null) return NotFound();

            // Actualizar PaisId solo si tiene valor en el DTO
            if (clienteDto.PaisId.HasValue && clienteDto.PaisId.Value != -1)
            {
                clienteExistente.PaisId = clienteDto.PaisId.Value;
            }

            // Actualizar Empleo solo si no es nulo y no está vacío
            if (!string.IsNullOrWhiteSpace(clienteDto.Empleo))
            {
                clienteExistente.Empleo = clienteDto.Empleo;
            }

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
