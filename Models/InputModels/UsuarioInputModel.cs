using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.InputModels
{
    public class UsuarioInputModel
    {
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public String UsuarioId { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome do Usuário")]
        public string? UsuarioNome { get; set; }

        [Required(ErrorMessage = "O sexo do usuário é obrigatório.")]
        [Display(Name = "Sexo do Usuário")]
        public string? UsuarioSexo { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [Display(Name = "E-mail do Usuário")]
        public string? UsuarioEmail { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.", MinimumLength = 6)]
        [Display(Name = "Senha do Usuário")]
        public string? UsuarioSenha { get; set; }

        [Phone(ErrorMessage = "O número de telefone deve ser válido.")]
        [Display(Name = "Telefone do Usuário")]
        public string? UsuarioTelefone { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateOnly DataNascimento { get; set; }

        [StringLength(200, ErrorMessage = "O logradouro deve ter no máximo 200 caracteres.")]
        [Display(Name = "Logradouro")]
        public string? UsuarioLogradouro { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        [Display(Name = "Tipo de Usuário")]
        public string? UsuarioTipo { get; set; } // "Cuidador" ou "Responsável"
    }
}
