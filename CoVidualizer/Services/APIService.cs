using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoVidualizer.Services
{
    /// This class manages the handling of the API - in this case the Corona API
    public class APIService
    {
        string apiKey;


        public Models.COVIDCountryData main = new Models.COVIDCountryData();



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
