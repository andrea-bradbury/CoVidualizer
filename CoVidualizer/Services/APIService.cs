using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;





namespace CoVidualizer.Services
{
    /// This class manages the handling of the API - in this case the Corona API

    


    public class APIService
    {

        //No API key is required for this API 
        string apiKey;

        //Instantiate 
        public Models.Rootobject main = new Models.Rootobject();

        //List of Countries as objects 
        public List<Models.Datum> listOfCountryData = new List<Models.Datum>();

        


        public async Task<bool> getCovidData()
        {


            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://corona-api.com/countries");


                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {

                    return false;

                }
                else
                {
                    string content = await response.Content.ReadAsStringAsync();

                    
                    Models.Rootobject allCountries = JsonConvert.DeserializeObject<Models.Rootobject>(content);

                   

                    Console.WriteLine("Checking reaching end of API");


                    return true;
                    
                }

            }
            catch
            {
                return false;
            }



        }
    }
}
