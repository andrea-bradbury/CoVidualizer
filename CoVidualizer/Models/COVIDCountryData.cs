using System;
using Newtonsoft.Json;

namespace CoVidualizer.Models
{
    ///Manages the modelling of the COVID data into clusters for each country. Each Country is an object
    
    public class COVIDCountryData
    {
        public Coordinates coordinates { get; set; }

        public string name { get; set; }

        public string code { get; set; }

        public int population { get; set; }

        public DateTime updated_at { get; set; }

        public Today today { get; set; }

        public LatestData latest_data { get; set; }

    }

    public class Coordinates
    {
        public decimal latitude { get; set; }

        public decimal longitude { get; set; }
    }

    public class Today
    {
        public int deaths { get; set; }

        public int confirmed { get; set; }

    }

    public class LatestData
    {
        public int deaths { get; set; }

        public int confirmed { get; set; }

        public int recovered { get; set; }

        public int critical { get; set; }

        public Calculated calculated { get; set; }

    }

    public class Calculated
    {
        public decimal death_rate { get; set; }

        public decimal recovery_rate { get; set; }

        public decimal recovered_vs_death_ratio { get; set; }

        public decimal cases_per_million_population { get; set; }
    }
}
