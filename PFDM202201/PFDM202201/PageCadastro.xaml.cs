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

        // Instância da classe ClassBase
        ClassBase classBase = new ClassBase();
        public string name;
        public string user;
        public string pass;
        public string confPass;

        private async void Insert() // Método para inserssão
        {
            name = etName.Text;
            user = etUser.Text;
            pass = etPass.Text;
            confPass = etConfPass.Text;

            // instância do DateTime
            DateTime date = DateTime.Now; 

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(user) && 
                !string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(confPass))
            {
                if (pass == confPass && pass.Length >= 8)
                {
                    try
                    {
                        // Chamada do método Insert passando nome, email, senha e data de inserssão
                        classBase.Insert(name, user, pass, date);

                        try
                        {   
                            // Disparo de e-mail

                            string from = "email@example.com"; // Quem vai enviar 
                            string to = user; // Para onde vai ser enviado

                            // Instanciando e passando o REMETENTE e o DESTINATÁRIO, respectivamente
                            MailMessage mail = new MailMessage(from, to);

                            // Titulo do e-mail
                            mail.Subject = "CEP - Cadastro realizado com sucesso";
                            // Ativação do corpo em HTML
                            mail.IsBodyHtml = true;
                            // Mensagem do e-mail
                            mail.Body = $"CEP<br/>Olá {name}! Obrigado por fazer seu cadastro no CEP<br/>" +
                                $"Seu usuário é <span>{user}</span><br/><br/>Cep</p>";

                            // Configuração do body HTML em UTF-8 
                            mail.BodyEncoding = Encoding.GetEncoding("UTF-8");
                            // Configuração do titulo em UTF-8
                            mail.SubjectEncoding = Encoding.GetEncoding("UTF-8");

                            // Conecxão com o servidor (Microsoft)
                            SmtpClient client = new SmtpClient("smtp.office365.com", 587);

                            // Desativação do uso das credenciais Default
                            client.UseDefaultCredentials = false;
                            // Credenciais
                            client.Credentials = new NetworkCredential("email@example.com", "senhadaconta");

                            // Criptografia SSL
                            client.EnableSsl = true;

                            // Envio do e-mail1
                            client.Send(mail);
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
                }
                else
                {
                    await DisplayAlert("Senhas inválidas",
                        "Digite uma senha com no mínimo 8 caracteres e tente novamente",
                        "Tente novamente");
                }

                etName.Text = "";
                etUser.Text = "";
                etPass.Text = "";
                etConfPass.Text = "";
            }
            else
            {
                await DisplayAlert("Campo vazio",
                    "Preencha todos os campos corretamente",
                    "Tente novamente");
            }

        }
        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            Insert();
        }
    }
}