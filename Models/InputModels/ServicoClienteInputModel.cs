using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.InputModels
{
    public class ServicoClienteInputModel
    {
        [Required(ErrorMessage = "O ID do serviço é obrigatório.")]
        public String ServicoClienteId { get; set; }

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

        [Required(ErrorMessage = "O local é obrigatório.")]
        [StringLength(200, ErrorMessage = "O local deve ter no máximo 200 caracteres.")]
        [Display(Name = "Local do Serviço")]
        public string Local { get; set; }

        // Relacionamento com Dependente
        [Required(ErrorMessage = "O dependente é obrigatório.")]
        [Display(Name = "Dependente")]
        public String? DependenteId { get; set; }
    }
}
