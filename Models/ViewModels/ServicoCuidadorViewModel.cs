using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.ViewModels
{
    public class ServicoCuidadorViewModel
    {
        [Display(Name = "Código do Serviço do Cuidador")]
        public Guid ServicoCuidadorId { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Data de Inicio")]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Data de Término")]
        public DateTime DataTermino { get; set; }
        [Display(Name = "Preferência")]
        public string Preferencia { get; set; }

        // Informações do cuidador (opcional)
        [Display(Name = "Código do Cuidador")]
        public Guid? CuidadorId { get; set; }
        [Display(Name = "Nome do Cuidador")]
        public string? CuidadorNome { get; set; } 
    }
}
