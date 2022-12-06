namespace Pedidos.DTO
{
    public class PedidoDTO
    {
        public PedidoDTO()
        {
            ItensPedidos = new List<ItensPedidoDTO>();
        }
        public int Id { get; set; }
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }
        public bool Pago { get; set; }
        public decimal ValorTotal { get; set; }

        public List<ItensPedidoDTO> ItensPedidos { get; set; }
    }
}
