using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;
using System;
using System.Collections.Generic;

namespace CareWithLoveApp.Services
{
    public class ServicoCuidadorService : IServicoCuidadorService
    {
        private readonly IServicoCuidadorRepository _servicoCuidadorRepository;

        public ServicoCuidadorService(IServicoCuidadorRepository servicoCuidadorRepository)
        {
            _servicoCuidadorRepository = servicoCuidadorRepository;
        }

        public ServicoCuidador? ObterServicoCuidadorPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do serviço cuidador não pode ser vazio.", nameof(id));
            }

            return _servicoCuidadorRepository.GetById(id);
        }

        public IEnumerable<ServicoCuidador> ObterTodosServicosCuidadores()
        {
            return _servicoCuidadorRepository.GetAll();
        }

        public void CriarServicoCuidador(ServicoCuidador servicoCuidador)
        {
            if (servicoCuidador == null)
            {
                throw new ArgumentNullException(nameof(servicoCuidador), "O serviço cuidador não pode ser nulo.");
            }

            if (servicoCuidador.DataInicio > servicoCuidador.DataTermino)
            {
                throw new ArgumentException("Data de início não pode ser maior do que a data de término.");
            }

            _servicoCuidadorRepository.Add(servicoCuidador);
        }

        public void AtualizarServicoCuidador(ServicoCuidador servicoCuidador)
        {
            if (servicoCuidador == null)
            {
                throw new ArgumentNullException(nameof(servicoCuidador), "O serviço cuidador não pode ser nulo.");
            }

            _servicoCuidadorRepository.Update(servicoCuidador);
        }

        public void ExcluirServicoCuidador(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do serviço cuidador não pode ser vazio.", nameof(id));
            }

            _servicoCuidadorRepository.Delete(id);
        }

        public void AdicionarServicoCuidador(ServicoCuidador servicoCuidador)
        {
            if (servicoCuidador == null)
            {
                throw new ArgumentNullException(nameof(servicoCuidador), "O serviço cuidador não pode ser nulo.");
            }

            _servicoCuidadorRepository.Add(servicoCuidador);
        }
    }
}
