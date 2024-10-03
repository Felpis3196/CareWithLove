using CareWithLoveApp.Data;
using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Models.InputModels;
using CareWithLoveApp.Models.ViewModels;
using CareWithLoveApp.Repositories;
using CareWithLoveApp.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareWithLoveApp.Models.InputModels
{
    public class CuidadorInputModel
    {
        public Guid CuidadorId { get; set; }
        public string? CPF { get; set; }
        public string? Experiencia { get; set; }
        public decimal? ValorHora { get; set; }
        public string? Disponibilidade { get; set; }
        public string? Especializacoes { get; set; }

        // Relacionamento um-para-um com Usuario
        public Guid? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        // Relacionamento de um-para-muitos com ServicoCuidador
        public ICollection<ServicoCuidador>? ServicosCuidador { get; set; }
    }
}
