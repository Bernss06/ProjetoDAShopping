using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.controllers
{
    internal class ItemCompraController
    {
        public List<ItemCompra> getItensDaCompra(int compraId)
        {
            using (var db = new ShoppingContext())
            {
                // Traz os itens com a informação do Artigo e respetiva Categoria
                return db.ItensCompra.Include("Artigo").Include("Artigo.TipoArtigo")
                                     .Where(i => i.Compra.Id == compraId)
                                     .ToList();
            }
        }

        public bool removerItem(int itemId)
        {
            using (var db = new ShoppingContext())
            {
                ItemCompra item = db.ItensCompra.Include("Compra").FirstOrDefault(i => i.Id == itemId);
                if (item == null || item.Compra.Fechada) return false; // Não pode remover se a compra estiver fechada

                // Se tinha valor, retira do total da compra
                item.Compra.ValorTotal -= (item.QuantidadeAdquirida * item.PrecoUnitario);

                db.ItensCompra.Remove(item);
                db.SaveChanges();
                return true;
            }
        }

        public bool editarQuantidadeAdquirida(int itemId, int novaQuantidade, decimal novoPreco)
        {
            using (var db = new ShoppingContext())
            {
                ItemCompra item = db.ItensCompra.Include("Compra").FirstOrDefault(i => i.Id == itemId);
                if (item == null || item.Compra.Fechada) return false;

                // Acerta o valor total da compra (subtrai o valor antigo, soma o novo)
                decimal valorAntigo = item.QuantidadeAdquirida * item.PrecoUnitario;
                decimal valorNovo = novaQuantidade * novoPreco;

                item.Compra.ValorTotal = item.Compra.ValorTotal - valorAntigo + valorNovo;

                item.QuantidadeAdquirida = novaQuantidade;
                item.PrecoUnitario = novoPreco;

                db.SaveChanges();
                return true;
            }
        }
    }
}
