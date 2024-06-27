using Fiap.Web.RotaDaReciclagem.Data.Contexts;
using Fiap.Web.RotaDaReciclagem.Models;
using Fiap.Web.RotaDaReciclagem.ViewModels.Caminhao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.RotaDaReciclagem.Controllers
{
    public class CaminhaoController : Controller
    {
        private readonly DatabaseContext _context;
        public CaminhaoController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        {
            var caminhoes = _context.Caminhoes.Include(a => a.Agendamentos).Include(r => r.Rotas).ToList();
            return View(caminhoes);
        }

        [HttpGet]
        public IActionResult Detail(int id) 
        {
            var caminhao = _context.Caminhoes
                                         .Include(c => c.Agendamentos)
                                         .Include(c => c.Rotas)
                                         .FirstOrDefault(c => c.CaminhaoId == id);

            if (caminhao == null)
            {
                return NotFound();
            }

            var viewModel = new CaminhaoDetailViewModel
            {
                CaminhaoId = caminhao.CaminhaoId,
                Motorista = caminhao.Motorista,
                Modelo = caminhao.Modelo,
                Placa = caminhao.Placa,
                CapacidadeLitros = caminhao.CapacidadeLitros,
                Agendamentos = caminhao.Agendamentos,
                Rotas = caminhao.Rotas
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FindById(int id)
        {
            var caminhao = _context.Caminhoes.Find(id);

            if (caminhao == null)
            {
                return NotFound();
            }
            else
            {
                return View(caminhao);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CaminhaoModel caminhaoModel)
        {
            _context.Caminhoes.Add(caminhaoModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"O caminhao {caminhaoModel.CaminhaoId} com o motorista '{caminhaoModel.Motorista}' foi cadastrado com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var caminhao = _context.Caminhoes.Find(id);
            if (caminhao == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = new CaminhaoEditViewModel
                {
                    CaminhaoId = caminhao.CaminhaoId,
                    Motorista = caminhao.Motorista,
                    Modelo = caminhao.Modelo,
                    Placa = caminhao.Placa,
                    CapacidadeLitros = caminhao.CapacidadeLitros
                };
                return View(viewModel);
            }
        }

        [HttpPost]
        [ActionName("EditPost")]
        public IActionResult Edit(CaminhaoModel caminhaoModel)
        {
            _context.Update(caminhaoModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"O caminhao {caminhaoModel.CaminhaoId} foi alterado com sucesso e agora será com o motorista: {caminhaoModel.Motorista}.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(CaminhaoEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var caminhao = _context.Caminhoes.Find(viewModel.CaminhaoId);
                if (caminhao == null)
                {
                    return NotFound();
                }

                caminhao.Motorista = viewModel.Motorista;
                caminhao.Modelo = viewModel.Modelo;
                caminhao.Placa = viewModel.Placa;
                caminhao.CapacidadeLitros = viewModel.CapacidadeLitros;

                _context.Update(caminhao);
                _context.SaveChanges();

                TempData["mensagemSucesso"] = $"O caminhao {caminhao.CaminhaoId} foi alterado com sucesso e agora será com o motorista: {caminhao.Motorista}.";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var caminhao = _context.Caminhoes.Find(id);

            if (caminhao != null)
            {
                _context.Caminhoes.Remove(caminhao);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"O caminhao {caminhao.CaminhaoId}, cadastrado com o motorista '{caminhao.Motorista}', foi removido com sucesso.";
            }
            else
            {
                TempData["mensagemFracasso"] = "Perdão, mas não temos uma rota com esse id em nossa base de dados.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
