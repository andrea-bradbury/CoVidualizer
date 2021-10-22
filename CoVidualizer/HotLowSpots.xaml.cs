using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CoVidualizer
{
    public partial class HotLowSpots : ContentPage
    {
        public HotLowSpots()
        {
            InitializeComponent();
        }

        async void buttonBack3_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await Navigation.PopModalAsync();
            }
            catch
            {

            }
        }
    }
}
