using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity; // Importante para o UserManager
using CareWithLoveApp.Models.InputModels;
using CareWithLoveApp.Models.OutputModels;
using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Models.ViewModels;
using CareWithLoveApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AplicacaoCareWithLove.Controllers
{
    //[Authorize(Roles = "Responsavel")]
    public class DependentesController : Controller
    {
        private readonly IDependenteService _dependenteService;
        private readonly UserManager<User> _userManager;

        public DependentesController(IDependenteService dependenteService, UserManager<User> userManager)
        {
            _dependenteService = dependenteService;
            _userManager = userManager; 
        }

        // GET: Dependentes
        public async Task<IActionResult> Index()
        {
            var dependentes = _dependenteService.ObterTodosDependentes()
                .Select(d => new DependenteViewModel
                {
                    DependenteId = d.DependenteId,
                    DependenteNome = d.DependenteNome,
                    DependenteIdade = d.DependenteIdade,
                    DependenteEndereco = d.DependenteEndereco,
                    Insulina = d.Insulina,
                    TelefoneEmergencia = d.TelefoneEmergencia,
                    Cuidados = d.Cuidados,
                });
            return View(dependentes);
        }

        // GET: Dependentes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var dependente = _dependenteService.ObterDependentePorId(id);
            if (dependente == null)
            {
                return NotFound();
            }

            var dependenteViewModel = new DependenteViewModel
            {
                DependenteId = dependente.DependenteId,
                DependenteNome = dependente.DependenteNome,
                DependenteIdade = dependente.DependenteIdade,
                DependenteEndereco = dependente.DependenteEndereco,
                Insulina = dependente.Insulina,
                TelefoneEmergencia = dependente.TelefoneEmergencia,
                Cuidados = dependente.Cuidados,
            };

            return View(dependenteViewModel);
        }

        // GET: Dependentes/Create
        public async Task<IActionResult> Create()
        {
            var usuarios = await _userManager.Users.ToListAsync(); 
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "UserName"); 
            return View();
        }

        // POST: Dependentes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DependenteInputModel dependenteInputModel)
        {
            if (dependenteInputModel != null)
            {
                var dependente = new Dependente
                {
                    DependenteId = Guid.NewGuid().ToString(),
                    DependenteNome = dependenteInputModel.DependenteNome,
                    DependenteIdade = dependenteInputModel.DependenteIdade,
                    DependenteEndereco = dependenteInputModel.DependenteEndereco,
                    Insulina = dependenteInputModel.Insulina,
                    TelefoneEmergencia = dependenteInputModel.TelefoneEmergencia,
                    Cuidados = dependenteInputModel.Cuidados,
                    UsuarioId = dependenteInputModel.UsuarioId
                };

                _dependenteService.AdicionarDependente(dependente);
                return RedirectToAction(nameof(Index));
            }

            var usuarios = await _userManager.Users.ToListAsync();
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "UserName", dependenteInputModel.UsuarioId);
            return View(dependenteInputModel);
        }

        // GET: Dependentes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var dependente = _dependenteService.ObterDependentePorId(id);
            if (dependente == null)
            {
                return NotFound();
            }

            var dependenteInputModel = new DependenteInputModel
            {
                DependenteId = dependente.DependenteId,
                DependenteNome = dependente.DependenteNome,
                DependenteIdade = dependente.DependenteIdade,
                DependenteEndereco = dependente.DependenteEndereco,
                Insulina = dependente.Insulina,
                TelefoneEmergencia = dependente.TelefoneEmergencia,
                Cuidados = dependente.Cuidados,
                UsuarioId = dependente.UsuarioId
            };

            var usuarios = await _userManager.Users.ToListAsync(); 
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "UserName", dependente.UsuarioId);
            return View(dependenteInputModel);
        }

        // POST: Dependentes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DependenteInputModel dependenteInputModel)
        {
            if (id.ToString() != dependenteInputModel.DependenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dependente = new Dependente
                {
                    DependenteId = dependenteInputModel.DependenteId,
                    DependenteNome = dependenteInputModel.DependenteNome,
                    DependenteIdade = dependenteInputModel.DependenteIdade,
                    DependenteEndereco = dependenteInputModel.DependenteEndereco,
                    Insulina = dependenteInputModel.Insulina,
                    TelefoneEmergencia = dependenteInputModel.TelefoneEmergencia,
                    Cuidados = dependenteInputModel.Cuidados,
                    UsuarioId = dependenteInputModel.UsuarioId
                };

                _dependenteService.AtualizarDependente(dependente);
                return RedirectToAction(nameof(Index));
            }
            dependenteInputModel.UsuarioId = (User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(dependenteInputModel);
        }

        // GET: Dependentes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var dependente = _dependenteService.ObterDependentePorId(id);
            if (dependente == null)
            {
                return NotFound();
            }

            var dependenteViewModel = new DependenteViewModel
            {
                DependenteId = dependente.DependenteId,
                DependenteNome = dependente.DependenteNome,
                DependenteIdade = dependente.DependenteIdade,
                DependenteEndereco = dependente.DependenteEndereco,
                Insulina = dependente.Insulina,
                TelefoneEmergencia = dependente.TelefoneEmergencia,
                Cuidados = dependente.Cuidados,
            };

            return View(dependenteViewModel);
        }

        // POST: Dependentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dependente = _dependenteService.ObterDependentePorId(id);
            if (dependente == null)
            {
                return NotFound();
            }

            _dependenteService.ExcluirDependente(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
