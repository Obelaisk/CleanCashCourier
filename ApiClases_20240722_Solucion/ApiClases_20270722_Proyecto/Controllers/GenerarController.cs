using BackendEstadistica.Faker;
using Microsoft.AspNetCore.Mvc;

namespace ApiClases_20270722_Proyecto.Controllers;
public class GenerarController : Controller
{
    public readonly IRepositorioGenerico<Transaccion> _transaccionRepositorio;
    public readonly IRepositorioGenerico<Cliente> _clientesRepositorio;
    public readonly ContactosRepositorioBBDD<Contacto> _contactoRepositorio;
    public readonly IRepositorioGenerico<Pais> _paisRepositorio;
    private readonly IMapper _mapper;

    public GenerarController(
        IRepositorioGenerico<Transaccion> transaccionRepositorio, 
        IRepositorioGenerico<Cliente> clientesRepositorio, 
        ContactosRepositorioBBDD<Contacto> contactoRepositorio, 
        IRepositorioGenerico<Pais> paisRepositorio, 
        IMapper mapper)
    {
        _transaccionRepositorio = transaccionRepositorio;
        _clientesRepositorio = clientesRepositorio;
        _contactoRepositorio = contactoRepositorio;
        _paisRepositorio = paisRepositorio;
        _mapper = mapper;
    }
    [HttpGet("generarClientes/{n_clientes}")]
    public async Task<IActionResult> GenerarClientes(int n_clientes)
    {
        var paises = await _paisRepositorio.Obtener();
        var clienteFaker = new ClienteFaker(paises);
        for (int i = 0; i < n_clientes; i++)
        {
            var clienteDto = clienteFaker.Generate();
            clienteDto.Usuario = clienteDto.Email.Split('@')[0]; //Sino no hay congruencia
            var nuevoCliente = _mapper.Map<Cliente>(clienteDto);
            _clientesRepositorio.Agregar(nuevoCliente);
        }
        if (await _clientesRepositorio.GuardarCambios())
            return Ok();
        else
            return StatusCode(500); // Para debug
    }
    [HttpGet("generarTransacciones/{n_transacciones}")]
    public async Task<IActionResult> GenerarTransacciones(int n_transacciones)
    {
        var paises = await _paisRepositorio.Obtener();
        Random random = new Random((int)DateTime.Now.Ticks);
        var contactos = await _contactoRepositorio.Obtener(); // Cuidado que puede ser que no haya contactos, revisar o generar clientes -> contactos -> transacciones
        var contacto = contactos[random.Next(0, contactos.Count)];
        var clienteOrigen = _clientesRepositorio.ObtenerPorId(contacto.ClienteOrigenId);
        var clienteDestino = _clientesRepositorio.ObtenerPorId(contacto.ClienteDestinoId);
        var transaccionFaker = new TransaccionFaker(clienteOrigen, clienteDestino, paises);
        for (int i = 0; i < n_transacciones; i++)
        {
            var transaccionDto = transaccionFaker.Generate();
            var nuevaTransaccion = _mapper.Map<Transaccion>(transaccionDto);
            _transaccionRepositorio.Agregar(nuevaTransaccion);
        }
        if (await _transaccionRepositorio.GuardarCambios())
            return Ok();
        else
            return StatusCode(500); // Para debug
    }
    [HttpGet("generarContactos/{n_contactos}")]
    public async Task<IActionResult> GenerarContactos(int n_contactos)
    {
        var clientes = await _clientesRepositorio.Obtener();
        Random random = new Random((int)DateTime.Now.Ticks);
        for (int i = 0; i < n_contactos; i++)
        {
            var clienteOrigenId = clientes[random.Next(clientes.Count)].Id;
            var clienteDestinoId = clientes[random.Next(clientes.Count)].Id;
            while (clienteDestinoId == clienteOrigenId)
                clienteDestinoId = clientes[random.Next(clientes.Count)].Id;

            if (_contactoRepositorio.ObtenerPorIds(clienteOrigenId, clienteDestinoId) == null)
            {
                _contactoRepositorio.Agregar(new Contacto
                {
                    Id = 0,
                    ClienteOrigenId = clienteOrigenId,
                    ClienteDestinoId = clienteDestinoId,
                });
            }
        }

        if (await _contactoRepositorio.GuardarCambios())
            return Ok();
        else
            return StatusCode(500); // Para debug
    }
    [HttpGet("generarContactosParaCliente")]
    public async Task<IActionResult> generarContactosParaCliente([FromQuery]int n_contactos, [FromQuery] int? id_cliente, [FromQuery] string? username_cliente)
    {
        var clientes = await _clientesRepositorio.Obtener();
        Random random = new Random((int)DateTime.Now.Ticks);
        int clienteOrigenId = -1;
        if(id_cliente != null)
            clienteOrigenId = id_cliente.Value;
        else if (username_cliente != null)
        {
            var cliente = _clientesRepositorio.ObtenerPorNombre(username_cliente);
            if (cliente == null)
                return BadRequest();
            clienteOrigenId = cliente.Id;
        }
        else
            BadRequest();
        for (int i = 0; i < n_contactos; i++)
        {
            var clienteDestinoId = clientes[random.Next(clientes.Count)].Id;
            while (clienteDestinoId == clienteOrigenId)
                clienteDestinoId = clientes[random.Next(clientes.Count)].Id;
            if (_contactoRepositorio.ObtenerPorIds(clienteOrigenId, clienteDestinoId) == null) // para no generar contactos repetidos
            {
                _contactoRepositorio.Agregar(new Contacto
                {
                    Id = 0,
                    ClienteOrigenId = clienteOrigenId,
                    ClienteDestinoId = clienteDestinoId,
                });
            }
        }
        if (await _contactoRepositorio.GuardarCambios())
            return Ok();
        else
            return StatusCode(500); // Para debug
    }

