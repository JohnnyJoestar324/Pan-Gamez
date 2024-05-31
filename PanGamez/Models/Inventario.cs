using System;
using System.Collections.Generic;

namespace PanGamez.Models
{
    public partial class Inventario
    {
        public short Idinventario { get; set; }
        public short Idmateriales { get; set; }
        public int Cantidad { get; set; }

        public virtual Materiale IdmaterialesNavigation { get; set; } = null!;
    }
}
