using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xamarin.Essentials;
using System.Linq;





namespace CoVidualizer.Services
{
    /// This class manages the handling of the API - in this case the Corona API

    


    public class APIService
    {

        //No API key is required for this API 
        string apiKey;

        //Instantiate API modelling
        public Models.Rootobject allCountries;

        public Models.Country country;


        //List of countries as names
        List<string> listOfCountryNames = new List<string>();


        //Lists of world data for populating mainpage
        List<int> listOfWorldCases = new List<int>();
        List<int> listOfWorldRecoveries = new List<int>();
        List<int> listOfWorldDeaths = new List<int>();

        //List of your locations data as a list
        List<string> listOfYourLocationData = new List<string>();

        //List of your location cases per million
        List<int> listOfYourLocationCPM = new List<int>();

        //List of Hot Spots
        List<Models.Country> listOfHotSpots = new List<Models.Country>();

        //List of Low Spots
        List<Models.Country> listOfLowSpots = new List<Models.Country>();




        public async Task<bool> getAllCOVIDData()
        {
          

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://corona-api.com/countries");

                

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {

                    return true;

                }
                else
                {
                    string content = await response.Content.ReadAsStringAsync();

                    
                    allCountries = JsonConvert.DeserializeObject<Models.Rootobject>(content);


                    Console.WriteLine("Checking reaching end of API");


                    return true;
                    
                }

            }
            catch
            {
                return false;

            }



        }

        public async Task<List<string>> getCOVIDCountries()
        {
            
            try
            {
                //Pulling a list by country names

                listOfCountryNames = allCountries.data.Select(data => data.name).ToList();

                return listOfCountryNames;
            }
            catch
            {
                return listOfCountryNames;
            }
        
        }



        public async Task<List<int>> getWorldCases()
        {

            try
            {
                //Pulling a list with just latest data confirmed

                listOfWorldCases = allCountries.data.Select(data => data.latest_data.confirmed).ToList();

                return listOfWorldCases;
            }
            catch
            {
                return listOfWorldCases;
            }

        }

        public async Task<List<int>> getWorldRecoveries()
        {

            try
            {
                //Pulling a list with just latest data recovered  

                listOfWorldRecoveries = allCountries.data.Select(data => data.latest_data.recovered).ToList();

                return listOfWorldRecoveries;
            }
            catch
            {
                return listOfWorldRecoveries;
            }

        }

        public async Task<List<int>> getWorldDeaths()
        {

            try
            {
                //Pulling a list with just latest data deaths 

                listOfWorldDeaths = allCountries.data.Select(data => data.latest_data.deaths).ToList();

                return listOfWorldDeaths;
            }
            catch
            {
                return listOfWorldDeaths;
            }

        }

        



        public async Task<Models.Country> getYourLocationData()
        {
            string yourLocation = Preferences.Get("YourLocation", "Australia");

            try
            {
                string yourLocationName = allCountries.data.Where(data => data.name == yourLocation).Select(data => data.name).First();

                int yourLocationCases  = allCountries.data.Where(data => data.name == yourLocation).Select(data => data.latest_data.confirmed).First();

                int yourLocationDeaths = allCountries.data.Where(data => data.name == yourLocation).Select(data => data.latest_data.deaths).First();

                int yourLocationRecovered = allCountries.data.Where(data => data.name == yourLocation).Select(data => data.latest_data.recovered).First();

                int yourLocationTodayCases = allCountries.data.Where(data => data.name == yourLocation).Select(data => data.today.confirmed).First();

                int yourLocationTodayDeath = allCountries.data.Where(data => data.name == yourLocation).Select(data => data.today.deaths).First();

                float? yourLocationRecoveryRate = allCountries.data.Where(data => data.name == yourLocation).Select(data => data.latest_data.calculated.recovery_rate).First();

                float? yourLocationDeathRate = allCountries.data.Where(data => data.name == yourLocation).Select(data => data.latest_data.calculated.death_rate).First();


                Models.Country yourLocationCountry = new Models.Country(yourLocationName, yourLocationCases, yourLocationDeaths, yourLocationRecovered, yourLocationTodayCases, yourLocationTodayDeath, yourLocationRecoveryRate, yourLocationDeathRate);


                return yourLocationCountry;
            }
            catch
            {
                Models.Country nullObject = new Models.Country("empty", 0, 0, 0, 0, 0, 0, 0);

                return nullObject;
            }

        }

        public async Task<List<Models.Country>> getHotSpots()
        {
            try
            {
                //Pulling a list by cases per million


                //listOfHotSpots = allCountries.data.Select(data => data.latest_data.calculated.cases_per_million_population).ToList();


                return listOfHotSpots;
            }
            catch
            {
                return listOfHotSpots;
            }
        }
    }
}
