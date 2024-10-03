using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Services
{
    public interface IAvaliacaoService
    {
        Avaliacao? ObterAvaliacaoPorId(Guid id);
        IEnumerable<Avaliacao> ObterTodasAvaliacoes();
        void CriarAvaliacao(Avaliacao avaliacao);
        void ExcluirAvaliacao(Guid id);
        void AdicionarAvaliacao(Avaliacao avaliacao);
    }
}
