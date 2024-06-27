using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.RotaDaReciclagem.Controllers
{
    public class RotaController : Controller
    {
        public IActionResult Index() {
            Console.WriteLine(_rotas.Count);
            return View(_rotas);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }
    }
}
