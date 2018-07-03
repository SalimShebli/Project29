using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Poject2.Models.Appoint
{
    public class Times
    {
        public int id { get; set; }
        
        public string TimeBegin { get; set; }
        public string Timeend { get; set; }
        public string breakBegin { get; set; }
        public string breakEnd { get; set; }

        //[Display(Name = "holiday")]
        public string Dayoff { get; set; }
    }
}