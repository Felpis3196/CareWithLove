using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Services
{
    public interface IServicoCuidadorService
    {
        Dependente? ObterServicoCuidadorPorId(Guid id);
        IEnumerable<ServicoCuidador> ObterTodosServicosCuidadores();
        void CriarServicoCuidador(ServicoCuidador servicoCuidador);
        void AtualizarServicoCuidador(ServicoCuidador servicoCuidador);
        void ExcluirServicoCuidador(Guid id);
        void AdicionarServicoCuidador(ServicoCuidador servicoCuidador);
    }
}
