using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CareWithLoveApp.Models.InputModels;
using CareWithLoveApp.Models.ViewModels;
using CareWithLoveApp.Services;
using CareWithLoveApp.Models.Entities;

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
        public async Task<IActionResult> Index()
        {
            var avaliacoes = _avaliacaoService.ObterTodasAvaliacoes()
                .Select(a => new AvaliacaoViewModel
                {
                    AvaliacaoId = a.AvaliacaoId,
                    Nota = a.Nota,
                    Review = a.Review,
                    UsuarioId = a.UsuarioId,
                    Usuario = a.Usuario // Carregando o usuário relacionado
                });

            return View(avaliacoes);
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
        public async Task<IActionResult> Create(AvaliacaoInputModel avaliacaoInputModel)
        {
            if (ModelState.IsValid)
            {
                var avaliacao = new Avaliacao
                {
                    AvaliacaoId = Guid.NewGuid(),
                    Nota = avaliacaoInputModel.Nota,
                    Review = avaliacaoInputModel.Review,
                    UsuarioId = avaliacaoInputModel.UsuarioId,
                    Usuario = _usuarioService.ObterUsuarioPorId(avaliacaoInputModel.UsuarioId)          
                };

                _avaliacaoService.CriarAvaliacao(avaliacao);
                return RedirectToAction(nameof(Index));
            }

            ViewData["UsuarioId"] = new SelectList(_usuarioService.ObterTodosUsuarios(), "UsuarioId", "UsuarioNome", avaliacaoInputModel.UsuarioId);
            return View(avaliacaoInputModel);
        }

        // GET: Avaliacoes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var avaliacao = _avaliacaoService.ObterAvaliacaoPorId(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            var avaliacaoViewModel = new AvaliacaoViewModel
            {
                AvaliacaoId = avaliacao.AvaliacaoId,
                Nota = avaliacao.Nota,
                Review = avaliacao.Review,
                UsuarioId = avaliacao.UsuarioId
            };

            return View(avaliacaoViewModel);
        }

        // POST: Avaliacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var avaliacao = _avaliacaoService.ObterAvaliacaoPorId(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            _avaliacaoService.ExcluirAvaliacao(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
