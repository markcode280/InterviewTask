using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Services
{
    public interface IBaseApi
    {
         TOut Post<TIn, TOut>(TIn data, string url);
        T Get<T>(string url);
    }
}