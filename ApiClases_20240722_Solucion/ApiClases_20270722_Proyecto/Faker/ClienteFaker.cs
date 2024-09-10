using Bogus;

namespace BackendEstadistica.Faker;

// Faker para Cliente
public class ClienteFaker : Faker<ClienteBaseDto>
{
    public ClienteFaker(IEnumerable<Pais> paises)
    {

            RuleFor(c => c.Nombre, f => f.Name.FirstName())
            .RuleFor(c => c.Apellido, f => f.Name.LastName())
            .RuleFor(c => c.FechaNacimiento, f => f.Date.Past(60, DateTime.Now.AddYears(-18))) // Asegura que sea mayor de edad
            .RuleFor(c => c.Empleo, f => f.PickRandom(new[] { "Desarrollador de Software", "Ingeniero Civil", "Diseñador Gráfico",
      "Médico", "Abogado", "Profesor", "Contador", "Consultor de Negocios",
      "Arquitecto", "Marketing Digital" }))
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.PaisId, f => f.PickRandom(paises).Id) // Selecciona un PaisId existente 
            .RuleFor(c => c.Usuario, f => f.Internet.UserName());
    }
}
