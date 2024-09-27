using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Services
{
    public interface IDependenteService
    {
        Dependente? ObterDependentePorId(Guid id);
        IEnumerable<Dependente> ObterTodosDependentes();
        void CriarDependente(Dependente dependente);
        void AtualizarDependente(Dependente dependente);
        void ExcluirDependente(Guid id);
        void AdicionarDependente(Dependente dependente);
    }
}
