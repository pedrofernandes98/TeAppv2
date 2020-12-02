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
using TeApp.Models.CriancaHumor;
using TeApp.ViewModels;
using TeApp.Views.ResponsavelViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeApp.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupObservacao : PopupPage
    {
        private CriancaHumorApi _criancahumorApi;
        public PopupObservacao()
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
            var eventArgs = (Button)sender;
            var criancaHumor = (CriancaHumorViewModel)eventArgs.CommandParameter;


            int id = criancaHumor.Id;
            int idCrianca = criancaHumor.IdCrianca;
            string obs = criancaHumor.Observacao;

            this.IsVisible = false;

            await Navigation.PushPopupAsync(new Loading());

            var resultado = await this._criancahumorApi.UpdateCriancaHumorComentario(new CriancaHumorUpdateObservacaoModel 
            { 
                IdCriancaHumor = id,
                IdCrianca = idCrianca,
                Observacao = obs
            });

            if (resultado.Success)
            {
                await DisplayAlert("Parabéns!", "Sua observação foi cadastrada com sucesso!", "OK");
            }
            else
            {
                await DisplayAlert("Erro!", "Houve um erro no cadastro da sua observação, por favor tente novamente!", "OK");
            }
            MessagingCenter.Send<App>((App)Application.Current, "OnCategoryCreated");
            await Navigation.PopAllPopupAsync();

        }
    }
}