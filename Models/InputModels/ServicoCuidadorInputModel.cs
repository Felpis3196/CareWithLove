using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.InputModel
{
    public class ServicoCuidadorInputModel
    {
        [Required(ErrorMessage = "O ID do serviço do cuidador é obrigatório.")]
        public Guid ServicoCuidadorId { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        [Display(Name = "Descrição do Serviço")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de término é obrigatória.")]
        [Display(Name = "Data de Término")]
        public DateTime DataTermino { get; set; }

        [Required(ErrorMessage = "A preferência é obrigatória.")]
        [StringLength(200, ErrorMessage = "A preferência deve ter no máximo 200 caracteres.")]
        [Display(Name = "Preferência do Serviço")]
        public string Preferencia { get; set; }

        // Id do Cuidador associado (relacionamento muitos-para-um)
        [Required(ErrorMessage = "O cuidador é obrigatório.")]
        [Display(Name = "Cuidador")]
        public Guid? CuidadorId { get; set; }
    }
}
