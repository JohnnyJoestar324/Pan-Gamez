using System;
using System.Collections.Generic;

namespace PanGamez.Models
{
    public partial class Maquina
    {
        public Maquina()
        {
            MantenimientoCorrectivos = new HashSet<MantenimientoCorrectivo>();
        }

        public short Idequipo { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<MantenimientoCorrectivo> MantenimientoCorrectivos { get; set; }
    }
}
