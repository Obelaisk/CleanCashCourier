namespace ApiClases_20270722_Proyecto.Modelos.Clientes;

public class ClienteBaseDto : IValidatableObject
{
    [Required]
    [StringLength(25)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(30)]
    public string Apellido { get; set; }

    [Required]
    public DateTime FechaNacimiento { get; set; }

    public string Empleo { get; set; }

    public string? NombrePais { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public int? PaisId { get; set; }

    public string? Usuario { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {

        if (char.IsDigit(Email[0]))
        {
            yield return new ValidationResult("El usuario no puede empezar por un número", new[] { "Usuario" });
        }

        if (FechaNacimiento.ComprobarMayoriaEdad())
        {
            yield return new ValidationResult("No se puede registrar un menor de edad", new[] { "Edad" });
        }

    }
}
