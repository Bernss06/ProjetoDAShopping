using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.controllers
{
    internal class EstatisticasController
    {
        // Regra 20.c: Sugerir um orçamento para o próximo mês com base na média dos anteriores
        public decimal sugerirOrcamentoProximoMes()
        {
            using (var db = new ShoppingContext())
            {
                var orcamentos = db.Orcamentos.ToList();
                if (orcamentos.Count == 0) return 0;

                // Calcula a média do Valor Máximo de todos os orçamentos criados
                decimal soma = orcamentos.Sum(o => o.ValorMaximo);
                return soma / orcamentos.Count;
            }
        }

        // Regra 20.b: Para cada compra, saber as estatísticas dos artigos (Devolve lista para a grelha)
        public List<EstatisticaCompraDTO> getEstatisticasComprasFechadas()
        {
            using (var db = new ShoppingContext())
            {
                List<EstatisticaCompraDTO> estatisticas = new List<EstatisticaCompraDTO>();

                // Vai buscar apenas as compras fechadas e os respetivos itens
                var comprasFechadas = db.Compras.Include("Itens").Where(c => c.Fechada).ToList();

                foreach (var compra in comprasFechadas)
                {
                    int totalItens = compra.Itens?.Count ?? 0;
                    int previstos = 0;
                    int naoPrevistos = 0;

                    if (totalItens > 0)
                    {
                        previstos = compra.Itens.OfType<ItemPrevisto>().Count();
                        naoPrevistos = compra.Itens.OfType<ItemNaoPrevisto>().Count();
                    }

                    estatisticas.Add(new EstatisticaCompraDTO
                    {
                        NomeCompra = compra.NomeCompra,
                        TotalArtigos = totalItens,
                        PercentagemPrevistos = totalItens > 0 ? (previstos * 100 / totalItens) : 0,
                        PercentagemNaoPrevistos = totalItens > 0 ? (naoPrevistos * 100 / totalItens) : 0,
                        ValorGasto = compra.ValorTotal
                    });
                }

                return estatisticas;
            }
        }
    }

    // Classe auxiliar (DTO - Data Transfer Object) para ser mais fácil de mostrar na DataGridView
    public class EstatisticaCompraDTO
    {
        public string NomeCompra { get; set; }
        public int TotalArtigos { get; set; }
        public int PercentagemPrevistos { get; set; }
        public int PercentagemNaoPrevistos { get; set; }
        public decimal ValorGasto { get; set; }
    }
}
