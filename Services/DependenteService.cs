using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;
using System;
using System.Collections.Generic;

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
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do dependente não pode ser vazio.", nameof(id));
            }

            return _dependenteRepository.GetById(id);
        }

        public IEnumerable<Dependente> ObterTodosDependentes()
        {
            return _dependenteRepository.GetAll();
        }

        public void CriarDependente(Dependente dependente)
        {
            if (dependente == null)
            {
                throw new ArgumentNullException(nameof(dependente), "O dependente não pode ser nulo.");
            }

            _dependenteRepository.Add(dependente);
        }

        public void AtualizarDependente(Dependente dependente)
        {
            if (dependente == null)
            {
                throw new ArgumentNullException(nameof(dependente), "O dependente não pode ser nulo.");
            }

            _dependenteRepository.Update(dependente);
        }

        public void ExcluirDependente(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do dependente não pode ser vazio.", nameof(id));
            }

            _dependenteRepository.Delete(id);
        }

        public void AdicionarDependente(Dependente dependente)
        {
            if (dependente == null)
            {
                throw new ArgumentNullException(nameof(dependente), "O dependente não pode ser nulo.");
            }

            _dependenteRepository.Add(dependente);
        }
    }
}
