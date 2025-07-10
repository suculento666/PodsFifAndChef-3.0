using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PodsFifAndChef.Controllers;



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

    public IActionResult IniciarSesion(string email, string contraseña)
    {
        Integrante integranteIngresado = BD.BuscarIntegrante(email, contraseña);
        @ViewBag.Email = integranteIngresado.Email;
        @ViewBag.Nombre = integranteIngresado.Nombre;
        @ViewBag.DNI = integranteIngresado.DNI;
        @ViewBag.Hobby = integranteIngresado.Hobby;
        @ViewBag.Edad = integranteIngresado.Edad;
        @ViewBag.Genero = integranteIngresado.Genero;
        if(integranteIngresado != null)
        {
            return View("DatosDelHombre");
        } else {
            return View("UsuarioNoEncontrado");
        }
    }

}