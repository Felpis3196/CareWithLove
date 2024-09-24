using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareWithLoveApp.Data;
using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Services;
using CareWithLoveApp.Models.InputModels;
using CareWithLoveApp.Models.OutputModels;

namespace AplicacaoCareWithLove.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = _usuarioService.ObterTodosUsuarios()
                .Select(u => new UsuarioViewModel
                {
                    UsuarioId = u.UsuarioId,
                    UsuarioNome = u.UsuarioNome,
                    UsuarioEmail = u.UsuarioEmail,
                    UsuarioSexo = u.UsuarioSexo,
                    DataNascimento = u.DataNascimento,
                    UsuarioTipo = u.UsuarioTipo
                });
            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var usuario = _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioViewModel = new UsuarioViewModel
            {
                UsuarioId = usuario.UsuarioId,
                UsuarioNome = usuario.UsuarioNome,
                UsuarioEmail = usuario.UsuarioEmail,
                UsuarioSexo = usuario.UsuarioSexo,
                DataNascimento = usuario.DataNascimento,
                UsuarioTipo = usuario.UsuarioTipo
            };

            return View(usuarioViewModel);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioInputModel usuarioInputModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    UsuarioId = Guid.NewGuid(),
                    UsuarioNome = usuarioInputModel.UsuarioNome,
                    UsuarioEmail = usuarioInputModel.UsuarioEmail,
                    UsuarioTelefone = usuarioInputModel.UsuarioTelefone,
                    UsuarioSexo = usuarioInputModel.UsuarioSexo,
                    UsuarioSenha = usuarioInputModel.UsuarioSenha,
                    DataNascimento = usuarioInputModel.DataNascimento,
                    UsuarioLogradouro = usuarioInputModel.UsuarioLogradouro,
                    UsuarioTipo = usuarioInputModel.UsuarioTipo
                };

                _usuarioService.AdicionarUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioInputModel);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var usuario = _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioInputModel = new UsuarioInputModel
            {
                UsuarioId = usuario.UsuarioId,
                UsuarioNome = usuario.UsuarioNome,
                UsuarioEmail = usuario.UsuarioEmail,
                UsuarioTelefone = usuario.UsuarioTelefone,
                UsuarioSexo = usuario.UsuarioSexo,
                DataNascimento = usuario.DataNascimento,
                UsuarioLogradouro = usuario.UsuarioLogradouro,
                UsuarioTipo = usuario.UsuarioTipo
            };

            return View(usuarioInputModel);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UsuarioInputModel usuarioInputModel)
        {
            if (id != usuarioInputModel.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    UsuarioId = usuarioInputModel.UsuarioId,
                    UsuarioNome = usuarioInputModel.UsuarioNome,
                    UsuarioEmail = usuarioInputModel.UsuarioEmail,
                    UsuarioTelefone = usuarioInputModel.UsuarioTelefone,
                    UsuarioSexo = usuarioInputModel.UsuarioSexo,
                    UsuarioSenha = usuarioInputModel.UsuarioSenha,
                    DataNascimento = usuarioInputModel.DataNascimento,
                    UsuarioLogradouro = usuarioInputModel.UsuarioLogradouro,
                    UsuarioTipo = usuarioInputModel.UsuarioTipo
                };

                _usuarioService.AtualizarUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioInputModel);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var usuario = _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioViewModel = new UsuarioViewModel
            {
                UsuarioId = usuario.UsuarioId,
                UsuarioNome = usuario.UsuarioNome,
                UsuarioEmail = usuario.UsuarioEmail,
                UsuarioSexo = usuario.UsuarioSexo,
                DataNascimento = usuario.DataNascimento,
                UsuarioTipo = usuario.UsuarioTipo
            };

            return View(usuarioViewModel);
        }


        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var usuario = _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioService.ExcluirUsuario(id);
            return RedirectToAction(nameof(Index));
        }

    }

}
