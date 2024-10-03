namespace CareWithLoveApp.Models.InputModel
{
    public class ServicoCuidadorInputModel
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Preferencia { get; set; }

        // Id do Cuidador associado (relacionamento muitos-para-um)
        public Guid? CuidadorId { get; set; }
    }
}
