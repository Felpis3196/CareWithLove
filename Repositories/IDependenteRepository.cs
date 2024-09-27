using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Repositories
{
    public interface IDependenteRepository
    {
        Dependente? GetById(Guid id);
        void Add(Dependente dependente);
        void Update(Dependente dependente);
        void Delete(Guid id);
        IEnumerable<Dependente> GetAll();
    }
}
