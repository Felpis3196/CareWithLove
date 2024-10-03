using CareWithLoveApp.Data;
using CareWithLoveApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareWithLoveApp.Repositories
{
    public class ServicoClienteRepository : IServicoClienteRepository
    {
        private readonly MainContext _context;

        public ServicoClienteRepository(MainContext context)
        {
            _context = context;
        }

        public void Add(ServicoCliente servicoCliente)
        {
            _context.Add(servicoCliente);
            _context.SaveChanges();
        }
        public ServicoCliente? GetById(Guid id)
        {
            return _context.ServicoClientes
                .Include(s => s.Dependente)
                .FirstOrDefault(s => s.ServicoClienteId == id);
        }

        public void Delete(Guid id)
        {
            var servicoCliente = GetById(id);
            if (servicoCliente != null)
            {
                _context.ServicoClientes.Remove(servicoCliente);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ServicoCliente> GetAll()
        {
            return _context.ServicoClientes
                .Include(s => s.Dependente);
        }


        public void Update(ServicoCliente servicoCliente)
        {
            _context.ServicoClientes.Update(servicoCliente);
            _context.SaveChanges();
        }
    }
}
