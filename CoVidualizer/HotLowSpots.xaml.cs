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
        //Instantiate the data model
        public Models.Rootobject root = new Models.Rootobject();


        //List of countries as names
        List<string> listOfCountries = new List<string>();


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


            string yourLocation = Preferences.Get("YourLocation", "Australia");

            try
            {
                listOfCountries = root.data.Select(data => data.name).ToList();



                for (int i = 0; i < listOfCountries.Count; i++)
                {
                    if (yourLocation == root.data[i].name)
                    {
                        labelYLTotalCasesAmount.Text = root.data[i].latest_data.confirmed.ToString();

                        labelTodaysCases.Text = root.data[i].today.confirmed.ToString();

                        labelTodaysDeaths.Text = root.data[i].today.deaths.ToString();

                        labelRecoveryRate.Text = root.data[i].latest_data.calculated.recovery_rate.ToString();

                        labelDeathRate.Text = root.data[i].latest_data.calculated.death_rate.ToString();


                    }
                }

                
            }
            catch
            {
                
            }



        }

        public void populateHotSpotUI()
        {
            List<Models.Rootobject> listOfHotSpotsObjects = new List<Models.Rootobject>();

            try
            {
                //listOfCountries = root.data.Select(data => data.name)Orderby(data.latest_data.calculated.cases_per_million_population).ToList();



                for (int i = 0; i < listOfCountries.Count ; i++)
                {
                    Models.Rootobject rootobject = new Models.Rootobject();


                    rootobject.data[i].latest_data.confirmed = root.data[i].latest_data.confirmed;

                    root.data[i].today.confirmed.ToString();

                    root.data[i].today.deaths.ToString();

                    root.data[i].latest_data.calculated.recovery_rate.ToString();

                    root.data[i].latest_data.calculated.death_rate.ToString();



                    listOfHotSpotsObjects.Add(rootobject);


                 
                }


            }
            catch
            {

            }



        }

        public void populateLowSpotsUI()
        {



        }
    }
}
