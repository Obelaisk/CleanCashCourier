
namespace ApiClases_20270722_Proyecto.SignalRServicio
{
    public class SignalRRequestHandler : IRequestHandler<SignalRRequest, string>
    {
        private readonly SignalRServicio _signalRServicio;
        private readonly IRepositorioGenerico<Cliente> _clienteRepositorio;

        public SignalRRequestHandler(SignalRServicio signalRServicio, IRepositorioGenerico<Cliente> clienteRepositorio)
        {
            _signalRServicio = signalRServicio;
            _clienteRepositorio = clienteRepositorio ?? throw new ArgumentNullException(nameof(clienteRepositorio));
        }

        public async Task<string> Handle(SignalRRequest request, CancellationToken cancellationToken)
        {
            if (request.MandamosCliente != null)
            {
                var cliente = request.MandamosCliente;
                var clienteData = new
                {
                    TipoAcceso = request.TipoAcceso, // Incluimos TipoAcceso
                    cliente.Nombre,
                    cliente.Apellido,
                    cliente.FechaNacimiento,
                    cliente.Empleo,
                    cliente.PaisId,
                    cliente.Email
                };

                await _signalRServicio.SendMessageAsync("", Newtonsoft.Json.JsonConvert.SerializeObject(clienteData));
                request.MandamosCliente = null;
                return "Datos del cliente enviados correctamente.";
            }
            else if (request.MandamosTransaccion != null)
            {
                var transaccion = request.MandamosTransaccion;

                // Obtener datos de los clientes desde la base de datos
                var clienteEnvia = _clienteRepositorio.ObtenerPorId(transaccion.IdEnvia);
                var clienteRecibe = _clienteRepositorio.ObtenerPorId(transaccion.IdRecibe);

                if (clienteEnvia == null || clienteRecibe == null)
                {
                    return "No se pudieron obtener los datos de los clientes.";
                }

                var transaccionData = new
                {
                    TipoAcceso = request.TipoAcceso, // Incluimos TipoAcceso
                    PaisOrigen = clienteEnvia.PaisId,
                    PaisDestino = clienteRecibe.PaisId,
                    ClienteOrigen = clienteEnvia.Usuario,
                    ClienteDestino = clienteRecibe.Usuario,
                    ClienteOrigenId = transaccion.IdEnvia,
                    ClienteDestinoId = transaccion.IdRecibe,
                    ValorOrigen = transaccion.CantidadEnvia,
                    ValorDestino = transaccion.CantidadRecibe,
                    Timestamp = transaccion.Fecha,
                    CosteTransaccion = transaccion.CosteTransaccion // Incluimos el campo CosteTransaccion
                };

                await _signalRServicio.SendMessageAsync("", Newtonsoft.Json.JsonConvert.SerializeObject(transaccionData));
                request.MandamosTransaccion = null;
                return "Datos de la transacción enviados correctamente.";
            }
            else if (!string.IsNullOrEmpty(request.Mensaje))
            {
                await _signalRServicio.SendMessageAsync("AplicaciónDeEnvio", request.Mensaje);
                return "Mensaje enviado correctamente.";
            }

            return "No se proporcionó ningún dato para enviar.";
        }
    }
}

