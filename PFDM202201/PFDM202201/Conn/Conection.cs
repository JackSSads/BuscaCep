namespace PFDM202201.Conn
{
    internal class Conection
    {
        /// <summary>
        /// Parâmetros para fazer a conecção com o banco de dados 
        /// </summary>
        private static string host = "host";
        private static string port = "5432";
        private static string user = "root";
        private static string database = "banco_de_dados";
        private static string password = "";

        public string Connstring()  // Retorno da istring de conecxão
        {
            return $"server={host};db={database};userId={user};port={port};password={password}";
        }
    }
}
