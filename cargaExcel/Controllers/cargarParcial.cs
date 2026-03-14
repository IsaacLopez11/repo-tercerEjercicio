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
        ExcelWorksheet verificacion = package.Workbook.Worksheets[0];
                int filas = hoja.Dimension.Rows;
                int filasVerificacion = verificacion.Dimension.Rows;


        for (int fila = 2; fila <= filas; fila++)
        {
            int idVenta = 0;
            DateTime fecha = DateTime.MinValue;
            string cliente = "";
            string ciudad = "";
            string producto = "";
            int cantidad = 0;
            decimal precio = 0;
            decimal total = 0;
            string estado = "";

            bool filaValida = true;

            if (hoja.Cells[fila, 1].Value == null)
            {
                errores.Add($"El campo IdVenta está vacío en la fila {fila}");
                filaValida = false;
            }
            else
            {
                idVenta = Convert.ToInt32(hoja.Cells[fila, 1].Value);
            }

            if (hoja.Cells[fila, 2].Value == null)
            {
                errores.Add($"El campo Fecha_Normalizada está vacío en la fila {fila}");
                filaValida = false;
            }
            else
            {
                fecha = Convert.ToDateTime(hoja.Cells[fila, 2].Value);
            }

            if (hoja.Cells[fila, 3].Value == null)
            {
                errores.Add($"El campo Cliente_Limpio está vacío en la fila {fila}");
                filaValida = false;
            }
            else
            {
                cliente = hoja.Cells[fila, 3].Value.ToString();
            }

            if (hoja.Cells[fila, 4].Value == null)
            {
                errores.Add($"El campo Ciudad_Limpia está vacío en la fila {fila}");
                filaValida = false;
            }
            else
            {
                ciudad = hoja.Cells[fila, 4].Value.ToString();
            }

            if (hoja.Cells[fila, 5].Value == null)
            {
                errores.Add($"El campo Producto_Limpio está vacío en la fila {fila}");
                filaValida = false;
            }
            else
            {
                producto = hoja.Cells[fila, 5].Value.ToString();
            }

            if (hoja.Cells[fila, 6].Value == null)
            {
                errores.Add($"El campo Cantidad_Validada está vacío en la fila {fila}");
                filaValida = false;
            }
            else
            {
                cantidad = Convert.ToInt32(hoja.Cells[fila, 6].Value);
            }

            if (hoja.Cells[fila, 7].Value == null)
            {
                errores.Add($"El campo PrecioUnitario está vacío en la fila {fila}");
                filaValida = false;
            }
            else
            {
                precio = Convert.ToDecimal(hoja.Cells[fila, 7].Value);
            }

            if (hoja.Cells[fila, 8].Value == null)
            {
                errores.Add($"El campo Total_Calculado está vacío en la fila {fila}");
                filaValida = false;
            }
            else
            {
                total = Convert.ToDecimal(hoja.Cells[fila, 8].Value);
            }

                    string totalVerificacion = verificacion.Cells[fila,8].Value.ToString();

            if (hoja.Cells[fila, 8].Value.ToString() == totalVerificacion)
                    {
                        if (filaValida)
                        {
                            Parcial datos = new Parcial
                            {
                                IdVenta = idVenta,
                                Fecha_Normalizada = fecha,
                                Cliente_Limpio = cliente,
                                Ciudad_Limpia = ciudad,
                                Producto_Limpio = producto,
                                Cantidad_Validada = cantidad,
                                PrecioUnitario = precio,
                                Total_Calculado = total//,
                                                       //Estado_Total = estado
                            };

                            parcial.Add(datos);
                        }

                    }
            //if (hoja.Cells[fila, 9].Value == null)
            //{
            //    errores.Add($"El campo Estado_Total está vacío en la fila {fila}");
            //    filaValida = false;
            //}
            //else
            //{
            //    estado = hoja.Cells[fila, 9].Value.ToString();
            //}

            
        }

        if (errores.Count > 0)
        {
            foreach (var error in errores)
            {
                Console.WriteLine(error);
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