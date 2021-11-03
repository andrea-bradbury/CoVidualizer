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
        

        public async Task<int> getWorldCases(List<int> listOfWorldCases)
        {

            int totalWorldCases = 0;

            try
            {
                
                for (int i = 0; i < listOfWorldCases.Count; i++)
                {
                    totalWorldCases += listOfWorldCases[i];
                }


                return totalWorldCases;

            }
            catch
            {
                return totalWorldCases;
            }


        }



        public async Task<int> getWorldRecoveries(List<int> listOfWorldRecoveries)
        {
            
            int totalWorldRecoveries = 0;

            try
            {

                for (int i = 0; i < listOfWorldRecoveries.Count; i++)
                {
                    totalWorldRecoveries += listOfWorldRecoveries[i];
                }


                return totalWorldRecoveries;

            }
            catch
            {
                return totalWorldRecoveries;
            }

        }




        public async Task<int> getWorldDeaths(List<int> listOfWorldDeaths)
        {



            int totalWorldDeaths = 0;

            try
            {

                for (int i = 0; i < listOfWorldDeaths.Count; i++)
                {
                    totalWorldDeaths += listOfWorldDeaths[i];
                }


                return totalWorldDeaths;

            }
            catch
            {
                return totalWorldDeaths;
            }


        }
    }
}
