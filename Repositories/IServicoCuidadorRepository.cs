using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Repositories
{
    public interface IServicoCuidadorRepository
    {
        ServicoCuidador? GetById(Guid id);
        void Add(ServicoCuidador servicoCuidador);
        void Update(ServicoCuidador servicoCuidador);
        void Delete(Guid id);
        IEnumerable<ServicoCuidador> GetAll();
    }
}
