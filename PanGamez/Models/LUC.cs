using System;
using System.Collections.Generic;

namespace PanGamez.Models
{
    public partial class Luc
    {
        public short Idluc { get; set; }
        public short Idproducto { get; set; }
        public int RequerimientoBruto { get; set; }
        public int Periodo { get; set; }
        public decimal CostoMantenimiento { get; set; }
        public decimal CostoDeOrdenar { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal CostoTotalU { get; set; }

        public virtual Producto IdproductoNavigation { get; set; } = null!;
    }
}
