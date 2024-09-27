using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Repositories
{
    public interface ICuidadorRepository
    {
        Cuidador? GetById(Guid id);
        void Add(Cuidador cuidador);
        void Update(Cuidador cuidador);
        void Delete(Guid id);
        IEnumerable<Cuidador> GetAll();
    }
}
