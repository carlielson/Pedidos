using Pedidos.Domain.Pedidos;

namespace Pedidos.Domain.Interfaces
{
    public interface IItemPedidoRepository
    {
        public IEnumerable<ItemPedido> GetAll();
        public bool Create(ItemPedido item);
        public bool Delete(int id);
        public bool Update(ItemPedido item);
        public ItemPedido GetById(int id);
        public IEnumerable<ItemPedido> GetByIdProduto(int idProduto);
        public IEnumerable<ItemPedido> GetByIdPedido(int idPedido);
    }
}
