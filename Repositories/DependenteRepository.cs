using CareWithLoveApp.Data;
using CareWithLoveApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareWithLoveApp.Repositories
{
    public class DependenteRepository : IDependenteRepository
    {
        private readonly MainContext _context;

        public DependenteRepository(MainContext context)
        {
            _context = context;
        }

        public void Add(Dependente dependente)
        {
            _context.Add(dependente);
            _context.SaveChanges();
        }
        public Dependente? GetById(Guid id)
        {
            return _context.Dependentes
                .Include(d => d.ServicosClientes)
                .Include(d => d.Usuario)
                .FirstOrDefault(d => d.DependenteId == id);
        }

        public void Delete(Guid id)
        {
            var dependente = GetById(id);
            if (dependente != null)
            {
                _context.Dependentes.Remove(dependente);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Dependente> GetAll()
        {
            return _context.Dependentes
                .Include(d => d.ServicosClientes)
                .Include(d => d.Usuario);
        }


        public void Update(Dependente dependente)
        {
            _context.Dependentes.Update(dependente);
            _context.SaveChanges();
        }
    }
}
