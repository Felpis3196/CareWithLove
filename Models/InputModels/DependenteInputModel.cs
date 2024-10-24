using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.InputModels
{
    public class DependenteInputModel
    {
        [Required(ErrorMessage = "O ID do dependente é obrigatório.")]
        public String DependenteId { get; set; }

        [Required(ErrorMessage = "O nome do dependente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do dependente deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome do Dependente")]
        public string DependenteNome { get; set; }

        [Required(ErrorMessage = "A idade do dependente é obrigatória.")]
        [Range(0, 120, ErrorMessage = "A idade deve ser um número entre 0 e 120.")]
        [Display(Name = "Idade do Dependente")]
        public int? DependenteIdade { get; set; }

        [Required(ErrorMessage = "O endereço do dependente é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres.")]
        [Display(Name = "Endereço do Dependente")]
        public string DependenteEndereco { get; set; }

        [Required(ErrorMessage = "Por favor, assinale se o dependente necessita de insulina.")]
        [Display(Name = "Necessita de Insulina")]
        public bool? Insulina { get; set; }

        [Required(ErrorMessage = "O telefone de emergência é obrigatório.")]
        [Phone(ErrorMessage = "O número de telefone de emergência deve ser válido.")]
        [Display(Name = "Telefone de Emergência")]
        public string TelefoneEmergencia { get; set; }

        [StringLength(1000, ErrorMessage = "Os cuidados devem ter no máximo 1000 caracteres.")]
        [Display(Name = "Cuidados Especiais")]
        public string? Cuidados { get; set; }

        // Relacionamento com Usuario
        [Display(Name = "Usuário Responsável")]
        public String? UsuarioId { get; set; }
    }
}
