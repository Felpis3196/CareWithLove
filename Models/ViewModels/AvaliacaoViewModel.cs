﻿using CareWithLoveApp.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.ViewModels
{
    public class AvaliacaoViewModel
    {
        [Display(Name = "Código da Avaliação")]
        public String AvaliacaoId { get; set; }

        [Display(Name = "Nota")]
        public int Nota { get; set; }

        [Display(Name = "Comentário")]
        public string Review { get; set; }

        // Chave estrangeira e relacionamento com Usuario
        [Display(Name = "Código do Usuário")]
        public String UsuarioId { get; set; }

        [Display(Name = "Usuário")]
        public String UsuarioNome { get; set; }
    }
}
