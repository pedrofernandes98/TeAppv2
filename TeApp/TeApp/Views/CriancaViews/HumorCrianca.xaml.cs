using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeApp.Views.CriancaViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HumorCrianca : ContentPage
    {
        public HumorCrianca()
        {
            InitializeComponent();
        }

        private async void img_acompanharHumor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new Popups.PopupFeliz());
        }


    }
}