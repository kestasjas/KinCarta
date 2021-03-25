using System;
using System.Collections.Generic;

namespace Meteo.E2E.Test
{
    public class MeteoRecord
    {
        public string station_name { get; set; }
        public DateTime measurement_timestamp { get; set; }
        public string air_temperature { get; set; }
        public string wet_bulb_temperature { get; set; }
        public string humidity { get; set; }
        public string rain_intensity { get; set; }
        public string interval_rain { get; set; }
        public string total_rain { get; set; }
        public string precipitation_type { get; set; }
        public string wind_direction { get; set; }
        public string wind_speed { get; set; }
        public string maximum_wind_speed { get; set; }
        public string barometric_pressure { get; set; }
        public string solar_radiation { get; set; }
        public string heading { get; set; }
        public string battery_life { get; set; }
        public string measurement_timestamp_label { get; set; }
        public string measurement_id { get; set; }
    }
}
