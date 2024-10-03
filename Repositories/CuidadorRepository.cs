using CareWithLoveApp.Data;
using CareWithLoveApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareWithLoveApp.Repositories
{
    public class CuidadorRepository : ICuidadorRepository
    {
        private readonly MainContext _context;

        public CuidadorRepository(MainContext context)
        {
            _context = context;
        }
        public void Add(Cuidador cuidador)
        {
            _context.Add(cuidador);
            _context.SaveChanges();
        }

        public Cuidador? GetById(Guid id)
        {
            return _context.Cuidadores
                .Include(c => c.ServicosCuidador)
                .FirstOrDefault(c => c.CuidadorId == id);
        }

        public void Delete(Guid id)
        {
            var cuidador = GetById(id);
            if (cuidador != null)
            {
                _context.Cuidadores.Remove(cuidador);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Cuidador> GetAll()
        {
            return _context.Cuidadores
                .Include(d => d.ServicosCuidador);
        }


        public void Update(Cuidador cuidador)
        {
            _context.Cuidadores.Update(cuidador);
            _context.SaveChanges();
        }
    }
}
