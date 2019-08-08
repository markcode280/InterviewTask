using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Formatting;

namespace InterviewTask.Services
{
    public class BaseApi:HttpClient
    {
        private ILoggingService loggingService;
        public BaseApi(string baseUrl,ILoggingService Logging)
        {
            loggingService = Logging;
            this.BaseAddress = new Uri(baseUrl);
        }

        public T Get<T>(string url)
        {
            try
            {
                using (var result = this.GetAsync(url).Result)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return result.Content.ReadAsAsync<T>().Result;
                    }
                    else
                    {
                        throw new HttpRequestException(result.Content.ReadAsStringAsync().Result);
                    }
                }
            }
            catch (Exception e)
            {
                loggingService.Log(e.Message + " " + e.InnerException.Message);
                throw new HttpRequestException(e.Message + " " + e.InnerException.Message);
                
            }

        }

        public TOut Post<TIn, TOut>(TIn data, string url)
        {
            try
            {
                using (var response = this.PostAsync(url, data, new JsonMediaTypeFormatter()).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsAsync<TOut>().Result;
                    }
                    else
                    {
                        loggingService.Log(response.Content.ReadAsStringAsync().Result);
                        throw new HttpRequestException(response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
            catch (Exception e)
            {
                loggingService.Log(e.Message + " " + e.InnerException.Message);
                throw new HttpRequestException(e.Message + " " + e.InnerException.Message);
            }

        }


    }
}