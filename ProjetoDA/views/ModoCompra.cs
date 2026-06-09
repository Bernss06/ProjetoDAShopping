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

        // Vai guardar o ID que vem do Form1
        private int _compraAbertaId;
        private decimal _orcamentoMensal = 0;

        // NOVO CONSTRUTOR: Agora recebe obrigatoriamente um ID de compra!
        public ModoCompra(int compraSelecionadaId)
        {
            InitializeComponent();

            _compraController = new CompraController();
            _itemCompraController = new ItemCompraController();
            _artigoController = new ArtigoController();
            _tipoArtigoController = new TipoArtigoController();
            _orcamentoController = new OrcamentoController();

            _compraAbertaId = compraSelecionadaId;

            this.Load += ModoCompra_Load;
            this.btnVoltarInicio.Click += BtnVoltarInicio_Click;

            this.btnadicionaritem.Click += BtnAtualizarPrevisto_Click;
            this.btnAddNaoPrevisto.Click += BtnAddNaoPrevisto_Click;
            this.btnremoveritem.Click += BtnRemoverItem_Click;
            this.btnfinalizarcompra.Click += BtnFinalizarCompra_Click;

            this.cbTipoArtigo.SelectedIndexChanged += CbTipoArtigo_SelectedIndexChanged;
        }

        private void ModoCompra_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;

            var tipos = _tipoArtigoController.getTiposArtigo();
            tipos.Insert(0, new TipoArtigo { Id = 0, Categoria = "-- Todos --" });
            cbTipoArtigo.DataSource = tipos;
            cbTipoArtigo.DisplayMember = "Categoria";
            cbTipoArtigo.ValueMember = "Id";
            CarregarArtigos(0);

            var orcMes = _orcamentoController.getOrcamentos().FirstOrDefault(o => o.Mes == DateTime.Now.Month && o.Ano == DateTime.Now.Year);
            if (orcMes != null)
            {
                _orcamentoMensal = orcMes.ValorMaximo;
                lbOrcamentoTotal.Text = _orcamentoMensal.ToString("C2");
            }
            else
            {
                lbOrcamentoTotal.Text = "Sem Orçamento";
            }

            // Agora ele apenas arranca com o ID que lhe deste no Form1!
            if (_compraAbertaId > 0)
            {
                AtualizarGrelhasETotais();
            }
            else
            {
                MessageBox.Show("Erro a carregar a compra selecionada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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

        private void AtualizarGrelhasETotais()
        {
            if (_compraAbertaId == 0) return;

            var todosItens = _itemCompraController.getItensDaCompra(_compraAbertaId);

            var itensPlaneados = todosItens.OfType<ItemPrevisto>().Select(i => new {
                Id = i.Id,
                Artigo = i.Artigo.Nome,
                QtdPlaneada = i.QuantidadePrevista,
                Estado = i.QuantidadeAdquirida > 0 ? "No Carrinho ✔️" : "Pendente"
            }).ToList();

            dtgItensCompra.DataSource = itensPlaneados;
            if (dtgItensCompra.Columns["Id"] != null) dtgItensCompra.Columns["Id"].Visible = false;

            var itensNoCarrinho = todosItens.Where(i => i.QuantidadeAdquirida > 0).Select(i => new {
                Id = i.Id,
                Artigo = i.Artigo.Nome,
                Tipo = (i is ItemPrevisto) ? "Planeado" : "Extra",
                Qtd = i.QuantidadeAdquirida,
                Preco = i.PrecoUnitario,
                SubTotal = i.QuantidadeAdquirida * i.PrecoUnitario
            }).ToList();

            dtgcompra.DataSource = itensNoCarrinho;
            if (dtgcompra.Columns["Id"] != null) dtgcompra.Columns["Id"].Visible = false;
            if (dtgcompra.Columns["Preco"] != null) dtgcompra.Columns["Preco"].DefaultCellStyle.Format = "C2";
            if (dtgcompra.Columns["SubTotal"] != null) dtgcompra.Columns["SubTotal"].DefaultCellStyle.Format = "C2";

            decimal totalCusto = itensNoCarrinho.Sum(i => i.Qtd * i.Preco);
            lbCustoTotaldaCompra.Text = totalCusto.ToString("C2");

            decimal restante = _orcamentoMensal - totalCusto;
            lbRestanteDisponivel.Text = restante.ToString("C2");
            lbRestanteDisponivel.ForeColor = restante < 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        private void BtnAtualizarPrevisto_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0 || dtgItensCompra.CurrentRow == null) return;
            int itemId = Convert.ToInt32(dtgItensCompra.CurrentRow.Cells["Id"].Value);
            int qtdReal = (int)numQuantidadeArtigo.Value;

            if (!decimal.TryParse(txtPreco.Text.Replace('.', ','), out decimal precoReal) || precoReal <= 0 || qtdReal <= 0) return;

            if (_itemCompraController.editarQuantidadeAdquirida(itemId, qtdReal, precoReal))
            {
                AtualizarGrelhasETotais();
                numQuantidadeArtigo.Value = 0;
                txtPreco.Text = "";
            }
        }

        private void BtnAddNaoPrevisto_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0 || cbArtigo.SelectedValue == null) return;
            int artigoSelecionadoId = (int)cbArtigo.SelectedValue;
            int qtd = (int)numNaoPrevisto.Value;

            if (!decimal.TryParse(txtPrecoNaoPrevisto.Text.Replace('.', ','), out decimal preco) || preco <= 0 || qtd <= 0) return;

            if (_compraController.adicionarItemNaoPrevisto(_compraAbertaId, artigoSelecionadoId, qtd, preco, "Item Extra"))
            {
                AtualizarGrelhasETotais();
                numNaoPrevisto.Value = 0;
                txtPrecoNaoPrevisto.Text = "";
            }
        }

        private void BtnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dtgcompra.CurrentRow == null) return;
            int itemId = Convert.ToInt32(dtgcompra.CurrentRow.Cells["Id"].Value);
            string tipoItem = dtgcompra.CurrentRow.Cells["Tipo"].Value.ToString();

            if (MessageBox.Show("Tens a certeza que queres tirar isto do carrinho?", "Remover", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tipoItem == "Planeado") _itemCompraController.editarQuantidadeAdquirida(itemId, 0, 0);
                else _itemCompraController.removerItem(itemId);
                AtualizarGrelhasETotais();
            }
        }

        private void BtnFinalizarCompra_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0) return;

            if (MessageBox.Show("Desejas fechar a conta na caixa? Não poderás mexer mais nesta lista.", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int userId = SessionManager.UtilizadorLogadoId != 0 ? SessionManager.UtilizadorLogadoId : 1;

                if (_compraController.fecharCompra(_compraAbertaId, userId))
                {
                    MessageBox.Show("Lista fechada", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void BtnVoltarInicio_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}