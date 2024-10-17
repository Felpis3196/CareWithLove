namespace CareWithLoveApp.Models.Entities
{
    public class Dependente
    {
        public String DependenteId { get; set; }
        public string? DependenteNome { get; set; }
        public int? DependenteIdade { get; set; }
        public string? DependenteEndereco { get; set; }
        public bool? Insulina { get; set; }
        public string? TelefoneEmergencia { get; set; }
        public string? Cuidados { get; set; }

        // Relacionamento de muitos-para-um com Usuario
        public String? UsuarioId { get; set; }
        public User? Usuario { get; set; }

        // Relacionamento de um-para-muitos com ServicoClientes
        public ICollection<ServicoCliente>? ServicosClientes { get; set; }
    }
}
