using System;
using System.Collections.Generic;

namespace PanGamez.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public short Idcategoria { get; set; }
        public string NombreCategoria { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
