using Pedidos.Domain.Pedidos;

namespace Pedidos.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        public Pedido Create(Pedido item);
        public bool Delete(int id);
        public bool Update(Pedido item);
        public Pedido GetById(int id);
        public IEnumerable<Pedido> GetByEmail(string email);
    }
}
