using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Models.InputModels;
using CareWithLoveApp.Models.OutputModels;
using CareWithLoveApp.Models.ViewModels;
using CareWithLoveApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CareWithLoveApp.Controllers
{
    public class AvaliacoesController : Controller
    {
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IUsuarioService _usuarioService;

        public AvaliacoesController(IAvaliacaoService avaliacaoService, IUsuarioService usuarioService)
        {
            _avaliacaoService = avaliacaoService;
            _usuarioService = usuarioService;
        }

        // GET: Avaliacoes
        public IActionResult Index()
        {
            var avaliacoes = _avaliacaoService.ObterTodasAvaliacoes();
            var viewModel = avaliacoes.Select(a => new AvaliacaoViewModel
            {
                AvaliacaoId = a.AvaliacaoId,
                Nota = a.Nota,
                Review = a.Review
            }).ToList();

            return View(viewModel);
        }

        // GET: Avaliacoes/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_usuarioService.ObterTodosUsuarios(), "UsuarioId", "UsuarioNome");
            return View();
        }

        // POST: Avaliacoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AvaliacaoInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = _usuarioService.ObterUsuarioPorId(inputModel.UsuarioId);
                if (usuario == null)
                {
                    ModelState.AddModelError(string.Empty, "Usuário não encontrado.");
                    ViewData["UsuarioId"] = new SelectList(_usuarioService.ObterTodosUsuarios(), "UsuarioId", "UsuarioNome", inputModel.UsuarioId);
                    return View(inputModel);
                }

                var avaliacao = new Avaliacao
                {
                    AvaliacaoId = Guid.NewGuid(),
                    Nota = inputModel.Nota,
                    Review = inputModel.Review,
                    UsuarioId = inputModel.UsuarioId,
                    Usuario = usuario
                };

                _avaliacaoService.CriarAvaliacao(avaliacao);
                return RedirectToAction(nameof(Index));
            }

            ViewData["UsuarioId"] = new SelectList(_usuarioService.ObterTodosUsuarios(), "UsuarioId", "UsuarioNome", inputModel.UsuarioId);
            return View(inputModel);
        }

        // POST: Avaliacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _avaliacaoService.ExcluirAvaliacao(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
