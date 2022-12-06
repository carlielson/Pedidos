using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Pedidos;

namespace Pedidos.Repository.Context
{
    public class PedidosContext : DbContext
    {
        public PedidosContext(DbContextOptions<PedidosContext> options)
          : base(options)
        { }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Produto>().HasData(                
        //        new Produto(1, "Arroz", 10m),
        //        new Produto(2, "Feijão", 20m),
        //        new Produto(3, "Macarrão", 12m),
        //        new Produto(4, "Tapioca", 50m)
        //    );
        //}
    }
}
