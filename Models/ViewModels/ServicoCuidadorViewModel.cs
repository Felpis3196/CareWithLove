namespace CareWithLoveApp.Models.ViewModels
{
    public class ServicoCuidadorViewModel
    {
        public Guid ServicoCuidadorId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Preferencia { get; set; }

        // Informações do cuidador (opcional)
        public Guid? CuidadorId { get; set; }
        public string? CuidadorNome { get; set; } 
    }
}
