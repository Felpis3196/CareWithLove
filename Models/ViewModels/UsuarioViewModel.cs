namespace CareWithLoveApp.Models.OutputModels
{
    public class UsuarioViewModel
    {
        public Guid UsuarioId { get; set; }
        public string? UsuarioNome { get; set; }
        public string? UsuarioSexo { get; set; }
        public string? UsuarioEmail { get; set; }
        public DateOnly DataNascimento { get; set; }

        // Definir o tipo de usuário (Cuidador ou Responsável por Dependentes)
        public string? UsuarioTipo { get; set; } // "Cuidador" ou "Responsável"
    }
}
