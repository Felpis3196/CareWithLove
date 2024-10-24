using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CareWithLoveApp.Services;
using CareWithLoveApp.Models.InputModels;
using CareWithLoveApp.Models.ViewModels;
using CareWithLoveApp.Models.Entities;

namespace AplicacaoCareWithLove.Controllers
{
    public class ServicoClientesController : Controller
    {
        private readonly IServicoClienteService _servicoClienteService;
        private readonly IDependenteService _dependenteService;

        public ServicoClientesController(IServicoClienteService servicoClienteService, IDependenteService dependenteService)
        {
            _servicoClienteService = servicoClienteService;
            _dependenteService = dependenteService;
        }

        // GET: ServicoClientes
        public async Task<IActionResult> Index()
        {
            var servicos = _servicoClienteService.ObterTodosServicosClientes()
                .Select(s => new ServicoClienteViewModel
                {
                    ServicoClienteId = s.ServicoClienteId,
                    Descricao = s.Descricao,
                    DataInicio = s.DataInicio,
                    DataTermino = s.DataTermino,
                    Local = s.Local,
                    DependenteNome = s.Dependente?.DependenteNome 
                });
            return View(servicos);
        }

        // GET: ServicoClientes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var servicoCliente = _servicoClienteService.ObterServicoClientePorId(id);
            if (servicoCliente == null)
            {
                return NotFound();
            }

            var servicoClienteViewModel = new ServicoClienteViewModel
            {
                ServicoClienteId = servicoCliente.ServicoClienteId,
                Descricao = servicoCliente.Descricao,
                DataInicio = servicoCliente.DataInicio,
                DataTermino = servicoCliente.DataTermino,
                Local = servicoCliente.Local,
            };

            return View(servicoClienteViewModel);
        }

        // GET: ServicoClientes/Create
        public IActionResult Create()
        {
            var dependentes = _dependenteService.ObterTodosDependentes()
                             .Select(c => new SelectListItem
                             {
                                 Value = c.DependenteId.ToString(),
                                 Text = c.DependenteNome
                             }).ToList();
            ViewBag.DependenteId = new SelectList(dependentes, "Value", "Text");
            return View();
        }

        // POST: ServicoClientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicoClienteInputModel servicoClienteInputModel)
        {
            if (servicoClienteInputModel != null && servicoClienteInputModel.DataTermino > servicoClienteInputModel.DataInicio)
            {
                var servicoCliente = new ServicoCliente
                {
                    ServicoClienteId = Guid.NewGuid().ToString(),
                    Descricao = servicoClienteInputModel.Descricao,
                    DataInicio = servicoClienteInputModel.DataInicio,
                    DataTermino = servicoClienteInputModel.DataTermino,
                    Local = servicoClienteInputModel.Local,
                    DependenteId = servicoClienteInputModel.DependenteId
                };

                _servicoClienteService.CriarServicoCliente(servicoCliente);
                return RedirectToAction(nameof(Index));
            }

            ViewData["DependenteId"] = new SelectList(_dependenteService.ObterTodosDependentes(), "DependenteId", "DependenteNome", servicoClienteInputModel.DependenteId);
            return View(servicoClienteInputModel);
        }


        // GET: ServicoClientes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var servicoCliente = _servicoClienteService.ObterServicoClientePorId(id);
            if (servicoCliente == null)
            {
                return NotFound();
            }

            var servicoClienteInputModel = new ServicoClienteInputModel
            {
                ServicoClienteId = servicoCliente.ServicoClienteId,
                Descricao = servicoCliente.Descricao,
                DataInicio = servicoCliente.DataInicio,
                DataTermino = servicoCliente.DataTermino,
                Local = servicoCliente.Local,
                DependenteId = servicoCliente.DependenteId
            };

            ViewData["DependenteId"] = new SelectList(_servicoClienteService.ObterTodosServicosClientes(), "DependenteId", "DependenteId", servicoCliente.DependenteId);
            return View(servicoClienteInputModel);
        }

        // POST: ServicoClientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ServicoClienteInputModel servicoClienteInputModel)
        {
            if (id.ToString() != servicoClienteInputModel.ServicoClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var servicoCliente = new ServicoCliente
                {
                    ServicoClienteId = servicoClienteInputModel.ServicoClienteId,
                    Descricao = servicoClienteInputModel.Descricao,
                    DataInicio = servicoClienteInputModel.DataInicio,
                    DataTermino = servicoClienteInputModel.DataTermino,
                    Local = servicoClienteInputModel.Local,
                    DependenteId = servicoClienteInputModel.DependenteId
                };

                _servicoClienteService.AtualizarServicoCliente(servicoCliente);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DependenteId"] = new SelectList(_servicoClienteService.ObterTodosServicosClientes(), "DependenteId", "DependenteId", servicoClienteInputModel.DependenteId);
            return View(servicoClienteInputModel);
        }

        // GET: ServicoClientes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var servicoCliente = _servicoClienteService.ObterServicoClientePorId(id);
            if (servicoCliente == null)
            {
                return NotFound();
            }

            var servicoClienteViewModel = new ServicoClienteViewModel
            {
                ServicoClienteId = servicoCliente.ServicoClienteId,
                Descricao = servicoCliente.Descricao,
                DataInicio = servicoCliente.DataInicio,
                DataTermino = servicoCliente.DataTermino,
                Local = servicoCliente.Local,
            };

            return View(servicoClienteViewModel);
        }

        // POST: ServicoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var servicoCliente = _servicoClienteService.ObterServicoClientePorId(id);
            if (servicoCliente == null)
            {
                return NotFound();
            }

            _servicoClienteService.ExcluirServicoCliente(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
