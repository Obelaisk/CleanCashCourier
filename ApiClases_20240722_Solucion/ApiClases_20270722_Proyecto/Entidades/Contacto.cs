using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClases_20270722_Proyecto.Entidades
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteOrigenId { get; set; }
        [ForeignKey(nameof(ClienteOrigenId))]
        public Cliente ClienteOrigen { get; set; }

        [Required]
        public int ClienteDestinoId { get; set; }
        [ForeignKey(nameof(ClienteDestinoId))]
        public Cliente ClienteDestino { get; set; }


    }
}
