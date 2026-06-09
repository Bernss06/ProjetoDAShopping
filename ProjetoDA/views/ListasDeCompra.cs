using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProjetoDA.controllers;
using ProjetoDA.modelos;

namespace ProjetoDA.views
{
    public partial class ListasDeCompra : Form
    {
        private CompraController _compraController;
        private List<Compra> _todasAsCompras; // Guarda tudo em memória para os filtros serem super rápidos!

        public ListasDeCompra()
        {
            InitializeComponent();
            _compraController = new CompraController();

            // Ligar os eventos aos componentes que criaste no Designer
            this.Load += ListasDeCompra_Load;
            this.btnVoltarAoInicio.Click += BtnVoltarAoInicio_Click;

            // Ligar a ComboBox e a TextBox ao mesmo método de filtro
            this.cbListaDeCompras.SelectedIndexChanged += Filtros_Changed;
            this.txtPesquisaCustom.TextChanged += Filtros_Changed;
        }

        private void ListasDeCompra_Load(object sender, EventArgs e)
        {
            // 1. Configurar as opções do filtro
            cbListaDeCompras.Items.Add("Todas");
            cbListaDeCompras.Items.Add("Abertas");
            cbListaDeCompras.Items.Add("Fechadas");
            cbListaDeCompras.SelectedIndex = 0; // Seleciona a opção "Todas" por defeito

            // 2. Ir à base de dados buscar o histórico
            CarregarDadosDaBaseDeDados();
        }

        private void CarregarDadosDaBaseDeDados()
        {
            // Vai buscar todas as compras através do teu controlador
            _todasAsCompras = _compraController.getTodasAsCompras();

            // Chama o método para aplicar os filtros e preencher a grelha
            AplicarFiltros();
        }

        // Este evento dispara automaticamente sempre que mudas a ComboBox ou escreves na TextBox
        private void Filtros_Changed(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (_todasAsCompras == null) return;

            // Começamos com a lista completa
            var comprasFiltradas = _todasAsCompras.AsQueryable();

            // --- 1º FILTRO: Estado (ComboBox) ---
            string filtroEstado = cbListaDeCompras.SelectedItem?.ToString();
            if (filtroEstado == "Abertas")
            {
                comprasFiltradas = comprasFiltradas.Where(c => c.Fechada == false);
            }
            else if (filtroEstado == "Fechadas")
            {
                comprasFiltradas = comprasFiltradas.Where(c => c.Fechada == true);
            }

            // --- 2º FILTRO: Pesquisa Rápida (TextBox) ---
            string textoPesquisa = txtPesquisaCustom.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(textoPesquisa))
            {
                // Pesquisa pelo nome da compra ignorando maiúsculas/minúsculas
                comprasFiltradas = comprasFiltradas.Where(c => c.NomeCompra.ToLower().Contains(textoPesquisa));
            }

            // --- 3º: FORMATAR DADOS PARA A GRELHA ---
            var dadosGrelha = comprasFiltradas.Select(c => new
            {
                Id = c.Id,
                Nome = c.NomeCompra,
                Estado = c.Fechada ? "Fechada 🔒" : "Aberta 🛒",
                Criador = c.UserCria != null ? c.UserCria.Username : "N/A",
                Data = c.DataCriacao.ToString("dd/MM/yyyy HH:mm"),
                Total = c.ValorTotal.ToString("C2")
            }).ToList();

            // Preenche a tua drgListaDeTodasAsCompras
            drgListaDeTodasAsCompras.DataSource = dadosGrelha;

            // Esconder a coluna ID para ficar bonito
            if (drgListaDeTodasAsCompras.Columns["Id"] != null)
            {
                drgListaDeTodasAsCompras.Columns["Id"].Visible = false;
            }

            // Esticar as colunas para ocuparem a largura total da grelha
            drgListaDeTodasAsCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // --- BOTÃO DE VOLTAR AO INÍCIO ---
        private void BtnVoltarAoInicio_Click(object sender, EventArgs e)
        {
            var formInicio = new Form1();
            formInicio.Show();
            this.Close();
        }

        private void btnNovaCompra_Click(object sender, EventArgs e)
        {
            var novaCompra = new views.Planeamento();
            novaCompra.Show();
            this.Hide();    
        }
    }
}