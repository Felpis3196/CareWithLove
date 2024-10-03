using CareWithLoveApp.Data;
using CareWithLoveApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareWithLoveApp.Repositories
{
    public class ServicoCuidadorRepository : IServicoCuidadorRepository
    {
        private readonly MainContext _context;

        public ServicoCuidadorRepository(MainContext context)
        {
            _context = context;
        }

        public void Add(ServicoCuidador servicoCuidador)
        {
            _context.Add(servicoCuidador);
            _context.SaveChanges();
        }
        public ServicoCuidador? GetById(Guid id)
        {
            return _context.ServicoCuidadores
                .Include(s=>s.CuidadorId)
                .FirstOrDefault(s => s.ServicoCuidadorId == id);

        }

        public void Delete(Guid id)
        {
            var servicoCuidador = GetById(id);
            if (servicoCuidador != null)
            {
                _context.ServicoCuidadores.Remove(servicoCuidador);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ServicoCuidador> GetAll()
        {
            return _context.ServicoCuidadores
                .Include(s => s.CuidadorId);
        }


        public void Update(ServicoCuidador servicoCuidador)
        {
            _context.ServicoCuidadores.Update(servicoCuidador);
            _context.SaveChanges();
        }
    }
}
