using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;



namespace CoVidualizer.Services
{
    /// This class manages the handling of the API - in this case the Corona API

    


    public class APIService
    {

        //No API key is required for this API 
        string apiKey;

        //Instantiate 
        public Models.COVIDCountryData main = new Models.COVIDCountryData();

        //List of Countries
        public List<Models.COVIDCountryData> listOfCountryData = new List<Models.COVIDCountryData>();



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

                    main = JsonConvert.DeserializeObject<Models.COVIDCountryData>(content);
                    
                    Console.WriteLine("Checking reaching end of API");



                    for (int i = 0; i < content.Length; i++)
                    {
                        if (main.name != null)
                        {
                            listOfCountryData.Add(main);
                        }
                        else
                        {
                            continue;
                        }
                            

                    }


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
