using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Poject2.Models;
using Poject2.Models.Persons;
using System.Net.Http;
using System.Web.Http;
namespace Poject2.Controllers.api
{
    public class RatingController : Controller
    {
        ApplicationDbContext _context;
        //
        // GET: /Rating/
        public RatingController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SetRatingForDoctor(int userId,int doctorID,int rate)
        {
            var DoctorPer = _context.Doctor.FirstOrDefault(m => m.Id == doctorID);
            var UserPer=_context.Pacient.FirstOrDefault(m=>m.id==userId);
            var rating = _context.Rating.FirstOrDefault(m => m.PersonId == DoctorPer.personId &&
                m.RaterId == UserPer.personId);
            if(rating==null)
            {
                Rating rat = new Rating();
                rat.PersonId = DoctorPer.personId;
                rat.RaterId = UserPer.personId;
                rat.value = rate;
                rat.Content = "";
                _context.Rating.Add(rat);
               
            }
            else
            {
                rating.value = rate;
            }
            _context.SaveChanges();
            return View();
        }
        public float  GetRating(int doctorId)
        {
            var doctor = _context.Doctor.FirstOrDefault(m => m.Id == doctorId);
            float rating = 0;
            if(doctor!=null&&doctor.person!=null)
            {
                for (int i = 0; i < doctor.person.ListRating.Count;i++ )
                {
                    rating += doctor.person.ListRating[i].value;
                }
                if (doctor.person.ListRating.Count > 0)
                    rating /= doctor.person.ListRating.Count;
            }
            return rating;
        }
	}
}