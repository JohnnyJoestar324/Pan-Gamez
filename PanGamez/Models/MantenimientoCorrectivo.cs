using System;
using System.Collections.Generic;

namespace PanGamez.Models
{
    public partial class MantenimientoCorrectivo
    {
        public short Idmantenimiento { get; set; }
        public short Idequipo { get; set; }
        public int HorasTrabajo { get; set; }
        public double Mtbf { get; set; }
        public int NumeroFallas { get; set; }
        public int DuracionTarea { get; set; }
        public decimal CostoHoraTrabajo { get; set; }
        public decimal Repuestos { get; set; }
        public decimal TareasAdicionales { get; set; }
        public int? RetrasoLogistico { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoFallaUnica { get; set; }

        public virtual Maquina IdequipoNavigation { get; set; } = null!;
    }
}
