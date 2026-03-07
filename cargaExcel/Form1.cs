using cargaExcel.Controllers;
using cargaExcel.Models;

namespace cargaExcel
{
    public partial class Form1 : Form
    {
        private List<Persona> personas;
        private string ruta;



        private CargaExcelController controller = new CargaExcelController();
        private ExportarController exporter = new ExportarController();

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

                personas = controller.ProcesarExcel(ruta);

                dgvVentas.DataSource = personas;

                var errores = controller.ObtenerErrores();

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
            if (personas.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV (*.csv)|*.csv";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                exporter.ExportarCSV(personas, dialog.FileName);

                MessageBox.Show("Archivo CSV exportado correctamente.");
            }
        }
    }
}