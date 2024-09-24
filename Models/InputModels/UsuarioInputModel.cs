using CareWithLoveApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.InputModels
{
    public class UsuarioInputModel
    {
        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        public string? UsuarioNome { get; set; }

        [Required(ErrorMessage = "O sexo do usuário é obrigatório")]
        public string? UsuarioSexo { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string? UsuarioEmail { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string? UsuarioSenha { get; set; }

        public string? UsuarioTelefone { get; set; }

        public DateOnly DataNascimento { get; set; }

        public string? UsuarioLogradouro { get; set; }

        public string? UsuarioTipo { get; set; } // "Cuidador" ou "Responsável"
    }

}
