using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Services
{
    public interface IUsuarioService
    {
        Usuario? ObterUsuarioPorId(Guid id);
        IEnumerable<Usuario> ObterTodosUsuarios();
        void CriarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        void ExcluirUsuario(Guid id);
        void AdicionarUsuario(Usuario usuario);
    }
}
