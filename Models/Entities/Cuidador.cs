namespace CareWithLoveApp.Models.Entities
{
    public class Cuidador
    {
        public String? CuidadorId { get; set; }
        public string? CPF { get; set; }
        public string? Experiencia { get; set; }
        public decimal? ValorHora { get; set; }
        public string? Disponibilidade { get; set; }
        public string? Especializacoes { get; set; }

        // Chave estrangeira para o User
        public String? UsuarioId { get; set; }
        public User? Usuario { get; set; }

        // Relacionamento de um-para-muitos com ServicoCuidador
        public ICollection<ServicoCuidador>? ServicosCuidador { get; set; }
    }
}
