namespace PruebaTecnica1.Models.DTO
{
    public class PedidosDTO
    {
        public Pedido pedido { get; set; }
        public List<DetallesPedido> lsDetalle { get; set; } = new List<DetallesPedido>();
    }
}
