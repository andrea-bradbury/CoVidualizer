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

            labelYourLocationTitle2.Text = yourLocation.name;

            labelYLCasesPerMillionAmount.Text = $" {yourLocation.cases_per_million_population.ToString("#,##0")} cases per million";

            return true;

        }

        public async Task<bool> populateHotSpotUI(List<Models.Country> listOfHotSpots)
        {
            try
            {
                List<string> listForListView = new List<string>();

                for (int i = 0; i <listOfHotSpots.Count; i++)
                {
                    string  countryName = listOfHotSpots[i].name;

                    string countryCPM = listOfHotSpots[i].cases_per_million_population.ToString("#,##0");

                    string fullCountry = $" {countryName}  |  {countryCPM} cases per million";

                    listForListView.Add(fullCountry);
                }

                
                listViewHotSpot.ItemsSource = listForListView;

                

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


                List<string> listForListView = new List<string>();

                for (int i = 0; i < threeLowSpots.Count; i++)
                {
                    string countryName = threeLowSpots[i].name;

                    string countryCPM = threeLowSpots[i].cases_per_million_population.ToString("#,##0");

                    string fullCountry = $" {countryName}  |  {countryCPM} cases per million";

                    listForListView.Add(fullCountry);
                }

                listViewLowSpot.ItemsSource = listForListView;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
