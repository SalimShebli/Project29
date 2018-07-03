using Poject2.Models;
using Poject2.Models.Appoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poject2.ViewModel
{
    public class tableappointViewModel
    {
        public Times time { get; set; }
        public List<Appointment> usedAppoint { set; get; }
        public DateTime today { set; get; }
        public DayOfWeek day { set; get; }
        public TimeViewModel timview { get; set; }
        public int numberoftable { get; set; }
        public Appointment appoint { get; set; }

    }
}