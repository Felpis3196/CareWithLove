using CareWithLoveApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.InputModels
{
    public class CuidadorInputModel
    {
        [Required(ErrorMessage = "O campo 'CuidadorId' é obrigatório.")]
        public Guid CuidadorId { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        [Display(Name = "CPF")]
        public string? CPF { get; set; }

        [Required(ErrorMessage = "A experiência é obrigatória.")]
        [StringLength(1000, ErrorMessage = "A experiência deve ter no máximo 1000 caracteres.")]
        [Display(Name = "Experiência")]
        public string? Experiencia { get; set; }

        [Required(ErrorMessage = "O valor por hora é obrigatório.")]
        [Range(0.01, 1000.00, ErrorMessage = "O valor por hora deve estar entre 0,01 e 1000.")]
        [Display(Name = "Valor por Hora")]
        public decimal? ValorHora { get; set; }

        [Required(ErrorMessage = "A disponibilidade é obrigatória.")]
        [Display(Name = "Disponibilidade")]
        public string? Disponibilidade { get; set; }

        [Required(ErrorMessage = "As especializações são obrigatórias.")]
        [StringLength(500, ErrorMessage = "As especializações devem ter no máximo 500 caracteres.")]
        [Display(Name = "Especializações")]
        public string? Especializacoes { get; set; }

        // Relacionamento um-para-um com Usuario
        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [Display(Name = "Usuário")]
        public Guid? UsuarioId { get; set; }

        public User? Usuario { get; set; }

        // Relacionamento de um-para-muitos com ServicoCuidador
        public ICollection<ServicoCuidador>? ServicosCuidador { get; set; }
    }
}
