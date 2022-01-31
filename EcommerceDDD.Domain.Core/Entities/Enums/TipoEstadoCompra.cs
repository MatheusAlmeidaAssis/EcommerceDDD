using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDDD.Domain.Core.Entities.Enums
{
    public enum TipoEstadoCompra
    {
        Carrinho =1,
        Comprado = 2,
        Preparacao =3,
        Caminho = 4,
        Entregue = 5,
        Recebido = 6,
        Cancelado = 7
    }
}
