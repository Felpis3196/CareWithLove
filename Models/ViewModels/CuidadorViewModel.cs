using CareWithLoveApp.Models.ViewModels;
using CareWithLoveApp.Models.Entities;
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

        [Display(Name = "Nome do Cuidador")]
        public string? CuidadorNome { get; set; }

        // Lista de serviços oferecidos (opcional, dependendo do contexto)
        [Display(Name = "Serviços Oferecidos")]
        public List<ServicoCuidadorViewModel>? ServicosCuidador { get; set; }
        public string? UsuarioId { get; set; }
        public User Usuario { get; set; }
    }
}
