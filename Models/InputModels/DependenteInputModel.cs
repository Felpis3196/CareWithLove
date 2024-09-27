namespace CareWithLoveApp.Models.InputModels
{
    public class DependenteInputModel
    {
        public string DependenteNome { get; set; }
        public int? DependenteIdade { get; set; }
        public string DependenteEndereco { get; set; }
        public bool? Insulina { get; set; }
        public string TelefoneEmergencia { get; set; }
        public string Cuidados { get; set; }

        // Relacionamento com Usuario
        public Guid? UsuarioId { get; set; }
    }
}
