namespace PruebaTecnica1.Models.DTO
{
    public class ProductosXPedidoDTO
    {
        public int Id { get; set; }
        public String Nombre { get; set; } = "";
        public String Categoria { get; set; } = "";
        public int CantidadPedidos { get; set; } = 0;
    }
}
