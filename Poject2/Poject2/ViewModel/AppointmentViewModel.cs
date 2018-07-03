using Poject2.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poject2.ViewModel
{
    public class AppointmentViewModel
    {
        public List<Doctor> listdoc { set; get; }
        public List<Student> liststud { set; get; }
        public int id { get; set; }

    }
}