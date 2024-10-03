using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Services
{
    public interface IServicoClienteService
    {
        ServicoCliente? ObterServicoClientePorId(Guid id);
        IEnumerable<ServicoCliente> ObterTodosServicosClientes();
        void CriarServicoCliente(ServicoCliente servicoCliente);
        void AtualizarServicoCliente(ServicoCliente servicoCliente);
        void ExcluirServicoCliente(Guid id);
        void AdicionarServicoCliente(ServicoCliente servicoCliente);
    }
}
