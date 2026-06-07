using System;
using System.Linq;
using ProjetoDA.modelos;

namespace ProjetoDA.controllers
{
    internal class LoginController
    {
        public int AutenticarUtilizador(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return -1;

            try
            {
                using (var db = new ShoppingContext())
                {
                    Utilizador utilizador = db.Utilizadores.FirstOrDefault(u =>
                        u.Username == username &&
                        u.Password == password);

                    return utilizador != null ? utilizador.Id : -1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro login: {ex.Message}");
                return -1;
            }
        }
    }
}