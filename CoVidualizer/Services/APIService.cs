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

        //Instantiate 
        public Models.Rootobject allCountries;


        //List of countries as names
        List<string> listOfCountryNames = new List<string>();


        //Lists of world data for populating mainpage
        List<int> listOfWorldCases = new List<int>();
        List<int> listOfWorldRecoveries = new List<int>();
        List<int> listOfWorldDeaths = new List<int>();

        //List of your locations data as a list
        List<string> listOfYourLocationData = new List<string>();




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

        public async Task<string[]> getYourLocation()
        {
            string yourLocation = Preferences.Get("YourLocation", "Australia");

            string[] arrayOfCountryData; 
            try
            {
                //Pull country matching preference name

                List<string> listOfCountryData = allCountries.data.Where(data => data.name == yourLocation).Select(data => data.ToString()).ToList();

                for (int i =0; i < listOfCountryData.Count; i++)
                {
                    //arrayOfCountryData.Add(i);
                }


                return arrayOfCountryData;
            }
            catch
            {
                return arrayOfCountryData;
            }

        }
    }
}
