using System.ComponentModel.DataAnnotations;
namespace CRUDASP.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Nombre de usuario")]
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string NombreUsuario { get; set; }
        [Display(Name  = "Ingresa la contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Contrasenna { get; set; }
        
        public DateTime FechaCreacion { get; set; }
    }
}
