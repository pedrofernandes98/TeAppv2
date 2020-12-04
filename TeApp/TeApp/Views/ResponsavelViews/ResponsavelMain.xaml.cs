using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeApp.Apis;
using TeApp.Helpers.Loading;
using TeApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeApp.Views.ResponsavelViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResponsavelMain : ContentPage
    {
        private UsuarioApi _usuarioApi;
        public ResponsavelMain()
        {
            InitializeComponent();

            this._usuarioApi = new UsuarioApi(new HttpClient());

            if (string.IsNullOrEmpty(GlobalUserModel.UserModel.nomeResponsavel))
            {
                GetUserDataById(GlobalUserModel.UserModel.idResponsavel, GlobalUserModel.UserModel.idCrianca);
            }
            else
            {
                BindingContext = GlobalUserModel.UserModel;
            }

        }

        private void img_edit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UpdateRegister());
        }

        private void img_acompanharHumor_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AcompanharHumor());
        }

        public async void GetUserDataById(int idResponsavel, int idCrianca)
        {
            await Navigation.PushPopupAsync(new Loading());

            var resultado = await this._usuarioApi.GetUsuario(idResponsavel, idCrianca);

            if (resultado.Success)
            {
                var dadosUsuario = resultado.Content;
                BindingContext = dadosUsuario;

                GlobalUserModel.UserModel.nomeCrianca = dadosUsuario.nomeCrianca;
                GlobalUserModel.UserModel.nomeResponsavel = dadosUsuario.nomeResponsavel;
            }
            else
            {
                await DisplayAlert("Erro!", "Erro ao buscar informações de usuário tente novamente mais tarde", "OK");
                await Navigation.PopAsync();
            }

            //await Navigation.PopAllPopupAsync();
        }
    }
}