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
            accessAPI();


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

        



        public async Task<bool> getWorldData()
        {
            try
            {
                Calculations calculations = new Calculations();


                List<int> listOfWorldCases = await api.getWorldCases();

                int totalWorldCases = await calculations.getWorldCases(listOfWorldCases);

                labelWorldCasesAmount.Text = totalWorldCases.ToString();



                List<int> listOfWorldRecoveries = await api.getWorldRecoveries();

                int totalWorldRecoveries = await calculations.getWorldRecoveries(listOfWorldRecoveries);

                labelWorldRecoveriesAmount.Text = totalWorldRecoveries.ToString();



                List<int> listOfWorldDeaths = await api.getWorldDeaths();

                int totalWorldDeaths = await calculations.getWorldDeaths(listOfWorldDeaths);

                labelWorldDeathsAmount.Text = totalWorldDeaths.ToString();



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


                List<string> listOfCountryNames = await api.getCOVIDCountries();

                await preferencesPage.populatePicker(listOfCountryNames);

            }
            catch
            {
               


            }
        }

        async void buttonViewLocation_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                YourLocation yourLocation = new YourLocation();

                await Navigation.PushModalAsync(yourLocation);



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



                List<Country> listOfHotSpots = await api.getHotSpots();

                



                await hotLowSpots.populateYourLocationUI();

                await hotLowSpots.populateLowSpotsUI();

            }
            catch
            {
                
            }
        }



        
    }
}
