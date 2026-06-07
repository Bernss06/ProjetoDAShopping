using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.controllers
{
    internal class ArtigoController
    {
        public List<Artigo> getArtigos()
        {
            using (var db = new ShoppingContext())
            {
                // Usa Include para trazer os dados da categoria associada, igual à Ficha 9
                return db.Artigos.Include("TipoArtigo").ToList();
            }
        }

        public bool adicionarArtigo(string nome, int tipoArtigoId)
        {
            using (var db = new ShoppingContext())
            {
                TipoArtigo tipo = db.TiposArtigo.FirstOrDefault(t => t.Id == tipoArtigoId);
                if (tipo == null) return false;

                Artigo novo = new Artigo(nome, tipo);
                db.Artigos.Add(novo);
                db.SaveChanges();
                return true;
            }
        }

        public bool editarArtigo(int id, string novoNome, int novoTipoArtigoId)
        {
            using (var db = new ShoppingContext())
            {
                Artigo artigo = db.Artigos.FirstOrDefault(a => a.Id == id);
                TipoArtigo tipo = db.TiposArtigo.FirstOrDefault(t => t.Id == novoTipoArtigoId);

                if (artigo == null || tipo == null) return false;

                artigo.Nome = novoNome;
                artigo.TipoArtigo = tipo;
                db.SaveChanges();
                return true;
            }
        }

        public bool removerArtigo(int id)
        {
            using (var db = new ShoppingContext())
            {
                Artigo artigo = db.Artigos.FirstOrDefault(a => a.Id == id);
                if (artigo == null) return false;

                db.Artigos.Remove(artigo);
                db.SaveChanges();
                return true;
            }
        }
    }
}
