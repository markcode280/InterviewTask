using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Services
{
    public class HelperApiService:BaseApi, IHelperApiService
    {
        
        public HelperApiService(string baseUrl, ILoggingService LoggingService) : base(baseUrl,LoggingService)
        {
           
        }
        public dynamic GetWeatherByCity(string cityName,string CountryCode=null)
        {
            return this.Get<dynamic>(string.Format("data/2.5/weather?q={0},{1}", cityName, CountryCode));
        }

    }
}