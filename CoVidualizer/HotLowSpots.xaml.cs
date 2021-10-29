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
        public async Task<bool> populateYourLocationUI()
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
                        labelYLCountryName.Text = root.data[i].name.ToString();

                        labelYLTodayCasesAmount.Text = root.data[i].today.confirmed.ToString();

                        labelYLTodayDeathsAmount.Text = root.data[i].today.deaths.ToString();

                        labelYLRecoveryRateAmount.Text = root.data[i].latest_data.calculated.recovery_rate.ToString();

                        labelYLDeathRateAmount.Text = root.data[i].latest_data.calculated.death_rate.ToString();


                    }
                }

                return true;
            }
            catch
            {
                return false;
            }



        }

        public async Task<bool> populateHotSpotUI()
        {
            List<Models.Rootobject> listOfHotSpotsObjects = new List<Models.Rootobject>();

            try
            {
                //Need to do pull descending order
                //listOfCountries = root.data.Select(data => data.name)Orderby(data.latest_data.calculated.cases_per_million_population).ToList();



                for (int i = 0; i < listOfCountries.Count ; i++)
                {
                    Models.Rootobject rootobject = new Models.Rootobject();

                    

                    rootobject.data[i].latest_data.confirmed = root.data[i].latest_data.confirmed;

                    rootobject.data[i].today.confirmed = root.data[i].today.confirmed;

                    rootobject.data[i].today.deaths = root.data[i].today.deaths;

                    rootobject.data[i].latest_data.calculated.recovery_rate = root.data[i].latest_data.calculated.recovery_rate;

                    rootobject.data[i].latest_data.calculated.death_rate = root.data[i].latest_data.calculated.death_rate;



                    listOfHotSpotsObjects.Add(rootobject);


                 
                }


                listViewHotSpot.ItemsSource = listOfHotSpotsObjects;


                return true;

            }
            catch
            {
                return false;
            }



        }

        public async Task<bool> populateLowSpotsUI()
        {
            List<Models.Rootobject> listOfLowSpotsObjects = new List<Models.Rootobject>();

            try
            {
                //Need to do pull ascending order and exclude zero or null values 
                //listOfCountries = root.data.Select(data => data.name)Orderby(data.latest_data.calculated.cases_per_million_population).ToList();



                for (int i = 0; i < listOfCountries.Count; i++)
                {
                    Models.Rootobject rootobject = new Models.Rootobject();


                    rootobject.data[i].latest_data.confirmed = root.data[i].latest_data.confirmed;

                    rootobject.data[i].today.confirmed = root.data[i].today.confirmed;

                    rootobject.data[i].today.deaths = root.data[i].today.deaths;

                    rootobject.data[i].latest_data.calculated.recovery_rate = root.data[i].latest_data.calculated.recovery_rate;

                    rootobject.data[i].latest_data.calculated.death_rate = root.data[i].latest_data.calculated.death_rate;



                    listOfLowSpotsObjects.Add(rootobject);



                }

                listViewLowSpot.ItemsSource = listOfLowSpotsObjects;

                return true;

            }
            catch
            {
                return false;
            }


        }
    }
}
