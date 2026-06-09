using ProjetoDA.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.controllers
{
    internal class CompraController
    {
        // Vai buscar apenas as compras que não foram fechadas (para o formulário principal)
        public List<Compra> getComprasAbertas()
        {
            using (var db = new ShoppingContext())
            {
                return db.Compras.Include("UserCria").Where(c => c.Fechada == false).ToList();
            }
        }

        public bool criarCompra(string nomeCompra, int utilizadorLogadoId)
        {
            using (var db = new ShoppingContext())
            {
                Utilizador user = db.Utilizadores.FirstOrDefault(u => u.Id == utilizadorLogadoId);
                if (user == null) return false;

                Compra nova = new Compra(nomeCompra, user);
                db.Compras.Add(nova);
                db.SaveChanges();
                return true;
            }
        }

        public bool adicionarItemPrevisto(int compraId, int artigoId, int qtPrevista)
        {
            using (var db = new ShoppingContext())
            {
                Compra compra = db.Compras.FirstOrDefault(c => c.Id == compraId);
                Artigo artigo = db.Artigos.FirstOrDefault(a => a.Id == artigoId);

                if (compra == null || artigo == null || compra.Fechada) return false;

                ItemPrevisto item = new ItemPrevisto
                {
                    Compra = compra,
                    Artigo = artigo,
                    QuantidadePrevista = qtPrevista,
                    QuantidadeAdquirida = 0, // Planeado apenas
                    PrecoUnitario = 0
                };

                db.ItensCompra.Add(item);
                db.SaveChanges();
                return true;
            }
        }

        public bool adicionarItemNaoPrevisto(int compraId, int artigoId, int qtAdquirida, decimal precoUnitario, string obs)
        {
            using (var db = new ShoppingContext())
            {
                Compra compra = db.Compras.FirstOrDefault(c => c.Id == compraId);
                Artigo artigo = db.Artigos.FirstOrDefault(a => a.Id == artigoId);

                if (compra == null || artigo == null || compra.Fechada) return false;

                ItemNaoPrevisto item = new ItemNaoPrevisto
                {
                    Compra = compra,
                    Artigo = artigo,
                    QuantidadeAdquirida = qtAdquirida,
                    PrecoUnitario = precoUnitario,
                    Observacoes = obs
                };

                db.ItensCompra.Add(item);

                // Atualiza logo o valor total acumulado da compra
                compra.ValorTotal += (qtAdquirida * precoUnitario);

                db.SaveChanges();
                return true;
            }
        }

        public bool fecharCompra(int compraId, int utilizadorLogadoId)
        {
            using (var db = new ShoppingContext())
            {
                Compra compra = db.Compras.FirstOrDefault(c => c.Id == compraId);
                Utilizador user = db.Utilizadores.FirstOrDefault(u => u.Id == utilizadorLogadoId);

                if (compra == null || user == null || compra.Fechada) return false;

                // 1. Muda os estados da compra
                compra.Fechada = true;
                compra.DataFechada = DateTime.Now;
                compra.UserFecha = user;

                // 2. Calcula o valor final exato gasto em todos os itens do carrinho
                decimal custoTotalDaCompra = db.ItensCompra
                    .Where(i => i.Compra.Id == compraId && i.QuantidadeAdquirida > 0)
                    .Select(i => i.QuantidadeAdquirida * i.PrecoUnitario)
                    .DefaultIfEmpty(0)
                    .Sum();

                // 3. Atualiza o valor total guardado na compra
                compra.ValorTotal = custoTotalDaCompra;

                // 4. A MAGIA: Procurar o Orçamento deste mês/ano e subtrair o custo
                int mesAtual = DateTime.Now.Month;
                int anoAtual = DateTime.Now.Year;

                Orcamento orcamentoDesteMes = db.Orcamentos.FirstOrDefault(o => o.Mes == mesAtual && o.Ano == anoAtual);

                if (orcamentoDesteMes != null)
                {
                    // O ValorMaximo (o teu plafond inicial de 500) vai ser cortado no valor gasto (ex: 500 - 20 = 480)
                    orcamentoDesteMes.ValorMaximo -= custoTotalDaCompra;
                }

                db.SaveChanges();
                return true;
            }
        }

        // ==========================================
        // O PROBLEMA ESTAVA AQUI! AGORA JÁ CARREGA TUDO
        // ==========================================
        public List<Compra> getTodasAsCompras()
        {
            using (var db = new ShoppingContext())
            {
                // Traz todas as compras e inclui o Utilizador que a criou para o Form1 conseguir mostrar o nome
                return db.Compras.Include("UserCria").ToList();
            }
        }
    }
}