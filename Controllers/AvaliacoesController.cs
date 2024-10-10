using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CareWithLoveApp.Models.InputModels;
using CareWithLoveApp.Models.ViewModels;
using CareWithLoveApp.Services;
using CareWithLoveApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CareWithLoveApp.Controllers
{
    public class AvaliacoesController : Controller
    {
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly UserManager<User> _userManager;

        public AvaliacoesController(IAvaliacaoService avaliacaoService, UserManager<User> userManager)
        {
            _avaliacaoService = avaliacaoService;
            _userManager = userManager;
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
                    Usuario = a.Usuario
                });

            return View(avaliacoes);
        }

        // GET: Avaliacoes/Create
        public async Task<IActionResult> Create()
        {
            // Obtendo todos os usuários para preencher o dropdown
            var usuarios = await _userManager.Users.ToListAsync();
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "UsuarioNome");
            return View();
        }

        // POST: Avaliacoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvaliacaoInputModel avaliacaoInputModel)
        {
            if (ModelState.IsValid)
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var usuario = await _userManager.FindByIdAsync(userIdString);

                if (usuario == null)
                {
                    ModelState.AddModelError("UsuarioId", "Usuário não encontrado.");
                    return View(avaliacaoInputModel);
                }

                if (!Guid.TryParse(usuario.Id, out Guid usuarioIdGuid))
                {
                    ModelState.AddModelError("UsuarioId", "ID do usuário inválido.");
                    return View(avaliacaoInputModel);
                }

                var avaliacao = new Avaliacao
                {
                    AvaliacaoId = Guid.NewGuid(),
                    Nota = avaliacaoInputModel.Nota,
                    Review = avaliacaoInputModel.Review,
                    UsuarioId = usuarioIdGuid, 
                    Usuario = usuario
                };

                _avaliacaoService.CriarAvaliacao(avaliacao);
                return RedirectToAction(nameof(Index));
            }

            // Preenche o UsuarioId com o Id do usuário logado na falha da validação
            if (Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid loggedUserId))
            {
                avaliacaoInputModel.UsuarioId = loggedUserId;
            }

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
