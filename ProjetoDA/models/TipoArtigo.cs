using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA
{
    public class TipoArtigo
    {
        public int Id { get; set; }
        public string Categoria { get; set; } // Conforme o diagrama

        public TipoArtigo() { }

        public TipoArtigo(string categoria)
        {
            Categoria = categoria;
        }

        public override string ToString()
        {
            return Categoria;
        }
    }
}
