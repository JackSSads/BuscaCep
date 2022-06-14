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

        public void Insert(string us_name, string us_email, string us_pass, DateTime us_criationdate)
        {
            conn = new NpgsqlConnection(conection.Connstring()); // Criando conecxão com o banco de dados
            try
            {
                conn.Open();    // Abrindo conecxão

                sql = $"INSERT INTO tb_usuario_login(us_name, us_email, us_pass, us_date)" +
                    $" VALUES ('{us_name}', '{us_email}', '{us_pass}', '{us_criationdate}')"; // String de inserção de dados no banco

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
        public string[] Verifica(string us_email, string us_pass)
        {
            string[] data = { "Erro", "Erro" };
            try
            {
                conn = new NpgsqlConnection(conection.Connstring());
                conn.Open();

                sql = $"SELECT us_email, us_pass FROM tb_usuario_login WHERE us_email = '{us_email}' AND us_pass = '{us_pass}';";

                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;

                // recebe o conteúdo que vem do banco
                dr = cmd.ExecuteReader();

                // lendo os dados das tabelas
                dr.Read();

                string email = dr.GetString(0);
                string senha = dr.GetString(1);

                string[] result = { email, senha };

                conn.Close();

                return result;
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine("Erro de comunicação no banco de dados! = " + ex.Message);
                this.err = "Erro de comunicação no banco de dados!";
            }
            return data;
        }

        public string[] GetAllUsers(string us_email)
        {
            string[] err = { "0" };

            try
            {
                conn = new NpgsqlConnection(conection.Connstring());
                conn.Open();

                sql = $"SELECT us_id, us_name, us_email, us_pass, us_date FROM tb_usuario_login WHERE us_email = '{us_email}';";

                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;

                // recebe o conteúdo que vem do banco
                dr = cmd.ExecuteReader();

                // lendo os dados das tabelas
                
                try
                {
                    dr.Read();
                
                    string id = dr.GetInt32(0).ToString();
                    string nome = dr.GetString(1);
                    string email = dr.GetString(2);
                    string senha = dr.GetString(3);
                    string data = dr.GetDateTime(4).ToString();

                    string[] result = { id, nome, email, senha, data };

                    conn.Close();

                    return result;

                }
                catch
                {
                    conn.Close();

                    return err;
                }


            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine("Erro de comunicação no banco de dados! = " + ex.Message);
                this.err = "Erro de comunicação no banco de dados!";
                return err;
            }
        }

        public string DeleteUser(string us_id)
        {
            try
            {
                conn = new NpgsqlConnection(conection.Connstring());
                conn.Open();    // Abrindo conecxão

                sql = $"DELETE FROM tb_usuario_login WHERE us_id = {us_id};";

                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.Clear();

                dr = cmd.ExecuteReader();

                conn.Close();

                return "Secesso";
            }
            catch (Exception ex)
            {
                conn.Close();

                return "Erro!: " + ex.Message;
            }
        }
    }
}






