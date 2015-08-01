using System.Web.Mvc;
using TrueBlood.Models;

namespace TrueBlood.Controllers
{
    public class HomeController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            ViewBag.Title = "Blood True";

            return View();
        }

        public ActionResult ListaPacientes()
        {
            ViewBag.Title = "Lista de Pacientes";

            return View();
        }





    }
}
