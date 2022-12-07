using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Pedidos;
using Pedidos.Domain.Interfaces;
using Pedidos.Repository.Context;

namespace Pedidos.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        public PedidosContext _pedidosContext;
        public ItemPedidoRepository(PedidosContext pedidosContext)
        {
            _pedidosContext = pedidosContext;
        }

        public bool Create(ItemPedido item)
        {
            _pedidosContext.ItensPedidos.Add(item);
            _pedidosContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var itemPedido = _pedidosContext.ItensPedidos.Where(x => x.IdPedido == id).ToList();
            if (itemPedido.Count > 0)
            {
                _pedidosContext.ItensPedidos.RemoveRange(itemPedido);
                _pedidosContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<ItemPedido> GetAll()
        {
           return _pedidosContext.ItensPedidos.Include(x=> x.Produto).ToList();
        }

        public ItemPedido GetById(int id)
        {
            return _pedidosContext.ItensPedidos.Include(x => x.Produto).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ItemPedido> GetByIdPedido(int idPedido)
        {
            return _pedidosContext.ItensPedidos.Include(x => x.Produto).Where(x => x.IdPedido == idPedido).ToList();
        }

        public IEnumerable<ItemPedido> GetByIdProduto(int idProduto)
        {
            return _pedidosContext.ItensPedidos.Include(x => x.Produto).Where(x=> x.IdProduto == idProduto).ToList();
        }

        public bool Update(ItemPedido item)
        {
            var itemPedido = _pedidosContext.ItensPedidos.FirstOrDefault(x => x.Id == item.Id);
            if (itemPedido != null)
            {
                itemPedido.IdPedido = item.IdPedido;
                itemPedido.IdProduto = item.IdProduto;
                itemPedido.Quantidade = item.Quantidade;
                _pedidosContext.ItensPedidos.Update(itemPedido);
                _pedidosContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
