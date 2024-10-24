﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CareWithLoveApp.Models.ViewModels
{
    public class DependenteViewModel
    {
        [Display(Name = "Código do Dependente")]
        public String DependenteId { get; set; }

        [Display(Name = "Nome do Dependente")]
        public string DependenteNome { get; set; }

        [Display(Name = "Idade do Dependente")]
        public int? DependenteIdade { get; set; }

        [Display(Name = "Endereço do Dependente")]
        public string DependenteEndereco { get; set; }

        [Display(Name = "Usa Insulina?")]
        public bool? Insulina { get; set; }

        [Display(Name = "Telefone de Emergência")]
        public string TelefoneEmergencia { get; set; }

        [Display(Name = "Cuidados Necessários")]
        public string Cuidados { get; set; }

        [Display(Name = "Nome do Usuário")]
        public string UsuarioNome { get; set; }

        // Relacionamento com ServicoClientes
        [Display(Name = "Serviços dos Clientes")]
        public ICollection<ServicoClienteViewModel> ServicosClientes { get; set; }
    }
}
