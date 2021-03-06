using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CoVidualizer.Models;
using CoVidualizer.Services;
using Xamarin.Essentials;

namespace CoVidualizer
{
    public partial class MainPage : ContentPage
    {
        

        //Instantiate the api service 
        public APIService api = new APIService();


        

        public MainPage()
        {
            InitializeComponent();

            //Collect data from API
            Task T = accessAPI();

            
        }


        public async Task<bool> accessAPI()
        {
            //Display error message if there's no internet, if the API call is wrong or if the URL changes.

            if (await api.getAllCOVIDData() == false)
            {
                await DisplayAlert("Error, please check internet connection.", "Also check COVID site is still live", "OK");

                return false;
            }
            else
            {
                Console.WriteLine("Checking API works");

                //Set up mainpage data
                getWorldData();

                return true;
            }
        }

        


        //Calculates the main page data

        public async Task<bool> getWorldData()
        {
            try
            {
                Calculations calculations = new Calculations();


                List<int> listOfWorldCases = await api.getWorldCases();

                int totalWorldCases = await calculations.getWorldCases(listOfWorldCases);

                labelWorldCasesAmount.Text = totalWorldCases.ToString("#,##0");



                List<int> listOfWorldRecoveries = await api.getWorldRecoveries();

                int totalWorldRecoveries = await calculations.getWorldRecoveries(listOfWorldRecoveries);

                labelWorldRecoveriesAmount.Text = totalWorldRecoveries.ToString("#,##0");



                List<int> listOfWorldDeaths = await api.getWorldDeaths();

                int totalWorldDeaths = await calculations.getWorldDeaths(listOfWorldDeaths);

                labelWorldDeathsAmount.Text = totalWorldDeaths.ToString("#,##0");



                return true;
            }
            catch
            {
                await DisplayAlert("World data not available at this time", "", "OK");

                return false;
            }
        }



        async void buttonSetPreference_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                PreferencesPage preferencesPage = new PreferencesPage();

                await Navigation.PushModalAsync(preferencesPage);


                //Populating the picker for 'set your location'
                List<string> listOfCountryNames = await api.getCOVIDCountries();

                await preferencesPage.populatePicker(listOfCountryNames);

            }
            catch
            {
                await DisplayAlert("Oops there was an issue collecting the countries", "Check your internet connection", "OK");
            }
        }


        async void buttonViewLocation_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                YourLocation yourLocation = new YourLocation();

                await Navigation.PushModalAsync(yourLocation);


                //Using your preference country, populate this data for 'your location'. If no preference is set it will defult to Australia

                Country yourLocationObject = await api.getYourLocationData();


                await yourLocation.populateCountryData(yourLocationObject);

                
            }
            catch
            {
                await DisplayAlert("Try selecting your location on the preferences page.", "", "OK");

            }
        }

        async void  buttonHViewHotSpotsLowSpots_Clicked(System.Object sender, System.EventArgs e)
        {


            try
            {
                HotLowSpots hotLowSpots = new HotLowSpots();

                await Navigation.PushModalAsync(hotLowSpots);


                //Get Your country data

                Country yourlocation = await api.getYourLocationData();

                await hotLowSpots.populateYourLocationUI(yourlocation);



                //Get top 3 hotspots data based on cases per million population

                List<Country> listOfHotSpots = await api.getHotSpots();

                await hotLowSpots.populateHotSpotUI(listOfHotSpots);




                //Get lowest 3 spots data based on cases per million population


                List<Country> listOfLowSpots = await api.getLowSpots();

                await hotLowSpots.populateLowSpotsUI(listOfLowSpots);


            }
            catch
            {
                await DisplayAlert("Oops there was an error.", "Try checking your internet connection", "OK");
            }
        }

        
    }
}
