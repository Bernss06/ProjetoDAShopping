using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA
{
    public class Artigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Relação 1 para * com TipoArtigo (linha direta no diagrama)
        public TipoArtigo TipoArtigo { get; set; }

        public Artigo() { }

        public Artigo(string nome, TipoArtigo tipoArtigo)
        {
            Nome = nome;
            TipoArtigo = tipoArtigo;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
