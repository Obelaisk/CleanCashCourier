
//namespace ApiClases_20270722_Proyecto.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class SignalREnvioController : ControllerBase
//{
//    private readonly IMediator _mediator;

//    public SignalREnvioController(IMediator mediator)
//    {
//        _mediator = mediator;
//    }

//    [HttpPost("enviarCliente")] 
//    public async Task<IActionResult> EnviarCliente([FromBody] ClienteBaseDto cliente)  // Aquí después se añadirán los datos del cliente que se registra o inicia sesión.
//    {
//        if (cliente == null)
//        {
//            return BadRequest("El cliente no puede estar vacío.");
//        }

//        var resultado = await _mediator.Send(new SignalRRequest { MandamosCliente = cliente });
//        return Ok(resultado);
//    }


//    [HttpPost("enviarTransaccion")]
//    public async Task<IActionResult> EnviarTransaccion([FromBody] TransaccionBaseDto transaccion)  // Aquí en vez de escribir por el POST se añadirán al haber una transacción. 
//    {
//        if (transaccion == null)
//        {
//            return BadRequest("La transacción no puede estar vacía.");
//        }

//        var resultado = await _mediator.Send(new SignalRRequest { MandamosTransaccion = transaccion });
//        return Ok(resultado);
//    }
//}
