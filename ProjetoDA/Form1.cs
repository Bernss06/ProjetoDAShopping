using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Quando o Form1 é fechado, limpar a sessão
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Limpa a sessão ao fechar o Form1
            SessionManager.ClearSession();
        }

        private void btnorcamento_Click(object sender, EventArgs e)
        {
            // Abre a view de Orçamento passando uma referência a este Form1
            var orcamentoForm = new views.Orcamento(this);
            orcamentoForm.Show();
            this.Hide();
        }

        private void btnplaneamento_Click(object sender, EventArgs e)
        {
            
                // Abre a view de Planeamento e esconde o Form1
                var planeamentoForm = new views.Planeamento();
                planeamentoForm.Show();
                this.Hide();
            
        }

        private void btnartigo_Click(object sender, EventArgs e)
        {

            // Abre a view de Artigos e esconde o Form1
            var artigoForm = new views.Artigos();
            artigoForm.Show();
            this.Hide();

        }

        public void AtualizarOrcamentoLabel(int valor)
        {
            // Atualiza a label com o novo valor do orçamento
            // lblOrcamento.Text = valor.ToString("C");
        }
    }
}
