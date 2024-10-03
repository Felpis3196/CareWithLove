using Microsoft.AspNetCore.Identity;

namespace CareWithLoveApp.Models.Entities
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public string? UsuarioNome { get; set; }
        public string? UsuarioSexo { get; set; }
        public string? UsuarioEmail { get; set; } 
        public string? UsuarioSenha { get; set; }
        public string? UsuarioTelefone { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string? UsuarioLogradouro { get; set; }

        // Definir o tipo de usuário (Cuidador ou Responsável por Dependentes)
        public string? UsuarioTipo { get; set; } // "Cuidador" ou "Responsável"

        // Relacionamento um-para-um com Cuidador
        public Cuidador? Cuidador { get; set; }

        // Relacionamento um-para-muitos com Dependente
        public ICollection<Dependente>? Dependentes { get; set; }
    }

}
