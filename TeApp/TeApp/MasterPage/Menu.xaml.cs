using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}