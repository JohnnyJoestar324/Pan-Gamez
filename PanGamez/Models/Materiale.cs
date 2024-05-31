using System;
using System.Collections.Generic;

namespace PanGamez.Models
{
    public partial class Materiale
    {
        public Materiale()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public short Idmateriales { get; set; }
        public short Idproducto { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual Producto IdproductoNavigation { get; set; } = null!;
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
