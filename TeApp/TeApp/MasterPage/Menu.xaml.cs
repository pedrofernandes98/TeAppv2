using System;
using TeApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeApp.MasterPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnSair_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Login());
        }

        private void btnMudarVisao_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TeApp.MasterPage.MenuCrianca();
        }

        private void btnAlterarCadastro_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new UpdateRegister());
            IsPresented = false;
        }

        private void btnMenu_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Menu());
            IsPresented = false;
        }

        private void btnAcompanharHumor_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Views.ResponsavelViews.AcompanharHumor());
            IsPresented = false;
        }
    }
}