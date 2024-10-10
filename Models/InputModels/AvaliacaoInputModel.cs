using CareWithLoveApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.InputModels
{
    public class AvaliacaoInputModel
    {
        [Required]
        [Range(1, 5, ErrorMessage = "Nota deve ser entre 1 e 5.")]
        public int Nota { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "O review não pode ter mais de 500 caracteres.")]
        public string Review { get; set; }
        [Required]
        public Guid UsuarioId { get; set; }
        public User? Usuario { get; set; }
    }
}
