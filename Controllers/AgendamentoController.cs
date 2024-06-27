using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.RotaDaReciclagem.Controllers
{
    public class AgendamentoController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine(_agendamentos.Count);
            return View(_agendamentos);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }
    }
}
