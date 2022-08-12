using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi.Library.Common.Models
{
    public class ForecastdayCommon
    {
        public double temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public double wind { get; set; }
        public int time { get; set; }
    }
}
