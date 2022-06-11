namespace PFDM202201.Conn
{
    internal class Conection
    {
        /// <summary>
        /// Parâmetros para fazer a conecção com o banco de dados 
        /// </summary>
        private static string host = "ec2-44-196-174-238.compute-1.amazonaws.com";
        private static string port = "5432";
        private static string user = "ffgfgeaaqdunme";
        private static string database = "dbi2unknbqgvf9";
        private static string password = "9bba8a08904cfc299acbef7ac294272c740c57d94760463b713d3440b01fcfd5";

        public string Connstring()  // Retorno da istring de conecxão
        {
            return $"server={host};db={database};userId={user};port={port};password={password}";
        }
    }
}
