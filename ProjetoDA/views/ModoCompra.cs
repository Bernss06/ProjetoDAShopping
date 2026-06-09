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

        // Vai guardar o ID que vem do Form1
        private int _compraAbertaId;
        private decimal _orcamentoMensal = 0;

        // NOVO CONSTRUTOR: Agora recebe obrigatoriamente um ID de compra!
        public ModoCompra(int compraSelecionadaId)
        {
            InitializeComponent();

            _compraController = new CompraController();
            _itemCompraController = new ItemCompraController();
            _artigoController = new ArtigoController();
            _tipoArtigoController = new TipoArtigoController();
            _orcamentoController = new OrcamentoController();

            _compraAbertaId = compraSelecionadaId;

            this.Load += ModoCompra_Load;
            this.btnVoltarInicio.Click += BtnVoltarInicio_Click;

            this.btnadicionaritem.Click += BtnAtualizarPrevisto_Click;
            this.btnAddNaoPrevisto.Click += BtnAddNaoPrevisto_Click;
            this.btnremoveritem.Click += BtnRemoverItem_Click;
            this.btnfinalizarcompra.Click += BtnFinalizarCompra_Click;

            this.cbTipoArtigo.SelectedIndexChanged += CbTipoArtigo_SelectedIndexChanged;
        }

        private void ModoCompra_Load(object sender, EventArgs e)
        {
            lbPreco.Visible = false;
            label4.Visible = false;

            var tipos = _tipoArtigoController.getTiposArtigo();
            tipos.Insert(0, new TipoArtigo { Id = 0, Categoria = "-- Todos --" });
            cbTipoArtigo.DataSource = tipos;
            cbTipoArtigo.DisplayMember = "Categoria";
            cbTipoArtigo.ValueMember = "Id";
            CarregarArtigos(0);

            var orcMes = _orcamentoController.getOrcamentos().FirstOrDefault(o => o.Mes == DateTime.Now.Month && o.Ano == DateTime.Now.Year);
            if (orcMes != null)
            {
                _orcamentoMensal = orcMes.ValorMaximo;
                lbOrcamentoTotal.Text = _orcamentoMensal.ToString("C2");
            }
            else
            {
                lbOrcamentoTotal.Text = "Sem Orçamento";
            }

            // Agora ele apenas arranca com o ID que lhe deste no Form1!
            if (_compraAbertaId > 0)
            {
                AtualizarGrelhasETotais();
            }
            else
            {
                MessageBox.Show("Erro a carregar a compra selecionada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void CarregarArtigos(int tipoId)
        {
            var artigos = _artigoController.getArtigos();
            if (tipoId > 0) artigos = artigos.Where(a => a.TipoArtigo.Id == tipoId).ToList();
            cbArtigo.DataSource = artigos;
            cbArtigo.DisplayMember = "Nome";
            cbArtigo.ValueMember = "Id";
        }

        private void GerarTalaoSVG(int compraId, string nomeCompra, decimal totalPago)
        {
            // 1. Vai buscar apenas os itens que foram efetivamente comprados
            var itensNoCarrinho = _itemCompraController.getItensDaCompra(compraId)
                                    .Where(i => i.QuantidadeAdquirida > 0)
                                    .ToList();

            // 2. Calcula a altura do talão dinamicamente (quantos mais itens, mais comprido é o papel)
            int alturaCabecalho = 120;
            int alturaRodape = 100;
            int espacoPorItem = 25;
            int alturaTotal = alturaCabecalho + alturaRodape + (itensNoCarrinho.Count * espacoPorItem);

            // 3. Começa a "desenhar" o SVG
            System.Text.StringBuilder svg = new System.Text.StringBuilder();

            // Fundo do talão (estilo papel com fonte de máquina de escrever)
            svg.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"350\" height=\"{alturaTotal}\" style=\"background-color: #fafafa; font-family: 'Courier New', monospace; font-size: 14px; fill: #111;\">");

            // Cabeçalho
            svg.AppendLine("<text x=\"175\" y=\"40\" text-anchor=\"middle\" font-size=\"22\" font-weight=\"bold\">🛒 PROJETO DA SHOPPING</text>");
            svg.AppendLine($"<text x=\"175\" y=\"65\" text-anchor=\"middle\" font-size=\"12\" fill=\"#555\">Lista: {nomeCompra}</text>");
            svg.AppendLine($"<text x=\"175\" y=\"85\" text-anchor=\"middle\" font-size=\"12\" fill=\"#555\">Data: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}</text>");

            // Linha tracejada separadora
            svg.AppendLine("<line x1=\"20\" y1=\"105\" x2=\"330\" y2=\"105\" stroke=\"#111\" stroke-dasharray=\"6,4\" stroke-width=\"1.5\" />");

            // Títulos das colunas
            svg.AppendLine("<text x=\"20\" y=\"125\" font-weight=\"bold\">Artigo</text>");
            svg.AppendLine("<text x=\"240\" y=\"125\" text-anchor=\"end\" font-weight=\"bold\">Qtd</text>");
            svg.AppendLine("<text x=\"330\" y=\"125\" text-anchor=\"end\" font-weight=\"bold\">Preço</text>");

            // 4. Ciclo para imprimir cada item do carrinho
            int yAtual = 150;
            foreach (var item in itensNoCarrinho)
            {
                string nomeArtigo = item.Artigo.Nome.Length > 18 ? item.Artigo.Nome.Substring(0, 18) + ".." : item.Artigo.Nome;
                decimal subTotal = item.QuantidadeAdquirida * item.PrecoUnitario;

                svg.AppendLine($"<text x=\"20\" y=\"{yAtual}\">{nomeArtigo}</text>");
                svg.AppendLine($"<text x=\"240\" y=\"{yAtual}\" text-anchor=\"end\">{item.QuantidadeAdquirida}</text>");
                svg.AppendLine($"<text x=\"330\" y=\"{yAtual}\" text-anchor=\"end\">{subTotal.ToString("C2", new System.Globalization.CultureInfo("pt-PT"))}</text>");

                yAtual += espacoPorItem;
            }

            // Linha tracejada antes do total
            svg.AppendLine($"<line x1=\"20\" y1=\"{yAtual}\" x2=\"330\" y2=\"{yAtual}\" stroke=\"#111\" stroke-dasharray=\"6,4\" stroke-width=\"1.5\" />");
            yAtual += 30;

            // TOTAL FINAL
            svg.AppendLine($"<text x=\"20\" y=\"{yAtual}\" font-size=\"18\" font-weight=\"bold\">TOTAL A PAGAR:</text>");
            svg.AppendLine($"<text x=\"330\" y=\"{yAtual}\" text-anchor=\"end\" font-size=\"18\" font-weight=\"bold\">{totalPago.ToString("C2", new System.Globalization.CultureInfo("pt-PT"))}</text>");

            // Rodapé
            yAtual += 40;
            svg.AppendLine($"<text x=\"175\" y=\"{yAtual}\" text-anchor=\"middle\" font-size=\"12\">Obrigado pela sua visita!</text>");

            svg.AppendLine("</svg>");

            // =======================================================
            // 5. NOVA LÓGICA DE DIRETÓRIO: GRAVAR NA PASTA DO PROJETO
            // =======================================================
            try
            {
                // Vai buscar a pasta onde o executável roda (.exe está em bin\Debug)
                string pastaExecutavel = AppDomain.CurrentDomain.BaseDirectory;

                // Sobe dois níveis para encontrar a pasta principal do projeto (onde tens os teus ficheiros .cs)
                string pastaRaizProjeto = System.IO.Path.GetFullPath(System.IO.Path.Combine(pastaExecutavel, @"..\..\"));
                string pastaTaloes = System.IO.Path.Combine(pastaRaizProjeto, "taloes");

                // Caso a aplicação rode fora do ambiente de desenvolvimento do Visual Studio,
                // garantimos que se a pasta não existir lá atrás, cria uma no sítio atual para não rebentar
                if (!System.IO.Directory.Exists(pastaTaloes))
                {
                    pastaTaloes = System.IO.Path.Combine(pastaExecutavel, "taloes");
                    if (!System.IO.Directory.Exists(pastaTaloes))
                    {
                        System.IO.Directory.CreateDirectory(pastaTaloes);
                    }
                }

                // Monta o nome do ficheiro e o caminho final completo
                string nomeFicheiro = $"Talao_{nomeCompra.Replace(" ", "")}_{DateTime.Now.ToString("ddMMyyyy_HHmm")}.svg";
                string caminhoCompleto = System.IO.Path.Combine(pastaTaloes, nomeFicheiro);

                // Cospe o código XML/SVG para o ficheiro de texto
                System.IO.File.WriteAllText(caminhoCompleto, svg.ToString());

                MessageBox.Show($"Talão de supermercado faturado com sucesso!\n\nGuardado em: \\taloes\\{nomeFicheiro}", "Fatura Exportada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro crítico ao exportar o talão digital: {ex.Message}", "Erro de Gravação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CbTipoArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoArtigo.SelectedValue is int tipoId) CarregarArtigos(tipoId);
        }

        private void AtualizarGrelhasETotais()
        {
            if (_compraAbertaId == 0) return;

            var todosItens = _itemCompraController.getItensDaCompra(_compraAbertaId);

            var itensPlaneados = todosItens.OfType<ItemPrevisto>().Select(i => new {
                Id = i.Id,
                Artigo = i.Artigo.Nome,
                QtdPlaneada = i.QuantidadePrevista,
                Estado = i.QuantidadeAdquirida > 0 ? "No Carrinho ✔️" : "Pendente"
            }).ToList();

            dtgItensCompra.DataSource = itensPlaneados;
            if (dtgItensCompra.Columns["Id"] != null) dtgItensCompra.Columns["Id"].Visible = false;

            var itensNoCarrinho = todosItens.Where(i => i.QuantidadeAdquirida > 0).Select(i => new {
                Id = i.Id,
                Artigo = i.Artigo.Nome,
                Tipo = (i is ItemPrevisto) ? "Planeado" : "Extra",
                Qtd = i.QuantidadeAdquirida,
                Preco = i.PrecoUnitario,
                SubTotal = i.QuantidadeAdquirida * i.PrecoUnitario
            }).ToList();

            dtgcompra.DataSource = itensNoCarrinho;
            if (dtgcompra.Columns["Id"] != null) dtgcompra.Columns["Id"].Visible = false;
            if (dtgcompra.Columns["Preco"] != null) dtgcompra.Columns["Preco"].DefaultCellStyle.Format = "C2";
            if (dtgcompra.Columns["SubTotal"] != null) dtgcompra.Columns["SubTotal"].DefaultCellStyle.Format = "C2";

            decimal totalCusto = itensNoCarrinho.Sum(i => i.Qtd * i.Preco);
            lbCustoTotaldaCompra.Text = totalCusto.ToString("C2");

            decimal restante = _orcamentoMensal - totalCusto;
            lbRestanteDisponivel.Text = restante.ToString("C2");
            lbRestanteDisponivel.ForeColor = restante < 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        private void BtnAtualizarPrevisto_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0 || dtgItensCompra.CurrentRow == null) return;
            int itemId = Convert.ToInt32(dtgItensCompra.CurrentRow.Cells["Id"].Value);
            int qtdReal = (int)numQuantidadeArtigo.Value;

            if (!decimal.TryParse(txtPreco.Text.Replace('.', ','), out decimal precoReal) || precoReal <= 0 || qtdReal <= 0) return;

            if (_itemCompraController.editarQuantidadeAdquirida(itemId, qtdReal, precoReal))
            {
                AtualizarGrelhasETotais();
                numQuantidadeArtigo.Value = 0;
                txtPreco.Text = "";
            }
        }

        private void BtnAddNaoPrevisto_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0 || cbArtigo.SelectedValue == null) return;
            int artigoSelecionadoId = (int)cbArtigo.SelectedValue;
            int qtd = (int)numNaoPrevisto.Value;

            if (!decimal.TryParse(txtPrecoNaoPrevisto.Text.Replace('.', ','), out decimal preco) || preco <= 0 || qtd <= 0) return;

            if (_compraController.adicionarItemNaoPrevisto(_compraAbertaId, artigoSelecionadoId, qtd, preco, "Item Extra"))
            {
                AtualizarGrelhasETotais();
                numNaoPrevisto.Value = 0;
                txtPrecoNaoPrevisto.Text = "";
            }
        }

        private void BtnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dtgcompra.CurrentRow == null) return;
            int itemId = Convert.ToInt32(dtgcompra.CurrentRow.Cells["Id"].Value);
            string tipoItem = dtgcompra.CurrentRow.Cells["Tipo"].Value.ToString();

            if (MessageBox.Show("Tens a certeza que queres tirar isto do carrinho?", "Remover", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tipoItem == "Planeado") _itemCompraController.editarQuantidadeAdquirida(itemId, 0, 0);
                else _itemCompraController.removerItem(itemId);
                AtualizarGrelhasETotais();
            }
        }

        private void BtnFinalizarCompra_Click(object sender, EventArgs e)
        {
            if (_compraAbertaId == 0) return;

            // ... (o teu código de validação de permissões que já lá tens) ...

            if (MessageBox.Show("Desejas fechar a conta na caixa? Não poderás mexer mais nesta lista.", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int userId = SessionManager.UtilizadorLogadoId != 0 ? SessionManager.UtilizadorLogadoId : 1;

                // Pega no nome da compra e no total antes de fechar para mandar para o talão
                string nomeDaCompraAFechar = this.Text; // Usando o título do formulário como nome da compra
                decimal valorTotalPago = decimal.Parse(lbCustoTotaldaCompra.Text, System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("pt-PT"));

                if (_compraController.fecharCompra(_compraAbertaId, userId))
                {
                    // A MAGIA ACONTECE AQUI: Assim que a base de dados confirma o fecho, gera o talão SVG!
                    GerarTalaoSVG(_compraAbertaId, nomeDaCompraAFechar, valorTotalPago);

                    MessageBox.Show("Lista fechada e faturada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void BtnVoltarInicio_Click(object sender, EventArgs e)
        {
            Form formPrincipal = Application.OpenForms["Form1"];

            if (formPrincipal != null)
            {
                formPrincipal.Show();
            }
            else
            {
                Form1 novoForm = new Form1();
                novoForm.Show();
            }

            this.Close();
        }
    }
}