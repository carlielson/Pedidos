﻿namespace Pedidos.DTO
{
    public class ItensPedidoDTO
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public string? NomeProduto { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
