using PFDM202201.Conn;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PFDM202201
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        ClassBase classBase = new ClassBase();  // Instância da classe ClassBase
        public string user;
        public string pass;
        public bool vericicador;
        public string err = "";
        private bool GetData(string us_email, string us_pass)
        {
            try
            {
                classBase.Verifica(us_email, us_pass);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"{ex.Message}", "Tente novamente");
            }
            if (!classBase.err.Equals(""))
            {
                this.err = classBase.err;
            }
            return vericicador;
        }
        private async Task emailErroAsync()
        {
            if (etUser.Text != null && etPass.Text != pass)
            {
                try
                {
                    string to = "fotosjackson2018@hotmail.com"; // Para onde vai ser enviado
                    string from = "contatoJacksonSouza@hotmail.com"; // Quem vai enviar 

                    MailMessage mail = new MailMessage(from, to); // Instanciando e passando o REMETENTE e o DESTINATÁRIO, respectivamente

                    mail.Subject = "Tentativas de senha incorreta"; // Titulo do e-maail

                    mail.IsBodyHtml = true; // Ativação do corpo em HTML
                    mail.Body = $"APP CEP<br/>Usuário:{user}<br/>Mensagem: Senha incorreta!</p>"; // Mensagem do e-mail

                    mail.BodyEncoding = Encoding.GetEncoding("UTF-8"); // Configuração do body HTML em UTF-8 
                    mail.SubjectEncoding = Encoding.GetEncoding("UTF-8"); // Configuração do titulo em UTF-8

                    SmtpClient client = new SmtpClient("smtp.office365.com", 587); // Conecção com o servidor (Microsoft)

                    client.UseDefaultCredentials = false; // Desativação do uso das credenciais Default
                    client.Credentials = new NetworkCredential("contatoJacksonSouza@hotmail.com", "Evolution2011*!@#$%"); // Credenciais

                    client.EnableSsl = true; // Criptografia SSL

                    client.Send(mail); // Envio do e-mail

                    await DisplayAlert("Erro", "Senha incorreta", "Tente novamente");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", $"{ex.Message}", "Tente novamente");
                }
            }
        }
        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            user = etUser.Text;
            pass = etPass.Text;

            GetData(user, pass);
            _ = emailErroAsync();
        }
        private async void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageCadastro()); // Redirecionamento para a página Cadastro (PageCadastro)

            etUser.Text = "";
            etPass.Text = "";
        }
    }
}
