using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;
using System;
using System.Collections.Generic;

namespace CareWithLoveApp.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public Avaliacao? ObterAvaliacaoPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID da avaliação não pode ser vazio.", nameof(id));
            }

            return _avaliacaoRepository.GetById(id);
        }

        public IEnumerable<Avaliacao> ObterTodasAvaliacoes()
        {
            return _avaliacaoRepository.GetAll();
        }

        public void CriarAvaliacao(Avaliacao avaliacao)
        {
            if (avaliacao == null)
            {
                throw new ArgumentNullException(nameof(avaliacao), "A avaliação não pode ser nula.");
            }

            // Adicione qualquer lógica de validação adicional aqui, se necessário

            _avaliacaoRepository.Add(avaliacao);
        }

        public void ExcluirAvaliacao(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID da avaliação não pode ser vazio.", nameof(id));
            }

            _avaliacaoRepository.Delete(id);
        }

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            if (avaliacao == null)
            {
                throw new ArgumentNullException(nameof(avaliacao), "A avaliação não pode ser nula.");
            }

            _avaliacaoRepository.Add(avaliacao);
        }
    }
}
