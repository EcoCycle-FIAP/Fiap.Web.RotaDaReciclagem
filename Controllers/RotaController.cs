using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.RotaDaReciclagem.Controllers
{
    public class RotaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
