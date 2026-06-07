using ProjetoDA.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.controllers
{
    internal class OrcamentoController
    {
        public List<Orcamento> getOrcamentos()
        {
            using (var db = new ShoppingContext())
            {
                return db.Orcamentos.Include("UserCria").Include("UserAltera").ToList();
            }
        }

        public bool salvarOuAtualizarOrcamento(int mes, int ano, int valorMaximo, int utilizadorLogadoId)
        {
            using (var db = new ShoppingContext())
            {
                Utilizador user = db.Utilizadores.FirstOrDefault(u => u.Id == utilizadorLogadoId);
                if (user == null) return false;

                // Verifica se já existe orçamento para este mês e ano
                Orcamento existente = db.Orcamentos.FirstOrDefault(o => o.Mes == mes && o.Ano == ano);

                if (existente == null)
                {
                    // Criação de raiz
                    Orcamento novo = new Orcamento(valorMaximo, mes, ano, user);
                    db.Orcamentos.Add(novo);
                }
                else
                {
                    // Alteração do existente (Guarda quem alterou)
                    existente.ValorMaximo = valorMaximo;
                    existente.UserAltera = user;
                }

                db.SaveChanges();
                return true;
            }
        }
    }
}
