using System;
using System.Collections.Generic;

namespace PruebaTecnica1.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Idcliente { get; set; }
        public decimal Total { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; } = null!;
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
