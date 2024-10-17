namespace CareWithLoveApp.Models.Entities
{
    public class ServicoCliente
    {
        public String ServicoClienteId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Local { get; set; }

        // Relacionamento de muitos-para-um com Dependente
        public String? DependenteId { get; set; }
        public Dependente? Dependente { get; set; }
    }
}
