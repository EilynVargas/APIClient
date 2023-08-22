using System.ComponentModel.DataAnnotations;

namespace Client.Model
{
    public class Clientes
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estatus { get; set; }
    }
}
