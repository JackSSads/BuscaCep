using System;
using PFDM202201.Conn;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PFDM202201
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAdmin : ContentPage
    {
        ClassBase classb = new ClassBase();

        public PageAdmin()
        {
            InitializeComponent();
        }

        private void pckUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(btnBuscar.Text))
            {
                string[] result = classb.GetAllUsers(etBusca.Text);

                if (result[0] != "0")
                {
                    lblId.Text = result[0];
                    lblNome.Text = result[1];
                    lblEmail.Text = result[2];
                    lblSenha.Text = result[3];
                    lblDataC.Text = result[4];
                }
                else
                {
                    DisplayAlert("Erro", "Usuário não cadastrado", "Tente novamente");
                }

                
            }
            else
            {
                DisplayAlert("Campo vazio", "Informe um e-mail para fazer a verificação", "Voltar");
            }
            
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                string delete = classb.DeleteUser(lblId.Text);
             
                DisplayAlert("Retorno", $"{delete}", "Ok");

                lblId.Text = "";
                lblNome.Text = "";
                lblEmail.Text = "";
                lblSenha.Text = "";
                lblDataC.Text = "";
                etBusca.Text = "";
            }
            else
            {
                DisplayAlert("Erro", "Usuário não encontrado", "Tente novamente");
            }
        }
    }
}