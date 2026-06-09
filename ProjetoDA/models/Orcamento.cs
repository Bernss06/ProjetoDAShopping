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
        // Passa a decimal para suportar cêntimos
        public decimal ValorMaximo { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public Utilizador UserCria { get; set; }
        public Utilizador UserAltera { get; set; }

        public Orcamento() { }

        // Alterar também aqui no construtor
        public Orcamento(decimal valorMaximo, int mes, int ano, Utilizador userCria)
        {
            ValorMaximo = valorMaximo;
            Mes = mes;
            Ano = ano;
            UserCria = userCria;
        }
    }
}