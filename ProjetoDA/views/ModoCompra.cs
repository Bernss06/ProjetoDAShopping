using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProjetoDA.controllers;
using ProjetoDA.modelos;

namespace ProjetoDA.views
{
    public partial class ModoCompra : Form
    {
        private CompraController _compraController;
        private ItemCompraController _itemCompraController;
        private ArtigoController _artigoController;
        private TipoArtigoController _tipoArtigoController;
        private OrcamentoController _orcamentoController;

        private int _compraAbertaId = 0;
        private decimal _orcamentoMensal = 0;

        public ModoCompra()
        {
            InitializeComponent();

            _compraController = new CompraController();
            _itemCompraController = new ItemCompraController();
            _artigoController = new ArtigoController();
            _tipoArtigoController = new TipoArtigoController();
            _orcamentoController = new OrcamentoController();

            this.Load += ModoCompra_Load;
            this.btnVoltarInicio.Click += BtnVoltarInicio_Click;

            // Botões do carrinho
            this.btnadicionaritem.Click += BtnAtualizarPrevisto_Click;
            this.btnAddNaoPrevisto.Click += BtnAddNaoPrevisto_Click;
            this.btnremoveritem.Click += BtnRemoverItem_Click;
            this.btnfinalizarcompra.Click += BtnFinalizarCompra_Click;

            this.cbTipoArtigo.SelectedIndexChanged += CbTipoArtigo_SelectedIndexChanged;
        }

        private void ModoCompra_Load(object sender, EventArgs e)
        {
            // Ocultar labels de debug
            label3.Visible = false;
            label4.Visible = false;

            // Carregar todos os artigos para a nova grelha (dtg) de extras
            var todosArtigos = _artigoController.getArtigos().Select(a => new { Id = a.Id, Nome = a.Nome }).ToList();
            dtgItensCompra.DataSource = todosArtigos;
            if (dtgItensCompra.Columns["Id"] != null) dtgItensCompra.Columns["Id"].Visible = false;

            // Carregar filtros
            var tipos = _tipoArtigoController.getTiposArtigo();
            tipos.Insert(0, new TipoArtigo { Id = 0, Categoria = "-- Todos --" });
            cbTipoArtigo.DataSource = tipos;
            cbTipoArtigo.DisplayMember = "Categoria";
            cbTipoArtigo.ValueMember = "Id";
            CarregarArtigos(0);

            // Obter Orçamento
            var orcMes = _orcamentoController.getOrcamentos().FirstOrDefault(o => o.Mes == DateTime.Now.Month && o.Ano == DateTime.Now.Year);
            if (orcMes != null)
            {
                _orcamentoMensal = orcMes.ValorMaximo;
                lbOrcamentoTotal.Text = _orcamentoMensal.ToString("C2");
            }

            // Puxar a compra que deixaste aberta no Planeamento
            var comprasAbertas = _compraController.getComprasAbertas();
            if (comprasAbertas.Count > 0)
            {
                _compraAbertaId = comprasAbertas.First().Id;
                AtualizarGrelhaETotais();
            }
            else
            {
                MessageBox.Show("Não tens nenhuma lista em andamento! Vai ao ecrã de Planeamento criar uma primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnadicionaritem.Enabled = false;
                btnAddNaoPrevisto.Enabled = false;
                btnfinalizarcompra.Enabled = false;
            }
        }

        private void CarregarArtigos(int tipoId)
        {
            var artigos = _artigoController.getArtigos();
            if (tipoId > 0) artigos = artigos.Where(a => a.TipoArtigo.Id == tipoId).ToList();
            cbArtigo.DataSource = artigos;
            cbArtigo.DisplayMember = "Nome";
            cbArtigo.ValueMember = "Id";
        }

        private void CbTipoArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoArtigo.SelectedValue is int tipoId) CarregarArtigos(tipoId);
        }

