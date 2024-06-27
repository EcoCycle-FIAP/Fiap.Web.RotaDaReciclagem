using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.RotaDaReciclagem.Controllers
{
    public class MoradorController : Controller
    {
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }
    }
}
