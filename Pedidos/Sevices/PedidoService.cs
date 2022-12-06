using AutoMapper;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Pedidos;
using Pedidos.DTO;
using Pedidos.Model;

namespace Pedidos.Sevices
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _itemPedidoRepository = itemPedidoRepository;
        }
        public PedidoDTO Create(PedidoModel item)
        {
            var pedido = new Pedido { 
                EmailCliente = item.EmailCliente,
                NomeCliente = item.NomeCliente,
                Pago = item.Pago,    
                DataCriacao = DateTime.Now,
            };
            var pedidoDb = _pedidoRepository.Create(pedido);
           
            
            foreach (var it in item.ItensPedido)
            {
                var itemPedido = new ItemPedido
                {
                    IdPedido = pedido.Id,
                    IdProduto = it.IdProduto,
                    Quantidade = it.Quantidade,
                };
                _itemPedidoRepository.Create(itemPedido);
                    
            }                
           return GetByIdPedido(pedido.Id);
        }

        public bool Delete(int idPedido)
        {
            _pedidoRepository.Delete(idPedido);
            _itemPedidoRepository.Delete(idPedido);

            return true;
        }

        public Pedido GetById(int idPedido)
        {
            var pedido = _pedidoRepository.GetById(idPedido);
            pedido.Items = _itemPedidoRepository.GetByIdPedido(idPedido).ToList();
            return pedido;
        }

        public PedidoDTO GetByIdPedido(int idPedido)
        {
            var pedido = _pedidoRepository.GetById(idPedido);
            pedido.Items = _itemPedidoRepository.GetByIdPedido(idPedido).ToList();
            var pedidoDTO = new PedidoDTO {
                Id = pedido.Id,
                EmailCliente = pedido.EmailCliente,
                NomeCliente = pedido.NomeCliente,
                Pago = pedido.Pago,
                ValorTotal = pedido.Items.Sum(x => x.Quantidade * x.Produto.Valor)

            };

            foreach (var item in pedido.Items)
            {
                pedidoDTO.ItensPedidos.Add(new ItensPedidoDTO
                {
                    Id = item.Id,
                    IdPedido = item.IdPedido,
                    IdProduto = item.IdProduto,
                    Quantidade = item.Quantidade,
                    NomeProduto = item.Produto.NomeProduto,
                    ValorUnitario = item.Produto.Valor
                });
            }

            return pedidoDTO;
        }

        public bool Update(PedidoModel item)
        {
            var pedido = new Pedido
            {
                Id = item.Id.Value,
                EmailCliente = item.EmailCliente,
                NomeCliente = item.NomeCliente,
                Pago = item.Pago,
            };

            if (_pedidoRepository.Update(pedido))
            {
                foreach (var it in item.ItensPedido)
                {
                    var itemPedido = new ItemPedido
                    {
                        Id = it.Id.Value,
                        IdPedido = pedido.Id,
                        IdProduto = it.IdProduto,
                        Quantidade = it.Quantidade,
                    };
                    _itemPedidoRepository.Update(itemPedido);
                }
                return true;

            }
            return false;
        }
    }
}
