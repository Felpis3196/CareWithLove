using CareWithLoveApp.Data;
using CareWithLoveApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareWithLoveApp.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MainContext _context;

        public UsuarioRepository(MainContext context)
        {
            _context = context;
        }

        // Adicionar novo usuário
        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);  // Note que "Usuario" é singular
            _context.SaveChanges();
        }

        // Obter usuário pelo ID
        public Usuario? GetById(Guid id)
        {
            return _context.Usuarios
                .Include(u => u.Cuidador)
                .Include(u => u.Dependentes)
                .FirstOrDefault(u => u.UsuarioId == id);
        }

        // Atualizar usuário existente
        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        // Excluir usuário pelo ID
        public void Delete(Guid id)
        {
            var usuario = GetById(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        // Obter todos os usuários
        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios
                .Include(u => u.Cuidador)
                .Include(u => u.Dependentes);
                
        }
    }
}
