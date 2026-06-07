using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.controllers
{
    internal class TipoArtigoController
    {
        public List<TipoArtigo> getTiposArtigo()
        {
            using (var db = new ShoppingContext())
            {
                return db.TiposArtigo.ToList();
            }
        }

        public bool adicionarTipoArtigo(string categoria)
        {
            using (var db = new ShoppingContext())
            {
                // Evita duplicados simples
                if (db.TiposArtigo.Any(t => t.Categoria == categoria))
                    return false;

                TipoArtigo novo = new TipoArtigo(categoria);
                db.TiposArtigo.Add(novo);
                db.SaveChanges();
                return true;
            }
        }

        public bool editarTipoArtigo(int id, string novaCategoria)
        {
            using (var db = new ShoppingContext())
            {
                TipoArtigo tipo = db.TiposArtigo.FirstOrDefault(t => t.Id == id);
                if (tipo == null) return false;

                tipo.Categoria = novaCategoria;
                db.SaveChanges();
                return true;
            }
        }

        public bool removerTipoArtigo(int id)
        {
            using (var db = new ShoppingContext())
            {
                TipoArtigo tipo = db.TiposArtigo.FirstOrDefault(t => t.Id == id);
                if (tipo == null) return false;

                db.TiposArtigo.Remove(tipo);
                db.SaveChanges();
                return true;
            }
        }
    }
}
