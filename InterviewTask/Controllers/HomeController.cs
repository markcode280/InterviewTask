using InterviewTask.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace InterviewTask.Controllers
{
    public class HomeController : Controller
    {
        private IHelperServiceRepository helperServiceRepository;

        public HomeController()
        {
            helperServiceRepository = new HelperServiceRepository();
            
        }
        /*
         * Prepare your opening times here using the provided HelperServiceRepository class.       
         */
        public ActionResult Index()
        {
            var helpers = helperServiceRepository.Get();

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
            helper = null;
            if (helper != null ) 
            {
                
                return PartialView("Hours", helper);
            }
            else
            {
                ModelState.AddModelError("Null", " Selection Not Presented");
                return View("Error",ModelState);
            }
           
        }
    }
}