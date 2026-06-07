using ProjetoDA.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDA.views
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
            // Registar os handlers dos botões
            this.btnRegisto.Click += BtnRegistrar_Click;
            this.btnJatenho.Click += Button1_Click;
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            // Método chamado quando o formulário é carregado
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Verifica se algum dos campos está vazio ou apenas com espaços
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios!",
                                "Campos Vazios",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Interrompe a execução do método aqui para não registar
            }

            // Instancia o controlador existente, exatamente como na Ficha 9
            UtilizadorController utilizadorController = new UtilizadorController();

            // Chama o método que faz a validação e insere na base de dados
            bool sucesso = utilizadorController.adicionarUtilizador(username, password);

            if (sucesso)
            {
                MessageBox.Show("Utilizador registado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Esconde a janela de registo
                this.Hide();

                // Cria e mostra a janela de Login
                FormLogin login = new FormLogin();
                login.ShowDialog(); // Utilizar ShowDialog() garante que o utilizador vai para a página de login

                // Fecha esta janela de vez após fechar o login (opcional, para limpar memória)
                this.Close();
            }
            else
            {
                // Alerta caso o Username já exista na base de dados (Regra 4)
                MessageBox.Show("Erro: Este Username já está a ser utilizado por outro membro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                                                                                                                                                                                                                                                                                                        
        private void Button1_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();

            // Esconde o formulário de registo
            this.Hide();
        }

    }
}
