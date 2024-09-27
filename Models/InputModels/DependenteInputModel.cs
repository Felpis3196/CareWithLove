using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.InputModels
{
    public class DependenteInputModel
    {
        public Guid DependenteId { get; set; }
        [Required(ErrorMessage = "O nome do dependente é obrigatório")]
        public string DependenteNome { get; set; }
        [Required(ErrorMessage = "A idade do dependente é obrigatória")]
        public int? DependenteIdade { get; set; }
        [Required(ErrorMessage = "O endereço do dependente é obrigatório")]
        public string DependenteEndereco { get; set; }
        [Required(ErrorMessage = "Por favor assinale o campo obrigatório!")]
        public bool? Insulina { get; set; }
        [Required(ErrorMessage = "Por favor telefone de emergênicia obrigatório")]
        public string TelefoneEmergencia { get; set; }
        public string Cuidados { get; set; }

        // Relacionamento com Usuario
        public Guid? UsuarioId { get; set; }
    }
}
