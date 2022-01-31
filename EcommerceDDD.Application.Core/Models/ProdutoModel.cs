using EcommerceDDD.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcommerceDDD.Application.Core.Models
{
    public class ProdutoModel : ModelBase
    {
        [Required, MaxLength(200), Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Qtd Estoque")]
        public int QtdEstoque { get; set; }

        public ProdutoModel(Produto produto) : base(produto)
        {
            Descricao = produto.Descricao;
            Valor = produto.Valor;
            Estado = produto.Estado;
            Observacao = produto.Observacao;
            QtdEstoque = produto.QtdEstoque;
        }

        public Produto ToEntity()
        {
            return new Produto
            {
                Id = Id,
                Descricao = Descricao,
                Estado = Estado,
                Observacao = Observacao,
                QtdEstoque = QtdEstoque,
                Valor = Valor
            };
        }
    }
}