using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;

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
            return _servicoCuidadorRepository.GetById(id);
        }
        public IEnumerable<ServicoCuidador> ObterTodosServicosCuidadores()
        {
            return _servicoCuidadorRepository.GetAll();
        }
        public void CriarServicoCuidador(ServicoCuidador servicoCuidador)
        {
            _servicoCuidadorRepository.Add(servicoCuidador);
        }
        public void AtualizarServicoCuidador(ServicoCuidador servicoCuidador)
        {
            _servicoCuidadorRepository.Update(servicoCuidador);
        }
        public void ExcluirServicoCuidador(Guid id)
        {
            _servicoCuidadorRepository.Delete(id);
        }
        public void AdicionarServicoCuidador(ServicoCuidador servicoCuidador)
        {
            _servicoCuidadorRepository.Add(servicoCuidador);
        }
        
        
    }
}
