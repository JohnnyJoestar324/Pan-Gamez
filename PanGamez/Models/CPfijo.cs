namespace PanGamez.Models
{
    public class CPfijo
    {
        public int InventarioPromedio { get; set; }

        public int VolumenOptimoDePedido { get; set; }

        public int StockDeSeguridad { get; set; }

        public int CalculoCP(int QQ, int SS)
        {
            //Primer plateamiento   
            VolumenOptimoDePedido = QQ;
            StockDeSeguridad = SS;

            var resultado = (QQ / 2) + SS;
            return resultado;


        }
        public int Rotacion(int IP)
        {
            InventarioPromedio = IP;
            if (InventarioPromedio > 0)
            {
                return InventarioPromedio / 2;
            }
            else { return InventarioPromedio + 1; }

        }
    }
}