    [HttpGet("generarTransaccionesParaCliente")]
    public async Task<IActionResult> GenerarTransaccionesParaCliente([FromQuery] int n_transacciones, [FromQuery] int? id_cliente, [FromQuery] string? username_cliente)
    {
        var clientes = await _clientesRepositorio.Obtener();
        var paises = await _paisRepositorio.Obtener();
        var contactos = await _contactoRepositorio.Obtener(); // Cuidado que puede ser que no haya contactos, revisar o generar clientes -> contactos -> transacciones
        Random random = new Random((int)DateTime.Now.Ticks);
        int clienteOrigenId = -1;

        if (id_cliente != null)
            clienteOrigenId = id_cliente.Value;
        else if (username_cliente != null)
        {
            var cliente = _clientesRepositorio.ObtenerPorNombre(username_cliente);
            if (cliente == null)
                return BadRequest();
            clienteOrigenId = cliente.Id;
        }
        else
            BadRequest();
        contactos = contactos.Where(c => c.ClienteOrigenId == clienteOrigenId).ToList();
        for (int i = 0; i < n_transacciones; i++)
        {
            var contacto = contactos[random.Next(0, contactos.Count)];
            var clienteOrigen = _clientesRepositorio.ObtenerPorId(clienteOrigenId);
            var clienteDestino = _clientesRepositorio.ObtenerPorId(contacto.ClienteDestinoId);
            var transaccionFaker = new TransaccionFaker(clienteOrigen, clienteDestino, paises);
            var transaccionDto = transaccionFaker.Generate();
            transaccionDto.CosteTransaccion = Math.Round(transaccionDto.CosteTransaccion, 2);
            transaccionDto.CantidadEnvia = Math.Round(transaccionDto.CantidadEnvia, 2);
            transaccionDto.CantidadRecibe = Math.Round(transaccionDto.CantidadRecibe, 2);
            var nuevaTransaccion = _mapper.Map<Transaccion>(transaccionDto);
            _transaccionRepositorio.Agregar(nuevaTransaccion);
        }
        if (await _transaccionRepositorio.GuardarCambios())
            return Ok();
        else
            return StatusCode(500); // Para debug
    }
}
