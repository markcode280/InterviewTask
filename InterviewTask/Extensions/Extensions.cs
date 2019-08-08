using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Extensions
{
    public  static class Extensions
    {
         public static int FormatIntDate(this int item)
        {
            var stringDate = item.ToString();
            if (item<10)
            {
                //stringDate=stringDate.Take(2).ToString() == "00" ? stringDate : stringDate.Reverse().ToString() + "0";
                //stringDate = stringDate.Reverse().ToString();

            }else if (item >= 10)
            {
                //stringDate
            }
            return 0;
        }
       
    }
}