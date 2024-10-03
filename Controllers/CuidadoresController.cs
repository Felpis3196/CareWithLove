using CareWithLoveApp.Services;
using CareWithLoveApp.Models.InputModels;
using CareWithLoveApp.Models.ViewModel;
using CareWithLoveApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CareWithLoveApp.Controllers
{
    public class CuidadoresController : Controller
    {
        private readonly ICuidadorService _cuidadorService;
        private readonly IUsuarioService _usuarioService;

        public CuidadoresController(ICuidadorService cuidadorService, IUsuarioService usuarioService)
        {
            _cuidadorService = cuidadorService;
            _usuarioService = usuarioService;
        }

        // GET: Cuidadores
        public async Task<IActionResult> Index()
        {
            var cuidadores = _cuidadorService.ObterTodosCuidadores()
                .Select(c => new CuidadorViewModel
                {
                    CuidadorId = c.CuidadorId,
                    CPF = c.CPF,
                    Experiencia = c.Experiencia,
                    ValorHora = c.ValorHora,
                    Disponibilidade = c.Disponibilidade,
                    Especializacoes = c.Especializacoes,
                    UsuarioId = c.UsuarioId,
                    UsuarioNome = c.Usuario?.UsuarioNome
                });
            return View(cuidadores);
        }

        // GET: Cuidadores/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var cuidador = _cuidadorService.ObterCuidadorPorId(id);
            if (cuidador == null)
            {
                return NotFound();
            }

            var cuidadorViewModel = new CuidadorViewModel
            {
                CuidadorId = cuidador.CuidadorId,
                CPF = cuidador.CPF,
                Experiencia = cuidador.Experiencia,
                ValorHora = cuidador.ValorHora,
                Disponibilidade = cuidador.Disponibilidade,
                Especializacoes = cuidador.Especializacoes,
                UsuarioId = cuidador.UsuarioId,
                UsuarioNome = cuidador.Usuario?.UsuarioNome
            };

            return View(cuidadorViewModel);
        }

        // GET: Cuidadores/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_usuarioService.ObterTodosUsuarios(), "UsuarioId", "UsuarioNome");
            return View();
        }

        // POST: Cuidadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CuidadorInputModel cuidadorInputModel)
        {
            if (ModelState.IsValid)
            {
                var cuidador = new Cuidador
                {
                    CuidadorId = Guid.NewGuid(),
                    CPF = cuidadorInputModel.CPF,
                    Experiencia = cuidadorInputModel.Experiencia,
                    ValorHora = cuidadorInputModel.ValorHora,
                    Disponibilidade = cuidadorInputModel.Disponibilidade,
                    Especializacoes = cuidadorInputModel.Especializacoes,
                    UsuarioId = cuidadorInputModel.UsuarioId
                };

                _cuidadorService.CriarCuidador(cuidador);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_usuarioService.ObterTodosUsuarios(), "UsuarioId", "UsuarioNome", cuidadorInputModel.UsuarioId);
            return View(cuidadorInputModel);
        }

        // GET: Cuidadores/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var cuidador = _cuidadorService.ObterCuidadorPorId(id);
            if (cuidador == null)
            {
                return NotFound();
            }

            var cuidadorInputModel = new CuidadorInputModel
            {
                CuidadorId = cuidador.CuidadorId,
                CPF = cuidador.CPF,
                Experiencia = cuidador.Experiencia,
                ValorHora = cuidador.ValorHora,
                Disponibilidade = cuidador.Disponibilidade,
                Especializacoes = cuidador.Especializacoes,
                UsuarioId = cuidador.UsuarioId
            };

            ViewData["UsuarioId"] = new SelectList(_usuarioService.ObterTodosUsuarios(), "UsuarioId", "UsuarioNome", cuidador.UsuarioId);
            return View(cuidadorInputModel);
        }

        // POST: Cuidadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CuidadorInputModel cuidadorInputModel)
        {
            if (id != cuidadorInputModel.CuidadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var cuidador = new Cuidador
                {
                    CuidadorId = cuidadorInputModel.CuidadorId,
                    CPF = cuidadorInputModel.CPF,
                    Experiencia = cuidadorInputModel.Experiencia,
                    ValorHora = cuidadorInputModel.ValorHora,
                    Disponibilidade = cuidadorInputModel.Disponibilidade,
                    Especializacoes = cuidadorInputModel.Especializacoes,
                    UsuarioId = cuidadorInputModel.UsuarioId
                };

                _cuidadorService.AtualizarCuidador(cuidador);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_usuarioService.ObterTodosUsuarios(), "UsuarioId", "UsuarioNome", cuidadorInputModel.UsuarioId);
            return View(cuidadorInputModel);
        }

        // GET: Cuidadores/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var cuidador = _cuidadorService.ObterCuidadorPorId(id);
            if (cuidador == null)
            {
                return NotFound();
            }

            var cuidadorViewModel = new CuidadorViewModel
            {
                CuidadorId = cuidador.CuidadorId,
                CPF = cuidador.CPF,
                Experiencia = cuidador.Experiencia,
                ValorHora = cuidador.ValorHora,
                Disponibilidade = cuidador.Disponibilidade,
                Especializacoes = cuidador.Especializacoes,
                UsuarioId = cuidador.UsuarioId,
                UsuarioNome = cuidador.Usuario?.UsuarioNome
            };

            return View(cuidadorViewModel);
        }

        // POST: Cuidadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cuidador = _cuidadorService.ObterCuidadorPorId(id);
            if (cuidador == null)
            {
                return NotFound();
            }

            _cuidadorService.ExcluirCuidador(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
