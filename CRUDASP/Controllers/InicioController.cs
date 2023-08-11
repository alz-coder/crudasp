using CRUDASP.Datos;
using CRUDASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace CRUDASP.Controllers
{
    public class InicioController : Controller
    {
        private readonly ApplicationDBContext _Contexto;
       

        public InicioController(ApplicationDBContext contexto)
        {
            //aplicacionde la inyeccion de dependencias y por medio de la variable
            //podemos acceder a cualquier propiedado modelo que contengamos en el programa
            _Contexto = contexto;
        }
        [HttpGet]
        public async Task<IActionResult>  Index()
        {
            //utilizamos a Entity Framework
            return View(await _Contexto.Contactos.ToListAsync());
        }
        //metodo crear
        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            //utilizamos a Entity Framework
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            //utilizamos a Entity Framework
            if(ModelState.IsValid)
            {
                _Contexto.Contactos.Add(contacto);
                contacto.FechaCreacion = DateTime.Now;
                await _Contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        //metodo editar
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            Contacto contacto = _Contexto.Contactos.Where(p => p.ID == id).FirstOrDefault();
            return PartialView("Editar", contacto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            //utilizamos a Entity Framework
            if (ModelState.IsValid)
            {
                _Contexto.Contactos.Update(contacto);
                _Contexto.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        //detalle
        [HttpGet]
        public IActionResult detalle(int? id)
        {
            Contacto contacto = _Contexto.Contactos.Where(p => p.ID == id).FirstOrDefault();
            return PartialView("detalle",contacto);
        }
        //eliminar
        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            Contacto contacto = _Contexto.Contactos.Where(p => p.ID == id).FirstOrDefault();
            return PartialView("Eliminar", contacto);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminarc(int? id)
        {

            var contacto = await _Contexto.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return View();
            }
            _Contexto.Contactos.Remove(contacto);
            await _Contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //metodo crear usuario
        [HttpPost]
        public async Task<IActionResult> CrearUsuario(Usuario usuario)
        {
            //utilizamos a Entity Framework
            // utilizamos a Entity Framework
            if (ModelState.IsValid)
            {
                _Contexto.Usuarios.Add(usuario);
                usuario.FechaCreacion = DateTime.Now;
                await _Contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        //metodo validar
        [HttpGet]
        public async Task<IActionResult> ValUsuario()
        {
            //utilizamos a Entity Framework
            return RedirectToAction("ListaUsuarios");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

    }
}