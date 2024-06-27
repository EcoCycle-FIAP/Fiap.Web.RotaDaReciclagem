using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.RotaDaReciclagem.Controllers
{
    public class MoradorController : Controller
    {
        public IActionResult Index() {
            Console.WriteLine(_moradores.Count);
            return View(_moradores);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }
    }
}
