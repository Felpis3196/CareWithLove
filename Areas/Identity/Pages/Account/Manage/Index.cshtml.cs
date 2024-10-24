// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CareWithLoveApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CareWithLoveApp.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Display(Name = "Nome Completo")]
            public string UsuarioNome { get; set; }

            [Display(Name = "Sexo")]
            public string UsuarioSexo { get; set; }

            [Phone]
            [Display(Name = "Telefone")]
            public string UsuarioTelefone { get; set; }

            [Display(Name = "Data de Nascimento")]
            [DataType(DataType.Date)]
            public DateOnly DataNascimento { get; set; }

            [Display(Name = "Logradouro")]
            public string UsuarioLogradouro { get; set; }

            [Display(Name = "Tipo de Usuário")]
            public string UsuarioTipo { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;

            Input = new InputModel
            {
                UsuarioNome = user.UsuarioNome,
                UsuarioSexo = user.UsuarioSexo,
                UsuarioTelefone = user.UsuarioTelefone,
                DataNascimento = user.DataNascimento,
                UsuarioLogradouro = user.UsuarioLogradouro,
                UsuarioTipo = user.UsuarioTipo
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.UsuarioNome != user.UsuarioNome)
            {
                user.UsuarioNome = Input.UsuarioNome;
            }

            if (Input.UsuarioSexo != user.UsuarioSexo)
            {
                user.UsuarioSexo = Input.UsuarioSexo;
            }

            if (Input.UsuarioTelefone != user.UsuarioTelefone)
            {
                user.UsuarioTelefone = Input.UsuarioTelefone;
            }

            if (Input.DataNascimento != user.DataNascimento)
            {
                user.DataNascimento = Input.DataNascimento;
            }

            if (Input.UsuarioLogradouro != user.UsuarioLogradouro)
            {
                user.UsuarioLogradouro = Input.UsuarioLogradouro;
            }

            if (Input.UsuarioTipo != user.UsuarioTipo)
            {
                user.UsuarioTipo = Input.UsuarioTipo;
            }

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update user profile.";
                return RedirectToPage();
            }

            // Recarrega a sessão para refletir as mudanças
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

    }
}