        private void AtualizarGrelhaETotais()
        {
            if (_compraAbertaId == 0) return;

            var itens = _itemCompraController.getItensDaCompra(_compraAbertaId);

            var dadosGrelha = itens.Select(i => new {
                Id = i.Id,
                Artigo = i.Artigo.Nome,
                Tipo = (i is ItemPrevisto) ? "Previsto" : "Extra",
                QtdPlan = (i is ItemPrevisto p) ? p.QuantidadePrevista : 0,
                QtdReal = i.QuantidadeAdquirida,
                Preco = i.PrecoUnitario,
                SubTotal = i.QuantidadeAdquirida * i.PrecoUnitario
            }).ToList();

            dtgcompra.DataSource = dadosGrelha;

            if (dtgcompra.Columns["Id"] != null) dtgcompra.Columns["Id"].Visible = false;
            if (dtgcompra.Columns["Preco"] != null) dtgcompra.Columns["Preco"].DefaultCellStyle.Format = "C2";
            if (dtgcompra.Columns["SubTotal"] != null) dtgcompra.Columns["SubTotal"].DefaultCellStyle.Format = "C2";

            decimal totalCusto = itens.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
            lbCustoTotaldaCompra.Text = totalCusto.ToString("C2");

            decimal restante = _orcamentoMensal - totalCusto;
            lbRestanteDisponivel.Text = restante.ToString("C2");
            lbRestanteDisponivel.ForeColor = restante < 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        // --- ZONA 1: CONFIRMAR PREÇOS DE ITENS PLANEADOS ---
        private void BtnAtualizarPrevisto_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0 || cbArtigo.SelectedValue == null) return;

            int artigoId = (int)cbArtigo.SelectedValue;
            int qtdReal = (int)numQuantidadeArtigo.Value;

            if (!decimal.TryParse(txtPreco.Text.Replace('.', ','), out decimal precoReal) || precoReal < 0) return;

            // Procura o item planeado no carrinho para o atualizar
            var itemPlaneado = _itemCompraController.getItensDaCompra(_compraAbertaId)
                                .OfType<ItemPrevisto>()
                                .FirstOrDefault(i => i.Artigo.Id == artigoId);

            if (itemPlaneado != null)
            {
                if (_itemCompraController.editarQuantidadeAdquirida(itemPlaneado.Id, qtdReal, precoReal))
                {
                    AtualizarGrelhaETotais();
                    numQuantidadeArtigo.Value = 0;
                    txtPreco.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Este artigo não estava no teu planeamento! Usa a secção dos itens Não Previstos aí ao lado.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- ZONA 2: ADICIONAR EXTRAS AO CARRINHO (NÃO PREVISTOS) ---
        private void BtnAddNaoPrevisto_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0 || dtgItensCompra.CurrentRow == null) return;

            int artigoSelecionadoId = Convert.ToInt32(dtgItensCompra.CurrentRow.Cells["Id"].Value);
            int qtd = (int)numNaoPrevisto.Value;

            if (!decimal.TryParse(txtPrecoNaoPrevisto.Text.Replace('.', ','), out decimal preco) || preco < 0 || qtd <= 0) return;

            if (_compraController.adicionarItemNaoPrevisto(_compraAbertaId, artigoSelecionadoId, qtd, preco, "Encontrado na prateleira"))
            {
                AtualizarGrelhaETotais();
                numNaoPrevisto.Value = 0;
                txtPrecoNaoPrevisto.Text = "";
            }
        }

        private void BtnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dtgcompra.CurrentRow == null) return;

            int itemId = Convert.ToInt32(dtgcompra.CurrentRow.Cells["Id"].Value);
            if (MessageBox.Show("Tens a certeza que queres remover isto do carrinho?", "Remover", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _itemCompraController.removerItem(itemId);
                AtualizarGrelhaETotais();
            }
        }

        private void BtnFinalizarCompra_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0) return;

            if (MessageBox.Show("Desejas fechar a conta? Não poderás mexer mais nesta lista.", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int userId = SessionManager.UtilizadorLogadoId != 0 ? SessionManager.UtilizadorLogadoId : 1;

                if (_compraController.fecharCompra(_compraAbertaId, userId))
                {
                    MessageBox.Show("Lista fechada! Missão cumprida socio.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void BtnVoltarInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Os eventos vazios que criaste no fundo do código (deixa-os estar para não dar erro de compilação)
        private void txtPrecoNaoPrevisto_TextChanged(object sender, EventArgs e) { }
        private void numNaoPrevisto_ValueChanged(object sender, EventArgs e) { }
    }
}