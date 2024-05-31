using System;
using System.Collections.Generic;

namespace PanGamez.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Cpfijos = new HashSet<Cpfijo>();
            Cpstocks = new HashSet<Cpstock>();
            Eoqs = new HashSet<Eoq>();
            Ltcs = new HashSet<Ltc>();
            Lucs = new HashSet<Luc>();
            Materiales = new HashSet<Materiale>();
        }

        public short Idproducto { get; set; }
        public string Nombre { get; set; } = null!;
        public short Idcategoria { get; set; }

        public virtual Categorium IdcategoriaNavigation { get; set; } = null!;
        public virtual ICollection<Cpfijo> Cpfijos { get; set; }
        public virtual ICollection<Cpstock> Cpstocks { get; set; }
        public virtual ICollection<Eoq> Eoqs { get; set; }
        public virtual ICollection<Ltc> Ltcs { get; set; }
        public virtual ICollection<Luc> Lucs { get; set; }
        public virtual ICollection<Materiale> Materiales { get; set; }
    }
}
