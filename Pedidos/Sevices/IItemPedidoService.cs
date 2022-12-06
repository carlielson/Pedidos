using Pedidos.Model;

namespace Pedidos.Sevices
{
    public interface IItemPedidoService
    {
        public bool Create(ItemPedidoModel item);
        public bool Update(ItemPedidoModel item);
    }
}
