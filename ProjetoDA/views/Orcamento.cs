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

        // Referência ao Form1 que abriu este formulário (pode ser null)
        private Form1 _parent;

        public Orcamento()
        {
            InitializeComponent();
            _orcamentoController = new OrcamentoController();
            _utilizadorLogadoId = SessionManager.UtilizadorLogadoId;
            _mesSelecionado = DateTime.Now.Month;
            _anoSelecionado = DateTime.Now.Year;

            // Registar handlers
          
            this.btndefinirOrçamento.Click += btndefinirOrçamento_Click;
            this.btnVoltarInicio.Click += btnVoltarInicio_Click;
        }

        // Construtor que recebe o Form1 para permitir atualização da label no Form1
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

                    // Atualiza a label do Form1 se houver um parent
                    _parent?    .AtualizarOrcamentoLabel(orcamentoAtual.ValorMaximo);
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
            // Validação e gravação do orçamento
            var texto = txtOrcamento.Text?.Trim();
            if (string.IsNullOrEmpty(texto))
            {
                MessageBox.Show("Introduza um valor para o orçamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out var valor))
            {
                MessageBox.Show("Formato inválido. Use números inteiros (ex.: 1000).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (valor < 0)
            {
                MessageBox.Show("O orçamento não pode ser negativo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Recupera o ID atual do utilizador da sessão (não usa o valor armazenado no construtor)
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

                    // Notifica o Form1 (se existir) para atualizar a label com o novo valor
                    _parent?.AtualizarOrcamentoLabel(valor);

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
            // Se temos referência ao Form1 parent, mostra-o novamente
            if (_parent != null)
            {
                _parent.Show();
            }
            else
            {                                               
                // Caso contrário, cria uma nova instância
                Form1 form1 = new Form1();
                form1.Show();
            }

            // Esconde o formulário atual
            this.Hide();
        }

        private string FormatCurrency(int valor)
        {
            // Formata conforme cultura do utilizador, com símbolo de moeda
            return string.Format(CultureInfo.CurrentCulture, "{0:C}", valor);
        }

        
    }
}