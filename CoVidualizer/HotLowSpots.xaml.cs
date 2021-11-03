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


        //List of countries 
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
                //listOfCountries = root.data.Orderby(data => data.latest_data.calculated.cases_per_million_population)Select(data => data.name).ToList();



                for (int i = 0; i < listOfCountries.Count ; i++)
                {
                    Models.Rootobject rootobject = new Models.Rootobject();

                   
                    rootobject.data[i].name = root.data[i].name;
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

                    if ( root.data[i].latest_data.calculated.death_rate != 0)
                    {
                        Models.Rootobject rootobject = new Models.Rootobject();


                        rootobject.data[i].name = root.data[i].name;
                        rootobject.data[i].latest_data.calculated.death_rate = root.data[i].latest_data.calculated.death_rate;

                        listOfLowSpotsObjects.Add(rootobject);
                    }
                    else
                    {
                        continue;
                    }
                    



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
