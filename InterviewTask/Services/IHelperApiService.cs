using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Services
{
    public interface IHelperApiService
    {
        dynamic GetWeatherByCity(string cityName, string CountryCode);
    }
}