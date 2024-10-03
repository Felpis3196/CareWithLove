using CareWithLoveApp.Models.Entities;

namespace CareWithLoveApp.Models.InputModels
{
    public class AvaliacaoInputModel
    {
        public Guid AvaliacaoId { get; set; }
        public int Nota { get; set; }
        public string Review { get; set; }

        // Chave estrangeira e relacionamento com Usuario
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
