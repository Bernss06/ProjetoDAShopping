namespace ProjetoDA.views
{
    partial class ListasDeCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVoltarAoInicio = new System.Windows.Forms.Button();
            this.drgListaDeTodasAsCompras = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.drgListaDeTodasAsCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltarAoInicio
            // 
            this.btnVoltarAoInicio.Location = new System.Drawing.Point(12, 12);
            this.btnVoltarAoInicio.Name = "btnVoltarAoInicio";
            this.btnVoltarAoInicio.Size = new System.Drawing.Size(77, 33);
            this.btnVoltarAoInicio.TabIndex = 0;
            this.btnVoltarAoInicio.Text = "Inicio";
            this.btnVoltarAoInicio.UseVisualStyleBackColor = true;
            // 
            // drgListaDeTodasAsCompras
            // 
            this.drgListaDeTodasAsCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drgListaDeTodasAsCompras.Location = new System.Drawing.Point(171, 66);
            this.drgListaDeTodasAsCompras.Name = "drgListaDeTodasAsCompras";
            this.drgListaDeTodasAsCompras.RowHeadersWidth = 51;
            this.drgListaDeTodasAsCompras.RowTemplate.Height = 24;
            this.drgListaDeTodasAsCompras.Size = new System.Drawing.Size(473, 275);
            this.drgListaDeTodasAsCompras.TabIndex = 1;
            // 
            // ListasDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.drgListaDeTodasAsCompras);
            this.Controls.Add(this.btnVoltarAoInicio);
            this.Name = "ListasDeCompra";
            this.Text = "ListasDeCompra";
            ((System.ComponentModel.ISupportInitialize)(this.drgListaDeTodasAsCompras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoltarAoInicio;
        private System.Windows.Forms.DataGridView drgListaDeTodasAsCompras;
    }
}