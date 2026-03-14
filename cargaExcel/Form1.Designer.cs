namespace cargaExcel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCargaExcel = new Button();
            dgvVentas = new DataGridView();
            ExportarCSV = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // btnCargaExcel
            // 
            btnCargaExcel.Location = new Point(95, 35);
            btnCargaExcel.Name = "btnCargaExcel";
            btnCargaExcel.Size = new Size(114, 42);
            btnCargaExcel.TabIndex = 0;
            btnCargaExcel.Text = "Cargar Excel";
            btnCargaExcel.UseVisualStyleBackColor = true;
            btnCargaExcel.Click += btnCargaExcel_Click;
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(95, 130);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(566, 251);
            dgvVentas.TabIndex = 1;
            // 
            // ExportarCSV
            // 
            ExportarCSV.Location = new Point(562, 35);
            ExportarCSV.Name = "ExportarCSV";
            ExportarCSV.Size = new Size(99, 42);
            ExportarCSV.TabIndex = 2;
            ExportarCSV.Tag = "ExportarCSV";
            ExportarCSV.Text = "Exportar";
            ExportarCSV.UseVisualStyleBackColor = true;
            ExportarCSV.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(671, 130);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 3;
            label1.Text = "cantidad de registros";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(671, 157);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(671, 157);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 5;
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ExportarCSV);
            Controls.Add(dgvVentas);
            Controls.Add(btnCargaExcel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCargaExcel;
        private DataGridView dgvVentas;
        private Button ExportarCSV;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
