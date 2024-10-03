using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;

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
            return _avaliacaoRepository.GetById(id);
        }
        public IEnumerable<Avaliacao> ObterTodasAvaliacoes()
        {
            return _avaliacaoRepository.GetAll();
        }
        public void CriarAvaliacao(Avaliacao avaliacao)
        {
            _avaliacaoRepository.Add(avaliacao);
        }
        public void ExcluirAvaliacao(Guid id)
        {
            _avaliacaoRepository.Delete(id);
        }
        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            _avaliacaoRepository.Add(avaliacao);
        }
    }
}
