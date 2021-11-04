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

                int yourLocationCPM = allCountries.data.Where(data => data.name == yourLocation).Select(data => data.latest_data.calculated.cases_per_million_population).First();


                Models.Country yourLocationCountry = new Models.Country(yourLocationName, yourLocationCases, yourLocationDeaths, yourLocationRecovered, yourLocationTodayCases, yourLocationTodayDeath, yourLocationRecoveryRate, yourLocationDeathRate, yourLocationCPM);


                return yourLocationCountry;
            }
            catch
            {
                Models.Country nullObject = new Models.Country("empty", 0, 0, 0, 0, 0, 0, 0, 0);

                return nullObject;
            }

        }

        public async Task<List<Models.Country>> getHotSpots()
        {
            try
            {
                //Pulling a list of Country objects ordered by cases per million descending
                

                List<Models.Datum> listOfHotSpotsDatum = allCountries.data.OrderByDescending(data => data.latest_data.calculated.cases_per_million_population).Select(data => data).ToList();

                for (int i = 0; i < 3; i++)
                {
                    string hotSpotName = listOfHotSpotsDatum[i].name;

                    int hotSpotCases = listOfHotSpotsDatum[i].latest_data.confirmed;

                    int hotSpotDeaths = listOfHotSpotsDatum[i].latest_data.deaths;

                    int hotSpotRecovered = listOfHotSpotsDatum[i].latest_data.recovered;

                    int hotSpotTodayCases = listOfHotSpotsDatum[i].today.confirmed;

                    int hotSpotTodayDeath = listOfHotSpotsDatum[i].today.deaths;

                    float? hotSpotRecoveryRate = listOfHotSpotsDatum[i].latest_data.calculated.recovery_rate;

                    float? hotSpotDeathRate = listOfHotSpotsDatum[i].latest_data.calculated.death_rate;

                    int hotSpotCPM = listOfHotSpotsDatum[i].latest_data.calculated.cases_per_million_population;


                    Models.Country hotSpotObject = new Models.Country(hotSpotName, hotSpotCases, hotSpotDeaths, hotSpotRecovered, hotSpotTodayCases, hotSpotTodayDeath, hotSpotRecoveryRate, hotSpotDeathRate, hotSpotCPM);

                    listOfHotSpots.Add(hotSpotObject);

                }

                return listOfHotSpots;
            }
            catch
            {
                return listOfHotSpots;
            }


        }


        public async Task<List<Models.Country>> getLowSpots()
        {
            try
            {
                //Pulling a list of Country objects ordered by cases per million ascending
                //Need to exclude zeros as we assume this is because no data has been provided.

                List<Models.Datum> listOfLowSpotsDatum = allCountries.data.OrderBy(data => data.latest_data.calculated.cases_per_million_population).Select(data => data).ToList();

                for (int i = 0; i < listOfLowSpotsDatum.Count; i++)
                {

                    if (listOfLowSpotsDatum[i].latest_data.calculated.cases_per_million_population > 0)
                    {
                        string lowSpotName = listOfLowSpotsDatum[i].name;

                        int lowSpotCases = listOfLowSpotsDatum[i].latest_data.confirmed;

                        int lowSpotDeaths = listOfLowSpotsDatum[i].latest_data.deaths;

                        int lowSpotRecovered = listOfLowSpotsDatum[i].latest_data.recovered;

                        int lowSpotTodayCases = listOfLowSpotsDatum[i].today.confirmed;

                        int lowSpotTodayDeath = listOfLowSpotsDatum[i].today.deaths;

                        float? lowSpotRecoveryRate = listOfLowSpotsDatum[i].latest_data.calculated.recovery_rate;

                        float? lowSpotDeathRate = listOfLowSpotsDatum[i].latest_data.calculated.death_rate;

                        int lowSpotCPM = listOfLowSpotsDatum[i].latest_data.calculated.cases_per_million_population;


                        Models.Country lowSpotObject = new Models.Country(lowSpotName, lowSpotCases, lowSpotDeaths, lowSpotRecovered, lowSpotTodayCases, lowSpotTodayDeath, lowSpotRecoveryRate, lowSpotDeathRate, lowSpotCPM);

                        listOfLowSpots.Add(lowSpotObject);
                    }
                    else
                    {
                        continue;
                    }


                }



                return listOfLowSpots;
            }
            catch
            {
                return listOfLowSpots;
            }
            
        }

    }
}
