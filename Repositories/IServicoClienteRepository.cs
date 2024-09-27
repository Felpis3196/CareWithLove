using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Repositories
{
    public interface IServicoClienteRepository
    {
        ServicoCliente? GetById(Guid id);
        void Add(ServicoCliente servicoCliente);
        void Update(ServicoCliente servicoCliente);
        void Delete(Guid id);
        IEnumerable<ServicoCliente> GetAll();
    }
}
