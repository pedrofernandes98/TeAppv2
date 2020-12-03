using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeApp.Views.ResponsavelViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResponsavelMain : ContentPage
    {
        public ResponsavelMain()
        {
            InitializeComponent();
            
            //Title = "Menu Principal";


            //NavigationPage.SetHasBackButton(this, false);


            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#2DDB58");
        }

        private void img_edit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UpdateRegister());
        }

        private void img_acompanharHumor_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AcompanharHumor());
        }
    }
}