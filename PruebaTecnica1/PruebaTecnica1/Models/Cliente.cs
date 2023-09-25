using System;
using System.Collections.Generic;

namespace PruebaTecnica1.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public DateTime? Fechacreado { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
