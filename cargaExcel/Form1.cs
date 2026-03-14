using cargaExcel.Controllers;
using cargaExcel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace cargaExcel
{
    public partial class Form1 : Form
    {
        private List<Parcial> parcial;
        private string ruta;



        // private CargaExcelController controller = new CargaExcelController();
        private ExportarController exporter = new ExportarController();
        private CargaParcialController cargarParcialController = new CargaParcialController();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargaExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Excel Files|*.xlsx";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ruta = dialog.FileName;

                parcial = cargarParcialController.ProcesarExcel(ruta);



                var resultado = parcial
                .Where(p =>
                    //p.Estado_Total == "OK" &&
                    p.Producto_Limpio != "Sin especificar" &&
                    p.Cliente_Limpio != "Sin Cliente"
                )
                .ToList();


                dgvVentas.DataSource = resultado;

                var cantidad = resultado.Count();
                label3.Text= cantidad.ToString();

                var errores = cargarParcialController.ObtenerErrores();

                if (errores.Count > 0)
                {
                    MessageBox.Show(
                        string.Join("\n", errores),
                        "Errores encontrados"
                    );
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (parcial.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV (*.csv)|*.csv";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                exporter.ExportarCSV(parcial, dialog.FileName);

                MessageBox.Show("Archivo CSV exportado correctamente.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}