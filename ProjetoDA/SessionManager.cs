using System;

namespace ProjetoDA
{
    /// <summary>
    /// Gerencia a sessão do utilizador logado na aplicação.
    /// </summary>
    internal static class SessionManager
    {
        public static int UtilizadorLogadoId { get; set; }

        public static void ClearSession()
        {
            UtilizadorLogadoId = 0;
        }
    }
}