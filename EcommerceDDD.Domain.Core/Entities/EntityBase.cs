using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceDDD.Domain.Core.Entities
{
    public class EntityBase
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        [Required]
        public virtual Usuario UsuarioCriacao { get; set; }

        public virtual Usuario UsuarioAlteracao { get; set; }
        public virtual Usuario UsuarioExclusao { get; set; }
    }
}