using EcommerceDDD.Domain.Core.Entities.Enums;

namespace EcommerceDDD.Domain.Core.Entities
{
    public class Compra : EntityBase
    {
        public Produto Produto { get; set; }
        public int QtdCompra { get; set; }
        public TipoEstadoCompra Estado { get; set; }
    }
}