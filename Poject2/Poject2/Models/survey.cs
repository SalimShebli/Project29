using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Poject2.Models
{
    public class survey
    {
        public int Id { set; get; }

        [StringLength(20)]
        public string question { set; get; }
        public bool Answer { get; set; }
        public int surveylistId { get; set; }
    }
}