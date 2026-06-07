using ProjetoDA.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA
{
    public class Compra
    {
        public int Id { get; set; }
        public string NomeCompra { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataFechada { get; set; }
        public bool Fechada { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime? DataAlteracao { get; set; }

        // Relações com o Utilizador
        public Utilizador UserCria { get; set; }
        public Utilizador UserEdita { get; set; }
        public Utilizador UserFecha { get; set; }
        public List<ItemCompra> Itens { get; set; }

        // Construtor vazio obrigatório para o Entity Framework
        public Compra()
        {
            Itens = new List<ItemCompra>(); // Garante que a lista não é nula
        }

        
        public Compra(string nomeCompra, Utilizador userCria)
        {
            NomeCompra = nomeCompra;
            UserCria = userCria;
            DataCriacao = DateTime.Now;
            Fechada = false;
            Itens = new List<ItemCompra>();
        }

        public override string ToString()
        {
            return NomeCompra;
        }
    }
}
