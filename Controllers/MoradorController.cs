using Fiap.Web.RotaDaReciclagem.Data.Contexts;
using Fiap.Web.RotaDaReciclagem.Models;
using Fiap.Web.RotaDaReciclagem.ViewModels.Morador;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.RotaDaReciclagem.Controllers
{
    public class MoradorController : Controller
    {
        private readonly DatabaseContext _context;
        public MoradorController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var moradores = _context.Moradores.Include(a => a.Agendamentos).ToList();
            return View(moradores);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var morador = _context.Moradores
                                         .Include(m => m.Agendamentos)
                                         .FirstOrDefault(m => m.MoradorId == id);

            if (morador == null)
            {
                return NotFound();
            }

            var viewModel = new MoradorDetailViewModel
            {
                MoradorId = morador.MoradorId,
                Nome = morador.Nome,
                Endereco = morador.Endereco,
                EnderecoNumero = morador.EnderecoNumero,
                EnderecoComplemento = morador.EnderecoComplemento,
                EnderecoBairro = morador.EnderecoBairro,
                Email = morador.Email,
                Telefone = morador.Telefone,
                Agendamentos = morador.Agendamentos
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FindById(int id)
        {
            var morador = _context.Moradores.Find(id);

            if (morador == null)
            {
                return NotFound();
            }
            else
            {
                return View(morador);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MoradorModel moradorModel)
        {
            _context.Moradores.Add(moradorModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"O morador {moradorModel.MoradorId} com o nome '{moradorModel.Nome}' foi cadastrado com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var morador = _context.Moradores.Find(id);
            if (morador == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = new MoradorEditViewModel
                {
                    MoradorId = morador.MoradorId,
                    Nome = morador.Nome,
                    Endereco = morador.Endereco,
                    EnderecoNumero = morador.EnderecoNumero,
                    EnderecoComplemento = morador.EnderecoComplemento,
                    EnderecoBairro = morador.EnderecoBairro,
                    Email = morador.Email,
                    Telefone = morador.Telefone
                };
                return View(viewModel);
            }
        }

        [HttpPost]
        [ActionName("EditPost")]
        public IActionResult Edit(MoradorModel moradorModel)
        {
            _context.Update(moradorModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"O morador {moradorModel.MoradorId} - {moradorModel.Nome} foi alterado com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(MoradorEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var morador = _context.Moradores.Find(viewModel.MoradorId);
                if (morador == null)
                {
                    return NotFound();
                }

                morador.Nome = viewModel.Nome;
                morador.Endereco = viewModel.Endereco;
                morador.EnderecoNumero = viewModel.EnderecoNumero;
                morador.EnderecoComplemento = viewModel.EnderecoComplemento;
                morador.EnderecoBairro = viewModel.EnderecoBairro;
                morador.Email = viewModel.Email;
                morador.Telefone = viewModel.Telefone;

                _context.Update(morador);
                _context.SaveChanges();

                TempData["mensagemSucesso"] = $"O morador {morador.MoradorId} - {morador.Nome} foi alterado com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var morador = _context.Moradores.Find(id);

            if (morador != null)
            {
                _context.Moradores.Remove(morador);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"O morador {morador.MoradorId}, cadastrado com o nome '{morador.Nome}', foi removido com sucesso.";
            }
            else
            {
                TempData["mensagemFracasso"] = "Perdão, mas não temos uma rota com esse id em nossa base de dados.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
