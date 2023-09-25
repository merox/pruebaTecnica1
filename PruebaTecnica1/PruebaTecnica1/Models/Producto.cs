using System;
using System.Collections.Generic;

namespace PruebaTecnica1.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int Id { get; set; }
        public int Idcategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public byte[]? Imagen { get; set; }
        public decimal Precioventa { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? Fechacreacion { get; set; }
        public DateTime? Fechaactuailizacion { get; set; }

        public virtual Categoria IdcategoriaNavigation { get; set; } = null!;
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
