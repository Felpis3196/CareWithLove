using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Services
{
    public interface IServicoClienteService
    {
        Dependente? ObterDependentePorId(Guid id);
        IEnumerable<Cuidador> ObterTodosServicosClientes();
        void CriarServicoCliente(ServicoCliente servicoCliente);
        void AtualizarServicoCliente(ServicoCliente servicoCliente);
        void ExcluirDependente(Guid id);
        void AdicionarServicoCliente(ServicoCliente servicoCliente);
    }
}
