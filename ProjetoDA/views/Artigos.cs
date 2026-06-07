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
    public partial class Artigos : Form
    {
        // Ligação com a Base de Dados
        private ShoppingContext _context = new ShoppingContext();

        public Artigos()
        {
            InitializeComponent();

            // Liga o evento de clique na tabela para preencher as caixas da direita
            grdArtigos.SelectionChanged += grdArtigos_SelectionChanged;
        }

        // 1. 🚀 EVENTO AO CARREGAR O ECRÃ
        private void Artigos_Load(object sender, EventArgs e)
        {
            AtualizarDadosEForm();
        }

        // Função para carregar as ComboBoxes e a Grid com os dados frescos da BD
        private void AtualizarDadosEForm()
        {
            try
            {
                // Desliga temporariamente o evento para evitar filtros acidentais ao carregar
               
                // B. Carrega as categorias na nova ComboBox de seleção (lado direito)
                cmbCategoria.DataSource = _context.TiposArtigo.ToList();
                cmbCategoria.DisplayMember = "Categoria";
                cmbCategoria.ValueMember = "Id";

               

                // C. Atualiza a tabela geral
                CarregarArtigos(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        // Função para preencher a DataGridView
        private void CarregarArtigos(int? artigoIdFiltrado)
        {
            try
            {
                var query = _context.Artigos.AsQueryable();

                if (artigoIdFiltrado.HasValue)
                {
                    query = query.Where(a => a.Id == artigoIdFiltrado.Value);
                }

                var lista = query
                    .Select(a => new
                    {
                        a.Id,
                        Artigo = a.Nome,
                        Categoria = a.TipoArtigo.Categoria
                    }).ToList();

                grdArtigos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar a tabela: {ex.Message}");
            }
        }

        // 3. ➕ BOTÃO: Novo Artigo (Usa a Categoria selecionada na ComboBox)
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtnome_artigo.Text))
                {
                    MessageBox.Show("Por favor, introduza o nome do artigo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Resgata a categoria selecionada na ComboBox da direita
                var categoriaSelecionada = cmbCategoria.SelectedItem as TipoArtigo;
                if (categoriaSelecionada == null)
                {
                    MessageBox.Show("Por favor, selecione uma categoria válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cria o artigo associando-o diretamente à categoria escolhida
                Artigo novoArtigo = new Artigo(txtnome_artigo.Text.Trim(), categoriaSelecionada);

                _context.Artigos.Add(novoArtigo);
                _context.SaveChanges();

                MessageBox.Show("Artigo adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AtualizarDadosEForm();
                LimparCamposDireita();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar o artigo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. ✏️ BOTÃO: Editar Artigo
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (grdArtigos.CurrentRow == null) return;

                int idSelecionado = Convert.ToInt32(grdArtigos.CurrentRow.Cells["Id"].Value);
                var artigo = _context.Artigos.Find(idSelecionado);

                if (artigo != null)
                {
                    var categoriaSelecionada = cmbCategoria.SelectedItem as TipoArtigo;
                    if (categoriaSelecionada == null)
                    {
                        MessageBox.Show("Selecione uma categoria válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    artigo.Nome = txtnome_artigo.Text.Trim();
                    artigo.TipoArtigo = categoriaSelecionada; // Altera para a nova categoria escolhida

                    _context.SaveChanges();
                    MessageBox.Show("Artigo editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AtualizarDadosEForm();
                    LimparCamposDireita();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. ❌ BOTÃO: Eliminar Artigo
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (grdArtigos.CurrentRow == null) return;

                int idSelecionado = Convert.ToInt32(grdArtigos.CurrentRow.Cells["Id"].Value);
                var artigo = _context.Artigos.Find(idSelecionado);

                if (artigo != null)
                {
                    var resultado = MessageBox.Show($"Deseja eliminar o artigo {artigo.Nome}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        _context.Artigos.Remove(artigo);
                        _context.SaveChanges();

                        MessageBox.Show("Artigo eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AtualizarDadosEForm();
                        LimparCamposDireita();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao eliminar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ao clicar numa linha da tabela, preenche o Nome e seleciona a Categoria certa na ComboBox da direita
        private void grdArtigos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdArtigos.CurrentRow != null && grdArtigos.CurrentRow.Cells["Artigo"].Value != null)
                {
                    txtnome_artigo.Text = grdArtigos.CurrentRow.Cells["Artigo"].Value.ToString();

                    // Procura a categoria correspondente dentro da ComboBox e seleciona-a automaticamente
                    string categoriaNome = grdArtigos.CurrentRow.Cells["Categoria"].Value.ToString();
                    foreach (TipoArtigo item in cmbCategoria.Items)
                    {
                        if (item.Categoria == categoriaNome)
                        {
                            cmbCategoria.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch { }
        }

        private void LimparCamposDireita()
        {
            txtnome_artigo.Clear();
            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            // Se temos referência ao Form1 parent, mostra-o novamente
         
           
          
            // Caso contrário, cria uma nova instância
            Form1 form1 = new Form1();
            form1.Show();
          

            // Esconde o formulário atual
            this.Hide();
        }
    }
}