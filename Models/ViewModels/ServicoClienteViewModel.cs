using System;
using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.ViewModels
{
    public class ServicoClienteViewModel
    {
        [Display(Name = "Código do Serviço do Cliente")]
        public String ServicoClienteId { get; set; }

        [Display(Name = "Descrição do Serviço")]
        public string Descricao { get; set; }

        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data de Término")]
        public DateTime DataTermino { get; set; }

        [Display(Name = "Local do Serviço")]
        public string Local { get; set; }

        // Relacionamento com Dependente
        [Display(Name = "Código do Dependente")]
        public String? DependenteId { get; set; }

        [Display(Name = "Nome do Dependente")]
        public string DependenteNome { get; set; }
    }
}
