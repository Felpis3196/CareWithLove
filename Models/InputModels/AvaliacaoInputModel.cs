using CareWithLoveApp.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareWithLoveApp.Models.InputModels
{
    public class AvaliacaoInputModel
    {
        [Required]
        public String AvaliacaoId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Nota deve ser entre 1 e 5.")]
        public int Nota { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "O review não pode ter mais de 500 caracteres.")]
        public string Review { get; set; }
        [Required]
        [ForeignKey("Id")]
        public String UsuarioId { get; set; }
        public User? Usuario { get; set; }
    }
}
