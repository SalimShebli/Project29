using Poject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poject2.ViewModel
{
    public class formAppoimtnetViewModel
    {
        public Appointment appoint { get; set; }
        public List<States> allstate { get; set; }
        public surveylist survey { get; set; }
        public bool checkout { get; set; }
        public bool surveyceck { get; set; }
    }
}