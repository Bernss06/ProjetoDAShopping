using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoDA.modelos;

namespace ProjetoDA.views
{
    public partial class TipoArtigos : Form
    {
        public TipoArtigos()
        {
            InitializeComponent();

            // Liga o evento de clique na tabela para preencher a caixa de texto da esquerda
            this.grdCategorias.SelectionChanged += grdCategorias_SelectionChanged;
            
            // Registar evento Load
            this.Load += TipoArtigos_Load;
        }

        // 1. 🚀 EVENTO AO CARREGAR O ECRÃ
        private void TipoArtigos_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("[TipoArtigos] Formulário carregado - Iniciando carregamento de categorias");
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
                System.Diagnostics.Debug.WriteLine($"[TipoArtigos] Erro em AtualizarDadosEForm: {ex.Message}");
            }
        }

        // Função para preencher a DataGridView
        private void CarregarCategorias()
        {
            try
            {
                using (var context = new ShoppingContext())
                {
                    System.Diagnostics.Debug.WriteLine("[TipoArtigos] Iniciando carregamento de categorias da BD");

                    // Carrega a lista diretamente da tabela TiposArtigo
                    var lista = context.TiposArtigo
                        .OrderBy(c => c.Categoria)
                        .Select(c => new
                        {
                            Id = c.Id,
                            Categoria = c.Categoria
                        }).ToList();

                    System.Diagnostics.Debug.WriteLine($"[TipoArtigos] Total de categorias carregadas: {lista.Count}");

                    // Limpar dados anteriores
                    grdCategorias.DataSource = null;
                    grdCategorias.Refresh();

                    // Carregar novos dados
                    grdCategorias.DataSource = lista;

                    // Configurar as colunas
                    if (grdCategorias.Columns.Count > 0)
                    {
                        // Configurar coluna ID
                        if (grdCategorias.Columns.Contains("Id"))
                        {
                            grdCategorias.Columns["Id"].HeaderText = "ID";
                            grdCategorias.Columns["Id"].Width = 50;
                            grdCategorias.Columns["Id"].Visible = false;
                        }

                        // Configurar coluna Categoria
                        if (grdCategorias.Columns.Contains("Categoria"))
                        {
                            grdCategorias.Columns["Categoria"].HeaderText = "Nome da Categoria";
                            grdCategorias.Columns["Categoria"].Width = 450;
                            grdCategorias.Columns["Categoria"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }

                    // Permitir selecção de linhas inteiras
                    grdCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grdCategorias.MultiSelect = false;

                    System.Diagnostics.Debug.WriteLine("[TipoArtigos] Carregamento concluído com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar a tabela: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[TipoArtigos] Erro em CarregarCategorias: {ex.Message}\n{ex.StackTrace}");
            }
        }

        // 3. ➕ BOTÃO: Nova Categoria
        private void btnNovaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar entrada
                if (string.IsNullOrWhiteSpace(txtNomeCategoria.Text))
                {
                    MessageBox.Show("Por favor, introduza o nome da categoria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var context = new ShoppingContext())
                {
                    // Verificar se a categoria já existe
                    string nomaNormalizado = txtNomeCategoria.Text.Trim().ToLower();
                    bool jaExiste = context.TiposArtigo.Any(c => c.Categoria.ToLower() == nomaNormalizado);

                    if (jaExiste)
                    {
                        MessageBox.Show("Esta categoria já existe!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Cria a nova categoria com base no texto inserido
                    TipoArtigo novaCategoria = new TipoArtigo
                    {
                        Categoria = txtNomeCategoria.Text.Trim()
                    };

                    context.TiposArtigo.Add(novaCategoria);
                    context.SaveChanges();

                    System.Diagnostics.Debug.WriteLine($"[TipoArtigos] Nova categoria criada: {novaCategoria.Categoria}");

                    MessageBox.Show("Categoria adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AtualizarDadosEForm();
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar a categoria: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[TipoArtigos] Erro em btnNovaCategoria_Click: {ex.Message}");
            }
        }

        // 4. ✏️ BOTÃO: Editar Categoria
        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdCategorias.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione uma categoria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNomeCategoria.Text))
                {
                    MessageBox.Show("O nome da categoria não pode ficar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idSelecionado = Convert.ToInt32(grdCategorias.CurrentRow.Cells["Id"].Value);

                using (var context = new ShoppingContext())
                {
                    var categoria = context.TiposArtigo.Find(idSelecionado);

                    if (categoria != null)
                    {
                        string novoNome = txtNomeCategoria.Text.Trim();
                        categoria.Categoria = novoNome;

                        context.SaveChanges();

                        System.Diagnostics.Debug.WriteLine($"[TipoArtigos] Categoria editada: {novoNome}");

                        MessageBox.Show("Categoria editada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AtualizarDadosEForm();
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Categoria não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[TipoArtigos] Erro em btnEditarCategoria_Click: {ex.Message}");
            }
        }

        // 5. ❌ BOTÃO: Eliminar Categoria
        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdCategorias.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione uma categoria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idSelecionado = Convert.ToInt32(grdCategorias.CurrentRow.Cells["Id"].Value);

                using (var context = new ShoppingContext())
                {
                    var categoria = context.TiposArtigo.Find(idSelecionado);

                    if (categoria != null)
                    {
                        // Verificar se existem artigos vinculados
                        var temArtigosVinculados = context.Artigos.Any(a => a.TipoArtigo.Id == idSelecionado);
                        
                        if (temArtigosVinculados)
                        {
                            MessageBox.Show("Não pode eliminar esta categoria porque existem artigos associados a ela.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var resultado = MessageBox.Show($"Deseja eliminar a categoria '{categoria.Categoria}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        
                        if (resultado == DialogResult.Yes)
                        {
                            context.TiposArtigo.Remove(categoria);
                            context.SaveChanges();

                            System.Diagnostics.Debug.WriteLine($"[TipoArtigos] Categoria eliminada: {categoria.Categoria}");

                            MessageBox.Show("Categoria eliminada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            AtualizarDadosEForm();
                            LimparCampos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao eliminar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[TipoArtigos] Erro em btnEliminarCategoria_Click: {ex.Message}");
            }
        }

        // Ao clicar numa linha da tabela, preenche a TextBox com o nome da categoria
        private void grdCategorias_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdCategorias.CurrentRow != null)
                {
                    object cellValue = grdCategorias.CurrentRow.Cells["Categoria"].Value;
                    
                    if (cellValue != null)
                    {
                        txtNomeCategoria.Text = cellValue.ToString();
                        System.Diagnostics.Debug.WriteLine($"[TipoArtigos] Categoria seleccionada: {cellValue}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[TipoArtigos] Erro em grdCategorias_SelectionChanged: {ex.Message}");
            }
        }

        private void LimparCampos()
        {
            txtNomeCategoria.Clear();
            grdCategorias.ClearSelection();
        }

        // 🏠 BOTÃO: Voltar ao Início
        private void btninicio_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        // Botão Sair
        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}