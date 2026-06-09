using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProjetoDA.controllers;
using ProjetoDA.modelos;

namespace ProjetoDA.views
{
    public partial class Planeamento : Form
    {
        private CompraController _compraController;
        private ArtigoController _artigoController;
        private TipoArtigoController _tipoArtigoController;
        private ItemCompraController _itemCompraController;

        private int _compraAbertaId = 0; // Guarda a lista que estamos a planear

        public Planeamento()
        {
            InitializeComponent();

            _compraController = new CompraController();
            _artigoController = new ArtigoController();
            _tipoArtigoController = new TipoArtigoController();
            _itemCompraController = new ItemCompraController();

            this.Load += Planeamento_Load;
            this.btnVoltarInicio.Click += BtnVoltarInicio_Click;
            this.comboTipoArtigo.SelectedIndexChanged += ComboTipoArtigo_SelectedIndexChanged;
            this.btnAddCompra.Click += BtnAddCompra_Click;
            this.btnAddItem.Click += BtnAddItem_Click;
            this.btnRemoveItem.Click += BtnRemoveItem_Click;
        }

        private void Planeamento_Load(object sender, EventArgs e)
        {
            CarregarTiposArtigo();
            CarregarArtigos(0);

            // Verifica se já deixaste uma lista a meio
            var comprasAbertas = _compraController.getComprasAbertas();
            if (comprasAbertas.Count > 0)
            {
                var compraAtual = comprasAbertas.First();
                _compraAbertaId = compraAtual.Id;

                txtnomeCompra.Text = compraAtual.NomeCompra;
                txtnomeCompra.ReadOnly = true;
                btnAddCompra.Enabled = false;

                AtualizarGrelhaDeItens();
            }
            else
            {
                // Modo criação de lista nova
                btnAddItem.Enabled = false;
                btnRemoveItem.Enabled = false;
            }
        }

        // --- CRIAR A COMPRA ABERTA ---
        private void BtnAddCompra_Click(object sender, EventArgs e)
        {
            string nome = txtnomeCompra.Text.Trim();
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Escreve um nome para a tua lista de planeamento!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = SessionManager.UtilizadorLogadoId != 0 ? SessionManager.UtilizadorLogadoId : 1;

            if (_compraController.criarCompra(nome, userId))
            {
                _compraAbertaId = _compraController.getComprasAbertas().Last().Id;

                txtnomeCompra.ReadOnly = true;
                btnAddCompra.Enabled = false;
                btnAddItem.Enabled = true;
                btnRemoveItem.Enabled = true;

                AtualizarGrelhaDeItens();
                MessageBox.Show("Lista criada! Já podes começar a planear os teus artigos.", "Boa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CarregarTiposArtigo()
        {
            var tipos = _tipoArtigoController.getTiposArtigo();
            tipos.Insert(0, new TipoArtigo { Id = 0, Categoria = "-- Todos --" });
            comboTipoArtigo.DataSource = tipos;
            comboTipoArtigo.DisplayMember = "Categoria";
            comboTipoArtigo.ValueMember = "Id";
        }

        private void CarregarArtigos(int tipoId)
        {
            var artigos = _artigoController.getArtigos();
            if (tipoId > 0) artigos = artigos.Where(a => a.TipoArtigo.Id == tipoId).ToList();
            comboArtigo.DataSource = artigos;
            comboArtigo.DisplayMember = "Nome";
            comboArtigo.ValueMember = "Id";
        }

        private void ComboTipoArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipoArtigo.SelectedValue is int tipoId) CarregarArtigos(tipoId);
        }

        private void AtualizarGrelhaDeItens()
        {
            if (_compraAbertaId != 0)
            {
                var itensFormatados = _itemCompraController.getItensDaCompra(_compraAbertaId)
                    .OfType<ItemPrevisto>()
                    .Select(i => new { Id = i.Id, Artigo = i.Artigo.Nome, Qtd = i.QuantidadePrevista })
                    .ToList();

                dtgCompras.DataSource = itensFormatados;
                if (dtgCompras.Columns["Id"] != null) dtgCompras.Columns["Id"].Visible = false;
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0 || comboArtigo.SelectedValue == null) return;

            int artigoId = (int)comboArtigo.SelectedValue;
            int qtd = (int)numArtigo.Value;

            if (qtd <= 0) return;

            if (_compraController.adicionarItemPrevisto(_compraAbertaId, artigoId, qtd))
            {
                AtualizarGrelhaDeItens();
                numArtigo.Value = 0;
            }
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dtgCompras.CurrentRow == null) return;
            int itemId = Convert.ToInt32(dtgCompras.CurrentRow.Cells["Id"].Value);

            if (_itemCompraController.removerItem(itemId)) AtualizarGrelhaDeItens();
        }

        private void BtnVoltarInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}