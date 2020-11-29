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
using TeApp.Models.Usuario;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        private UsuarioApi _usuarioApi;
        private AutenticacaoApi _autenticacaoApi;
        public Register()
        {
            InitializeComponent();
            this._usuarioApi = new UsuarioApi(new HttpClient());
            this._autenticacaoApi = new AutenticacaoApi(new HttpClient());
        }

        private void ReturnToLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string nomeResponsavel = TxtNomeResponsavel.Text;
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;
            string confirmPassword = TxtConfirmPassword.Text;
            string nomeCrianca = TxtNomeCrianca.Text;
            DateTime dataNasc = DpkDataNasc.Date;
            string sexo = PSexo.SelectedItem.ToString();

            await Navigation.PushPopupAsync(new Loading());

            UsuarioInsertModel user = new UsuarioInsertModel()
            {
                NomeResponsavel = nomeResponsavel,
                Email = email,
                Senha = password,
                SenhaRepetida = confirmPassword,
                NomeCrianca = nomeCrianca,
                DataNascimentoCrianca = dataNasc,
                SexoCrianca = sexo
            };

            //TODO: Chamar a função de InsertUsuario
            var resultado = await this._usuarioApi.InsertUsuario(user);
            if (resultado.Success)
            {
                await DisplayAlert("Parabéns!", "Usuário cadastrado cadastrado com sucesso!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Erro!", "Erro no cadastro de usuário", "OK");
            }

            await Navigation.PopAllPopupAsync();
        }
    }
}