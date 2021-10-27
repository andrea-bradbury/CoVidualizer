using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace CoVidualizer
{
    public partial class YourLocation : ContentPage
    {
        public YourLocation()
        {
            InitializeComponent();

            labelYourLocationTitle2.Text = Preferences.Get("YourLocation", "Australia");

        }

        async void buttonBack2_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await Navigation.PopModalAsync();
            }
            catch
            {

            }
        }

        async void buttonSeeWorldHotSpots_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                HotLowSpots hotLowSpots = new HotLowSpots();

                await Navigation.PushModalAsync(hotLowSpots);
            }
            catch
            {

            }
        }

        async void populateCountryData()
        {
            string yourLocation = Preferences.Get("YourLocation", "Australia");

            

            
        }
    }
}
