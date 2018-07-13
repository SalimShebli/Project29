using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Poject2.Models;
using Poject2.ViewModel;
using Poject2.Models.Persons;
using System.Globalization;

namespace Poject2.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _context;

        public AppointmentController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Appointment
        public ActionResult ShowDocOrStud(int id)
        {
            AppointmentViewModel app = null;

            if (id == 1)//doc
            {
                List<Person> persons = _context.Person.ToList();
                app = new AppointmentViewModel
                {
                    listdoc = _context.Doctor.ToList(),

                };
                for (int i = 0; i < app.listdoc.Count; i++)
                {
                    app.listdoc[i].person = persons.FirstOrDefault(m => m.Id == app.listdoc[i].personId);
                }
            }
            else if (id == 2)
            {
                List<Person> persons = _context.Person.ToList();
                app = new AppointmentViewModel
                {
                    liststud = _context.Student.ToList(),

                };
                for (int i = 0; i < app.liststud.Count; i++)
                {
                    app.liststud[i].person = persons.FirstOrDefault(m => m.Id == app.liststud[i].personId);
                }
            }
           
            return View("_Appoint", app);
        }
        public ActionResult takeAppoint()
        {
            return RedirectToAction("tableAppiont", "Appointment", new { id = 0, docid = 5, type = 1 });
        }
        public ActionResult tableAppiont(int id, int docid, int type)
        {
            tableappointViewModel viewModel = new tableappointViewModel();
            int doctor = 5;
            var doctype = _context.PersonType.SingleOrDefault(m => m.id == type);
            DateTime today = DateTime.Today.AddDays(id * 7), todaye = DateTime.Today.AddDays(7 * (id + 1));
            if (doctype.type.Equals("doctor"))
            {
                var doc = _context.Doctor.SingleOrDefault(m => m.Id == docid);
                viewModel = new tableappointViewModel()
                {
                    usedAppoint = _context.Appointment.Where(m => (DateTime.Compare(m.Date, today) >= 0 &&
                   DateTime.Compare(m.Date, todaye) <= 0) && m.Docid == doc.Id).ToList(),
                    time = _context.times.SingleOrDefault(m => m.id == doc.Timesid),
                    today = today,
                    timview = new TimeViewModel(),
                    day = DayOfWeek.Friday,
                    numberoftable = id,
                    appoint = new Appointment
                    {
                        Docid = docid,
                        type = type
                    },
                };
            }
            else if (doctype.type.Equals("student"))
            {
                var doc = _context.Student.SingleOrDefault(m => m.id == docid);
                viewModel = new tableappointViewModel()
                {
                    usedAppoint = _context.Appointment.Where(m => (DateTime.Compare(m.Date, today) >= 0 &&
                    DateTime.Compare(m.Date, todaye) <= 0) && m.Docid == doc.id).ToList(),
                    time = _context.times.SingleOrDefault(m => m.id == doc.Timesid),
                    today = today,
                    timview = new TimeViewModel(),
                    day = DayOfWeek.Friday,
                    numberoftable = id,
                    appoint = new Appointment
                    {
                        Docid = docid,
                        type = type
                    },
                };
            }
            for (int i = 0; i < viewModel.usedAppoint.Count; i++)
            {
                int x = viewModel.usedAppoint[i].PacientId;
                viewModel.usedAppoint[i].pacient = _context.Pacient.
                    FirstOrDefault(m => m.id == x);
                x = viewModel.usedAppoint[i].pacient.personId;
                viewModel.usedAppoint[i].pacient.person = _context.Person.
                                SingleOrDefault(m => m.Id == x);
            }
            switch (viewModel.time.Dayoff)
            {
                case "Saturday":
                    {
                        viewModel.day = (DayOfWeek.Saturday);
                        break;
                    }
                case "Sunday":
                    {
                        viewModel.day = (DayOfWeek.Sunday);
                        break;
                    }
                case "Monday":
                    {
                        viewModel.day = (DayOfWeek.Monday);
                        break;
                    }
                case "Tuesday":
                    {
                        viewModel.day = (DayOfWeek.Tuesday);
                        break;
                    }
                case "Wednesday":
                    {
                        viewModel.day = (DayOfWeek.Wednesday);
                        break;
                    }
                case "Thursday":
                    {
                        viewModel.day = (DayOfWeek.Thursday);
                        break;
                    }
            }
            //test
            Session["type"] = "3";
            Session["id"] = "1";
            return View("_tableAppiont", viewModel);
        }
        public ActionResult NextTable(int id, int docid, int type)
        {
            return RedirectToAction("tableAppiont", "Appointment", new { id = id + 1, docid = docid, type = type });
        }
        public ActionResult PervTable(int id, int docid, int type)
        {
            return RedirectToAction("tableAppiont", "Appointment", new { id = id - 1, docid = docid, type = type });
        }
        public ActionResult FormAppointment(string dt, int docid, int type)
        {
            surveylist survey = _context.surveylist.SingleOrDefault(m => m.Doctorid == docid);
            if (survey == null)
            {
                survey = _context.surveylist.SingleOrDefault(m => m.Doctorid == 1);
            }
            formAppoimtnetViewModel fview = new formAppoimtnetViewModel
            {
                appoint = new Appointment
                {
                    Docid = docid, type = type,
                    Date = DateTime.ParseExact(dt, "dd/MM/yyyy-HH:mm", CultureInfo.InvariantCulture)
                },
                allstate = _context.States.ToList(),
                survey = survey,
                checkout = false,
            };
            fview.allstate.RemoveAt(fview.allstate.Count - 1);
            return View("_NewAppointment", fview);
        }
        [HttpPost]
        public ActionResult saveAppointment(formAppoimtnetViewModel app)
        {
            Session["id"] = "1";
            int pacid = Convert.ToInt32(Session["id"]);
            var Newapp = app.appoint;
            var pac = _context.Pacient.SingleOrDefault(m => m.id == pacid);
            if (pac == null)
            {
                return HttpNotFound();
            }
            Newapp.PacientId = pac.id;
            Newapp.sure = false;
            if (app.checkout|| (app.appoint.StatesId == 0))
            {
                app.appoint.StatesId = _context.States.SingleOrDefault(m=>m.Content.Equals("Checkout")).Id;
            }
            //else if(app.appoint.StatesId==0)
            //{
            //    //code for suvey result but now it checkout
            //}
            _context.Appointment.Add(Newapp);
            _context.SaveChanges();
            return Content(app.appoint.Date.ToShortDateString() +  app.appoint.StatesId);
        }

    }
}