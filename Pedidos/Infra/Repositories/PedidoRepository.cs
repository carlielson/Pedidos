using Pedidos.Domain.Pedidos;
using Pedidos.Domain.Interfaces;
using Pedidos.Repository.Context;

namespace Pedidos.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        public PedidosContext _pedidosContext;
        public PedidoRepository(PedidosContext pedidosContext)
        {
            _pedidosContext = pedidosContext;
        }
        public Pedido Create(Pedido item)
        {
            _pedidosContext.Pedidos.Add(item);
            _pedidosContext.SaveChanges();
            return item;
        }

        public bool Delete(int id)
        {
            var pedido = _pedidosContext.Pedidos.FirstOrDefault(x => x.Id == id);
            if (pedido != null)
            {
                _pedidosContext.Pedidos.Remove(pedido);
                _pedidosContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Pedido> GetByEmail(string email)
        {
            return _pedidosContext.Pedidos.Where(x => x.EmailCliente == email);
        }

        public Pedido GetById(int id)
        {
            return _pedidosContext.Pedidos.FirstOrDefault(x=> x.Id == id);
        }

        public bool Update(Pedido item)
        {
            var pedido = _pedidosContext.Pedidos.FirstOrDefault(x => x.Id == item.Id);
            if (pedido != null)
            {
                pedido.Pago = item.Pago;
                pedido.EmailCliente = item.EmailCliente;
                pedido.NomeCliente = item.NomeCliente;
                _pedidosContext.Pedidos.Update(pedido);
                _pedidosContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Pedido> GetAll()
        {
            return _pedidosContext.Pedidos;
        }
    }
}
