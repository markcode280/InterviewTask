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
            if(helpers!= null)
            {
                if (helpers.Any() && helpers.Count()>1)
                {
                    return View(helpers);
                }
            }

            ModelState.AddModelError("Null", "Issue Loading entry's");
            return View(ModelState);
            
        }

        public ActionResult GetByID(Guid id)
        {
            if (id != null)
            {
                var helper = helperServiceRepository.Get(id);
                return PartialView("Hours", helper);
            }
            else
            {
                ModelState.AddModelError("Null", "No Id Presented");
                return View("Shared/Error");
            }
           
        }
    }
}