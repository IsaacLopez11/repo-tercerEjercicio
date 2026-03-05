using cargaExcel.Controllers;
using cargaExcel.Models;

namespace cargaExcel
{
    public partial class Form1 : Form
    {

        private CargaExcelController controller = new CargaExcelController();

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
                string ruta = dialog.FileName;

                List<Persona> personas = controller.ProcesarExcel(ruta);

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
    }
}