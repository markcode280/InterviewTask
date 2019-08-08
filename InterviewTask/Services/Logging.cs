using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace InterviewTask.Services
{
    public class LoggingService:ILoggingService
    {
        private string filePath;

        public LoggingService(string FilePath)
        {
            filePath = FilePath;
        }

        public void Log(string text)
        {
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath+Environment.NewLine, text);
            }
            else
            {
                File.Create(filePath);
            }
        }
    }
       
 }
