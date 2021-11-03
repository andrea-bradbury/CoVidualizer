using System;
namespace CoVidualizer.Models
{
    public class Country
    {
        public string name { get; set; }
        public int totalConfirmed { get; set; }
        public int totalDeaths { get; set; }
        public int totalRecovered { get; set; }
        public int todaysConfirmed { get; set; }
        public int todaysDeaths { get; set; }
        public float? death_rate { get; set; }
        public float? recovery_rate { get; set; }
        

        public Country(string Name, int TotalConfirmed, int TotalDeaths, int TotalRecovered, int TodaysConfirmed,  int TodaysDeaths, float? DeathRate, float? RecoveryRate)
        {
            name = Name;

            totalConfirmed = TotalConfirmed;

            totalDeaths = TotalDeaths;

            totalRecovered = TotalRecovered;

            todaysConfirmed = todaysConfirmed;

            todaysDeaths = TodaysDeaths;

            death_rate = DeathRate;

            recovery_rate = RecoveryRate;

        }

    }
}
