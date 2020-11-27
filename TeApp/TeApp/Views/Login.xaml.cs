using System;
using System.Net.Http;
using TeApp.Apis;
using TeApp.Models.Autenticacao;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private UsuarioApi _usuarioApi;
        private AutenticacaoApi _autenticacaoApi;

        public Login()
        {
            InitializeComponent();
            this._usuarioApi = new UsuarioApi(new HttpClient());
            this._autenticacaoApi = new AutenticacaoApi(new HttpClient());

            this._autenticacaoApi.LoginResponsavel(new AutenticacaoModel
            {
                Email = "teste",
                Senha = "Teste"
            });
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private async void Entrar_Clicked(object sender, EventArgs e)
        {
            //TODO: Chamar a função de InsertUsuario


            App.Current.MainPage = new MasterPage.Menu();
        }
    }
}