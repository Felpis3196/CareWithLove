using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Services
{
    public interface ICuidadorService
    {
        Dependente? ObterDependentePorId(Guid id);
        IEnumerable<Cuidador> ObterTodosCuidadores();
        void CriarDependente(Cuidador cuidador);
        void AtualizarDependente(Cuidador cuidador);
        void ExcluirDependente(Guid id);
        void AdicionarDependente(Cuidador cuidador);
    }
}
