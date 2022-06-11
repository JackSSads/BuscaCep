using PFDM202201.Conn;
using System;
using Xamarin.Forms;

namespace PFDM202201
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        ClassBase classBase = new ClassBase();

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {

            if (etUser.Text != null && etPass.Text != null && etPass.Text.Length >= 8)
            {


                string[] data = classBase.Verifica(etUser.Text, etPass.Text);

                string Email = data[0];
                string Senha = data[1];



                if (etUser.Text == Email && etPass.Text == Senha)
                {


                    etUser.Text = "";
                    etPass.Text = "";

                    await Navigation.PushAsync(new PageConsulta());


                }
                else
                {
                    await DisplayAlert("Dados inválidos!",
                   "Usuário ou senha inválidos, confirme os dados e tente novamente",
                   "Tente novamente");
                }

            }
            else
            {
                await DisplayAlert("Dados inválidos",
                        "Preencha os campos com um e-mail e uma senha contendo no mínimo 8 dígitos",
                        "Tente novamente");
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
