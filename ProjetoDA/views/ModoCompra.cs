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

            // Ligar Eventos
            this.Load += ModoCompra_Load;
            this.btnVoltarInicio.Click += BtnVoltarInicio_Click;
            this.btniniciarcompra.Click += BtnIniciarCompra_Click;
            this.btnadicionaritem.Click += BtnAdicionarItem_Click;
            this.btneditarpreco.Click += BtnEditarPreco_Click;
            this.btnremoveritem.Click += BtnRemoverItem_Click;
            this.btnGuadarCompra.Click += BtnGuardarCompra_Click;
            this.btnfinalizarcompra.Click += BtnFinalizarCompra_Click;

            this.cbTipoArtigo.SelectedIndexChanged += CbTipoArtigo_SelectedIndexChanged;
        }

        // ==========================================
        // 1. CARREGAMENTO INICIAL
        // ==========================================
        private void ModoCompra_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;

            // ERRO CORRIGIDO AQUI: Usar 'Categoria' como está no teu modelo
            var tipos = _tipoArtigoController.getTiposArtigo();
            tipos.Insert(0, new TipoArtigo { Id = 0, Categoria = "-- Todos --" });
            cbTipoArtigo.DataSource = tipos;
            cbTipoArtigo.DisplayMember = "Categoria";
            cbTipoArtigo.ValueMember = "Id";

            CarregarArtigos(0);

            // Obter o Orçamento deste mês
            var orcamentos = _orcamentoController.getOrcamentos();
            var orcMes = orcamentos.FirstOrDefault(o => o.Mes == DateTime.Now.Month && o.Ano == DateTime.Now.Year);
            if (orcMes != null)
            {
                _orcamentoMensal = orcMes.ValorMaximo;
                lbOrcamentoTotal.Text = _orcamentoMensal.ToString("C2");
            }
            else
            {
                lbOrcamentoTotal.Text = "Sem Orçamento";
            }

            // A NOVA LÓGICA: Verificar se já existe uma compra aberta
            var comprasAbertas = _compraController.getComprasAbertas();
            if (comprasAbertas.Count > 0)
            {
                // Já existe uma lista em andamento! Carrega-a.
                var compraAtual = comprasAbertas.First();
                _compraAbertaId = compraAtual.Id;

                txtnomeCompra.Text = compraAtual.NomeCompra;
                txtnomeCompra.ReadOnly = true;
                btniniciarcompra.Enabled = false; // Já está iniciada

                AtualizarGrelhaETotais();
            }
            else
            {
                // Não existe nenhuma compra aberta. Prepara a interface para criar uma nova.
                txtnomeCompra.Text = "";
                txtnomeCompra.ReadOnly = false;
                btniniciarcompra.Enabled = true;

                // Desativa os botões de adicionar itens até a pessoa clicar em "Iniciar Compra"
                btnadicionaritem.Enabled = false;
                btneditarpreco.Enabled = false;
                btnremoveritem.Enabled = false;
                btnfinalizarcompra.Enabled = false;

                MessageBox.Show("Não tens nenhuma lista em aberto. Escreve o nome da tua nova compra e clica em 'Iniciar Compra' para começares a registar!", "Nova Lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CbTipoArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoArtigo.SelectedValue is int tipoId)
            {
                CarregarArtigos(tipoId);
            }
        }

        private void CarregarArtigos(int tipoId)
        {
            var artigos = _artigoController.getArtigos();
            if (tipoId > 0)
            {
                artigos = artigos.Where(a => a.TipoArtigo.Id == tipoId).ToList();
            }
            cbArtigo.DataSource = artigos;
            cbArtigo.DisplayMember = "Nome";
            cbArtigo.ValueMember = "Id";
        }

        // ==========================================
        // 2. ATUALIZAR GRELHA E CÁLCULO DE TOTAIS
        // ==========================================
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

            if (restante < 0) lbRestanteDisponivel.ForeColor = System.Drawing.Color.Red;
            else lbRestanteDisponivel.ForeColor = System.Drawing.Color.Green;

            rtxtInformacoesCompra.Text = $"Estado: Em curso...\nTotal de Itens Físicos: {itens.Sum(i => i.QuantidadeAdquirida)}\nItens Diferentes: {itens.Count}";
        }

        // ==========================================
        // 3. AÇÕES DOS BOTÕES
        // ==========================================

        private void BtnIniciarCompra_Click(object sender, EventArgs e)
        {
            string nomeDaCompra = txtnomeCompra.Text.Trim();

            if (string.IsNullOrEmpty(nomeDaCompra))
            {
                MessageBox.Show("Por favor, escreve um nome para a tua lista de compras (Ex: Compras da Semana).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = SessionManager.UtilizadorLogadoId != 0 ? SessionManager.UtilizadorLogadoId : 1;

            if (_compraController.criarCompra(nomeDaCompra, userId))
            {
                var novaCompra = _compraController.getComprasAbertas().LastOrDefault();
                if (novaCompra != null)
                {
                    _compraAbertaId = novaCompra.Id;

                    txtnomeCompra.ReadOnly = true;
                    btniniciarcompra.Enabled = false;

                    btnadicionaritem.Enabled = true;
                    btneditarpreco.Enabled = true;
                    btnremoveritem.Enabled = true;
                    btnfinalizarcompra.Enabled = true;

                    AtualizarGrelhaETotais();
                    MessageBox.Show("Lista criada e guardada! Já podes começar a registar os artigos.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Erro ao criar a compra na base de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdicionarItem_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0 || cbArtigo.SelectedValue == null) return;

            int artigoId = (int)cbArtigo.SelectedValue;
            int qtd = (int)numQuantidadeArtigo.Value;

            string precoTexto = txtPreco.Text.Replace('.', ',');
            if (!decimal.TryParse(precoTexto, out decimal preco) || preco < 0)
            {
                MessageBox.Show("Preço inválido! Insere um valor numérico correto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (qtd <= 0)
            {
                MessageBox.Show("A quantidade tem de ser pelo menos 1.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sucesso = _compraController.adicionarItemNaoPrevisto(_compraAbertaId, artigoId, qtd, preco, "Adicionado no carrinho");
            if (sucesso)
            {
                AtualizarGrelhaETotais();
                LimparInputs();
            }
        }

        private void BtnEditarPreco_Click(object sender, EventArgs e)
        {
            if (dtgcompra.CurrentRow == null)
            {
                MessageBox.Show("Seleciona uma linha na tabela primeiro!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int itemId = Convert.ToInt32(dtgcompra.CurrentRow.Cells["Id"].Value);
            int qtdReal = (int)numQuantidadeArtigo.Value;

            string precoTexto = txtPreco.Text.Replace('.', ',');
            if (!decimal.TryParse(precoTexto, out decimal precoReal) || precoReal < 0)
            {
                MessageBox.Show("Preço inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_itemCompraController.editarQuantidadeAdquirida(itemId, qtdReal, precoReal))
            {
                AtualizarGrelhaETotais();
                LimparInputs();
            }
        }

        private void BtnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dtgcompra.CurrentRow == null) return;

            int itemId = Convert.ToInt32(dtgcompra.CurrentRow.Cells["Id"].Value);
            if (MessageBox.Show("Tens a certeza que queres remover este item do carrinho?", "Remover", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _itemCompraController.removerItem(itemId);
                AtualizarGrelhaETotais();
            }
        }

        private void BtnGuardarCompra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A tua lista está segura e é gravada automaticamente a cada alteração!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnFinalizarCompra_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0) return;

            if (MessageBox.Show("Desejas finalizar a compra? O estado passará a Fechada e já não poderás alterar os itens.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int userId = SessionManager.UtilizadorLogadoId != 0 ? SessionManager.UtilizadorLogadoId : 1;

                if (_compraController.fecharCompra(_compraAbertaId, userId))
                {
                    MessageBox.Show("Compra fechada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void BtnVoltarInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimparInputs()
        {
            numQuantidadeArtigo.Value = 0;
            txtPreco.Text = "";
        }

        private void btnAddNaoPrevisto_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecoNaoPrevisto_TextChanged(object sender, EventArgs e)
        {

        }

        private void numNaoPrevisto_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}