using CareWithLoveApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.ViewModel
{
    public class CuidadorViewModel
    {
        [Display(Name = "Código do Cuidador")]
        public String CuidadorId { get; set; }

        [Display(Name = "CPF")]
        public string? CPF { get; set; }

        [Display(Name = "Experiência")]
        public string? Experiencia { get; set; }

        [Display(Name = "Valor por Hora")]
        public decimal? ValorHora { get; set; }

        [Display(Name = "Disponibilidade")]
        public string? Disponibilidade { get; set; }

        [Display(Name = "Especializações")]
        public string? Especializacoes { get; set; }

        // Detalhes do Usuario (se necessário)
        [Display(Name = "Código do Usuário")]
        public String? UsuarioId { get; set; }

        [Display(Name = "Nome do Usuário")]
        public string? UsuarioNome { get; set; }

        // Lista de serviços oferecidos (opcional, dependendo do contexto)
        [Display(Name = "Serviços Oferecidos")]
        public List<ServicoCuidadorViewModel>? ServicosCuidador { get; set; }
    }
}
