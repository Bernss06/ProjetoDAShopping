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
            this.cbListaDeCompras = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesquisaCustom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNovaCompra = new System.Windows.Forms.Button();
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
            this.drgListaDeTodasAsCompras.Location = new System.Drawing.Point(12, 111);
            this.drgListaDeTodasAsCompras.Name = "drgListaDeTodasAsCompras";
            this.drgListaDeTodasAsCompras.RowHeadersWidth = 51;
            this.drgListaDeTodasAsCompras.RowTemplate.Height = 24;
            this.drgListaDeTodasAsCompras.Size = new System.Drawing.Size(473, 275);
            this.drgListaDeTodasAsCompras.TabIndex = 1;
            // 
            // cbListaDeCompras
            // 
            this.cbListaDeCompras.FormattingEnabled = true;
            this.cbListaDeCompras.Location = new System.Drawing.Point(196, 81);
            this.cbListaDeCompras.Name = "cbListaDeCompras";
            this.cbListaDeCompras.Size = new System.Drawing.Size(157, 24);
            this.cbListaDeCompras.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filtro";
            // 
            // txtPesquisaCustom
            // 
            this.txtPesquisaCustom.Location = new System.Drawing.Point(12, 83);
            this.txtPesquisaCustom.Name = "txtPesquisaCustom";
            this.txtPesquisaCustom.Size = new System.Drawing.Size(157, 22);
            this.txtPesquisaCustom.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pesquisa Rapida";
            // 
            // btnNovaCompra
            // 
            this.btnNovaCompra.Location = new System.Drawing.Point(372, 12);
            this.btnNovaCompra.Name = "btnNovaCompra";
            this.btnNovaCompra.Size = new System.Drawing.Size(113, 52);
            this.btnNovaCompra.TabIndex = 6;
            this.btnNovaCompra.Text = "Nova Compra";
            this.btnNovaCompra.UseVisualStyleBackColor = true;
            this.btnNovaCompra.Click += new System.EventHandler(this.btnNovaCompra_Click);
            // 
            // ListasDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 396);
            this.Controls.Add(this.btnNovaCompra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPesquisaCustom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbListaDeCompras);
            this.Controls.Add(this.drgListaDeTodasAsCompras);
            this.Controls.Add(this.btnVoltarAoInicio);
            this.Name = "ListasDeCompra";
            this.Text = "ListasDeCompra";
            ((System.ComponentModel.ISupportInitialize)(this.drgListaDeTodasAsCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVoltarAoInicio;
        private System.Windows.Forms.DataGridView drgListaDeTodasAsCompras;
        private System.Windows.Forms.ComboBox cbListaDeCompras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesquisaCustom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNovaCompra;
    }
}