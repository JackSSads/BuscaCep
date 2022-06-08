using PFDM202201.Conn;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PFDM202201
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastro : ContentPage
    {
        public PageCadastro()
        {
            InitializeComponent();
        }

        ClassBase classBase = new ClassBase();  // Instância da classe ClassBase
        string user;
        string pass;
        string confPass;

        private async void Insert() // Método para inserssão
        {
            user = etUser.Text;
            pass = etPass.Text;
            confPass = etConfPass.Text;
            DateTime date = DateTime.Now; // instância do DateTime

            if (user != null && pass == confPass)
            {
                try
                {
                    classBase.Insert(user, pass, date); // Chamada do método Insert passando usuário, senha e data de inserssão

                    try
                    {
                        string from = "apicep@outlook.com"; // Quem vai enviar 
                        string to = user; // Para onde vai ser enviado

                        MailMessage mail = new MailMessage(from, to); // Instanciando e passando o REMETENTE e o DESTINATÁRIO, respectivamente

                        mail.Subject = "APP CEP - Cadastro realizado com sucesso"; // Titulo do e-maail

                        mail.IsBodyHtml = true; // Ativação do corpo em HTML
                        mail.Body = $"APP CEP<br/>Usuário: {user}<br/>Obrigado por se cadastrar no Api Cep</p>"; // Mensagem do e-mail

                        mail.BodyEncoding = Encoding.GetEncoding("UTF-8"); // Configuração do body HTML em UTF-8 
                        mail.SubjectEncoding = Encoding.GetEncoding("UTF-8"); // Configuração do titulo em UTF-8

                        SmtpClient client = new SmtpClient("smtp.office365.com", 587); // Conecção com o servidor (Microsoft)

                        client.UseDefaultCredentials = false; // Desativação do uso das credenciais Default
                        client.Credentials = new NetworkCredential("apicep@outlook.com", "senhadaconta12345"); // Credenciais

                        client.EnableSsl = true; // Criptografia SSL

                        client.Send(mail); // Envio do e-mail
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    await DisplayAlert("Sucesso", "Cadastro Realizado com Sucesso", "OK");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                etUser.Text = "";
                etPass.Text = "";
                etConfPass.Text = "";
            }
            else
            {
                await DisplayAlert("Senha incorreta", "Confirme sua senha para finalizar o cadastro", "Tente novamente");
            }
        }
        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            Insert();
        }
    }
}