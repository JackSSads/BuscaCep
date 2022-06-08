using PFDM202201.Models;
using System;
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

        private int erroLogin = 0;
        public string Email = "jackson";
        public string Senha = "123";

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {

            

            if (Email != null && Senha != null)
            {

                if (etUser.Text == Email && etPass.Text == Senha)
                {


                    etUser.Text = "";
                    etPass.Text = "";

                    await Navigation.PushAsync(new PageConsulta());


                }
                else
                {
                    erroLogin = +1;

                    if (erroLogin >= 3)
                    {
                        await DisplayAlert("Erro", "Você digitou uma senha incorreta por três vezes", "Tente Novamenter");
                        erroLogin = 0;
                    }

                    await DisplayAlert("Dados inválidos", "E-mail ou senha incorreto", "Tente novamente");
                }

            }
            else
            {
                await DisplayAlert("Preencha os campos!", "Preencha os campos com e-amil e senha", "Tente novamente");
            }

        }
        private async void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageCadastro()); // Redirecionamento para a página Cadastro (PageCadastro)

            etUser.Text = "";
            etPass.Text = "";
        }
    }
}
