using CareWithLoveApp.Data;
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
            return _usuarioRepository.GetById(id);
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            return _usuarioRepository.GetAll();
        }

        public void CriarUsuario(Usuario usuario)
        {
            // Aqui você pode aplicar regras de negócio
            _usuarioRepository.Add(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _usuarioRepository.Update(usuario);
        }

        public void ExcluirUsuario(Guid id)
        {
            _usuarioRepository.Delete(id);
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
        }
    }
}
