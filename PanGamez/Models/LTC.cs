using System;
using System.Collections.Generic;

namespace PanGamez.Models
{
    public partial class Ltc
    {
        public short Idltc { get; set; }
        public short Idproducto { get; set; }
        public int Periodo { get; set; }
        public int Unidades { get; set; }
        public int PeridodosMantenidos { get; set; }
        public decimal CostoMantenimiento { get; set; }
        public decimal CostoMantenimientoAcumulado { get; set; }

        public virtual Producto IdproductoNavigation { get; set; } = null!;
    }
}
