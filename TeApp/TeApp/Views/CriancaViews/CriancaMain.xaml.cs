using System;
using System.Net.Http;
using TeApp.Apis;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeApp.Views.CriancaViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriancaMain : ContentPage
    {
        private HumorApi _humorApi;

        public CriancaMain()
        {
            InitializeComponent();
            this._humorApi = new HumorApi(new HttpClient());
        }

        private async void img_meuhumor_Clicked(object sender, EventArgs e)
        {
            var humores = await this._humorApi.GetHumores();
            await Navigation.PushAsync(new HumorCrianca());
        }
    }
}