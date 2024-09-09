
using ApiClases_20270722_Proyecto.SignalRServicio;
using Microsoft.AspNetCore.Cors;

namespace ApiClases_20270722_Proyecto.Controllers;


[Route("api/Clientes/{id_cliente}/Transacciones")]
[ApiController]
public class TransaccionesController : ControllerBase
{

    public readonly IRepositorioGenerico<Transaccion> _repositorio;
    public readonly IRepositorioGenerico<Cliente> _clienteRepositorio;

    private readonly IMapper _mapper;
    //private readonly IMediator _mediator;
    private readonly IHubContext<SignalRHubNotificacion> _hubContext;
    public TransaccionesController(
            IRepositorioGenerico<Transaccion> repositorio,
            IMapper mapper,
            IHubContext<SignalRHubNotificacion> hubcontext,
            IRepositorioGenerico<Cliente> clienteRepositorio
            /*IMediator mediator*/)
    {
        _repositorio = repositorio;
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        //_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _hubContext = hubcontext ?? throw new ArgumentNullException(nameof(hubcontext));
        _clienteRepositorio = clienteRepositorio;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransaccionGetDto>>> GetAsync([FromRoute] int id_cliente, [FromQuery] DateTime? fechaInicio, [FromQuery] DateTime? fechaFin, [FromQuery] double? cantidadEnviadaMin, [FromQuery] double? cantidadEnviadaMax, [FromQuery] double? cantidadRecibidaMin, [FromQuery] double? cantidadRecibidaMax)
    {
        var filtro = new FiltroTransacciones
        {
            IdCliente = id_cliente,
            FechaInicio = fechaInicio,
            FechaFin = fechaFin,
            CantidadEnviadaMin = cantidadEnviadaMin,
            CantidadEnviadaMax = cantidadEnviadaMax,
            CantidadRecibidaMin = cantidadRecibidaMin,
            CantidadRecibidaMax = cantidadRecibidaMax
        };

        return Ok(_mapper.Map<IEnumerable<TransaccionGetDto>>(await _repositorio.ObtenerTodosFiltrado(filtro)));
    }


    [HttpGet("{id_transaccion}", Name = "getTransaccion")]
    public ActionResult<TransaccionGetDto> Get([FromRoute] int id_cliente, [FromRoute] int id_transaccion)
    {
        var transaccion = _repositorio.ObtenerTransaccionId(id_cliente, id_transaccion);

        // Si la transacción es nula, devolvemos un 404 Not Found
        if (transaccion == null)
        {
            return NotFound();
        }

        var finalTransaccionGetDto = _mapper.Map<TransaccionGetDto>(transaccion);

        // Si el mapeo falla y finalTransaccionGetDto es null (aunque esto no debería suceder si transaccion no es null)
        return finalTransaccionGetDto == null ? NotFound() : Ok(finalTransaccionGetDto);
    }



    [EnableCors("AllowAllOrigins")]
    [HttpPost]
    public async Task<ActionResult<TransaccionPostDto>> Post(TransaccionPostDto transaccion)
    {
        var transaccionEntidad = _mapper.Map<Transaccion>(transaccion);
        _repositorio.Agregar(transaccionEntidad);

        if (await _repositorio.GuardarCambios())
        {
            var transaccionDto = _mapper.Map<TransaccionPostDto>(transaccionEntidad);

            // Enviar los datos de la transacción utilizando el mediador. SignalR.
            // Obtener datos de los clientes desde la base de datos
            var clienteEnvia = _clienteRepositorio.ObtenerPorId(transaccion.IdEnvia);
            var clienteRecibe = _clienteRepositorio.ObtenerPorId(transaccion.IdRecibe);
            await _hubContext.Clients.All.SendAsync("newtransaction", new
            {
                Message = "Nueva Transaccion",
                PaisOrigen = clienteEnvia.PaisId,
                PaisDestino = clienteRecibe.PaisId,
                ClienteOrigen = clienteEnvia.Usuario,
                ClienteDestino = clienteRecibe.Usuario,
                ClienteOrigenId = transaccion.IdEnvia,
                ClienteDestinoId = transaccion.IdRecibe,
                ValorOrigen = transaccion.CantidadEnvia,
                ValorDestino = transaccion.CantidadRecibe,
                Timestamp = transaccion.Fecha,
                transaccion.CosteTransaccion // Incluimos el campo CosteTransaccion
            });

            return CreatedAtAction(
                nameof(Get),
                new { id_cliente = transaccionEntidad.IdEnvia, id_transaccion = transaccionEntidad.Id },
                transaccionDto
            );
        }
        else
        {
            return BadRequest();
        }

    }


    // No usamos ni Put ni Delete
}
