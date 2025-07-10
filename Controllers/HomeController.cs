using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PodsFifAndChef.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(string email, string password)
        {
            Integrante integranteIngresado = BD.BuscarIntegrante(email, password);
            if (integranteIngresado != null)
            {
                ViewBag.Email = integranteIngresado.Email;
                ViewBag.Nombre = integranteIngresado.Nombre;
                ViewBag.DNI = integranteIngresado.DNI;
                ViewBag.Hobby = integranteIngresado.Hobby;
                ViewBag.Edad = integranteIngresado.Edad;
                ViewBag.Genero = integranteIngresado.Genero;
                return View("Datos");
            }
            else
            {
                return View("UsuarioNoEncontrado");
            }
        }
    }
}