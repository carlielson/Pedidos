using Pedidos.Domain.Pedidos;
using Pedidos.Domain.Interfaces;
using Pedidos.Repository.Context;

namespace Pedidos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public PedidosContext _pedidosContext;

        public ProdutoRepository(PedidosContext pedidosContext)
        {
            _pedidosContext = pedidosContext;            
        }
        public bool Create(Produto item)
        {
            _pedidosContext.Produtos.Add(item);
            _pedidosContext.SaveChanges();

            var produtos = _pedidosContext.Produtos.ToList();
            return true;
        }

        public bool Delete(int id)
        {
            var produto = _pedidosContext.Produtos.FirstOrDefault(x=> x.Id == id);
            if (produto == null) {
                _pedidosContext.Produtos.Remove(produto);
                _pedidosContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _pedidosContext.Produtos.ToList();
        }

        public bool Update(Produto item)
        {
            var produto = _pedidosContext.Produtos.FirstOrDefault(x => x.Id == item.Id);
            if (produto == null)
            {
                produto.Valor = item.Valor;
                produto.NomeProduto = item.NomeProduto;
                _pedidosContext.Produtos.Update(produto);
                _pedidosContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
