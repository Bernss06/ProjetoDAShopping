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
    public partial class TipoArtigos : Form
    {
        // Ligação com a Base de Dados
        private ShoppingContext _context = new ShoppingContext();

        public TipoArtigos()
        {
            InitializeComponent();

            // Liga o evento de clique na tabela para preencher a caixa de texto da esquerda
            grdCategorias.SelectionChanged += grdCategorias_SelectionChanged;
        }

        // 1. 🚀 EVENTO AO CARREGAR O ECRÃ
        private void TipoArtigos_Load(object sender, EventArgs e)
        {
            AtualizarDadosEForm();
        }

        // Função para atualizar a Grid com os dados frescos da BD
        private void AtualizarDadosEForm()
        {
            try
            {
                CarregarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Função para preencher a DataGridView
        private void CarregarCategorias()
        {
            try
            {
                // Carrega a lista diretamente da tabela TiposArtigo
                var lista = _context.TiposArtigo
                    .Select(c => new
                    {
                        c.Id,
                        Categoria = c.Categoria
                    }).ToList();

                grdCategorias.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar a tabela: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. ➕ BOTÃO: Nova Categoria
        private void btnNovaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                // AQUI: Corrigido para ler da TextBox em vez da label
                if (string.IsNullOrWhiteSpace(txtNomeCategoria.Text))
                {
                    MessageBox.Show("Por favor, introduza o nome da categoria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cria a nova categoria com base no texto inserido
                TipoArtigo novaCategoria = new TipoArtigo
                {
                    Categoria = txtNomeCategoria.Text.Trim()
                };

                _context.TiposArtigo.Add(novaCategoria);
                _context.SaveChanges();

                MessageBox.Show("Categoria adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AtualizarDadosEForm();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar a categoria: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. ✏️ BOTÃO: Editar Categoria
        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdCategorias.CurrentRow == null) return;

                // AQUI: Corrigido para ler da TextBox
                if (string.IsNullOrWhiteSpace(txtNomeCategoria.Text))
                {
                    MessageBox.Show("O nome da categoria não pode ficar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idSelecionado = Convert.ToInt32(grdCategorias.CurrentRow.Cells["Id"].Value);
                var categoria = _context.TiposArtigo.Find(idSelecionado);

                if (categoria != null)
                {
                    // AQUI: Atualiza o nome da categoria com o que está na TextBox
                    categoria.Categoria = txtNomeCategoria.Text.Trim();

                    _context.SaveChanges();
                    MessageBox.Show("Categoria editada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AtualizarDadosEForm();
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. ❌ BOTÃO: Eliminar Categoria
        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdCategorias.CurrentRow == null) return;

                int idSelecionado = Convert.ToInt32(grdCategorias.CurrentRow.Cells["Id"].Value);
                var categoria = _context.TiposArtigo.Find(idSelecionado);

                if (categoria != null)
                {
                    var temArtigosVinculados = _context.Artigos.Any(a => a.TipoArtigo.Id == idSelecionado);
                    if (temArtigosVinculados)
                    {
                        MessageBox.Show("Não pode eliminar esta categoria porque existem artigos associados a ela.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var resultado = MessageBox.Show($"Deseja eliminar a categoria '{categoria.Categoria}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        _context.TiposArtigo.Remove(categoria);
                        _context.SaveChanges();

                        MessageBox.Show("Categoria eliminada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AtualizarDadosEForm();
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao eliminar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ao clicar numa linha da tabela, preenche a TextBox com o nome da categoria
        private void grdCategorias_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdCategorias.CurrentRow != null && grdCategorias.CurrentRow.Cells["Categoria"].Value != null)
                {
                    // AQUI: Corrigido para escrever na TextBox em vez de substituir a label1
                    txtNomeCategoria.Text = grdCategorias.CurrentRow.Cells["Categoria"].Value.ToString();
                }
            }
            catch { }
        }

        private void LimparCampos()
        {
            txtNomeCategoria.Clear();
        }

        // 🏠 BOTÃO: Voltar ao Início
        private void btninicio_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}