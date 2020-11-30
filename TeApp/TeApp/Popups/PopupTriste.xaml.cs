using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeApp.Apis;
using TeApp.Helpers.Loading;
using TeApp.Models;
using TeApp.Models.CriancaHumor;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeApp.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupTriste : PopupPage
    {
        private CriancaHumorApi _criancahumorApi;
        const int idHumor = 3;
        public PopupTriste()
        {
            InitializeComponent();
            _criancahumorApi = new CriancaHumorApi(new HttpClient());
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAllPopupAsync();
        }

        private async void btnConfirm_Clicked(object sender, EventArgs e)
        {
            int idCrianca = GlobalUserModel.UserModel.IdCrianca;
            idCrianca = 4;

            this.IsVisible = false;

            //await Navigation.PopAllPopupAsync();
            
            await Navigation.PushPopupAsync(new Loading());

            var resultado = await this._criancahumorApi.InsertCriancaHumor(new CriancaHumorInsertModel
            {
                IdCrianca = (short)idCrianca,
                IdHumor = idHumor
            });

            if (resultado.Success)
            {
                await DisplayAlert("Parabéns!", "Seu humor foi cadastrado com sucesso!", "OK");
            }
            else
            {
                await DisplayAlert("Erro!", "Houve um erro no cadastro do seu humor, por favor tente novamente!", "OK");
            }

            await Navigation.PopAllPopupAsync();
            //await Navigation.PopPopupAsync();
        }
    }
}