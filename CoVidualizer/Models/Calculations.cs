using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;


namespace CoVidualizer.Models
{

    /// This class performs all maths related manipulation of the data from the API
    ///



    public class Calculations
    {
        
        //Instantiate the data model
        public Models.Rootobject root = new Models.Rootobject();


        public async Task<bool> getWorldCases()
        {

            //List of cases from each country
            List<int> listOfTotalCases = new List<int>();


            int totalWorldCases = 0;

            try
            {
                listOfTotalCases = root.data.Select(data => data.latest_data.confirmed).ToList();



                for (int i = 0; i < listOfTotalCases.Count; i++)
                {
                    totalWorldCases += listOfTotalCases[i];
                }


                return true;

            }
            catch
            {
                return false;
            }


        }



        public async Task<bool> getWorldRecoveries()
        {
            //List of recoveries from each country
            List<int> listOfTotalRecoveries = new List<int>();


            int totalWorldRecoveries = 0;

            try
            {
                listOfTotalRecoveries = root.data.Select(data => data.latest_data.recovered).ToList();



                for (int i = 0; i < listOfTotalRecoveries.Count; i++)
                {
                    totalWorldRecoveries += listOfTotalRecoveries[i];
                }


                return true;

            }
            catch
            {
                return false;
            }

        }




        public async Task<bool> getWorldDeaths()
        {

            //List of deaths from each country
            List<int> listOfTotalDeaths = new List<int>();


            int totalWorldDeaths = 0;

            try
            {
                listOfTotalDeaths = root.data.Select(data => data.latest_data.deaths).ToList();



                for (int i = 0; i < listOfTotalDeaths.Count; i++)
                {
                    totalWorldDeaths += listOfTotalDeaths[i];
                }


                return true;

            }
            catch
            {
                return false;
            }


        }
    }
}
