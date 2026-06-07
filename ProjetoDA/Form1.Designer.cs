namespace ProjetoDA
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnsair = new System.Windows.Forms.Button();
            this.btnestatistica = new System.Windows.Forms.Button();
            this.btnartigos = new System.Windows.Forms.Button();
            this.btntipoartigo = new System.Windows.Forms.Button();
            this.btncompra = new System.Windows.Forms.Button();
            this.btnplaneamento = new System.Windows.Forms.Button();
            this.btnorcamento = new System.Windows.Forms.Button();
            this.btninicio = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.grdCompras = new System.Windows.Forms.DataGridView();
            this.btnfecharcompra = new System.Windows.Forms.Button();
            this.btndetalhes = new System.Windows.Forms.Button();
            this.btnnovacompra = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompras)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnsair);
            this.groupBox1.Controls.Add(this.btnestatistica);
            this.groupBox1.Controls.Add(this.btnartigos);
            this.groupBox1.Controls.Add(this.btntipoartigo);
            this.groupBox1.Controls.Add(this.btncompra);
            this.groupBox1.Controls.Add(this.btnplaneamento);
            this.groupBox1.Controls.Add(this.btnorcamento);
            this.groupBox1.Controls.Add(this.btninicio);
            this.groupBox1.Location = new System.Drawing.Point(-4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 569);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
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
            // btnestatistica
            // 
            this.btnestatistica.Location = new System.Drawing.Point(31, 401);
            this.btnestatistica.Name = "btnestatistica";
            this.btnestatistica.Size = new System.Drawing.Size(202, 42);
            this.btnestatistica.TabIndex = 6;
            this.btnestatistica.Text = "Estatistica";
            this.btnestatistica.UseVisualStyleBackColor = true;
            // 
            // btnartigos
            // 
            this.btnartigos.Location = new System.Drawing.Point(31, 339);
            this.btnartigos.Name = "btnartigos";
            this.btnartigos.Size = new System.Drawing.Size(202, 42);
            this.btnartigos.TabIndex = 5;
            this.btnartigos.Text = "Artigos";
            this.btnartigos.UseVisualStyleBackColor = true;
            this.btnartigos.Click += new System.EventHandler(this.btnartigo_Click);
            // 
            // btntipoartigo
            // 
            this.btntipoartigo.Location = new System.Drawing.Point(31, 276);
            this.btntipoartigo.Name = "btntipoartigo";
            this.btntipoartigo.Size = new System.Drawing.Size(202, 42);
            this.btntipoartigo.TabIndex = 4;
            this.btntipoartigo.Text = "Tipos Artigo";
            this.btntipoartigo.UseVisualStyleBackColor = true;
            // 
            // btncompra
            // 
            this.btncompra.Location = new System.Drawing.Point(31, 217);
            this.btncompra.Name = "btncompra";
            this.btncompra.Size = new System.Drawing.Size(202, 42);
            this.btncompra.TabIndex = 3;
            this.btncompra.Text = "Modo Compra";
            this.btncompra.UseVisualStyleBackColor = true;
            // 
            // btnplaneamento
            // 
            this.btnplaneamento.Location = new System.Drawing.Point(31, 158);
            this.btnplaneamento.Name = "btnplaneamento";
            this.btnplaneamento.Size = new System.Drawing.Size(202, 42);
            this.btnplaneamento.TabIndex = 2;
            this.btnplaneamento.Text = "Planeamento";
            this.btnplaneamento.UseVisualStyleBackColor = true;
            this.btnplaneamento.Click += new System.EventHandler(this.btnplaneamento_Click);
            // 
            // btnorcamento
            // 
            this.btnorcamento.Location = new System.Drawing.Point(31, 97);
            this.btnorcamento.Name = "btnorcamento";
            this.btnorcamento.Size = new System.Drawing.Size(202, 42);
            this.btnorcamento.TabIndex = 1;
            this.btnorcamento.Text = "Orçamentos";
            this.btnorcamento.UseVisualStyleBackColor = true;
            this.btnorcamento.Click += new System.EventHandler(this.btnorcamento_Click);
            // 
            // btninicio
            // 
            this.btninicio.Location = new System.Drawing.Point(31, 40);
            this.btninicio.Name = "btninicio";
            this.btninicio.Size = new System.Drawing.Size(202, 42);
            this.btninicio.TabIndex = 0;
            this.btninicio.Text = "Inicio";
            this.btninicio.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(260, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(732, 569);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(495, 152);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(223, 48);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "groupBox6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Disponivel:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(257, 152);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(223, 48);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Gasto:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.grdCompras);
            this.groupBox7.Controls.Add(this.btnfecharcompra);
            this.groupBox7.Controls.Add(this.btndetalhes);
            this.groupBox7.Controls.Add(this.btnnovacompra);
            this.groupBox7.Location = new System.Drawing.Point(17, 235);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(701, 319);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "groupBox7";
            // 
            // grdCompras
            // 
            this.grdCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCompras.Location = new System.Drawing.Point(17, 22);
            this.grdCompras.Name = "grdCompras";
            this.grdCompras.RowHeadersWidth = 51;
            this.grdCompras.RowTemplate.Height = 24;
            this.grdCompras.Size = new System.Drawing.Size(674, 218);
            this.grdCompras.TabIndex = 4;
            // 
            // btnfecharcompra
            // 
            this.btnfecharcompra.Location = new System.Drawing.Point(506, 267);
            this.btnfecharcompra.Name = "btnfecharcompra";
            this.btnfecharcompra.Size = new System.Drawing.Size(189, 39);
            this.btnfecharcompra.TabIndex = 3;
            this.btnfecharcompra.Text = "Fechar Compra";
            this.btnfecharcompra.UseVisualStyleBackColor = true;
            // 
            // btndetalhes
            // 
            this.btndetalhes.Location = new System.Drawing.Point(256, 267);
            this.btndetalhes.Name = "btndetalhes";
            this.btndetalhes.Size = new System.Drawing.Size(198, 39);
            this.btndetalhes.TabIndex = 1;
            this.btndetalhes.Text = "Ver Detalhes";
            this.btndetalhes.UseVisualStyleBackColor = true;
            // 
            // btnnovacompra
            // 
            this.btnnovacompra.Location = new System.Drawing.Point(17, 267);
            this.btnnovacompra.Name = "btnnovacompra";
            this.btnnovacompra.Size = new System.Drawing.Size(165, 39);
            this.btnnovacompra.TabIndex = 0;
            this.btnnovacompra.Text = "Nova Compra";
            this.btnnovacompra.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(17, 152);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(223, 48);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(17, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(701, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Bem-Vindo,";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 581);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCompras)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnsair;
        private System.Windows.Forms.Button btnestatistica;
        private System.Windows.Forms.Button btnartigos;
        private System.Windows.Forms.Button btntipoartigo;
        private System.Windows.Forms.Button btncompra;
        private System.Windows.Forms.Button btnplaneamento;
        private System.Windows.Forms.Button btnorcamento;
        private System.Windows.Forms.Button btninicio;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView grdCompras;
        private System.Windows.Forms.Button btnfecharcompra;
        private System.Windows.Forms.Button btndetalhes;
        private System.Windows.Forms.Button btnnovacompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

