namespace PruebaTecnica1.Models.DTO
{
    public class ProductosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precioventa { get; set; }
        public DateTime? Fechacreacion { get; set; }
        public String Nombrecategoria { get; set; } = "";
    }
}
