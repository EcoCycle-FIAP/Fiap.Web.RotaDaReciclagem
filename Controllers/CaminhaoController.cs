using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.RotaDaReciclagem.Controllers
{
    public class CaminhaoController : Controller
    {
        public IActionResult Index() {
            Console.WriteLine(_caminhoes.Count);
            return View(_caminhoes);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }
    }
}
