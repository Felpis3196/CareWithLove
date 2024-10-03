using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Services
{
    public interface ICuidadorService
    {
        Cuidador? ObterCuidadorPorId(Guid id);
        IEnumerable<Cuidador> ObterTodosCuidadores();
        void CriarCuidador(Cuidador cuidador);
        void AtualizarCuidador(Cuidador cuidador);
        void ExcluirCuidador(Guid id);
        void AdicionarCuidador(Cuidador cuidador);
    }
}
