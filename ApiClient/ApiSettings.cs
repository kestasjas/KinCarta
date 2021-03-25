using System;

namespace Api.Client
{
    public class ApiSettings
    {
        protected const int DEFAULT_TIMEOUT = 60000;

        public string BaseUrl { get; set; }
        public string Route { get; set; }
        public string Timeout { get; set; }

        internal int GetTimeoutValue()
        {
            if (!Int32.TryParse(Timeout, out int timeoutValue))
                return DEFAULT_TIMEOUT;

            return timeoutValue;
        }
    }
}
