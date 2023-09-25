using System;
using System.Collections.Generic;

namespace PruebaTecnica1.Models
{
    public partial class DetallesPedido
    {
        public int Id { get; set; }
        public int? Idpedido { get; set; }
        public int Idproducto { get; set; }
        public decimal? Valor { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Valortotal { get; set; }

        public virtual Pedido? IdpedidoNavigation { get; set; }
        public virtual Producto IdproductoNavigation { get; set; } = null!;
    }
}
