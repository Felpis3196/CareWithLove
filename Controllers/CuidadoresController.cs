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
using CareWithLoveApp.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CareWithLoveApp.Controllers
{
    //[Authorize(Roles = "Cuidador")]
    public class CuidadoresController : Controller
    {
        private readonly ICuidadorService _cuidadorService;
        private readonly UserManager<User> _userManager;

        public CuidadoresController(ICuidadorService cuidadorService, UserManager<User> userManager)
        {
            _cuidadorService = cuidadorService;
            _userManager = userManager;
        }

        // GET: Cuidadores
        public async Task<IActionResult> Index()
        {
            var usuarioLogadoId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuarioLogado = await _userManager.FindByIdAsync(usuarioLogadoId);

            var cuidadores = _cuidadorService.ObterTodosCuidadores()
                .Select(c => new CuidadorViewModel
                {
                    CuidadorId = c.CuidadorId,
                    CPF = c.CPF,
                    Experiencia = c.Experiencia,
                    ValorHora = c.ValorHora,
                    Disponibilidade = c.Disponibilidade,
                    Especializacoes = c.Especializacoes,
                    CuidadorNome = usuarioLogado?.UsuarioNome 
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
                CuidadorNome = cuidador.Usuario.UsuarioNome
            };

            return View(cuidadorViewModel);
        }

        // GET: Cuidadores/Create
        public async Task<IActionResult> Create()
        {
            // Carregar a lista de usuários no ViewData para popular o SelectList
            var usuarios = await _userManager.Users.ToListAsync();
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "UsuarioNome");
            return View();
        }

        // POST: Cuidadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CuidadorInputModel cuidadorInputModel)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuario = await _userManager.FindByIdAsync(userIdString);

            if (usuario == null)
            {
                ModelState.AddModelError("UsuarioId", "Usuário não encontrado.");
                return View(cuidadorInputModel);
            }

            if (!Guid.TryParse(usuario.Id, out Guid usuarioIdGuid))
            {
                ModelState.AddModelError("UsuarioId", "ID do usuário inválido.");
                return View(cuidadorInputModel);
            }

            if (cuidadorInputModel != null)
            {
                var cuidador = new Cuidador
                {
                    CuidadorId = Guid.NewGuid().ToString(),
                    CPF = cuidadorInputModel.CPF,
                    Experiencia = cuidadorInputModel.Experiencia,
                    ValorHora = cuidadorInputModel.ValorHora,
                    Disponibilidade = cuidadorInputModel.Disponibilidade,
                    Especializacoes = cuidadorInputModel.Especializacoes,
                    UsuarioId = usuarioIdGuid.ToString()
                };

                _cuidadorService.CriarCuidador(cuidador);
                return RedirectToAction(nameof(Index));
            }

            cuidadorInputModel.UsuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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
                UsuarioId = cuidador.UsuarioId,
                Usuario = cuidador.Usuario
            };

            var usuarios = await _userManager.Users.ToListAsync();
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "UsuarioNome", cuidador.UsuarioId);
            return View(cuidadorInputModel);
        }

        // POST: Cuidadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CuidadorInputModel cuidadorInputModel)
        {
            if (id.ToString() != cuidadorInputModel.CuidadorId)
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
                    UsuarioId = cuidadorInputModel.UsuarioId,
                    Usuario = cuidadorInputModel.Usuario
                };

                _cuidadorService.AtualizarCuidador(cuidador);
                return RedirectToAction(nameof(Index));
            }

            var usuarios = await _userManager.Users.ToListAsync();
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "UsuarioNome", cuidadorInputModel.UsuarioId);
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
                CuidadorNome = cuidador.Usuario?.UsuarioNome
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
