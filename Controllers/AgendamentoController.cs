using Fiap.Web.RotaDaReciclagem.Data.Contexts;
using Fiap.Web.RotaDaReciclagem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Fiap.Web.RotaDaReciclagem.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly DatabaseContext _context;
        public AgendamentoController(DatabaseContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var agendamentos = _context.Agendamentos.Include(c => c.Caminhao).Include(m => m.Morador).ToList();
            return View(agendamentos);
        }

        [HttpGet]
        public IActionResult FindById(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            else
            {
                return View(agendamento);
            }
        }

        [HttpGet]
        public IActionResult FindByDate(DateTime date)
        {
            var agendamentos = _context.Agendamentos.Where(a => a.Data.Equals(date)).ToList();

            if (agendamentos.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return View(agendamentos);
            }
        }

        [HttpPost]
        public IActionResult Create(AgendamentoModel agendamentoModel)
        {
            _context.Agendamentos.Add(agendamentoModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"O agendamento {agendamentoModel.AgendamentoId} para o dia {agendamentoModel.Data} foi cadastrado com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.Caminhoes = new SelectList(_context.Caminhoes.ToList(), "CaminhaoId", "Motorista", agendamento.CaminhaoId);
                ViewBag.Moradores = new SelectList(_context.Moradores.ToList(), "MoradorId", "Nome", agendamento.MoradorId);
                return View(agendamento);
            }
        }

        [HttpPost]
        public IActionResult Edit(AgendamentoModel agendamentoModel)
        {
            _context.Update(agendamentoModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"O agendamento {agendamentoModel.AgendamentoId} foi alterado com sucesso e agora será na data e horário: {agendamentoModel.Data}.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);
            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"O agendamento {agendamento.AgendamentoId}, para o dia e horário {agendamento.Data}, foi cancelado com sucesso.";
            }
            else
            {
                TempData["mensagemFracasso"] = "Perdão, mas não temos um agendamento com esse id em nossa base de dados.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
