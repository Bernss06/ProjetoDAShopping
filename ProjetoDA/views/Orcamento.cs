using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            this.btndefinirOrçamento.Click += btndefinirOrçamento_Click;
            this.btnVoltarInicio.Click += btnVoltarInicio_Click;
        }

        public Orcamento(Form1 parent) : this()
        {
            _parent = parent;
        }

        private void CarregarOrcamento()
        {
            try
            {
                var orcamentos = _orcamentoController.getOrcamentos();
                var orcamentoAtual = orcamentos.FirstOrDefault(o => o.Mes == _mesSelecionado && o.Ano == _anoSelecionado);

                if (orcamentoAtual != null)
                {
                    lblOrcamentos.Text = FormatCurrency(orcamentoAtual.ValorMaximo);
                    txtOrcamento.Text = orcamentoAtual.ValorMaximo.ToString("N2", CultureInfo.CurrentCulture);

                    // Adicionado o (int) para converter e não dar erro de incompatibilidade com o Form1
                    _parent?.AtualizarOrcamentoLabel((int)orcamentoAtual.ValorMaximo);
                }
                else
                {
                    lblOrcamentos.Text = "Ainda sem orçamento definido";
                    txtOrcamento.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o orçamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndefinirOrçamento_Click(object sender, EventArgs e)
        {
            var texto = txtOrcamento.Text?.Trim();
            if (string.IsNullOrEmpty(texto))
            {
                MessageBox.Show("Introduza um valor para o orçamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // AQUI: Passou a decimal.TryParse para aceitar números com vírgula!
            if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out var valor))
            {
                MessageBox.Show("Formato inválido. Use números válidos (ex.: 1000 ou 1000,50).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (valor < 0)
            {
                MessageBox.Show("O orçamento não pode ser negativo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int userId = SessionManager.UtilizadorLogadoId;

                if (userId == 0)
                {
                    MessageBox.Show("Erro: Nenhum utilizador logado. Por favor, faça login novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool sucesso = _orcamentoController.salvarOuAtualizarOrcamento(_mesSelecionado, _anoSelecionado, valor, userId);

                if (sucesso)
                {
                    CarregarOrcamento();

                    // Adicionado o (int) para o Form1
                    _parent?.AtualizarOrcamentoLabel((int)valor);

                    MessageBox.Show("Orçamento guardado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao gravar o orçamento. Utilizador não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gravar o orçamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltarInicio_Click(object sender, EventArgs e)
        {
            if (_parent != null)
            {
                _parent.Show();
            }
            else
            {
                Form1 form1 = new Form1();
                form1.Show();
            }
            this.Hide();
        }

        // AQUI: Passou a aceitar decimal no formatador de moeda
        private string FormatCurrency(decimal valor)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0:C}", valor);
        }
    }
}