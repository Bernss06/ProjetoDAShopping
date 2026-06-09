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
            this.btnartigos = new System.Windows.Forms.Button();
            this.btntipoartigo = new System.Windows.Forms.Button();
            this.btnplaneamento = new System.Windows.Forms.Button();
            this.btnorcamento = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbValorOrcamentoDisponivel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbValorDoOrcamentoGasto = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.grdCompras = new System.Windows.Forms.DataGridView();
            this.btnfecharcompra = new System.Windows.Forms.Button();
            this.btnnovacompra = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbValorTotalOrcamento = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.btnartigos);
            this.groupBox1.Controls.Add(this.btntipoartigo);
            this.groupBox1.Controls.Add(this.btnplaneamento);
            this.groupBox1.Controls.Add(this.btnorcamento);
            this.groupBox1.Location = new System.Drawing.Point(-4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 569);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnsair
            // 
            this.btnsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsair.Location = new System.Drawing.Point(31, 489);
            this.btnsair.Name = "btnsair";
            this.btnsair.Size = new System.Drawing.Size(202, 65);
            this.btnsair.TabIndex = 7;
            this.btnsair.Text = "Sair";
            this.btnsair.UseVisualStyleBackColor = true;
            this.btnsair.Click += new System.EventHandler(this.btnsair_Click);
            // 
            // btnartigos
            // 
            this.btnartigos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnartigos.Location = new System.Drawing.Point(31, 368);
            this.btnartigos.Name = "btnartigos";
            this.btnartigos.Size = new System.Drawing.Size(202, 76);
            this.btnartigos.TabIndex = 5;
            this.btnartigos.Text = "Artigos";
            this.btnartigos.UseVisualStyleBackColor = true;
            this.btnartigos.Click += new System.EventHandler(this.btnartigo_Click);
            // 
            // btntipoartigo
            // 
            this.btntipoartigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntipoartigo.Location = new System.Drawing.Point(31, 257);
            this.btntipoartigo.Name = "btntipoartigo";
            this.btntipoartigo.Size = new System.Drawing.Size(202, 75);
            this.btntipoartigo.TabIndex = 4;
            this.btntipoartigo.Text = "Tipos Artigo";
            this.btntipoartigo.UseVisualStyleBackColor = true;
            this.btntipoartigo.Click += new System.EventHandler(this.btntipoartigo_Click);
            // 
            // btnplaneamento
            // 
            this.btnplaneamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnplaneamento.Location = new System.Drawing.Point(31, 145);
            this.btnplaneamento.Name = "btnplaneamento";
            this.btnplaneamento.Size = new System.Drawing.Size(202, 73);
            this.btnplaneamento.TabIndex = 2;
            this.btnplaneamento.Text = "Planeamento";
            this.btnplaneamento.UseVisualStyleBackColor = true;
            this.btnplaneamento.Click += new System.EventHandler(this.btnplaneamento_Click);
            // 
            // btnorcamento
            // 
            this.btnorcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnorcamento.Location = new System.Drawing.Point(31, 40);
            this.btnorcamento.Name = "btnorcamento";
            this.btnorcamento.Size = new System.Drawing.Size(202, 69);
            this.btnorcamento.TabIndex = 1;
            this.btnorcamento.Text = "Orçamentos";
            this.btnorcamento.UseVisualStyleBackColor = true;
            this.btnorcamento.Click += new System.EventHandler(this.btnorcamento_Click);
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
            this.groupBox2.Size = new System.Drawing.Size(716, 569);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbValorOrcamentoDisponivel);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(495, 143);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(211, 67);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            // 
            // lbValorOrcamentoDisponivel
            // 
            this.lbValorOrcamentoDisponivel.AutoSize = true;
            this.lbValorOrcamentoDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorOrcamentoDisponivel.Location = new System.Drawing.Point(95, 29);
            this.lbValorOrcamentoDisponivel.Name = "lbValorOrcamentoDisponivel";
            this.lbValorOrcamentoDisponivel.Size = new System.Drawing.Size(46, 18);
            this.lbValorOrcamentoDisponivel.TabIndex = 5;
            this.lbValorOrcamentoDisponivel.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Disponivel:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbValorDoOrcamentoGasto);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(257, 143);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(223, 67);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // lbValorDoOrcamentoGasto
            // 
            this.lbValorDoOrcamentoGasto.AutoSize = true;
            this.lbValorDoOrcamentoGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorDoOrcamentoGasto.Location = new System.Drawing.Point(65, 29);
            this.lbValorDoOrcamentoGasto.Name = "lbValorDoOrcamentoGasto";
            this.lbValorDoOrcamentoGasto.Size = new System.Drawing.Size(46, 18);
            this.lbValorDoOrcamentoGasto.TabIndex = 3;
            this.lbValorDoOrcamentoGasto.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Gasto:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.grdCompras);
            this.groupBox7.Controls.Add(this.btnfecharcompra);
            this.groupBox7.Controls.Add(this.btnnovacompra);
            this.groupBox7.Location = new System.Drawing.Point(6, 235);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(700, 319);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
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
            this.btnfecharcompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfecharcompra.Location = new System.Drawing.Point(398, 254);
            this.btnfecharcompra.Name = "btnfecharcompra";
            this.btnfecharcompra.Size = new System.Drawing.Size(179, 52);
            this.btnfecharcompra.TabIndex = 3;
            this.btnfecharcompra.Text = "Fechar Compra";
            this.btnfecharcompra.UseVisualStyleBackColor = true;
            this.btnfecharcompra.Click += new System.EventHandler(this.btnfecharcompra_Click);
            // 
            // btnnovacompra
            // 
            this.btnnovacompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnovacompra.Location = new System.Drawing.Point(124, 254);
            this.btnnovacompra.Name = "btnnovacompra";
            this.btnnovacompra.Size = new System.Drawing.Size(165, 52);
            this.btnnovacompra.TabIndex = 0;
            this.btnnovacompra.Text = "Nova Compra";
            this.btnnovacompra.UseVisualStyleBackColor = true;
            this.btnnovacompra.Click += new System.EventHandler(this.btnnovacompra_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbValorTotalOrcamento);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(17, 143);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(223, 67);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // lbValorTotalOrcamento
            // 
            this.lbValorTotalOrcamento.AutoSize = true;
            this.lbValorTotalOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorTotalOrcamento.Location = new System.Drawing.Point(65, 29);
            this.lbValorTotalOrcamento.Name = "lbValorTotalOrcamento";
            this.lbValorTotalOrcamento.Size = new System.Drawing.Size(46, 18);
            this.lbValorTotalOrcamento.TabIndex = 1;
            this.lbValorTotalOrcamento.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(17, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(689, 109);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(145, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Bem-Vindo,";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(988, 581);
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
        private System.Windows.Forms.Button btnartigos;
        private System.Windows.Forms.Button btntipoartigo;
        private System.Windows.Forms.Button btnplaneamento;
        private System.Windows.Forms.Button btnorcamento;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView grdCompras;
        private System.Windows.Forms.Button btnfecharcompra;
        private System.Windows.Forms.Button btnnovacompra;
        private System.Windows.Forms.Label lbValorTotalOrcamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbValorOrcamentoDisponivel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbValorDoOrcamentoGasto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

