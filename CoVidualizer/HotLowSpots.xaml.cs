using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;


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

        


        //Filling based on the preference "YourLocation". The default is Australia
        public async Task<bool> populateYourLocationUI(Models.Country yourLocation)
        {

            labelYourLocationTitle2.Text = yourLocation.name.ToString();

            labelYLCasesPerMillionAmount.Text = yourLocation.cases_per_million_population.ToString();

            return true;

        }

        public async Task<bool> populateHotSpotUI(List<Models.Country> listOfHotSpots)
        {
            try
            {
                listViewHotSpot.ItemsSource = listOfHotSpots;

                return true;
            }
            catch
            {
                return false;
            }
            


        }

        public async Task<bool> populateLowSpotsUI(List<Models.Country> listOfLowSpots)
        {
            List<Models.Country> threeLowSpots = new List<Models.Country>();

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    threeLowSpots.Add(listOfLowSpots[i]);
                }


                listViewLowSpot.ItemsSource = threeLowSpots;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
