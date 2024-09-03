using ApiClases_20270722_Proyecto.Repositorios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;

namespace ApiClases_20270722_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : Controller
    {
        private readonly IVistaContactoRepositorio<VContacto> _vistaContactoRepositorio;
        private readonly IRepositorioGenerico<Cliente> _clienteRepositorio;
        private readonly ContactosRepositorioBBDD<Contacto> _contactosRepositorio;
        public ContactosController(
            IVistaContactoRepositorio<VContacto> vistacontactorepositorio,
            IRepositorioGenerico<Cliente> clienteRepositorio,
            ContactosRepositorioBBDD<Contacto> contactosRepositorio)
        {
            _vistaContactoRepositorio = vistacontactorepositorio;
            _clienteRepositorio = clienteRepositorio;
            _contactosRepositorio = contactosRepositorio;
        }
        [HttpPost("getAllContacts")]
        public async Task<ActionResult<IEnumerable<VContacto>>> GetVistaContactos(VContactoParametrosFiltradoDto filtro)
        {
            var (contactos, count) = await _vistaContactoRepositorio.GetVContactosAsync(filtro);
            return contactos.ToList();
        }
        [HttpGet("getAllContactsById")]
        public async Task<ActionResult<IEnumerable<VContacto>>> GetVistaContactos(int id)
        {
            VContactoParametrosFiltradoDto filtro = new VContactoParametrosFiltradoDto
            {
                IdCliente = id,
                NumeroPaginas = 1,
                TamanoPagina = 30
            };
            var (contactos, count) = await _vistaContactoRepositorio.GetVContactosAsync(filtro);
            return contactos.ToList();
        }
        [HttpGet("{valor}", Name = "getAllContactsByToken")]

        public async Task<ActionResult<IEnumerable<VContacto>>> ObtenerVistaContactosPorToken(string valor)
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
            var idCliente = _clienteRepositorio.ObtenerPorNombre(nombre.ToString()).Id;
            VContactoParametrosFiltradoDto filtro = new VContactoParametrosFiltradoDto
            {
                IdCliente = idCliente,
                NumeroPaginas = 1,
                TamanoPagina = 30
            };
            var (contactos, count) = await _vistaContactoRepositorio.GetVContactosAsync(filtro);
            return contactos.ToList();
        }

        [HttpDelete("")]
        public async Task<ActionResult> DeleteAsync(string nombreAEliminar,string token) {
            string nombre;
            // Intentar decodificar el token JWT
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            nombre = jwtToken.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;


            var idContactoAEliminar = _clienteRepositorio.ObtenerPorNombre(nombreAEliminar.ToString()).Id;
            var idContactoRelacionado = _clienteRepositorio.ObtenerPorNombre(nombre.ToString()).Id;

            var contacto = _contactosRepositorio.ObtenerPorIds(idContactoRelacionado, idContactoAEliminar);

            if(contacto == null) return NotFound();

            _contactosRepositorio.Borrar(contacto.Id);

            if(await _contactosRepositorio.GuardarCambios())
            {
                return NoContent();
            }

            return BadRequest("Error al borrar el cliente");
        }
        [HttpPost("checkIfExists")]
        public async Task<ActionResult> CheckIfExists([FromBody] ModeloBusquedaContacto modelo) {
            string nombre;
            // Intentar decodificar el token JWT
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var jwtToken = handler.ReadJwtToken(modelo.tokenCliente);
                nombre = jwtToken.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
            }
            catch(ArgumentException)
            {
                // Si no es un token JWT válido, asumir que es un nombre
                nombre = modelo.tokenCliente;
            }
            var idCliente = _clienteRepositorio.ObtenerPorNombre(nombre.ToString()).Id;
            if(await _vistaContactoRepositorio.CheckIfExistsInView(idCliente, modelo.NombreUsuarioClienteABuscar))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactoRequest request) {
            string nombre;
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(request.token);
            nombre = jwtToken.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;

            var idContactoNuevo = _clienteRepositorio.ObtenerPorNombre(request.nombreNuevoContacto).Id;
            var idContactoRelacionado = _clienteRepositorio.ObtenerPorNombre(nombre).Id;

            _contactosRepositorio.Agregar(new Contacto
            {
                Id = 0,
                ClienteOrigenId = idContactoRelacionado,
                ClienteDestinoId = idContactoNuevo,
            });
            var addContactoResult = await _contactosRepositorio.GuardarCambios();

            if(!addContactoResult)
            {
                return BadRequest(new { Message = "Error al guardar en la tabla Clientes" });
            }
            return Ok();
        }
        
    }
}
