using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Poject2.Models
{
    public class surveylist
    {
        public int Id { set; get; }
        public int Doctorid { get; set; }
        //استبيان الدكتور 
        public virtual List<survey> Mysurvey { get; set; }

    }
}