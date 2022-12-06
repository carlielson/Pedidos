using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Domain.Pedidos
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Pago { get; set; }

        [NotMapped]
        public List<ItemPedido>? Items { get; set; }
    }
}
