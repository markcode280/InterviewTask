using InterviewTask.Services;
using InterviewTask.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InterviewTask.Controllers
{
    public class HomeController : Controller
    {
        private IHelperServiceRepository helperServiceRepository;
        private IHelperApiService serviceProvider;
        public HomeController()
        {
            helperServiceRepository = new HelperServiceRepository();
            serviceProvider = new HelperApiService("https://openweathermap.org");
        }
        /*
         * Prepare your opening times here using the provided HelperServiceRepository class.       
         */
        public ActionResult Index()
        {
            var helpers = helperServiceRepository.Get();
            var helperViewModel = new List<HelperViewModel>();
            foreach (var help in helpers)
            {
                helperViewModel.Add(new HelperViewModel()
                {
                    helper = help,
                    weather = serviceProvider.GetWeatherByCity(help.Title.Split(' ').FirstOrDefault().ToString(), "").main.temp
                });
            } 
            
            if (!helpers.Where(x => x.MondayOpeningHours == null || x.TuesdayOpeningHours == null ||
             x.WednesdayOpeningHours == null || x.ThursdayOpeningHours == null || x.FridayOpeningHours == null ||
             x.SaturdayOpeningHours == null || x.SundayOpeningHours == null).Any()) // I would always do checking before Controller in seperate IService interface
            {
                if (helpers != null)
                {
                    if (helpers.Any() && helpers.Count() > 1)
                    {
                        return View(helpers);
                    }
                }
            }
            {
                ModelState.AddModelError("Null", "No Times Available");
            }
            ModelState.AddModelError("Null", "Issue Loading entry's");
            return View("Error",ModelState);
            
        }

        public ActionResult GetByID(Guid id)
        {
            var helper = helperServiceRepository?.Get(id);
        
            if (helper != null ) 
            {
                
                return PartialView("Hours", helper);
            }
            else
            {
                
                ModelState.AddModelError("Null", " Selection Not Presented");
                return View("Error",ModelState["Null"].Errors);
            }
           
        }
    }
}