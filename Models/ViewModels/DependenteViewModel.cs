namespace CareWithLoveApp.Models.ViewModels
{
    public class DependenteViewModel
    {
        public Guid DependenteId { get; set; }
        public string DependenteNome { get; set; }
        public int? DependenteIdade { get; set; }
        public string DependenteEndereco { get; set; }
        public bool? Insulina { get; set; }
        public string TelefoneEmergencia { get; set; }
        public string Cuidados { get; set; }

        // Relacionamento com Usuario
        public Guid? UsuarioId { get; set; }
        public string UsuarioNome { get; set; }

        // Relacionamento com ServicoClientes
        public ICollection<ServicoClienteViewModel> ServicosClientes { get; set; }
    }

}
