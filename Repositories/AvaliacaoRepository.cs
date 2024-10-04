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
            if (avaliacao == null)
            {
                throw new ArgumentNullException(nameof(avaliacao), "A avaliação não pode ser nula.");
            }

            try
            {
                _context.Avaliacao.Add(avaliacao);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Ocorreu um erro ao salvar a avaliação no banco de dados.", ex);
            }
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
