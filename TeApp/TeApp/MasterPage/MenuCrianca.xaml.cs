using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeApp.MasterPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuCrianca : MasterDetailPage
    {
        public MenuCrianca()
        {
            InitializeComponent();
        }

        private void btnMudarVisao_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Views.Login());
        }
    }
}