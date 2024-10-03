using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;

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
            return _cuidadorRepository.GetById(id);
        }
        public IEnumerable<Cuidador> ObterTodosCuidadores()
        {
            return _cuidadorRepository.GetAll();
        }
        public void CriarCuidador(Cuidador cuidador)
        {
            _cuidadorRepository.Add(cuidador);
        }
        public void AtualizarCuidador(Cuidador cuidador)
        {
            _cuidadorRepository.Update(cuidador);
        }
        public void ExcluirCuidador(Guid id)
        {
            _cuidadorRepository.Delete(id);
        }
        public void AdicionarCuidador(Cuidador cuidador)
        {
            _cuidadorRepository.Add(cuidador);
        }
    }
}
