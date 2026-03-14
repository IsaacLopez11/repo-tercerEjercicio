using cargaExcel.Models;

namespace cargaExcel.Controllers
{
    public class ExportarController
    {
        public void ExportarCSV(List<Parcial> parcial,string ruta)
        {
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                writer.WriteLine("IdVenta;Fecha_Normalizada;Cliente_Limpio;Ciudad_Limpia;Producto_Limpio;Cantidad_Validada;PrecioUnitario;Total_Calculado;Estado_Total");
                foreach (var p in parcial)
                {
                    writer.WriteLine($"{p.IdVenta};{p.Fecha_Normalizada:yyyy-MM-dd};{p.Cliente_Limpio};{p.Ciudad_Limpia};{p.Producto_Limpio};{p.Cantidad_Validada};{p.PrecioUnitario};{p.Total_Calculado}");
                }
            }
        }
    }
}

