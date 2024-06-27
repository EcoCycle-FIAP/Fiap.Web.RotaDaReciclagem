using Fiap.Web.RotaDaReciclagem.Data.Contexts;
using Fiap.Web.RotaDaReciclagem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.RotaDaReciclagem.Controllers
{
    public class RotaController : Controller
    {
        private readonly DatabaseContext _context;
        public RotaController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rotas = _context.Rotas.Include(c => c.Caminhao).ToList();
            return View(rotas);
        }

        [HttpGet]
        public IActionResult FindById(int id)
        {
            var rota = _context.Rotas.Find(id);
            if (rota == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.Caminhoes = new SelectList(_context.Caminhoes.ToList(), "CaminhaId", "Motorista", rota.CaminhaoId);
                return View(rota);
            }
        }

        [HttpPost]
        public IActionResult Create(RotaModel rotaModel)
        {
            _context.Rotas.Add(rotaModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"A rota {rotaModel.RotaId} com o itinerário {rotaModel.PontosDeColeta} foi cadastrada com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(RotaModel rotaModel)
        {
            _context.Update(rotaModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"A rota {rotaModel.RotaId} foi alterada com sucesso e agora possui o itinerário: {rotaModel.PontosDeColeta}.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var rota = _context.Rotas.Find(id);
            if (rota != null)
            {
                _context.Rotas.Remove(rota);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"A rota {rota.RotaId}, que possuia o itinerário {rota.PontosDeColeta}, foi removida com sucesso.";
            }
            else
            {
                TempData["mensagemFracasso"] = "Perdão, mas não temos uma rota com esse id em nossa base de dados.";
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
