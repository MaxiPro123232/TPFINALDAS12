namespace TechStore.Vistas
{
    partial class FormHistorialCompras
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvVentas = new DataGridView();
            this.lblCliente = new Label();
            this.SuspendLayout();
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new Point(20, 60);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.Size = new Size(900, 400);
            this.dgvVentas.TabIndex = 0;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblCliente.Location = new Point(20, 20);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new Size(0, 25);
            this.lblCliente.TabIndex = 1;
            // 
            // FormHistorialCompras
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(940, 480);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.dgvVentas);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormHistorialCompras";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Historial de Compras";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DataGridView dgvVentas;
        private Label lblCliente;
    }
}

