using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProjetoDA.controllers;

namespace ProjetoDA.views
{
    public partial class ModoCompra : Form
    {
        // Controladores que vamos usar
        private CompraController _compraController;
        private ItemCompraController _itemCompraController;
        private ArtigoController _artigoController;

        public ModoCompra()
        {
            InitializeComponent();

            _compraController = new CompraController();
            _itemCompraController = new ItemCompraController();
            _artigoController = new ArtigoController();

            // Ligar os eventos (se não o tiveres feito nas propriedades visuais)
            this.Load += ModoCompra_Load;
            this.cbSelecionarCompra.SelectedIndexChanged += CbSelecionarCompra_SelectedIndexChanged;

            this.btnAtualizarItem.Click += BtnAtualizarItem_Click;
            this.btnAdicionarExtra.Click += BtnAdicionarExtra_Click;
            this.btnRemoverItem.Click += BtnRemoverItem_Click;
            this.btnFinalizarCompra.Click += BtnFinalizarCompra_Click;
        }

        private void ModoCompra_Load(object sender, EventArgs e)
        {
            // 1. Carregar Compras em Aberto
            var compras = _compraController.getComprasAbertas();
            cbSelecionarCompra.DataSource = compras;
            cbSelecionarCompra.DisplayMember = "NomeCompra";
            cbSelecionarCompra.ValueMember = "Id";

            // 2. Carregar TODOS os artigos para a lista de itens extras (Não Previstos)
            var artigos = _artigoController.getArtigos();
            cbArtigoMercado.DataSource = artigos;
            cbArtigoMercado.DisplayMember = "Nome";
            cbArtigoMercado.ValueMember = "Id";
        }

        private void CbSelecionarCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarGrelhaCarrinho();
        }

        // ==========================================
        // ATUALIZAR A GRELHA E O CUSTO TOTAL
        // ==========================================
        private void AtualizarGrelhaCarrinho()
        {
            if (cbSelecionarCompra.SelectedValue is int compraId)
            {
                var itens = _itemCompraController.getItensDaCompra(compraId);

                // Formatar dados para a DataGridView (dtgExecutionItems)
                var dadosGrelha = itens.Select(i => new {
                    Id = i.Id,
                    Artigo = i.Artigo.Nome,
                    QtdPrevista = (i is ItemPrevisto p) ? p.QuantidadePrevista : 0,
                    QtdReal = i.QuantidadeAdquirida,
                    PrecoUnitario = i.PrecoUnitario,
                    Subtotal = i.QuantidadeAdquirida * i.PrecoUnitario,
                    Tipo = (i is ItemPrevisto) ? "Planeado" : "Extra"
                }).ToList();

                dtgExecutionItems.DataSource = dadosGrelha;

                // Esconder o ID da base de dados e formatar as moedas
                if (dtgExecutionItems.Columns["Id"] != null)
                    dtgExecutionItems.Columns["Id"].Visible = false;

                if (dtgExecutionItems.Columns["PrecoUnitario"] != null)
                    dtgExecutionItems.Columns["PrecoUnitario"].DefaultCellStyle.Format = "C2";

                if (dtgExecutionItems.Columns["Subtotal"] != null)
                    dtgExecutionItems.Columns["Subtotal"].DefaultCellStyle.Format = "C2";

                // Calcular o Total da Compra em tempo real
                decimal totalCompra = itens.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
                lblCustoTotal.Text = $"Total da Compra: {totalCompra:C2}";
            }
            else
            {
                dtgExecutionItems.DataSource = null;
                lblCustoTotal.Text = "Total da Compra: 0,00 €";
            }
        }

        // ==========================================
        // AÇÃO 1: ATUALIZAR UM ITEM PREVISTO (Qtd/Preço Real)
        // ==========================================
        private void BtnAtualizarItem_Click(object sender, EventArgs e)
        {
            if (dtgExecutionItems.CurrentRow == null)
            {
                MessageBox.Show("Seleciona um item na tabela primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int itemId = Convert.ToInt32(dtgExecutionItems.CurrentRow.Cells["Id"].Value);
            int qtdReal = (int)numQtdReal.Value;
            decimal precoReal = numPrecoReal.Value;

            if (qtdReal < 0 || precoReal < 0) return;

            bool sucesso = _itemCompraController.editarQuantidadeAdquirida(itemId, qtdReal, precoReal);
            if (sucesso)
            {
                AtualizarGrelhaCarrinho();
                numQtdReal.Value = 0;
                numPrecoReal.Value = 0;
            }
        }

        // ==========================================
        // AÇÃO 2: ADICIONAR UM ITEM EXTRA (Não Previsto)
        // ==========================================
        private void BtnAdicionarExtra_Click(object sender, EventArgs e)
        {
            if (cbSelecionarCompra.SelectedValue == null || cbArtigoMercado.SelectedValue == null) return;

            int compraId = (int)cbSelecionarCompra.SelectedValue;
            int artigoId = (int)cbArtigoMercado.SelectedValue;
            int qtd = (int)numQtdExtra.Value;
            decimal preco = numPrecoExtra.Value;
            string obs = txtObservacoes.Text; // Pode ser vazio, cumpre a regra do ItemNaoPrevisto

            if (qtd <= 0 || preco < 0)
            {
                MessageBox.Show("A quantidade do item extra tem de ser maior que 0.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sucesso = _compraController.adicionarItemNaoPrevisto(compraId, artigoId, qtd, preco, obs);
            if (sucesso)
            {
                AtualizarGrelhaCarrinho();
                numQtdExtra.Value = 0;
                numPrecoExtra.Value = 0;
                txtObservacoes.Text = "";
            }
        }

        // ==========================================
        // AÇÃO 3: REMOVER ITEM DA TABELA
        // ==========================================
        private void BtnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dtgExecutionItems.CurrentRow == null) return;

            int itemId = Convert.ToInt32(dtgExecutionItems.CurrentRow.Cells["Id"].Value);
            DialogResult resp = MessageBox.Show("Queres apagar este item do carrinho?", "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                if (_itemCompraController.removerItem(itemId))
                    AtualizarGrelhaCarrinho();
            }
        }

        // ==========================================
        // AÇÃO 4: FECHAR E FINALIZAR A COMPRA
        // ==========================================
        private void BtnFinalizarCompra_Click(object sender, EventArgs e)
        {
            if (cbSelecionarCompra.SelectedValue == null) return;
            int compraId = (int)cbSelecionarCompra.SelectedValue;

            DialogResult resp = MessageBox.Show("Queres finalizar a compra? Ao fechar, não poderás alterar os itens.", "Finalizar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                // ATENÇÃO: Substitui o ID estático pelo ID do Utilizador do teu SessionManager
                // Exemplo: int userId = SessionManager.UtilizadorLogado.Id;
                int userId = 1;

                bool sucesso = _compraController.fecharCompra(compraId, userId);
                if (sucesso)
                {
                    MessageBox.Show("Compra finalizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ModoCompra_Load(null, null); // Faz refresh (a compra desaparece da lista)
                }
            }
        }
    }
}