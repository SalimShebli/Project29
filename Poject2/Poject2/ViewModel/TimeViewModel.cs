using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poject2.Models.Appoint;
namespace Poject2.ViewModel
{
    public class TimeViewModel
    {
        public TimeViewModel()
        {
            day = new List<string>();
            tim = new List<string>();
            day.Add("Saturday");
            day.Add("Sunday");
            day.Add("Monday");
            day.Add("Tuesday");
            day.Add("Wednesday");
            day.Add("Thursday");
            for (int i = 8; i <= 22; i++)
            {
                tim.Add(Convert.ToString(i) + ":00");
                tim.Add(Convert.ToString(i) + ":30");
            }
        }
            
        public Times time { get; set; }
        public List<string> day { get; set; }
        public List<string> tim { get; set; }
    }
}