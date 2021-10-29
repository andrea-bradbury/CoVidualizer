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

            accessAPI();

            PreferencesPage preferencesPage = new PreferencesPage();

            YourLocation yourLocation = new YourLocation();

            HotLowSpots hotLowSpots = new HotLowSpots();

            
            


        }


        public async Task<bool> accessAPI()
        {
            //Display error message if there's no internet, if the API call is wrong or if the URL changes.

            if (await api.getCovidData() == false)
            {
                await DisplayAlert("Error, please check internet connection.", "Also check COVID site is still live", "OK");

                return false;
            }
            else
            {
                Console.WriteLine("Checking API works");

                return true;
            }

        }

        async void buttonSetPreference_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                PreferencesPage preferencesPage = new PreferencesPage();

                await Navigation.PushModalAsync(preferencesPage);

                await preferencesPage.populatePicker();

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

                yourLocation.populateCountryData();
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

                
            }
            catch
            {
                
            }
        }


        async Task<bool> updateMainContent()
        {
            try
            {
                

                return true;
            }
            catch
            {
                
                return false;
            }


        }

        
    }
}
