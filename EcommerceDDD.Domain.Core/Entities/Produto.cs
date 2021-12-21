namespace EcommerceDDD.Domain.Core.Entities
{
    public class Produto : EntityBase
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Estado { get; set; }
    }
}