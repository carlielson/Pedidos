namespace Pedidos.Model
{
    public class PedidoModel
    {
        public int? Id { get; set; }
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }
        public bool Pago { get; set; }
        public List<ItemPedidoModel>? ItensPedido { get; set; }
    }
}
