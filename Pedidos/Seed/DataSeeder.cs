using Pedidos.Domain.Pedidos;
using Pedidos.Repository.Context;

namespace Pedidos.Seed
{
    public class DataSeeder
    {
        private readonly PedidosContext _pedidosContext;

        public DataSeeder(PedidosContext pedidosContext)
        {
            _pedidosContext = pedidosContext;
        }

        public void Seed()
        {
            var produtos = new List<Produto>()
                {
                    new Produto
                    {
                        NomeProduto="Arroz",
                        Valor = 15m
                    },
                    new Produto
                    {
                        NomeProduto="Feijão",
                        Valor = 10m
                    },
                    new Produto
                    {
                        NomeProduto="Macarrão",
                        Valor = 15m
                    },
                    new Produto
                    {
                        NomeProduto="Ervilha",
                        Valor = 3.5m
                    },
                };

                _pedidosContext.AddRange(produtos);
                _pedidosContext.SaveChanges();
            
        }
    }
}
