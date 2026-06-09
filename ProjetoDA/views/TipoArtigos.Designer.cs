namespace ProjetoDA.views
{
    partial class TipoArtigos
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnsair = new System.Windows.Forms.Button();
            this.btninicio = new System.Windows.Forms.Button();
            this.groupBoxdetalhes = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            this.btnEditarCategoria = new System.Windows.Forms.Button();
            this.btnNovaCategoria = new System.Windows.Forms.Button();
            this.txtNomeCategoria = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdCategorias = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBoxdetalhes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnsair);
            this.groupBox2.Controls.Add(this.btninicio);
            this.groupBox2.Location = new System.Drawing.Point(585, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 122);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // btnsair
            // 
            this.btnsair.Location = new System.Drawing.Point(31, 489);
            this.btnsair.Name = "btnsair";
            this.btnsair.Size = new System.Drawing.Size(202, 65);
            this.btnsair.TabIndex = 7;
            this.btnsair.Text = "Sair";
            this.btnsair.UseVisualStyleBackColor = true;
            // 
            // btninicio
            // 
            this.btninicio.Location = new System.Drawing.Point(31, 40);
            this.btninicio.Name = "btninicio";
            this.btninicio.Size = new System.Drawing.Size(202, 42);
            this.btninicio.TabIndex = 0;
            this.btninicio.Text = "Inicio";
            this.btninicio.UseVisualStyleBackColor = true;
            this.btninicio.Click += new System.EventHandler(this.btninicio_Click);
            // 
            // groupBoxdetalhes
            // 
            this.groupBoxdetalhes.Controls.Add(this.label1);
            this.groupBoxdetalhes.Controls.Add(this.btnEliminarCategoria);
            this.groupBoxdetalhes.Controls.Add(this.btnEditarCategoria);
            this.groupBoxdetalhes.Controls.Add(this.btnNovaCategoria);
            this.groupBoxdetalhes.Controls.Add(this.txtNomeCategoria);
            this.groupBoxdetalhes.Location = new System.Drawing.Point(12, 12);
            this.groupBoxdetalhes.Name = "groupBoxdetalhes";
            this.groupBoxdetalhes.Size = new System.Drawing.Size(200, 484);
            this.groupBoxdetalhes.TabIndex = 10;
            this.groupBoxdetalhes.TabStop = false;
            this.groupBoxdetalhes.Text = "Detalhes da Categoria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome da Categoria:";
            // 
            // btnEliminarCategoria
            // 
            this.btnEliminarCategoria.Location = new System.Drawing.Point(29, 346);
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.Size = new System.Drawing.Size(140, 48);
            this.btnEliminarCategoria.TabIndex = 4;
            this.btnEliminarCategoria.Text = "✖️ Eliminar Categoria";
            this.btnEliminarCategoria.UseVisualStyleBackColor = true;
            this.btnEliminarCategoria.Click += new System.EventHandler(this.btnEliminarCategoria_Click);
            // 
            // btnEditarCategoria
            // 
            this.btnEditarCategoria.Location = new System.Drawing.Point(29, 297);
            this.btnEditarCategoria.Name = "btnEditarCategoria";
            this.btnEditarCategoria.Size = new System.Drawing.Size(140, 43);
            this.btnEditarCategoria.TabIndex = 3;
            this.btnEditarCategoria.Text = "🔍 Editar Categoria";
            this.btnEditarCategoria.UseVisualStyleBackColor = true;
            this.btnEditarCategoria.Click += new System.EventHandler(this.btnEditarCategoria_Click);
            // 
            // btnNovaCategoria
            // 
            this.btnNovaCategoria.Location = new System.Drawing.Point(29, 241);
            this.btnNovaCategoria.Name = "btnNovaCategoria";
            this.btnNovaCategoria.Size = new System.Drawing.Size(140, 47);
            this.btnNovaCategoria.TabIndex = 2;
            this.btnNovaCategoria.Text = "➕ Nova Categoria";
            this.btnNovaCategoria.UseVisualStyleBackColor = true;
            this.btnNovaCategoria.Click += new System.EventHandler(this.btnNovaCategoria_Click);
            // 
            // txtNomeCategoria
            // 
            this.txtNomeCategoria.Location = new System.Drawing.Point(29, 111);
            this.txtNomeCategoria.Name = "txtNomeCategoria";
            this.txtNomeCategoria.Size = new System.Drawing.Size(140, 22);
            this.txtNomeCategoria.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdCategorias);
            this.groupBox1.Location = new System.Drawing.Point(247, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 262);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categorias";
            // 
            // grdCategorias
            // 
            this.grdCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCategorias.Location = new System.Drawing.Point(0, 21);
            this.grdCategorias.Name = "grdCategorias";
            this.grdCategorias.RowHeadersWidth = 51;
            this.grdCategorias.RowTemplate.Height = 24;
            this.grdCategorias.Size = new System.Drawing.Size(571, 223);
            this.grdCategorias.TabIndex = 5;
            // 
            // TipoArtigos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(860, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxdetalhes);
            this.Controls.Add(this.groupBox2);
            this.Name = "TipoArtigos";
            this.Text = "TipoArtigos";
            this.groupBox2.ResumeLayout(false);
            this.groupBoxdetalhes.ResumeLayout(false);
            this.groupBoxdetalhes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCategorias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnsair;
        private System.Windows.Forms.Button btninicio;
        private System.Windows.Forms.GroupBox groupBoxdetalhes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminarCategoria;
        private System.Windows.Forms.Button btnEditarCategoria;
        private System.Windows.Forms.Button btnNovaCategoria;
        private System.Windows.Forms.TextBox txtNomeCategoria;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdCategorias;
    }
}