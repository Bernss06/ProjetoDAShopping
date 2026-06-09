using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ProjetoDA.controllers;

namespace ProjetoDA.views
{
    public partial class Orcamento : Form
    {
        private readonly OrcamentoController _orcamentoController;
        private readonly int _utilizadorLogadoId;
        private int _mesSelecionado;
        private int _anoSelecionado;

        private Form1 _parent;

        public Orcamento()
        {
            InitializeComponent();
            _orcamentoController = new OrcamentoController();
            _utilizadorLogadoId = SessionManager.UtilizadorLogadoId;
            _mesSelecionado = DateTime.Now.Month;
            _anoSelecionado = DateTime.Now.Year;

            this.Load += Orcamento_Load;
            this.btndefinirOrçamento.Click += btndefinirOrçamento_Click;
            this.btnVoltarInicio.Click += btnVoltarInicio_Click;

            // IMPORTANTE: Muda aqui o nome se a tua grelha se chamar de outra forma!
            // this.dataGridViewOrcamentos.CellClick += DataGridViewOrcamentos_CellClick;
        }

        public Orcamento(Form1 parent) : this()
        {
            _parent = parent;
        }

        private void Orcamento_Load(object sender, EventArgs e)
        {
            CarregarOrcamentoAtual();
            CarregarGrelhaOrcamentos();
        }

        private void CarregarOrcamentoAtual()
        {
            try
            {
                var orcamentos = _orcamentoController.getOrcamentos();
                var orcAtual = orcamentos.FirstOrDefault(o => o.Mes == _mesSelecionado && o.Ano == _anoSelecionado);

                if (orcAtual != null)
                {
                    lblOrcamentos.Text = orcAtual.ValorMaximo.ToString("C2", CultureInfo.CurrentCulture);
                    txtOrcamento.Text = orcAtual.ValorMaximo.ToString("N2", CultureInfo.CurrentCulture);
                    _parent?.AtualizarOrcamentoLabel((int)orcAtual.ValorMaximo);
                }
                else
                {
                    lblOrcamentos.Text = "Ainda sem orçamento definido";
                    txtOrcamento.Text = string.Empty;
                }

                // Garante que se estivermos no mês atual, os controlos estão ativos
                txtOrcamento.Enabled = true;
                btndefinirOrçamento.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 1. CARREGAR A GRELHA COM O HISTÓRICO
        // ==========================================
        private void CarregarGrelhaOrcamentos()
        {
            var todosOrcamentos = _orcamentoController.getOrcamentos()
                                    .OrderByDescending(o => o.Ano)
                                    .ThenByDescending(o => o.Mes)
                                    .ToList();

            var dadosGrelha = todosOrcamentos.Select(o => new
            {
                Id = o.Id,
                Periodo = $"{o.Mes:D2}/{o.Ano}",
                Valor = o.ValorMaximo.ToString("C2", CultureInfo.CurrentCulture),
                CriadoPor = o.UserCria?.Username ?? "N/A",
                Estado = (o.Mes == DateTime.Now.Month && o.Ano == DateTime.Now.Year) ? "Atual (Editável)" : "Fechado 🔒"
            }).ToList();


            dtgOrcamentos.DataSource = dadosGrelha;
            if (dtgOrcamentos.Columns["Id"] != null) dtgOrcamentos.Columns["Id"].Visible = false;
            dtgOrcamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }

        // ==========================================
        // 2. LÓGICA DE BLOQUEIO AO CLICAR NA GRELHA
        // ==========================================
        private void DataGridViewOrcamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                string estado = dtgOrcamentos.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
                
                if (estado == "Fechado 🔒")
                {
                    // Bloqueia a edição
                    txtOrcamento.Text = dtgOrcamentos.Rows[e.RowIndex].Cells["Valor"].Value.ToString();
                    txtOrcamento.Enabled = false;
                    btndefinirOrçamento.Enabled = false;
                }
                else
                {
                    // Liberta para edição
                    txtOrcamento.Enabled = true;
                    btndefinirOrçamento.Enabled = true;
                    CarregarOrcamentoAtual(); // Volta a carregar os dados limpos para editar
                }
            }
            
        }

        private void btndefinirOrçamento_Click(object sender, EventArgs e)
        {
            var texto = txtOrcamento.Text?.Trim();
            if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out var valor) || valor < 0)
            {
                MessageBox.Show("Valor inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = SessionManager.UtilizadorLogadoId != 0 ? SessionManager.UtilizadorLogadoId : 1;

            if (_orcamentoController.salvarOuAtualizarOrcamento(_mesSelecionado, _anoSelecionado, valor, userId))
            {
                CarregarOrcamentoAtual();
                CarregarGrelhaOrcamentos(); // Atualiza a tabela logo após gravar!
                _parent?.AtualizarOrcamentoLabel((int)valor);
                MessageBox.Show("Orçamento atualizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVoltarInicio_Click(object sender, EventArgs e)
        {
            if (_parent != null) _parent.Show();
            else new Form1().Show();
            this.Hide();
        }
    }
}