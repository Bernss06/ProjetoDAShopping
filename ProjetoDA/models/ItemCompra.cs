using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA
{
    // Classe Base
    public abstract class ItemCompra
    {
        public int Id { get; set; }
        public int QuantidadeAdquirida { get; set; } // No diagrama está 'int'
        public decimal PrecoUnitario { get; set; }

        // Relações (O losango no diagrama indica que pertence a uma Compra, e a linha associa a Artigo)
        public Compra Compra { get; set; }
        public Artigo Artigo { get; set; }

        public ItemCompra() { }
    }

    // Subclasse: Item Previsto
    public class ItemPrevisto : ItemCompra
    {
        public int QuantidadePrevista { get; set; } // No diagrama está 'int'

        public ItemPrevisto() { }
    }

    // Subclasse: Item Não Previsto
    public class ItemNaoPrevisto : ItemCompra
    {
        public string Observacoes { get; set; }

        public ItemNaoPrevisto() { }
    }
}
