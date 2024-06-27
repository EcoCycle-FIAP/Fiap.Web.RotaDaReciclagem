using Fiap.Web.RotaDaReciclagem.Data.Contexts;
using Fiap.Web.RotaDaReciclagem.Models;
using Fiap.Web.RotaDaReciclagem.ViewModels.Agendamento;
using Fiap.Web.RotaDaReciclagem.ViewModels.Rota;
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
        public IActionResult Create()
        {
            var viewModel = new RotaCreateViewModel
            {
                Caminhoes = new SelectList(_context.Caminhoes.ToList(), "CaminhaoId", "Motorista")
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(RotaModel rotaModel)
        {
            _context.Rotas.Add(rotaModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"A rota {rotaModel.RotaId} com o itinerário {rotaModel.PontosDeColeta} foi cadastrada com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var rota = _context.Rotas
                .Include(r => r.Caminhao)
                .FirstOrDefault(r => r.RotaId == id);

            if (rota == null)
            {
                return NotFound();
            }

            var viewModel = new RotaDetailViewModel
            {
                RotaId = rota.RotaId,
                PontosDeColeta = rota.PontosDeColeta,
                HorarioInicial = rota.HorarioInicial,
                HorarioFinal = rota.HorarioFinal,
                CaminhaoId = rota.CaminhaoId,
                Caminhao = rota.Caminhao
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FindByPontoDeColeta(string pontoDeColeta)
        {
            var rotas = _context.Rotas.Where(r => r.PontosDeColeta.Contains(pontoDeColeta)).ToList();

            if (rotas.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return View(rotas);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var rota = _context.Rotas.Find(id);
            if (rota == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = new RotaEditViewModel
                {
                    RotaId = rota.RotaId,
                    PontosDeColeta = rota.PontosDeColeta,
                    HorarioInicial = rota.HorarioInicial,
                    HorarioFinal = rota.HorarioFinal,
                    CaminhaoId = rota.CaminhaoId,
                    Caminhoes = new SelectList(_context.Caminhoes.ToList(), "CaminhaoId", "Motorista", rota.CaminhaoId)
                };
                return View(viewModel);
            }
        }


        [HttpPost]
        [ActionName("EditPost")]
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
