namespace CareWithLoveApp.Models.Entities
{
    public class ServicoCliente
    {
        public Guid ServicoClienteId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Local { get; set; }

        // Relacionamento de muitos-para-um com Dependente
        public Guid? DependenteId { get; set; }
        public Dependente? Dependente { get; set; }
    }
}
