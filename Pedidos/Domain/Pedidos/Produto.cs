using System.ComponentModel.DataAnnotations;

namespace Pedidos.Domain.Pedidos
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string? NomeProduto { get; set; }
        public decimal Valor { get; set; }
        // public List<ItemPedido> ItemPedidos { get; set; }

        public Produto()
        {

        }
        public Produto(int? id, string nomeProduto, decimal valor)
        {
            Id = id.Value;
            NomeProduto = nomeProduto;
            Valor = valor;

        }
    }
}
