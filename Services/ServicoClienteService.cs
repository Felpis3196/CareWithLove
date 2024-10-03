using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;

namespace CareWithLoveApp.Services
{
    public class ServicoClienteService : IServicoClienteService
    {
        private readonly IServicoClienteRepository _servicoClienteRepository;

        public ServicoClienteService(IServicoClienteRepository servicoClienteRepository)
        {
            _servicoClienteRepository = servicoClienteRepository;
        }

        public ServicoCliente? ObterServicoClientePorId(Guid id)
        {
          return _servicoClienteRepository.GetById(id);
        }
        public IEnumerable<ServicoCliente> ObterTodosServicosClientes()
        {
          return _servicoClienteRepository.GetAll();
        }
        public void CriarServicoCliente(ServicoCliente servicoCliente)
        {
            _servicoClienteRepository.Add(servicoCliente);
        }
        public void AtualizarServicoCliente(ServicoCliente servicoCliente)
        {
            _servicoClienteRepository.Update(servicoCliente);
        }
        public void ExcluirServicoCliente(Guid id)
        {
            _servicoClienteRepository.Delete(id);
        }
        public void AdicionarServicoCliente(ServicoCliente servicoCliente)
        {
            _servicoClienteRepository.Add(servicoCliente);
        }
    }
}
