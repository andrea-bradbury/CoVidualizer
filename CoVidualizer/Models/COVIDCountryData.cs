using System;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace CoVidualizer.Models
{
    ///Manages the modelling of the COVID data into clusters for each country. Each Country is an object
    ///


    public class Coordinates
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Today
    {
        public int deaths { get; set; }
        public int confirmed { get; set; }
    }

    public class Calculated
    {
        public double death_rate { get; set; }
        public double recovery_rate { get; set; }
        public double recovered_vs_death_ratio { get; set; }
        public double cases_per_million_population { get; set; }
    }

    public class LatestData
    {
        public int deaths { get; set; }
        public int confirmed { get; set; }
        public int recovered { get; set; }
        public int critical { get; set; }
        public Calculated calculated { get; set; }
    }

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

    public class Root
    {
        public List<COVIDCountryData> data { get; set; }
        public bool _cacheHit { get; set; }
    }
}
