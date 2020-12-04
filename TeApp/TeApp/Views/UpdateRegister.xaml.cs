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
    public partial class UpdateRegister : ContentPage
    {
        private UsuarioApi _usuarioApi;
        private AutenticacaoApi _autenticacaoApi;
        public UpdateRegister()
        {
            InitializeComponent();
            this._usuarioApi = new UsuarioApi(new HttpClient());
            this._autenticacaoApi = new AutenticacaoApi(new HttpClient());

            GetUserDataById(GlobalUserModel.UserModel.idResponsavel, GlobalUserModel.UserModel.idCrianca);
        }

        public async void GetUserDataById(int idResponsavel, int idCrianca)
        {
            await Navigation.PushPopupAsync(new Loading());

            var resultado = await this._usuarioApi.GetUsuario(idResponsavel, idCrianca);

            if (resultado.Success)
            {
                var dadosUsuario = resultado.Content;

                PSexo.SelectedItem = dadosUsuario.sexoCrianca;
                BindingContext = dadosUsuario;
            }
            else
            {
                await DisplayAlert("Erro!", "Erro ao buscar informações de usuário tente novamente mais tarde", "OK");
                await Navigation.PopAsync();
            }

            await Navigation.PopAllPopupAsync();
        }

        private void ReturnToLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string nomeResponsavel = TxtNomeResponsavel.Text;
            //string email = TxtEmail.Text;
            string password = TxtNovaSenha.Text;
            string antigaSenha = TxtAntigaSenha.Text;
            string nomeCrianca = TxtNomeCrianca.Text;
            DateTime dataNasc = DpkDataNasc.Date;
            string sexo = PSexo.SelectedItem == null ? "" : PSexo.SelectedItem.ToString();

            await Navigation.PushPopupAsync(new Loading());

            UsuarioUpdateModel user = new UsuarioUpdateModel()
            {
                IdResponsavel = (short)GlobalUserModel.UserModel.idResponsavel,
                IdCrianca = (short)GlobalUserModel.UserModel.idCrianca,
                NomeResponsavel = nomeResponsavel,
                NovaSenha = password,
                AntigaSenha = antigaSenha,
                NomeCrianca = nomeCrianca,
                DataNascimentoCrianca = dataNasc,
                SexoCrianca = sexo
            };

            //TODO: Chamar a função de InsertUsuario
            var resultado = await this._usuarioApi.UpdateUsuario(user);
            if (resultado.Success)
            {
                await DisplayAlert("Parabéns!", "Usuário alterado cadastrado com sucesso!", "OK");
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