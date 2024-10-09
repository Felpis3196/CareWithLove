﻿using Microsoft.AspNetCore.Identity;

namespace CareWithLoveApp.Models.Entities
{
    public class User : IdentityUser
    {
        public Guid UsuarioId { get; set; }
        public string? UsuarioNome { get; set; }
        public string? UsuarioSexo { get; set; }
        public string? UsuarioTelefone { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string? UsuarioLogradouro { get; set; }

        // Definir o tipo de usuário (Cuidador ou Responsável por Dependentes)
        public string? UsuarioTipo { get; set; } // "Cuidador" ou "Responsável"

    }
}