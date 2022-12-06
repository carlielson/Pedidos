using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Pedidos;
using Pedidos.Model;

namespace Pedidos.Sevices
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;

        }
        public bool Create(ProdutoModel item)
        {
            var produto = new Produto            
            {
                NomeProduto = item.NomeProduto,
                Valor = item.Valor
            };
            return _produtoRepository.Create(produto);
        }

        public bool Update(ProdutoModel item)
        {
            var produto = new Produto
            {
                Id = item.Id.Value,
                NomeProduto = item.NomeProduto,
                Valor = item.Valor
            };
            return _produtoRepository.Create(produto);
        }
    }
}
