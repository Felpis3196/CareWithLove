using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CareWithLoveApp.Services;
using CareWithLoveApp.Models.InputModel;
using CareWithLoveApp.Models.ViewModels;
using CareWithLoveApp.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using CareWithLoveApp.Models.InputModels;

namespace CareWithLoveApp.Controllers
{
    public class ServicoCuidadoresController : Controller
    {
        private readonly IServicoCuidadorService _servicoCuidadorService;
        private readonly ICuidadorService _cuidadorService;
        private readonly UserManager<User> _userManager;

        public ServicoCuidadoresController(IServicoCuidadorService servicoCuidadorService, ICuidadorService cuidadorService, UserManager<User> userManager)
        {
            _servicoCuidadorService = servicoCuidadorService;
            _cuidadorService = cuidadorService;
            _userManager = userManager;
        }

        // GET: ServicoCuidadores
        public IActionResult Index()
        {
            var servicos = _servicoCuidadorService.ObterTodosServicosCuidadores();
            var viewModel = servicos.Select(s => new ServicoCuidadorViewModel
            {
                ServicoCuidadorId = s.ServicoCuidadorId,
                Descricao = s.Descricao,
                DataInicio = s.DataInicio,
                DataTermino = s.DataTermino,
                Preferencia = s.Preferencia,
                CuidadorId = s.CuidadorId,
                CuidadorNome = s.Cuidador.Usuario.UsuarioNome
            }).ToList();

            return View(viewModel);
        }

        // GET: ServicoCuidadores/Details/5
        public IActionResult Details(Guid id)
        {
            var servico = _servicoCuidadorService.ObterServicoCuidadorPorId(id);

            if (servico == null)
            {
                return NotFound();
            }

            var viewModel = new ServicoCuidadorViewModel
            {
                ServicoCuidadorId = servico.ServicoCuidadorId,
                Descricao = servico.Descricao,
                DataInicio = servico.DataInicio,
                DataTermino = servico.DataTermino,
                Preferencia = servico.Preferencia,
                CuidadorId = servico.CuidadorId,
                CuidadorNome = servico.Cuidador.Usuario.UsuarioNome
            };

            return View(viewModel);
        }

        // GET: ServicoCuidadores/Create
        public async Task<IActionResult> Create()
        {
            var usuarioLogadoId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuarioLogado = await _userManager.FindByIdAsync(usuarioLogadoId);
            var cuidadores = _cuidadorService.ObterTodosCuidadores()
                             .Select(c => new SelectListItem
                             {
                                 Value = c.CuidadorId.ToString(),
                                 Text = usuarioLogado?.UsuarioNome
                             }).ToList();
            ViewBag.CuidadorId = new SelectList(cuidadores, "Value", "Text");
            return View();
        }
         
        // POST: ServicoCuidadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServicoCuidadorInputModel inputModel)
        {
            if (inputModel != null && inputModel.DataTermino > inputModel.DataInicio)
            {
                var servicoCuidador = new ServicoCuidador
                {
                    ServicoCuidadorId = Guid.NewGuid().ToString(),
                    Descricao = inputModel.Descricao,
                    DataInicio = inputModel.DataInicio,
                    DataTermino = inputModel.DataTermino,
                    Preferencia = inputModel.Preferencia,
                    CuidadorId = inputModel.CuidadorId
                };

                _servicoCuidadorService.CriarServicoCuidador(servicoCuidador);
                return RedirectToAction(nameof(Index));
            }
            return View(inputModel);
        }

        // GET: ServicoCuidadores/Edit/5
        public IActionResult Edit(Guid id)
        {
            var servico = _servicoCuidadorService.ObterServicoCuidadorPorId(id);

            if (servico == null)
            {
                return NotFound();
            }

            var inputModel = new ServicoCuidadorInputModel
            {
                Descricao = servico.Descricao,
                DataInicio = servico.DataInicio,
                DataTermino = servico.DataTermino,
                Preferencia = servico.Preferencia,
                CuidadorId = servico.CuidadorId
            };

            return View(inputModel);
        }

        // POST: ServicoCuidadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, ServicoCuidadorInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var servicoCuidador = _servicoCuidadorService.ObterServicoCuidadorPorId(id);

                if (servicoCuidador == null)
                {
                    return NotFound();
                }

                servicoCuidador.Descricao = inputModel.Descricao;
                servicoCuidador.DataInicio = inputModel.DataInicio;
                servicoCuidador.DataTermino = inputModel.DataTermino;
                servicoCuidador.Preferencia = inputModel.Preferencia;
                servicoCuidador.CuidadorId = inputModel.CuidadorId;

                _servicoCuidadorService.AtualizarServicoCuidador(servicoCuidador);
                return RedirectToAction(nameof(Index));
            }

            return View(inputModel);
        }

        // GET: ServicoCuidadores/Delete/5
        public IActionResult Delete(Guid id)
        {
            var servico = _servicoCuidadorService.ObterServicoCuidadorPorId(id);

            if (servico == null)
            {
                return NotFound();
            }

            var viewModel = new ServicoCuidadorViewModel
            {
                ServicoCuidadorId = servico.ServicoCuidadorId,
                Descricao = servico.Descricao,
                DataInicio = servico.DataInicio,
                DataTermino = servico.DataTermino,
                Preferencia = servico.Preferencia,
                CuidadorId = servico.CuidadorId,
                CuidadorNome = servico.Cuidador.Usuario.UsuarioNome
            };

            return View(viewModel);
        }

        // POST: ServicoCuidadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _servicoCuidadorService.ExcluirServicoCuidador(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
