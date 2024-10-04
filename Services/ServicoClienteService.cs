using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;
using System;
using System.Collections.Generic;

namespace CareWithLoveApp.Services
{
    public class ServicoClienteService : IServicoClienteService
    {
        private readonly IServicoClienteRepository _servicoClienteRepository;

        public ServicoClienteService(IServicoClienteRepository servicoClienteRepository)
        {
            _servicoClienteRepository = servicoClienteRepository;
        }

        public ServicoCliente? ObterServicoClientePorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do serviço não pode ser vazio.", nameof(id));
            }

            return _servicoClienteRepository.GetById(id);
        }

        public IEnumerable<ServicoCliente> ObterTodosServicosClientes()
        {
            return _servicoClienteRepository.GetAll();
        }

        public void CriarServicoCliente(ServicoCliente servicoCliente)
        {
            if (servicoCliente == null)
            {
                throw new ArgumentNullException(nameof(servicoCliente), "O serviço não pode ser nulo.");
            }

            if (servicoCliente.DataInicio > servicoCliente.DataTermino)
            {
                throw new ArgumentException("Data de início não pode ser maior do que a data de término.");
            }

            _servicoClienteRepository.Add(servicoCliente);
        }

        public void AtualizarServicoCliente(ServicoCliente servicoCliente)
        {
            if (servicoCliente == null)
            {
                throw new ArgumentNullException(nameof(servicoCliente), "O serviço não pode ser nulo.");
            }

            _servicoClienteRepository.Update(servicoCliente);
        }

        public void ExcluirServicoCliente(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do serviço não pode ser vazio.", nameof(id));
            }

            _servicoClienteRepository.Delete(id);
        }

        public void AdicionarServicoCliente(ServicoCliente servicoCliente)
        {
            if (servicoCliente == null)
            {
                throw new ArgumentNullException(nameof(servicoCliente), "O serviço não pode ser nulo.");
            }

            _servicoClienteRepository.Add(servicoCliente);
        }
    }
}
