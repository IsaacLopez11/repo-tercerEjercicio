using cargaExcel.Models;

namespace cargaExcel.Controllers
{
    public class ExportarController
    {
        public void ExportarCSV(List<Persona> personas,string ruta)
        {
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                writer.WriteLine("TipoDoc;NumDoc;Nombre;FechaNac;Sueldo;CiudadRes");
                foreach (var p in personas)
                {
                    writer.WriteLine($"{p.TipoDoc};{p.NumDoc};{p.Nombre};{p.FechaNac:yyyy-MM-dd};{p.Sueldo};{p.CiudadRes}");
                }
            }
        }
    }
}

