using Pedidos.Domain.Pedidos;
using Pedidos.DTO;
using Pedidos.Model;

namespace Pedidos.Sevices
{
    public interface IPedidoService
    {
        public PedidoDTO Create(PedidoModel item);
        public bool Update(PedidoModel item);
        public bool Delete(int idPedido);
        public Pedido GetById(int idPedido);
        PedidoDTO GetByIdPedido(int idPedido);
    }
}
