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
        //Instantiate the data model
        public Models.Rootobject root = new Models.Rootobject();

        //List of countries as names
        List<string> listOfCountries = new List<string>();


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

        public async Task<bool> populateCountryData()
        {
            string yourLocation = Preferences.Get("YourLocation", "Australia");

            try
            {
                listOfCountries = root.data.Select(data => data.name).ToList();



                for (int i = 0; i < listOfCountries.Count; i++)
                {
                    if (yourLocation == root.data[i].name)
                    {
                        labelTotalCasesAmount.Text = root.data[i].latest_data.confirmed.ToString();

                        labelTotalDeathsAmount.Text = root.data[i].latest_data.deaths.ToString();

                        labelTodaysCasessAmount.Text = root.data[i].today.confirmed.ToString();

                        labelTodaysDeathsAmount.Text = root.data[i].today.deaths.ToString();

                        labelRecoveryRateAmount.Text = root.data[i].latest_data.calculated.recovery_rate.ToString();

                        labelDeathRateAmount.Text = root.data[i].latest_data.calculated.death_rate.ToString();


                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
            


            


        }
    }
}
