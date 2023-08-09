using System.ComponentModel.DataAnnotations;

namespace CRUDASP.Models
{
    public class Contacto
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Nombre Completo")]
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Numero de Celular")]
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        public string Telefono { get; set; }
        [Display(Name = "Gmail")]
        [Required(ErrorMessage = "El    Email es obligatorio")]
        public string Email { get; set; }
          
        public DateTime FechaCreacion { get; set; }

        
    }
}
