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


                //Need to add in populate Hot Spot Low Spot Page data 


            }
            catch
            {

            }
        }

        public async Task<bool> populateCountryData(Models.Country yourLocationData)
        {


            labelTotalCasesAmount.Text = yourLocationData.totalConfirmed.ToString();

            labelTotalDeathsAmount.Text = yourLocationData.totalDeaths.ToString();

            labelTodaysCasesAmount.Text = yourLocationData.todaysConfirmed.ToString();

            labelTodaysDeathsAmount.Text = yourLocationData.todaysDeaths.ToString();

            labelRecoveryRateAmount.Text = yourLocationData.recovery_rate.ToString();

            labelDeathRateAmount.Text = yourLocationData.death_rate.ToString();

            return true;
        }
    }
}
