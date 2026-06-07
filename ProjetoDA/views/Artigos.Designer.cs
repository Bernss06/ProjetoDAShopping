namespace ProjetoDA.views
{
    partial class Artigos
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
            this.grdArtigos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxdetalhes = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtnome_artigo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnsair = new System.Windows.Forms.Button();
            this.btninicio = new System.Windows.Forms.Button();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdArtigos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxdetalhes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdArtigos
            // 
            this.grdArtigos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdArtigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArtigos.Location = new System.Drawing.Point(0, 54);
            this.grdArtigos.Name = "grdArtigos";
            this.grdArtigos.RowHeadersWidth = 51;
            this.grdArtigos.RowTemplate.Height = 24;
            this.grdArtigos.Size = new System.Drawing.Size(571, 190);
            this.grdArtigos.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdArtigos);
            this.groupBox1.Location = new System.Drawing.Point(236, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 262);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Artigos";
            // 
            // groupBoxdetalhes
            // 
            this.groupBoxdetalhes.Controls.Add(this.label2);
            this.groupBoxdetalhes.Controls.Add(this.label1);
            this.groupBoxdetalhes.Controls.Add(this.button3);
            this.groupBoxdetalhes.Controls.Add(this.button2);
            this.groupBoxdetalhes.Controls.Add(this.button1);
            this.groupBoxdetalhes.Controls.Add(this.txtnome_artigo);
            this.groupBoxdetalhes.Location = new System.Drawing.Point(12, 12);
            this.groupBoxdetalhes.Name = "groupBoxdetalhes";
            this.groupBoxdetalhes.Size = new System.Drawing.Size(200, 484);
            this.groupBoxdetalhes.TabIndex = 7;
            this.groupBoxdetalhes.TabStop = false;
            this.groupBoxdetalhes.Text = "Detalhes do Artigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Categoria (Tipo):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(29, 346);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 48);
            this.button3.TabIndex = 4;
            this.button3.Text = "✖️ Eliminar Artigo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 43);
            this.button2.TabIndex = 3;
            this.button2.Text = "🔍 Editar Artigo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "➕ Novo Artigo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtnome_artigo
            // 
            this.txtnome_artigo.Location = new System.Drawing.Point(29, 75);
            this.txtnome_artigo.Name = "txtnome_artigo";
            this.txtnome_artigo.Size = new System.Drawing.Size(140, 22);
            this.txtnome_artigo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnsair);
            this.groupBox2.Controls.Add(this.btninicio);
            this.groupBox2.Location = new System.Drawing.Point(608, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 122);
            this.groupBox2.TabIndex = 8;
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
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(41, 177);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(140, 24);
            this.cmbCategoria.TabIndex = 7;
            // 
            // Artigos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 508);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxdetalhes);
            this.Controls.Add(this.groupBox1);
            this.Name = "Artigos";
            this.Text = "Artigos";
            this.Load += new System.EventHandler(this.Artigos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdArtigos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxdetalhes.ResumeLayout(false);
            this.groupBoxdetalhes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdArtigos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxdetalhes;
        private System.Windows.Forms.TextBox txtnome_artigo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnsair;
        private System.Windows.Forms.Button btninicio;
        private System.Windows.Forms.ComboBox cmbCategoria;
    }
}