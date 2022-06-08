using System;
using Correios.NET;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PFDM202201
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageConsulta : ContentPage
    {
        public PageConsulta()
        {
            InitializeComponent();
        }
        private void btnBuscaCep_Clicked(object sender, EventArgs e)
        {
            var cep = entCep.Text;
            GetCep(cep);
        }
        public async void GetCep(string cep)
        {
            try
            {
                var endereco = await new CorreiosService().GetAddressesAsync(cep);  // Chamada da API no método assincrono de retorno dos dados
                                                                                    // passando como parâmetro uma string contendo no máximo 8 digitos
                foreach (var item in endereco)  // retornando os dados para o front-end
                {
                    lblBairro.Text = item.Street;
                    lblCidade.Text = item.City;
                    lblUf.Text = item.State;
                    lblDistrito.Text = item.District;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"ERRO: {ex.Message}", "OK");
            }
        }
    }
}