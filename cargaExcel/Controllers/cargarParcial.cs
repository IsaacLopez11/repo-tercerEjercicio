using OfficeOpenXml;
using cargaExcel.Models;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;

namespace cargaExcel.Controllers
{

    public class CargaParcialController
    {
        private List<Parcial> parcial = new List<Parcial>();
        private List<string> errores = new List<string>();

        public List<Parcial> ProcesarExcel(string ruta)
        {
            parcial.Clear();
            errores.Clear();

            ExcelPackage.License.SetNonCommercialPersonal("Isaac Lopez");
            using (var package = new ExcelPackage(new FileInfo(ruta)))
            {
                ExcelWorksheet hoja = package.Workbook.Worksheets[2];
                int filas = hoja.Dimension.Rows;

                for (int fila = 2; fila <= filas; fila++)
                {
                    int idventa = int.Parse(hoja.Cells[fila, 1].Text.Trim());
                    if (idventa > 0
                    ) { }
                    else
                    {
                        errores.Add($"Fila: {fila}, ID de venta es inválido");
                        continue;
                    }


                    string fechaNorm = hoja.Cells[fila, 2].Text;
                    DateTime fecha;

                    bool esFechaValida = DateTime.TryParse(
                        fechaNorm,
                        new System.Globalization.CultureInfo("es-CO"),
                        System.Globalization.DateTimeStyles.None,
                        out fecha
                    );

                    if (esFechaValida)
                    {
                        if (fecha > DateTime.Now
                        || DateTime.Now.Year - fecha.Year > 150
                        )
                        {
                            errores.Add($"Fila {fila}: La fecha de nacimiento es inválida.");
                            continue;
                        }
                    }

                    string nombre = hoja.Cells[fila, 3].Text;
                    if (string.IsNullOrEmpty(nombre)
                    || nombre == "Sin Cliente")
                    {
                        errores.Add($"Fila {fila}, nombre inválido");
                    }

                    string ciudad =  hoja.Cells[fila, 4].Text.ToUpper();
                    if (string.IsNullOrEmpty(ciudad))
                    {
                        errores.Add($"Fila {fila}, ciudad inválida");
                    }

                    string producto = hoja.Cells[fila, 5].Text.ToUpper();
                    if (string.IsNullOrEmpty(producto))
                    {
                        errores.Add($"Fila {fila}, producto inválido");
                    }


                    string cantidadStr = hoja.Cells[fila, 6].Text;
                    int cantidad;
                    if (int.TryParse(cantidadStr, out cantidad))
                    {
                        if (cantidad <= 0)
                        {
                            errores.Add($"Fila {fila}, cantidad inválida");
                        }
                    }
                    else
                    {
                        errores.Add($"Fila {fila}, cantidad no es un número válido");
                    }

                    string precioStr = hoja.Cells[fila, 7].Text;
                    decimal precio;

                    if (decimal.TryParse(precioStr, NumberStyles.Any, new CultureInfo("es-CO"), out precio))
                    {
                        if (precio <= 0)
                        {
                            errores.Add($"Fila {fila}, precio unitario inválido");
                        }
                    }
                    else
                    {
                        errores.Add($"Fila {fila}, precio unitario no es un número válido");
                    }

                    string totalStr = hoja.Cells[fila, 8].Text;
                    decimal total;
                    if (decimal.TryParse(totalStr, NumberStyles.Any, new CultureInfo("es-CO"), out total))
                    {
                        decimal totalCalculado = cantidad * precio;
                        if (total != totalCalculado)
                        {
                            errores.Add($"Fila {fila}, total calculado no coincide con el total proporcionado");
                        }
                    }
                    else
                    {
                        errores.Add($"Fila {fila}, total no es un número válido");
                    }

                    string estado = hoja.Cells[fila, 9].Text.ToUpper();
                    if (estado != "OK" )
                    {
                        errores.Add($"Fila {fila}, estado total inválido");
                    }

                }
                if (errores.Count > 0)
                {
                    for (int i = 0; i < errores.Count; i++)
                    {
                        Console.WriteLine($"{errores[i]}");
                    }
                }
            }

            return parcial;
        }
    
        public List<string> ObtenerErrores()
            {
                return errores;
            }

         
    }
}