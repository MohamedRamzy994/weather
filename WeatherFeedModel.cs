using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherFeed
{
    internal class WeatherFeedModel
    {
        public Location? location { get; set; }
        public Current? current { get; set; }
    }

    internal class Condition
    {
        public string? text { get; set; }
        public string? icon { get; set; }
        public int? code { get; set; }

        
    }
    internal class Current
    {
        public double last_updated_epoch { get; set; }
        public DateTime last_updated { get; set; }

        public double temp_c { get; set; }

        public double temp_f { get; set; }
        public int is_day { get; set; }

        public Condition? condition { get; set; }

    }
    internal class Location
    {
        public string? name { get; set; }
        public string? region { get; set; }

        public string? country { get; set; }

        public double lat { get; set; }
        public double lon { get; set; }
        public string? tz_id { get; set; }
        public double localtime_epoch { get; set; }
        public DateTime localtime { get; set; }
    }

    internal class Countries
    {

        public  Country? name { get; set; }

        public string? common => name?.common;
        public string? official => name?.official;


    }
    internal class Country
    {
        public string? common { get; set; }
        public string? official { get; set; }

    }

}
