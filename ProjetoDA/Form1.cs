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
        // Procura o user na BD através do ID guardado na sessão
        var user = _utilizadorController.getUtilizadores().FirstOrDefault(u => u.Id == userId);
        
        // Se encontrar, mete o nome. Se der algum erro bizarro, previne falhas.
        label8.Text = user != null ? user.Username : "Desconhecido";
    }
    else
    {
        // Caso estejas a arrancar a app diretamente no Form1 sem passar pelo Login para testar
        label8.Text = "Visitante (Modo Debug)"; 
    }

    // 2. Mostrar a Data formatada na label9
    // dddd = dia da semana (ex: terça-feira)
    // dd = dia do mês (ex: 09)
    // HH:mm = horas e minutos (ex: 15:00)
    label9.Text = DateTime.Now.ToString("dddd, dd - HH:mm", new System.Globalization.CultureInfo("pt-PT"));
}

        private void CarregarCompras()
        {
            try
            {
                // Buscar TODAS as compras (abertas e fechadas)
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
                grdCompras.Columns["Id"].HeaderText = "ID";
                grdCompras.Columns["Nome"].HeaderText = "Nome da Compra";
                grdCompras.Columns["DataCriacao"].HeaderText = "Data de Criação";
                grdCompras.Columns["Fechada"].HeaderText = "Fechada";
                grdCompras.Columns["ValorTotal"].HeaderText = "Valor Total (€)";
                grdCompras.Columns["Utilizador"].HeaderText = "Utilizador";
                
                // Ajustar largura das colunas
                grdCompras.Columns["Id"].Width = 40;
                grdCompras.Columns["Nome"].Width = 130;
                grdCompras.Columns["DataCriacao"].Width = 120;
                grdCompras.Columns["Fechada"].Width = 70;
                grdCompras.Columns["ValorTotal"].Width = 100;
                grdCompras.Columns["Utilizador"].Width = 110;
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
            // Abre a view de Orçamento passando uma referência a este Form1
            var orcamentoForm = new views.Orcamento(this);
            orcamentoForm.Show();
            this.Hide();
        }

        private void btnplaneamento_Click(object sender, EventArgs e)
        {
            
                // Abre a view de Planeamento e esconde o Form1
                var planeamentoForm = new views.Planeamento();
                planeamentoForm.Show();
                this.Hide();
            
        }

        private void btnartigo_Click(object sender, EventArgs e)
        {

            // Abre a view de Artigos e esconde o Form1
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
            var modoCompraForm = new views.ModoCompra();
            modoCompraForm.Show();
            this.Hide();
        }

        private void btncompra_Click_1(object sender, EventArgs e)
        {
            var modoCompraForm = new views.ModoCompra();
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

        private void btnfecharcompra_Click(object sender, EventArgs e)
        {
            var modoCompraForm = new views.ModoCompra();
            modoCompraForm.Show();
            this.Hide();
        }
    }
}
