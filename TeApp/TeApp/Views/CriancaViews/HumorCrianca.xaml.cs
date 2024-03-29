﻿using Rg.Plugins.Popup.Extensions;
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

        private async void img_sad_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new Popups.PopupTriste());
        }

        private async void img_medo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new Popups.PopupMedo());
        }

        private async void img_raiva_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new Popups.PopupRaiva());
        }

        private async void img_surpresa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new Popups.PopupSurpreso());
        }

        private async void img_nojo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new Popups.PopupNojo());
        }
    }
}