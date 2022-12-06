namespace Pedidos.Model
{
    public class ItemPedidoModel
    {
        public int? Id { get; set; }
        public int? IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
