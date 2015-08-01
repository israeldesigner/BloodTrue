using System.Web.Mvc;

namespace TrueBlood.Controllers
{
    public class HomeController : Controller
    {
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
