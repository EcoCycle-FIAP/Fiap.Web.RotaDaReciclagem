using Fiap.Web.RotaDaReciclagem.Data.Contexts;
using Fiap.Web.RotaDaReciclagem.Models;
using Fiap.Web.RotaDaReciclagem.ViewModels.Agendamento;
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

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new AgendamentoCreateViewModel
            {
                Caminhoes = new SelectList(_context.Caminhoes.ToList(), "CaminhaoId", "Motorista"),
                Moradores = new SelectList(_context.Moradores.ToList(), "MoradorId", "Nome")
            };
            return View(viewModel);
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
                var viewModel = new AgendamentoEditViewModel
                {
                    AgendamentoId = agendamento.AgendamentoId,
                    Data = agendamento.Data,
                    TipoResiduo = agendamento.TipoResiduo,
                    QuantidadeLitros = agendamento.QuantidadeLitros,
                    CaminhaoId = agendamento.CaminhaoId,
                    MoradorId = agendamento.MoradorId,
                    Caminhoes = new SelectList(_context.Caminhoes.ToList(), "CaminhaoId", "Motorista", agendamento.CaminhaoId),
                    Moradores = new SelectList(_context.Moradores.ToList(), "MoradorId", "Nome", agendamento.MoradorId)
                };
                return View(viewModel);
            }
        }

        [HttpPost]
        [ActionName("EditPost")]
        public IActionResult Edit(AgendamentoModel agendamentoModel)
        {
            _context.Update(agendamentoModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"O agendamento {agendamentoModel.AgendamentoId} foi alterado com sucesso e agora será na data e horário: {agendamentoModel.Data}.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(AgendamentoEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var agendamento = _context.Agendamentos.Find(viewModel.AgendamentoId);
                if (agendamento == null)
                {
                    return NotFound();
                }

                agendamento.Data = viewModel.Data;
                agendamento.TipoResiduo = viewModel.TipoResiduo;
                agendamento.QuantidadeLitros = viewModel.QuantidadeLitros;
                agendamento.CaminhaoId = viewModel.CaminhaoId;
                agendamento.MoradorId = viewModel.MoradorId;

                _context.Update(agendamento);
                _context.SaveChanges();

                TempData["mensagemSucesso"] = $"O agendamento {agendamento.AgendamentoId} foi alterado com sucesso e agora será na data e horário: {agendamento.Data}.";
                return RedirectToAction(nameof(Index));
            }

            // Se houver erros de validação, recarrega a view com os dados da view model e as listas de seleção
            viewModel.Caminhoes = new SelectList(_context.Caminhoes.ToList(), "CaminhaoId", "Motorista", viewModel.CaminhaoId);
            viewModel.Moradores = new SelectList(_context.Moradores.ToList(), "MoradorId", "Nome", viewModel.MoradorId);
            return View(viewModel);
        }
    }
}
