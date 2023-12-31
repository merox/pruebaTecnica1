﻿using System;
using System.Collections.Generic;

namespace PruebaTecnica1.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime? Fechacreado { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
