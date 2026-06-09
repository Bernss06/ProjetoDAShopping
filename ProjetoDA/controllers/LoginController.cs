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
            {
                System.Diagnostics.Debug.WriteLine("Erro: Username ou Password vazios");
                return -1;
            }

            try
            {
                using (var db = new ShoppingContext())
                {
                    // Trim para remover espaços
                    string usernameNormalizado = username.Trim().ToLower();
                    string passwordNormalizada = password.Trim();

                    System.Diagnostics.Debug.WriteLine($"[LOGIN] Procurando utilizador: '{usernameNormalizado}'");

                    // Comparação case-insensitive para username
                    Utilizador utilizador = db.Utilizadores.FirstOrDefault(u =>
                        u.Username.ToLower() == usernameNormalizado &&
                        u.Password == passwordNormalizada);

                    if (utilizador != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"[LOGIN SUCESSO] Utilizador '{utilizador.Username}' autenticado com ID: {utilizador.Id}");
                        return utilizador.Id;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"[LOGIN FALHOU] Utilizador ou password incorretos");

                        // Debug: Listar utilizadores disponíveis
                        int totalUsers = db.Utilizadores.Count();
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] Total de utilizadores na BD: {totalUsers}");
                        
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERRO LOGIN] {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"[STACK TRACE] {ex.StackTrace}");
                return -1;
            }
        }
    }
}