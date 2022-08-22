using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi.Library.Common.Models
{
    public class ForecastdayCommon
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public double Wind { get; set; }
        public int Time { get; set; }
    }
}
