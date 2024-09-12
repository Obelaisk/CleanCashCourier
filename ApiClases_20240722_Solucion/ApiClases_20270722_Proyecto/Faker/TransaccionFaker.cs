using Bogus;

namespace BackendEstadistica.Faker;

// Faker para Transacción
public class TransaccionFaker : Faker<TransaccionBaseDto>
{
    public TransaccionFaker(Cliente origen, Cliente destino, IEnumerable<Pais> paises)
    {
        //RuleFor(t => t.ImporteRecibido, f => f.Random.Double(1.0, 100.0))
        //    .RuleFor(t => t.ImporteEnviado, f => f.Random.Double(1.0, 100.0))
        //    .RuleFor(t => t.Fecha, f => f.Date.Past(1))
        //    .RuleFor(t => t.ClienteOrigenId, _ => origen.ClienteId)  // Asignar ID de origen
        //    .RuleFor(t => t.ClienteDestinoId, _ => destino.ClienteId);  // Asignar ID de destino
        RuleFor(t => t.IdEnvia, _ => origen.Id)  // Id aleatorio para el que envía
            .RuleFor(t => t.CantidadEnvia, f => f.Random.Double(10, 1000))  // Cantidad entre 10 y 1000
            .RuleFor(t => t.IdRecibe, _ => destino.Id)  // Id aleatorio para el que recibe
            .RuleFor(t => t.CantidadRecibe, (f, t) => t.CantidadEnvia * f.Random.Double(0.6, 6.0))  // Cantidad recibida con bastante margen
            .RuleFor(t => t.Fecha, f => f.Date.Past(10))  // Fecha en los ultimos 10 años
            .RuleFor(t => t.MonedaOrigen, paises.FirstOrDefault(p => p.Id == origen.PaisId).Iso3Divisa)  // Código de moneda de origen
            .RuleFor(t => t.MonedaDestino, paises.FirstOrDefault(p => p.Id == destino.PaisId).Iso3Divisa)  // Código de moneda de destino
            .RuleFor(t => t.CosteTransaccion, f => f.Random.Double(1, 10));  // Coste fijo o porcentual entre 1 y 10 unidades
    }
}