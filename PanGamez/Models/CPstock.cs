namespace PanGamez.Models
{
    public class CPstock
    {
        
        //Valor en Inventario (D)
        public int Demanda { get; set; }
        //Valor en T
        public int TiempoReposicion { get; set; }
        //Valor en SS
        public int InventarioSeguridad { get; set; }
    }
}
