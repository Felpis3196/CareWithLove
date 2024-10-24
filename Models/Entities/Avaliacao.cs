using System.ComponentModel.DataAnnotations.Schema;

namespace CareWithLoveApp.Models.Entities
{
    public class Avaliacao
    {
        public String AvaliacaoId { get; set; }
        public int Nota {  get; set; }
        public string Review { get; set; }
        public String UsuarioId { get; set; }
        public User Usuario { get; set; }
    }
}
