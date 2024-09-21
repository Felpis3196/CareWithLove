namespace CareWithLoveApp.Models.Entities
{
    public class ServicoCuidador
    {
        public Guid ServicoCuidadorId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Preferencia { get; set; }

        // Relacionamento muitos-para-um com Cuidador
        public Guid? CuidadorId { get; set; }
        public Cuidador? Cuidador { get; set; }
    }
}
