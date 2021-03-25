using System;
using Xunit;
using System.Reflection;
using Api.Client;
using System.Linq;
using Newtonsoft.Json;

namespace Meteo.E2E.Test
{
    public partial class Meteo
    {


        string url = @"https://data.cityofchicago.org/resource/k7hf-8y75.json?";

        public bool GetOakAll()
        {

            string stationName = "Oak Street Weather Station";
            string station = $"station_name='{stationName}'";
            string limit = @"&$limit=1000000";

            ApiSettings endPoint = new ApiSettings();
            endPoint.BaseUrl = url + station  + limit;
            endPoint.Route = String.Empty;
            string raw = "";

            try
            {

                ApiClient client = new ApiClient(endPoint);
                raw = (string)client.Get("");
                var list = JsonConvert.DeserializeObject<MeteoRecord[]>(raw);

                return list.All(x => x.station_name == stationName);

            }
            catch { return false; }
        }

        public bool GetPage()
        {

            string timeStamp =
                @"&$where=measurement_timestamp  between '2019-01-01T00:00:00' and '2020-01-01T00:00:00'";
            string limit = @"&$limit=10";
            string offset = @"&$offset=10";

            string stationName = "63rd Street Weather Station";
            string station = $"station_name='{stationName}'";


            ApiSettings endPoint = new ApiSettings();
            endPoint.BaseUrl = url + station + timeStamp + limit;
            endPoint.Route = String.Empty;

            string raw = String.Empty;

            try
            {

                ApiClient client = new ApiClient(endPoint);
                raw = (string)client.Get("");
                var list1 = JsonConvert.DeserializeObject<MeteoRecord[]>(raw);

                endPoint.BaseUrl = url + station + timeStamp + limit + offset;
                client = new ApiClient(endPoint);
                raw = (string)client.Get("");
                var list2 = JsonConvert.DeserializeObject<MeteoRecord[]>(raw);

                return !list1.Any(x => list2.Contains(x));

            }
            catch { return false; }
        }

        public bool GetApiErr()
        {

            string range = @"&$where=battery_life < full";

            string stationName = "63rd Street Weather Station";
            string station = $"station_name='{stationName}'";

            ApiSettings endPoint = new ApiSettings();
            endPoint.BaseUrl = url + station + range;
            endPoint.Route = String.Empty;

            string raw = String.Empty;

            try
            {

                ApiClient client = new ApiClient(endPoint);
                raw = (string)client.Get("");
                var list = JsonConvert.DeserializeObject<MeteoRecord[]>(raw);

                return true;

            }
            catch (Exception e)
            {
                if (raw.Contains("Could not parse SoQL query")) return false;
                return true; 
            }
        }
    }

}
