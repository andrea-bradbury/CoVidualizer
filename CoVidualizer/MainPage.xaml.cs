using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CoVidualizer.Models;
using CoVidualizer.Services;

namespace CoVidualizer
{
    public partial class MainPage : ContentPage
    {
        //Instantiate the data model
        COVIDCountryData Model = new COVIDCountryData();

        //Instantiate the api service 
        public APIService api = new APIService();


        public MainPage()
        {
            InitializeComponent();

            accessAPI();

           
        }


        public async void accessAPI()
        {
            //Display error message if there's no internet, if the API call is wrong or if the URL changes.

            if (await api.getCovidData() == false)
            {
                await DisplayAlert("Error, please check internet connection.", "Also check COVID site is still live", "OK");
            }

        }
    }
}
