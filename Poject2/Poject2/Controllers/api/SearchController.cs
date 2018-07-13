using Poject2.Models;
using Poject2.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Poject2.Controllers.api
{
    public class SearchController : Controller
    {
        ApplicationDbContext _context;

        public SearchController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View("_ViewStart");
        }
#region Get for doctors and students
        [HttpGet]
        public ActionResult GetDoctorOrStudentByName(string doctorName, string userId,bool justStudents,bool justDoctors)
        {
            if (!ModelState.IsValid)
            {
                //TODO
            }
            var Doctors = new List<Doctor>();
            var Students = new List<Student>();
            if (justDoctors)
            {
                Doctors = _context.Doctor.Where(m => (m.person.fName + " " + m.person.lName).Contains(doctorName)).ToList();
            }
            else if (justStudents)
            {
                Students = _context.Student.Where(m => (m.person.fName + " " + m.person.lName).Contains(doctorName)).ToList();
            }
            else
            {
                Doctors = _context.Doctor.Where(m => (m.person.fName + " " + m.person.lName).Contains(doctorName)).ToList();
                Students = _context.Student.Where(m => (m.person.fName + " " + m.person.lName).Contains(doctorName)).ToList();
            }
         //   Doctors = _context.Doctor.ToList();
         //   Students = _context.Student.ToList();
           ViewBag.Students = Students;
           ViewBag.Doctors = Doctors;
            return View();
        }
         [HttpGet]
        public ActionResult GetStudentBySubjects(List<Subject> subjects,string userId)
        {
            if (!ModelState.IsValid)
            {
                //TODO
            }
            var Students = new List<Student>();
            for (int i = 0; i < subjects.Count;i++ )
               Students.AddRange(_context.Student.Where(m => m.ListSubject.Contains(subjects[i]) && 
                   !Students.Contains(m)).ToList());
            ViewBag.Students = Students;
            return View("Search/GetDoctorOrStudentByName");
        }
        bool compareByDistancefromCurrent(Doctor first,Doctor second,double mypositionX,double mypositionY)
         {
            if(Math.Pow((double)first.AddressClinic.Xvalue-mypositionX,(double)2)+
                        Math.Pow((double)first.AddressClinic.Yvalue-mypositionY,(double)2)>
                Math.Pow((double)second.AddressClinic.Xvalue-mypositionX,(double)2)+
                        Math.Pow((double)second.AddressClinic.Yvalue-mypositionY,(double)2))
            {
                return true;
            }
            return false;
         }
        public ActionResult GetDoctorOrStudentByposition(double mypositionX,double mypositionY,double range)
         {
             var Doctors = _context.Doctor.Where(m => Math.Pow((double)m.AddressClinic.Xvalue - mypositionX,(double)2) +
                 Math.Pow((double)m.AddressClinic.Yvalue - mypositionY, (double)2) <= range).ToList();
            for(int i=0;i<Doctors.Count;i++)
            {
                for(int j=i+1;j<Doctors.Count;j++)
                {
                   if(compareByDistancefromCurrent(Doctors[i],Doctors[j],mypositionX,mypositionY))
                   {
                       Doctor f = Doctors[i];
                       Doctors[i] = Doctors[j];
                       Doctors[j] = f;
                   }
                }
            }
            ViewBag.Doctors = Doctors;
            return View("Search/GetDoctorOrStudentByName");
         }
#endregion
    }

}
