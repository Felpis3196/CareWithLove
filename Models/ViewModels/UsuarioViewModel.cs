using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.OutputModels
{
    public class UsuarioViewModel
    {
        [Display(Name = "Código do Usuário")]
        public String UsuarioId { get; set; }
        [Display(Name = "Nome do Usuário")]
        public string? UsuarioNome { get; set; }
        [Display(Name = "Sexo do Usuário")]
        public string? UsuarioSexo { get; set; }
        [Display(Name = "Nome do E-Mail")]
        public string? UsuarioEmail { get; set; }
        [Display(Name = "Data de Nascimento do Usuário")]
        public DateOnly DataNascimento { get; set; }

        // Definir o tipo de usuário (Cuidador ou Responsável por Dependentes)
        [Display(Name = "Tipo do Usuário")]
        public string? UsuarioTipo { get; set; } // "Cuidador" ou "Responsável"
    }
}
