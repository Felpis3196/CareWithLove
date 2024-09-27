using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;

namespace CareWithLoveApp.Services
{
    public class DependenteService : IDependenteService
    {
        private readonly IDependenteRepository _dependenteRepository;

        public DependenteService(IDependenteRepository dependenteRepository)
        {
            _dependenteRepository = dependenteRepository;
        }

        public Dependente? ObterDependentePorId(Guid id)
        {
            return _dependenteRepository.GetById(id);
        }

        public IEnumerable<Dependente> ObterTodosDependentes()
        {
            return _dependenteRepository.GetAll();
        }

        public void CriarDependente(Dependente dependente)
        {
            _dependenteRepository.Add(dependente);
        }

        public void AtualizarDependente(Dependente dependente)
        {
            _dependenteRepository.Update(dependente);
        }

        public void ExcluirDependente(Guid id)
        {
            _dependenteRepository.Delete(id);
        }

        public void AdicionarDependente(Dependente dependente)
        {
            _dependenteRepository.Add(dependente);
        }
    }
}

