// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using CareWithLoveApp.Data;
using CareWithLoveApp.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace CareWithLoveApp.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MainContext _mainContext;

        private Dictionary<string, string> errorMessages = new Dictionary<string, string>
        {
            { "DuplicateUserName", "Nome do usuário já está em uso." },
            // Adicione mais códigos e mensagens conforme necessário
            // { "ERR002", "Email format is invalid." },
            
        };

        public RegisterModel(
            UserManager<User> userManager,
            IUserStore<User> userStore,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            MainContext mainContext)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
            _mainContext = mainContext;
        }

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
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>

            [Required(ErrorMessage = "O E-mail é obrigatório.")]
            [EmailAddress(ErrorMessage = "O campo Email não é um endereço de e-mail válido.")]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "A Senha é obrigatório.")]
            [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password, ErrorMessage = "A senha precisa ter pelo menos uma letra maiúscula, uma minúscula, um número e um caractere especial")]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirmar Senha")]
            [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não coincidem.")]
            public string ConfirmPassword { get; set; }




            // Additional fields from the User class

            public Guid UsuarioId { get; set; }

            [Required(ErrorMessage = "O Nome é obrigatório.")]
            [Display(Name = "Nome Completo")]
            public string? UsuarioNome { get; set; }

            [Display(Name = "Sexo")]
            public string? UsuarioSexo { get; set; }

            [Required(ErrorMessage = "O Telefone é obrigatório.")]
            [Display(Name = "Telefone")]
            public string? UsuarioTelefone { get; set; }

            [Required(ErrorMessage = "A Data de Nascimento é obrigatório.")]
            [Display(Name = "Data de Nascimento")]
            [DataType(DataType.Date)]
            public DateOnly DataNascimento { get; set; }

            [Required(ErrorMessage = "O Logradouro é obrigatório.")]
            [Display(Name = "Logradouro")]
            public string? UsuarioLogradouro { get; set; }

            [Required(ErrorMessage = "O Tipo é obrigatório.")]
            [Display(Name = "Tipo de Usuário")]
            public string? UsuarioTipo { get; set; } // "Cuidador" ou "Responsável"
        }



        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var dataNascimento = Input.DataNascimento;
            var diaHoje = DateOnly.FromDateTime(DateTime.Today);
            var idade = diaHoje.Year - dataNascimento.Year;

            if (dataNascimento > diaHoje.AddYears(-idade))
            {
                idade--;
            }

            if (idade < 21)
            {
                ModelState.AddModelError("Input.DataNascimento", "Você precisa ter pelo menos 21 anos de idade.");
            }

            if (ModelState.IsValid && idade > 21)
            {
                var user = new User
                {
                    Email = Input.Email,
                    UserName = Input.Email,
                    UsuarioNome = Input.UsuarioNome,
                    UsuarioSexo = Input.UsuarioSexo,
                    UsuarioTelefone = Input.UsuarioTelefone,
                    DataNascimento = Input.DataNascimento,
                    UsuarioLogradouro = Input.UsuarioLogradouro,
                    UsuarioTipo = Input.UsuarioTipo // Este campo será o role
                };

                var usuario = new User
                {
                    Id = user.Id,
                    UsuarioNome = user.UsuarioNome,
                    UsuarioSexo = user.UsuarioSexo,
                    UsuarioTelefone = user.UsuarioTelefone,
                    DataNascimento = user.DataNascimento,
                    UsuarioLogradouro = user.UsuarioLogradouro,
                    UsuarioTipo = user.UsuarioTipo,
                    UserName = user.UserName,
                    NormalizedUserName = user.NormalizedUserName,
                    EmailConfirmed = user.EmailConfirmed,
                    PasswordHash = user.PasswordHash,
                    SecurityStamp = user.SecurityStamp,
                    ConcurrencyStamp = user.ConcurrencyStamp,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    PhoneNumber = user.PhoneNumber,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    LockoutEnabled = user.LockoutEnabled,
                    LockoutEnd = user.LockoutEnd,
                    AccessFailedCount = user.AccessFailedCount,
                };

                _mainContext.Usuarios.Add(usuario);
                _mainContext.SaveChanges();

                // Define o nome de usuário e o email
                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                // Cria o usuário
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("O usuário criou uma nova conta com senha.");

                    // Verifica se o role existe, caso contrário, cria-o
                    if (!await _roleManager.RoleExistsAsync(user.UsuarioTipo))
                    {
                        var roleResult = await _roleManager.CreateAsync(new IdentityRole(user.UsuarioTipo));
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError(string.Empty, "Erro ao criar o papel de usuário.");
                            return Page();
                        }
                    }

                    // Atribui o role ao usuário
                    await _userManager.AddToRoleAsync(user, user.UsuarioTipo);

                    // Gera o código de confirmação de email
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, getErrorMessage(error));
                }


                ModelState.AddModelError("DataNascimento", "Você precisa ter pelo menos 21 anos de idade.");
            }

            return Page();
        }


        private string getErrorMessage(IdentityError error)
        {
            string errorMessage = error.Description;

            if (errorMessages.ContainsKey(error.Code))
                errorMessage = errorMessages[error.Code];

            return errorMessage;
        }


        private User CreateUser()
        {
            try
            {
                return Activator.CreateInstance<User>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(User)}'. " +
                    $"Ensure that '{nameof(User)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<User>)_userStore;
        }
    }
}
