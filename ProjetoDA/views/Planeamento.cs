using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProjetoDA.controllers;

namespace ProjetoDA.views
{
    public partial class Planeamento : Form
    {
        // 1. Instanciar os controladores necessários
        private CompraController _compraController;
        private ArtigoController _artigoController;
        private TipoArtigoController _tipoArtigoController;
        private ItemCompraController _itemCompraController;

        public Planeamento()
        {
            InitializeComponent();

            // Inicializar controladores
            _compraController = new CompraController();
            _artigoController = new ArtigoController();
            _tipoArtigoController = new TipoArtigoController();
            _itemCompraController = new ItemCompraController();

            // 2. Ligar os eventos do formulário aos botões e dropdowns
            this.Load += Planeamento_Load;
            this.btnVoltarInicio.Click += BtnVoltarInicio_Click;

            this.cbSelecionarCompra.SelectedIndexChanged += CbSelecionarCompra_SelectedIndexChanged;
            this.comboTipoArtigo.SelectedIndexChanged += ComboTipoArtigo_SelectedIndexChanged;

            this.btnAddItem.Click += BtnAddItem_Click;
            this.btnRemoveItem.Click += BtnRemoveItem_Click;
        }

        // ------------------------------------------------------------------
        // EVENTOS DE ARRANQUE DO FORMULÁRIO
        // ------------------------------------------------------------------
        private void Planeamento_Load(object sender, EventArgs e)
        {
            CarregarComprasAbertas();
            CarregarTiposArtigo();
            CarregarArtigos(0); // O zero significa que carrega todos inicialmente
            AtualizarGrelhaDeItens();
        }

        private void CarregarComprasAbertas()
        {
            var comprasAbertas = _compraController.getComprasAbertas();

            cbSelecionarCompra.DataSource = comprasAbertas;
            cbSelecionarCompra.DisplayMember = "NomeCompra"; // O que o utilizador lê
            cbSelecionarCompra.ValueMember = "Id";           // O valor que fica guardado por trás

            if (comprasAbertas.Count == 0)
            {
                MessageBox.Show("Não tem nenhuma Lista de Compras em aberto! Para planear, deve primeiro ir criar uma lista nova.", "Sem Listas Abertas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAddItem.Enabled = false;
                btnRemoveItem.Enabled = false;
            }
        }

        private void CarregarTiposArtigo()
        {
            var tipos = _tipoArtigoController.getTiposArtigo();

            // Adicionamos a opção "Todos" no topo da lista para não obrigar a filtrar
            tipos.Insert(0, new TipoArtigo { Id = 0, Categoria = "-- Todas as Categorias --" });

            comboTipoArtigo.DataSource = tipos;
            comboTipoArtigo.DisplayMember = "Categoria";
            comboTipoArtigo.ValueMember = "Id";
        }

        private void CarregarArtigos(int tipoArtigoId)
        {
            var artigos = _artigoController.getArtigos();

            // Se o utilizador escolheu uma categoria específica, filtramos a lista!
            if (tipoArtigoId > 0)
            {
                artigos = artigos.Where(a => a.TipoArtigo.Id == tipoArtigoId).ToList();
            }

            comboArtigo.DataSource = artigos;
            comboArtigo.DisplayMember = "Nome";
            comboArtigo.ValueMember = "Id";
        }

        // ------------------------------------------------------------------
        // EVENTOS INTERATIVOS
        // ------------------------------------------------------------------

        // Quando o utilizador muda a Categoria no menu suspenso
        private void ComboTipoArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipoArtigo.SelectedValue is int tipoId)
            {
                CarregarArtigos(tipoId); // Recarrega os artigos só daquela categoria
            }
        }

        // Quando o utilizador muda de Lista de Compras
        private void CbSelecionarCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarGrelhaDeItens();
        }

        // Vai à base de dados buscar os itens da compra e desenha a tabela
        private void AtualizarGrelhaDeItens()
        {
            if (cbSelecionarCompra.SelectedValue is int compraId)
            {
                var itensGerais = _itemCompraController.getItensDaCompra(compraId);

                // O planeamento só lida com "ItemPrevisto" (ignoramos os NaoPrevistos aqui)
                var itensFormatadosParaTabela = itensGerais.OfType<ItemPrevisto>().Select(i => new
                {
                    Id = i.Id,
                    Artigo = i.Artigo.Nome,
                    Categoria = i.Artigo.TipoArtigo.Categoria,
                    Quantidade = i.QuantidadePrevista
                }).ToList();

                dtgCompras.DataSource = itensFormatadosParaTabela;

                // Escondemos a coluna do ID porque o utilizador não precisa de ver números de base de dados
                if (dtgCompras.Columns["Id"] != null)
                {
                    dtgCompras.Columns["Id"].Visible = false;
                }
            }
            else
            {
                dtgCompras.DataSource = null;
            }
        }

        // ------------------------------------------------------------------
        // BOTÕES DE AÇÃO
        // ------------------------------------------------------------------
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (cbSelecionarCompra.SelectedValue == null || comboArtigo.SelectedValue == null)
            {
                MessageBox.Show("Selecione uma lista de compras e um artigo válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int compraId = (int)cbSelecionarCompra.SelectedValue;
            int artigoId = (int)comboArtigo.SelectedValue;
            int quantidade = (int)numArtigo.Value;

            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade prevista tem de ser pelo menos 1.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chama o Controller da Compra que salva na BD
            bool sucesso = _compraController.adicionarItemPrevisto(compraId, artigoId, quantidade);

            if (sucesso)
            {
                AtualizarGrelhaDeItens(); // Faz refresh à tabela
                numArtigo.Value = 0;      // Limpa a caixinha do número
            }
            else
            {
                MessageBox.Show("Erro ao adicionar o item à base de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dtgCompras.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma linha na tabela para remover.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int itemIdParaApagar = Convert.ToInt32(dtgCompras.CurrentRow.Cells["Id"].Value);

            DialogResult resposta = MessageBox.Show("Tem a certeza que deseja remover este item do planeamento?", "Confirmar Remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                bool sucesso = _itemCompraController.removerItem(itemIdParaApagar);

                if (sucesso)
                {
                    AtualizarGrelhaDeItens(); // Faz refresh à tabela para o item desaparecer
                }
                else
                {
                    MessageBox.Show("Não foi possível remover o item.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnVoltarInicio_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close(); // Fecha a página do planeamento para poupar memória
        }

    }
}