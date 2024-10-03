namespace CareWithLoveApp.Models.InputModels
{
    public class ServicoClienteInputModel
    {
        public Guid ServicoClienteId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Local { get; set; }

        // Relacionamento com Dependente
        public Guid? DependenteId { get; set; }
    }

}
