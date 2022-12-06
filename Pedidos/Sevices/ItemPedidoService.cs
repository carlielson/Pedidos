using Pedidos.Model;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Pedidos;

namespace Pedidos.Sevices
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepository _itemPedidoRepository;
        public ItemPedidoService(IItemPedidoRepository itemPedidoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
        }
        public bool Create(ItemPedidoModel item)
        {
            var itemPedido = new ItemPedido 
            { 
                IdPedido = item.IdPedido.Value,
                IdProduto = item.IdProduto,
                Quantidade = item.Quantidade,
            };

            return _itemPedidoRepository.Create(itemPedido);
        }

        public bool Update(ItemPedidoModel item)
        {
            var itemPedido = new ItemPedido
            {
                Id =  item.Id.Value,
                IdPedido = item.IdPedido.Value,
                IdProduto = item.IdProduto,
                Quantidade = item.Quantidade,
            };

            return _itemPedidoRepository.Update(itemPedido);
        }
    }
}
