namespace PFDM202201.Conn
{
    internal class Conection
    {
        /// <summary>
        /// Parâmetros para fazer a conecção com o banco de dados 
        /// </summary>
        private static string host = "host";
        private static string port = "5432";
        private static string user = "user";
        private static string database = "database";
        private static string password = "password";

        public string Connstring()  // Retorno da istring de conecxão
        {
            return $"server={host};db={database};userId={user};port={port};password={password}";
        }
    }
}
