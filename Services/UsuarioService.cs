using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;
using System;
using System.Collections.Generic;

namespace CareWithLoveApp.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario? ObterUsuarioPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do usuário não pode ser vazio.", nameof(id));
            }

            return _usuarioRepository.GetById(id);
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            return _usuarioRepository.GetAll();
        }

        public void CriarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "O usuário não pode ser nulo.");
            }

            _usuarioRepository.Add(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "O usuário não pode ser nulo.");
            }

            _usuarioRepository.Update(usuario);
        }

        public void ExcluirUsuario(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do usuário não pode ser vazio.", nameof(id));
            }

            _usuarioRepository.Delete(id);
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "O usuário não pode ser nulo.");
            }

            _usuarioRepository.Add(usuario);
        }
    }
}
