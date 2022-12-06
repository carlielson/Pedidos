using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Domain.Pedidos
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        [ForeignKey("IdProduto")]
        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
