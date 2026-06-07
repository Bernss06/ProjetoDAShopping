using ProjetoDA.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA
{
    public class Orcamento
    {
        public int Id { get; set; }
        public int ValorMaximo { get; set; } // No diagrama está definido como 'int'
        public int Mes { get; set; }
        public int Ano { get; set; }

        // Relações com Utilizador indicadas no diagrama (user cria, user altera)
        public Utilizador UserCria { get; set; }
        public Utilizador UserAltera { get; set; }

        public Orcamento() { }

        public Orcamento(int valorMaximo, int mes, int ano, Utilizador userCria)
        {
            ValorMaximo = valorMaximo;
            Mes = mes;
            Ano = ano;
            UserCria = userCria;
        }
    }
}
