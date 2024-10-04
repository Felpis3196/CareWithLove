using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;
using System;
using System.Collections.Generic;

namespace CareWithLoveApp.Services
{
    public class CuidadorService : ICuidadorService
    {
        private readonly ICuidadorRepository _cuidadorRepository;

        public CuidadorService(ICuidadorRepository cuidadorRepository)
        {
            _cuidadorRepository = cuidadorRepository;
        }

        public Cuidador? ObterCuidadorPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do cuidador não pode ser vazio.", nameof(id));
            }

            return _cuidadorRepository.GetById(id);
        }

        public IEnumerable<Cuidador> ObterTodosCuidadores()
        {
            return _cuidadorRepository.GetAll();
        }

        public void CriarCuidador(Cuidador cuidador)
        {
            if (cuidador == null)
            {
                throw new ArgumentNullException(nameof(cuidador), "O cuidador não pode ser nulo.");
            }


            _cuidadorRepository.Add(cuidador);
        }

        public void AtualizarCuidador(Cuidador cuidador)
        {
            if (cuidador == null)
            {
                throw new ArgumentNullException(nameof(cuidador), "O cuidador não pode ser nulo.");
            }

            _cuidadorRepository.Update(cuidador);
        }

        public void ExcluirCuidador(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do cuidador não pode ser vazio.", nameof(id));
            }

            _cuidadorRepository.Delete(id);
        }

        public void AdicionarCuidador(Cuidador cuidador)
        {
            if (cuidador == null)
            {
                throw new ArgumentNullException(nameof(cuidador), "O cuidador não pode ser nulo.");
            }

            _cuidadorRepository.Add(cuidador);
        }
    }
}
