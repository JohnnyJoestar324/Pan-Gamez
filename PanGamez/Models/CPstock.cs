using System;
using System.Collections.Generic;

namespace PanGamez.Models
{
    public partial class Cpstock
    {
        public short Idcpstock { get; set; }
        public short Idproducto { get; set; }
        public int Demanda { get; set; }
        public int TiempoReposo { get; set; }
        public int InventarioSeguridad { get; set; }

        public virtual Producto IdproductoNavigation { get; set; } = null!;
    }
}
