namespace PanGamez.Models
{
    public class CostoMantenimiento
    {
        public double HorasTrabajo { get; set; }
        public double Mtbf { get; set; }
        public int NumeroFallas { get; set; }
        public double DuracionTarea { get; set; }
        public double CostoHoraTrabajo { get; set; }
        public double Repuestos { get; set; }
        public double TareasAdicionales { get; set; }
        public double RetrasoLogistico { get; set; }
        public double CostoUnitarioParada { get; set; }
        public double CostoFallaUnica { get; set; }
    }
}
