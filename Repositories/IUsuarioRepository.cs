using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario? GetById(Guid id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Guid id);
        IEnumerable<Usuario> GetAll();
    }
}
