namespace CareWithLoveApp.Models.Entities
{
    public class Avaliacao
    {
        public Guid AvaliacaoId { get; set; }
        public int Nota {  get; set; }
        public string Review { get; set; }

        // Chave estrangeira e relacionamento com Usuario
        public Guid UsuarioId { get; set; }
        public User Usuario { get; set; }
    }
}
