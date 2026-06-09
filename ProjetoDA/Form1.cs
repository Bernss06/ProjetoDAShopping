using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoDA.controllers;
using ProjetoDA.modelos;

namespace ProjetoDA
{
    public partial class Form1 : Form
    {
        private CompraController compraController = new CompraController();

        public Form1()
        {
            InitializeComponent();
            // Quando o Form1 é fechado, limpar a sessão
            this.FormClosing += Form1_FormClosing;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarCompras();

            // 1. Mostrar o Nome do Utilizador Logado na label8
            int userId = SessionManager.UtilizadorLogadoId;

            if (userId != 0)
            {
                var _utilizadorController = new UtilizadorController();
                var user = _utilizadorController.getUtilizadores().FirstOrDefault(u => u.Id == userId);
                label8.Text = user != null ? user.Username : "Desconhecido";
            }
            else
            {
                label8.Text = "Visitante (Modo Debug)";
            }

            // 2. Mostrar a Data formatada na label9
            label9.Text = DateTime.Now.ToString("dddd, dd - HH:mm", new System.Globalization.CultureInfo("pt-PT"));
        }

        public void CarregarCompras()
        {
            try
            {
                // Buscar TODAS as compras
                List<Compra> compras = compraController.getTodasAsCompras();

                // Limpar as linhas anteriores
                grdCompras.DataSource = null;

                // Criar uma lista anônima com os dados que queremos exibir
                var dadosCompras = compras.Select(c => new
                {
                    Id = c.Id,
                    Nome = c.NomeCompra,
                    DataCriacao = c.DataCriacao,
                    Fechada = c.Fechada ? "Sim" : "Não",
                    ValorTotal = c.ValorTotal,
                    Utilizador = c.UserCria != null ? c.UserCria.ToString() : "N/A"
                }).ToList();

                grdCompras.DataSource = dadosCompras;

                // Configurar colunas do DataGrid
                if (grdCompras.Columns["Id"] != null)
                {
                    grdCompras.Columns["Id"].HeaderText = "ID";
                    grdCompras.Columns["Id"].Visible = false; // Esconde o ID para ficar mais limpo
                }
                if (grdCompras.Columns["Nome"] != null) grdCompras.Columns["Nome"].HeaderText = "Nome da Compra";
                if (grdCompras.Columns["DataCriacao"] != null) grdCompras.Columns["DataCriacao"].HeaderText = "Data de Criação";
                if (grdCompras.Columns["Fechada"] != null) grdCompras.Columns["Fechada"].HeaderText = "Fechada";
                if (grdCompras.Columns["ValorTotal"] != null) grdCompras.Columns["ValorTotal"].HeaderText = "Valor Total (€)";
                if (grdCompras.Columns["Utilizador"] != null) grdCompras.Columns["Utilizador"].HeaderText = "Utilizador";

                // Ajustar largura das colunas
                if (grdCompras.Columns["Nome"] != null) grdCompras.Columns["Nome"].Width = 130;
                if (grdCompras.Columns["DataCriacao"] != null) grdCompras.Columns["DataCriacao"].Width = 120;
                if (grdCompras.Columns["Fechada"] != null) grdCompras.Columns["Fechada"].Width = 70;
                if (grdCompras.Columns["ValorTotal"] != null) grdCompras.Columns["ValorTotal"].Width = 100;
                if (grdCompras.Columns["Utilizador"] != null) grdCompras.Columns["Utilizador"].Width = 110;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar compras: " + ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Limpa a sessão ao fechar o Form1
            SessionManager.ClearSession();
        }

        private void btnorcamento_Click(object sender, EventArgs e)
        {
            var orcamentoForm = new views.Orcamento(this);
            orcamentoForm.Show();
            this.Hide();
        }

        private void btnplaneamento_Click(object sender, EventArgs e)
        {
            var planeamentoForm = new views.Planeamento();
            planeamentoForm.Show();
            this.Hide();
        }

        private void btnartigo_Click(object sender, EventArgs e)
        {
            var artigoForm = new views.Artigos();
            artigoForm.Show();
            this.Hide();
        }

        private void btntipoartigo_Click(object sender, EventArgs e)
        {
            var tipoArtigosForm = new views.TipoArtigos();
            tipoArtigosForm.Show();
            this.Hide();
        }

        public void AtualizarOrcamentoLabel(int valor)
        {
            // Atualiza a label com o novo valor do orçamento
            // lblOrcamento.Text = valor.ToString("C");
        }

        private void btncompra_Click(object sender, EventArgs e)
        {
            // Mantido caso precises, mas a abrir com ID 0
            var modoCompraForm = new views.ModoCompra(0);
            modoCompraForm.Show();
            this.Hide();
        }

        private void btncompra_Click_1(object sender, EventArgs e)
        {
            // Mantido caso precises, mas a abrir com ID 0
            var modoCompraForm = new views.ModoCompra(0);
            modoCompraForm.Show();
            this.Hide();
        }

        private void grdCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnnovacompra_Click(object sender, EventArgs e)
        {
            var planeamentoForm = new views.Planeamento();
            planeamentoForm.Show();
            this.Hide();
        }

        // =======================================================
        // AQUI ESTÁ A LÓGICA DE ABRIR A COMPRA SELECIONADA NA GRELHA
        // =======================================================
        private void btnfecharcompra_Click(object sender, EventArgs e)
        {
            if (grdCompras.CurrentRow != null)
            {
                int compraSelecionadaId = Convert.ToInt32(grdCompras.CurrentRow.Cells["Id"].Value);

                var modoCompraForm = new views.ModoCompra(compraSelecionadaId);

                this.Hide();
                modoCompraForm.ShowDialog(); // Pausa o Form1 até o ModoCompra fechar

                this.Show();
                CarregarCompras(); // Atualiza a grelha quando voltares!
            }
            else
            {
                MessageBox.Show("Seleciona uma compra na tabela primeiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            var registerForm = new views.FormRegistro();
            registerForm.Show();
            this.Hide();
        }
    }
}