using Pedidos.Model;

namespace Pedidos.Sevices
{
    public interface IProdutoService
    {
        public bool Create(ProdutoModel item);
        public bool Update(ProdutoModel item);
    }
}
