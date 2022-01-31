using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceDDD.Domain.Core.Entities
{
    public class Produto : EntityBase
    {
        [Required, MaxLength(200)]
        public string Descricao { get; set; }

        public decimal Valor { get; set; }
        public bool Estado { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Observacao { get; set; }

        public int QtdEstoque { get; set; }
    }
}