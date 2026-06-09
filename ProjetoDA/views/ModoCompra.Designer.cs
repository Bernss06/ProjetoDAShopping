namespace ProjetoDA.views
{
    partial class ModoCompra
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
            this.btnVoltarInicio = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTipoArtigo = new System.Windows.Forms.ComboBox();
            this.btnAddNaoPrevisto = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPreco = new System.Windows.Forms.Label();
            this.cbArtigo = new System.Windows.Forms.ComboBox();
            this.txtPrecoNaoPrevisto = new System.Windows.Forms.TextBox();
            this.numNaoPrevisto = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dtgItensCompra = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnadicionaritem = new System.Windows.Forms.Button();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.numQuantidadeArtigo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnremoveritem = new System.Windows.Forms.Button();
            this.dtgcompra = new System.Windows.Forms.DataGridView();
            this.btnfinalizarcompra = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbCustoTotaldaCompra = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbOrcamentoTotal = new System.Windows.Forms.Label();
            this.lbRestanteDisponivel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNaoPrevisto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItensCompra)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidadeArtigo)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgcompra)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltarInicio
            // 
            this.btnVoltarInicio.Location = new System.Drawing.Point(12, 12);
            this.btnVoltarInicio.Name = "btnVoltarInicio";
            this.btnVoltarInicio.Size = new System.Drawing.Size(72, 34);
            this.btnVoltarInicio.TabIndex = 0;
            this.btnVoltarInicio.Text = "<- Inicio";
            this.btnVoltarInicio.UseVisualStyleBackColor = true;
            this.btnVoltarInicio.Click += new System.EventHandler(this.BtnVoltarInicio_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTipoArtigo);
            this.groupBox1.Controls.Add(this.btnAddNaoPrevisto);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbPreco);
            this.groupBox1.Controls.Add(this.cbArtigo);
            this.groupBox1.Controls.Add(this.txtPrecoNaoPrevisto);
            this.groupBox1.Controls.Add(this.numNaoPrevisto);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 347);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // cbTipoArtigo
            // 
            this.cbTipoArtigo.FormattingEnabled = true;
            this.cbTipoArtigo.Location = new System.Drawing.Point(4, 99);
            this.cbTipoArtigo.Name = "cbTipoArtigo";
            this.cbTipoArtigo.Size = new System.Drawing.Size(200, 24);
            this.cbTipoArtigo.TabIndex = 14;
            // 
            // btnAddNaoPrevisto
            // 
            this.btnAddNaoPrevisto.BackColor = System.Drawing.Color.White;
            this.btnAddNaoPrevisto.Location = new System.Drawing.Point(22, 278);
            this.btnAddNaoPrevisto.Name = "btnAddNaoPrevisto";
            this.btnAddNaoPrevisto.Size = new System.Drawing.Size(165, 48);
            this.btnAddNaoPrevisto.TabIndex = 11;
            this.btnAddNaoPrevisto.Text = "Adicionar Item Extra";
            this.btnAddNaoPrevisto.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Artigo";
            // 
            // lbPreco
            // 
            this.lbPreco.AutoSize = true;
            this.lbPreco.Location = new System.Drawing.Point(6, 218);
            this.lbPreco.Name = "lbPreco";
            this.lbPreco.Size = new System.Drawing.Size(46, 16);
            this.lbPreco.TabIndex = 14;
            this.lbPreco.Text = "Preço:";
            // 
            // cbArtigo
            // 
            this.cbArtigo.FormattingEnabled = true;
            this.cbArtigo.Location = new System.Drawing.Point(4, 43);
            this.cbArtigo.Name = "cbArtigo";
            this.cbArtigo.Size = new System.Drawing.Size(204, 24);
            this.cbArtigo.TabIndex = 11;
            // 
            // txtPrecoNaoPrevisto
            // 
            this.txtPrecoNaoPrevisto.Location = new System.Drawing.Point(58, 215);
            this.txtPrecoNaoPrevisto.Name = "txtPrecoNaoPrevisto";
            this.txtPrecoNaoPrevisto.Size = new System.Drawing.Size(149, 22);
            this.txtPrecoNaoPrevisto.TabIndex = 13;
            // 
            // numNaoPrevisto
            // 
            this.numNaoPrevisto.Location = new System.Drawing.Point(84, 158);
            this.numNaoPrevisto.Name = "numNaoPrevisto";
            this.numNaoPrevisto.Size = new System.Drawing.Size(120, 22);
            this.numNaoPrevisto.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Quantidade";
            // 
            // dtgItensCompra
            // 
            this.dtgItensCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItensCompra.Location = new System.Drawing.Point(6, 13);
            this.dtgItensCompra.Name = "dtgItensCompra";
            this.dtgItensCompra.RowHeadersWidth = 51;
            this.dtgItensCompra.RowTemplate.Height = 24;
            this.dtgItensCompra.Size = new System.Drawing.Size(277, 193);
            this.dtgItensCompra.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnadicionaritem);
            this.groupBox2.Controls.Add(this.txtPreco);
            this.groupBox2.Controls.Add(this.dtgItensCompra);
            this.groupBox2.Controls.Add(this.numQuantidadeArtigo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(231, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 354);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 16);
            this.label12.TabIndex = 10;
            this.label12.Text = "Preço";
            // 
            // btnadicionaritem
            // 
            this.btnadicionaritem.Location = new System.Drawing.Point(50, 285);
            this.btnadicionaritem.Name = "btnadicionaritem";
            this.btnadicionaritem.Size = new System.Drawing.Size(200, 48);
            this.btnadicionaritem.TabIndex = 7;
            this.btnadicionaritem.Text = "Adicionar Item Registado";
            this.btnadicionaritem.UseVisualStyleBackColor = true;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(96, 252);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(154, 22);
            this.txtPreco.TabIndex = 4;
            // 
            // numQuantidadeArtigo
            // 
            this.numQuantidadeArtigo.Location = new System.Drawing.Point(93, 219);
            this.numQuantidadeArtigo.Name = "numQuantidadeArtigo";
            this.numQuantidadeArtigo.Size = new System.Drawing.Size(157, 22);
            this.numQuantidadeArtigo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantidade";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnremoveritem);
            this.groupBox4.Controls.Add(this.dtgcompra);
            this.groupBox4.Controls.Add(this.btnfinalizarcompra);
            this.groupBox4.Location = new System.Drawing.Point(526, 52);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 354);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // btnremoveritem
            // 
            this.btnremoveritem.Location = new System.Drawing.Point(19, 285);
            this.btnremoveritem.Name = "btnremoveritem";
            this.btnremoveritem.Size = new System.Drawing.Size(129, 52);
            this.btnremoveritem.TabIndex = 1;
            this.btnremoveritem.Text = "Remover Item Registado";
            this.btnremoveritem.UseVisualStyleBackColor = true;
            // 
            // dtgcompra
            // 
            this.dtgcompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgcompra.Location = new System.Drawing.Point(6, 13);
            this.dtgcompra.Name = "dtgcompra";
            this.dtgcompra.RowHeadersWidth = 51;
            this.dtgcompra.RowTemplate.Height = 24;
            this.dtgcompra.Size = new System.Drawing.Size(319, 248);
            this.dtgcompra.TabIndex = 0;
            // 
            // btnfinalizarcompra
            // 
            this.btnfinalizarcompra.Location = new System.Drawing.Point(175, 285);
            this.btnfinalizarcompra.Name = "btnfinalizarcompra";
            this.btnfinalizarcompra.Size = new System.Drawing.Size(139, 52);
            this.btnfinalizarcompra.TabIndex = 3;
            this.btnfinalizarcompra.Text = "Finalizar Compra";
            this.btnfinalizarcompra.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(358, 424);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Custo total da Compra:";
            // 
            // lbCustoTotaldaCompra
            // 
            this.lbCustoTotaldaCompra.AutoSize = true;
            this.lbCustoTotaldaCompra.Location = new System.Drawing.Point(506, 424);
            this.lbCustoTotaldaCompra.Name = "lbCustoTotaldaCompra";
            this.lbCustoTotaldaCompra.Size = new System.Drawing.Size(44, 16);
            this.lbCustoTotaldaCompra.TabIndex = 8;
            this.lbCustoTotaldaCompra.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(623, 424);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Orcamento Total:";
            // 
            // lbOrcamentoTotal
            // 
            this.lbOrcamentoTotal.AutoSize = true;
            this.lbOrcamentoTotal.Location = new System.Drawing.Point(739, 422);
            this.lbOrcamentoTotal.Name = "lbOrcamentoTotal";
            this.lbOrcamentoTotal.Size = new System.Drawing.Size(51, 16);
            this.lbOrcamentoTotal.TabIndex = 10;
            this.lbOrcamentoTotal.Text = "label10";
            // 
            // lbRestanteDisponivel
            // 
            this.lbRestanteDisponivel.AutoSize = true;
            this.lbRestanteDisponivel.Location = new System.Drawing.Point(746, 460);
            this.lbRestanteDisponivel.Name = "lbRestanteDisponivel";
            this.lbRestanteDisponivel.Size = new System.Drawing.Size(44, 16);
            this.lbRestanteDisponivel.TabIndex = 11;
            this.lbRestanteDisponivel.Text = "label8";
            // 
            // ModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1010, 487);
            this.Controls.Add(this.lbRestanteDisponivel);
            this.Controls.Add(this.btnVoltarInicio);
            this.Controls.Add(this.lbOrcamentoTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbCustoTotaldaCompra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModoCompra";
            this.Text = "ModoCompra";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNaoPrevisto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItensCompra)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidadeArtigo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgcompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVoltarInicio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnremoveritem;
        private System.Windows.Forms.DataGridView dtgcompra;
        private System.Windows.Forms.Button btnfinalizarcompra;
        private System.Windows.Forms.Button btnadicionaritem;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.NumericUpDown numQuantidadeArtigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbCustoTotaldaCompra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbOrcamentoTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbRestanteDisponivel;
        private System.Windows.Forms.DataGridView dtgItensCompra;
        private System.Windows.Forms.Label lbPreco;
        private System.Windows.Forms.TextBox txtPrecoNaoPrevisto;
        private System.Windows.Forms.NumericUpDown numNaoPrevisto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddNaoPrevisto;
        private System.Windows.Forms.ComboBox cbTipoArtigo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbArtigo;
    }
}