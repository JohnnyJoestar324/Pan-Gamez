using System;
using System.Collections.Generic;

namespace PanGamez.Models
{
    public partial class Cpfijo
    {
        public short Idcpfijo { get; set; }
        public short Idproducto { get; set; }
        public int Demanda { get; set; }
        public int InventarioPedido { get; set; }
        public int InventarioSeguridad { get; set; }

        public virtual Producto IdproductoNavigation { get; set; } = null!;
    }
}
