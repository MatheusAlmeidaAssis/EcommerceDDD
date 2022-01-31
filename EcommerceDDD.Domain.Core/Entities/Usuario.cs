using EcommerceDDD.Domain.Core.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceDDD.Domain.Core.Entities
{
    public class Usuario : IdentityUser<string>
    {
        [Required, MaxLength(50)]
        public string Cpf { get; set; }

        public int Idade { get; set; }

        [Required, MaxLength(255)]
        public string Nome { get; set; }

        [Required, MaxLength(15)]
        public string Cep { get; set; }

        [Required, MaxLength(255)]
        public string Logradouro { get; set; }

        [MaxLength(255)]
        public string Complemento { get; set; }

        [MaxLength(20)]
        public string TelefoneFixo { get; set; }

        [MaxLength(20)]
        public string Celular { get; set; }

        public bool Estado { get; set; }
        public TipoUsuario? Tipo { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        [Required]
        public virtual IdentityUser UsuarioCriacao { get; set; }

        public virtual IdentityUser UsuarioAlteracao { get; set; }
        public virtual IdentityUser UsuarioExclusao { get; set; }
    }
}