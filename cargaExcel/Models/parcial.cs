using System.Numerics;

namespace cargaExcel.Models
{
    public class Parcial
    {
        public int IdVenta { get; set; }	
        public DateTime Fecha_Normalizada { get; set; }	
        public string Cliente_Limpio { get; set; }	
        public string Ciudad_Limpia { get; set; }	
        public string Producto_Limpio { get; set; }	
        public int Cantidad_Validada { get; set; }	
        public decimal PrecioUnitario { get; set; }	
        public decimal Total_Calculado { get; set; }	
        public string Estado_Total { get; set; }
       
    }
}