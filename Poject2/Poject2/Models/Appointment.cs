﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poject2.Models.Persons;

namespace Poject2.Models
{
    public class Appointment
    {
        public int Id { set; get; }
        public DateTime Date { get; set; }

        public int StatesId { set; get; }
        public States States { set; get; }
        //من اجل معرفة ان كان الموعد مع طبيب ام طالب 
        public int Docid { get; set; }
        public int type { get; set; }
        //معرفة في حال تم تاكيد الموعد
        public bool sure { get; set; }
        public int PacientId { get; set; }
        public Pacient pacient { get; set; }

    }
}