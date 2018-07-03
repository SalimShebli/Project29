using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Poject2.Models;
using System.Data.Entity;
namespace Poject2.Controllers
{
    public class surveyController : Controller
    {
        private ApplicationDbContext _context;

        public surveyController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: survey
        public ActionResult Index()
        {
            int x = 1; //defult value for surveys 
            var surlist = _context.surveylist.Include(m => m.Mysurvey).SingleOrDefault(m => m.Doctorid == x);
            /*_context.survey.Add(new survey { Answer = false,question="test",surveylistId=1});
            _context.SaveChanges();
            */
            return View("_survey",surlist);
        }
        [HttpPost]
        public ActionResult save(surveylist surlist)
        {
            //
            return RedirectToAction("Appoint", "Appointment");
        }
    }
}