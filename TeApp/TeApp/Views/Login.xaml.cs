using System;
using System.Net.Http;
using System.Threading.Tasks;
using TeApp.Apis;
using TeApp.Models;
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

            
        }

        private  void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
             Navigation.PushAsync(new Register());
        }

        private async void Entrar_Clicked(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;

            //TODO: Chamar a função de InsertUsuario
            var resultado = await this._autenticacaoApi.LoginResponsavel(new AutenticacaoModel
            {
                Email = email,
                Senha = password
            });

            if (resultado.Success)
            {
                GlobalUserModel.UserModel = resultado.Content;
                App.Current.MainPage = new MasterPage.Menu();
            }
            else
            {
                await DisplayAlert("Erro!", "Usuário não encontrado!", "OK");
            }
            
            
            
        }
    }
}