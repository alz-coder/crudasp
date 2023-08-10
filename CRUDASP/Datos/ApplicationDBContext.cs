using CRUDASP.Models;
using Microsoft.EntityFrameworkCore;
namespace CRUDASP.Datos
{
    public class ApplicationDBContext:DbContext
    {
        //crear constructor de la clase
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        //modelos
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
