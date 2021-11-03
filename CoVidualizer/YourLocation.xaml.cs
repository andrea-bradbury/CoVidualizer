using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

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

                await hotLowSpots.populateYourLocationUI();

                await hotLowSpots.populateLowSpotsUI();
            }
            catch
            {

            }
        }

        public async Task<bool> populateCountryData(List<string> yourLocation)
        {


            labelTotalCasesAmount.Text = yourLocation[]

            return true;
        }
    }
}
