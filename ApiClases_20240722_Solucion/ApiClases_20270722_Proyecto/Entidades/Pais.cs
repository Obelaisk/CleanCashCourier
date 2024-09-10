using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClases_20270722_Proyecto.Entidades
{
    [Table("Paises")] 
    public class Pais
    {
        [Key] 
        public int Id { get; set; }

        [Required] 
        [StringLength(100)] 
        public string Nombre { get; set; }

        [Required]
        [StringLength(3)] // Limita la longitud de la cadena para la divisa
        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Iso3 debe tener exactamente 3 letras mayúsculas.")]
        public string Iso3Pais { get; set; }

        [Required]
        [StringLength(50)] 
        public string Divisa { get; set; }


        [Required]
        [StringLength(3)] // Limita la longitud de la cadena para la divisa
        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Iso3 debe tener exactamente 3 letras mayúsculas.")]
        public string Iso3Divisa { get; set; }

    }
}
