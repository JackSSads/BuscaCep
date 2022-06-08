using Npgsql;
using System;
using System.Data;
using Xamarin.Forms;

namespace PFDM202201.Conn
{
    internal class ClassBase
    {
        Conection conection = new Conection();                  // Chamada da classe Conection
        NavigationPage navigationPage = new NavigationPage();   // Instância da classe NavigationPage

        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        private NpgsqlDataReader dr;

        public bool vericicador = false;    // Variável resposta 
        public string err = "";             // Variável para armazenar erro caso a verificação falhe

        public void Insert(string us_email, string us_pass, DateTime us_criationdate)
        {
            conn = new NpgsqlConnection(conection.Connstring()); // Criando conecxão com o banco de dados
            try
            {
                conn.Open();    // Abrindo conecxão
                
                sql = $"select * from tb_insert('{us_email}'," +
                    $" '{us_pass}', '{us_criationdate}');";     // String de inserção de dados no banco

                cmd = new NpgsqlCommand(sql, conn); // comando de execução. Requer uma string SQL
                                                    // e a conecxão com o banco
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                conn.Close();   // Fechando conecxão
            }
            catch (Exception ex)
            {
                conn.Close(); 
                Console.WriteLine(ex.Message); // Retorno do erro
            }
        }
        public async void Redirect()
        {
            await navigationPage.PushAsync(new PageConsulta()); // Redirecionando para a página de consulta (PageConsulta)
        }
        public bool Verifica(string us_email, string us_pass)
        {
            conn = new NpgsqlConnection(conection.Connstring()); 

            try
            {
                conn.Open();

                sql = $"SELECT us_email, us_pass FROM tb_usuario_login WHERE us_email = '{us_email}' AND us_pass = '{us_pass}';";

                cmd = new NpgsqlCommand(sql, conn);

                dt = new DataTable();

                dt.Load(cmd.ExecuteReader());

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    vericicador = true;
                    Redirect();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine("Erro de comunicação no banco de dados! = " + ex.Message);
                this.err = "Erro de comunicação no banco de dados!";
            }
            return vericicador;
        }
    }
}
