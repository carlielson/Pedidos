using Pedidos.Domain.Pedidos;

namespace Pedidos.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        public IEnumerable<Produto> GetAll();
        public bool Create(Produto item);
        public bool Delete(int id);
        public bool Update(Produto item);
    }
}
