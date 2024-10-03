using CareWithLoveApp.Data;
using CareWithLoveApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareWithLoveApp.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly MainContext _context;

        public AvaliacaoRepository(MainContext context)
        {
            _context = context;
        }
        public Avaliacao? GetById(Guid id)
        {
            return _context.Avaliacao
                .Include(a => a.Usuario)
                .FirstOrDefault(a => a.AvaliacaoId == id);
        }
        public void Add(Avaliacao avaliacao)
        { 
            _context.Add(avaliacao);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var avaliacao = GetById(id);
            if (avaliacao != null)
            {
                _context.Avaliacao.Remove(avaliacao);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Avaliacao> GetAll()
        {
            return _context.Avaliacao
                .Include(a => a.Usuario);
        }
    }
}
