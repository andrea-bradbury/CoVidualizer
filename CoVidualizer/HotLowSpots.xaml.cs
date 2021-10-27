using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;


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
        public void populateYourLocationUI()
        {
            labelYourLocationTitle2.Text = Preferences.Get("YourLocation", "Australia");


            /*
            for (int i = 0; i< Models.Root.listOfCountryData; i++ )
            {
                if (Models.Datum.name == Preferences.Get("YourLocation", "Australia"))
                {
                    //labelYLTotalCasesAmount.Text = LatestData.confirmed;

                    //labelYLTodayCasesAmount.Text = Today.confirmed;

                    //labelYLTodayDeathsAmount.Text = Today.deaths;

                    //labelYLRecoveryRateAmount.Text = Calculated.recovery_rate;

                    //labelYLDeathRateAmount.Text = Calculated.death_rate;
                }
            }
            */



        }

        public void populateHotSpotUI()
        {




        }

        public void populateLowSpotsUI()
        {



        }
    }
}
