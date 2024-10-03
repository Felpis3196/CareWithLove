
using CareWithLoveApp.Models.ViewModels;

namespace CareWithLoveApp.Models.ViewModel
{
    public class CuidadorViewModel
    {
        public Guid CuidadorId { get; set; }
        public string? CPF { get; set; }
        public string? Experiencia { get; set; }
        public decimal? ValorHora { get; set; }
        public string? Disponibilidade { get; set; }
        public string? Especializacoes { get; set; }

        // Detalhes do Usuario (se necessário)
        public Guid? UsuarioId { get; set; }
        public string? UsuarioNome { get; set; } 

        // Lista de serviços oferecidos (opcional, dependendo do contexto)
        public List<ServicoCuidadorViewModel>? ServicosCuidador { get; set; }
    }
}
