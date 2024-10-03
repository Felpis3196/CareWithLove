using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Repositories
{
    public interface IAvaliacaoRepository
    {
        Avaliacao? GetById(Guid id);
        void Add(Avaliacao avaliacao);
        void Delete(Guid id);
        IEnumerable<Avaliacao> GetAll();
    }
}
