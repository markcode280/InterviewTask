using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterviewTask.Models
{
    public class HelperServiceModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        [Display(Name ="Description")]
        public string Description { get; set; }
        [Display(Name = "Telephone")]
        public string TelephoneNumber { get; set; }
        [Display(Name = "Monday Opening Hours")]
        public List<int> MondayOpeningHours { get ; set; }
        [Display(Name = "Tuesday Opening Hours")]
        public List<int> TuesdayOpeningHours { get; set; }
        [Display(Name = "Wednesday Opening Hours")]
        public List<int> WednesdayOpeningHours { get; set; }
        [Display(Name = "Thursday Opening Hours")]
        public List<int> ThursdayOpeningHours { get; set; }
        [Display(Name = "Friday Opening Hours")]
        public List<int> FridayOpeningHours { get; set; }
        [Display(Name = "Saturday Opening Hours")]
        public List<int> SaturdayOpeningHours { get; set; }
        [Display(Name = "Sunday Opening Hours")]
        public List<int> SundayOpeningHours { get; set; }
    }

    public class Hours
    {

    }
}

