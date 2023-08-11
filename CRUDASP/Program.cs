using Microsoft.EntityFrameworkCore;
using CRUDASP.Datos;

var builder = WebApplication.CreateBuilder(args);
//la variable builder  se usa como constructor para la creacion de objetos
//configurar conexion sql 
builder.Services.AddDbContext<ApplicationDBContext>(opciones 
    => opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=index}/{id?}");

app.Run();
