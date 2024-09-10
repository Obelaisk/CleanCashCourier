using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClases_20270722_Proyecto.Entidades;

public class Cliente
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(30)]
    public string Apellido { get; set; }

    public static ValidationResult ValidarFechaNacimiento(DateTime fechaNacimiento, ValidationContext validationContext)
    {
        if (fechaNacimiento > DateTime.Now)
        {
            return new ValidationResult("La fecha de nacimiento no puede ser posterior a la fecha actual.");
        }
        return ValidationResult.Success;
    }

    [Required]
    [CustomValidation(typeof(Cliente), nameof(ValidarFechaNacimiento))]
    public DateTime FechaNacimiento { get; set; }

    [StringLength(50)]
    public string Empleo { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "El PaisId debe ser mayor que 0.")]
    public int PaisId { get; set; }

    [ForeignKey(nameof(PaisId))]
    public Pais Pais { get; set; }  
    [Required]
    [StringLength(256)]
    [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de correo electrónico válida.")]
    public string Email { get; set; }

    [StringLength(256, ErrorMessage = "El Usuario no puede tener más de 256 caracteres.")]
    public string Usuario { get; set; }
}