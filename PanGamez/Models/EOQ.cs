using System;
using System.Collections.Generic;

namespace PanGamez.Models
{
    public partial class Eoq
    {
        public short Ideoq { get; set; }
        public short Idproducto { get; set; }
        public int Demanda { get; set; }
        public decimal CostoPedido { get; set; }
        public decimal CostoMantenimiento { get; set; }
        public int PeriodoSeleccionado { get; set; }

        public virtual Producto IdproductoNavigation { get; set; } = null!;
    }
}
