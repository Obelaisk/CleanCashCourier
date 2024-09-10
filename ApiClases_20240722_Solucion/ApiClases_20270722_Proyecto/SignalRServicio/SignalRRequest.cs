
using ApiClases_20270722_Proyecto.Modelos.Clientes;

namespace ApiClases_20270722_Proyecto.SignalRServicio;

public class SignalRRequest : IRequest<string>
{
    public ClienteBaseDto MandamosCliente { get; set; }
    public TransaccionBaseDto MandamosTransaccion { get; set; }
    public string TipoAcceso { get; set; }
    public string Mensaje { get; set; }  

}
