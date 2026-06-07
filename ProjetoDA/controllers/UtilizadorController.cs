using ProjetoDA.modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoDA.controllers
{
    internal class UtilizadorController
    {
        // 1. Vai buscar a lista de todos os utilizadores à base de dados
        public List<Utilizador> getUtilizadores()
        {
            using (var db = new ShoppingContext())
            {
                return db.Utilizadores.ToList();
            }
        }

        // 2. Cria um novo utilizador, cumprindo a Regra 4 do Enunciado (Username Único)
        public bool adicionarUtilizador(string username, string password)
        {
            using (var db = new ShoppingContext())
            {
                // Verifica primeiro se já existe alguém com o mesmo Username
                if (db.Utilizadores.Any(u => u.Username == username))
                {
                    return false; // Retorna falso porque o username já está em uso
                }

                // Se estiver livre, cria o objeto e guarda na base de dados
                Utilizador novo = new Utilizador(username, password);
                db.Utilizadores.Add(novo);
                db.SaveChanges();

                return true;
            }
        }

        // 3. Edita a palavra-passe de um utilizador existente
        public bool editarUtilizador(int id, string novaPassword)
        {
            using (var db = new ShoppingContext())
            {
                // Vai buscar o *objeto* Utilizador com base no ID recebido
                Utilizador user = db.Utilizadores.FirstOrDefault(u => u.Id == id);

                // Se não encontrar o utilizador, cancela a operação
                if (user == null)
                {
                    return false;
                }

                // Atualiza a password com o valor novo
                user.Password = novaPassword;
                db.SaveChanges();

                return true;
            }
        }

        // 4. Apaga o utilizador da base de dados
        public bool removerUtilizador(int id)
        {
            using (var db = new ShoppingContext())
            {
                // Vai buscar o *objeto* Utilizador à base de dados
                Utilizador user = db.Utilizadores.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return false;
                }

                // Remove e guarda as alterações
                db.Utilizadores.Remove(user);
                db.SaveChanges();

                return true;
            }
        }
    }
}