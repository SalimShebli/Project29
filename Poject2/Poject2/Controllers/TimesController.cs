using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Poject2.Models.Appoint;
using Poject2.Models;
using Poject2.ViewModel;
namespace Poject2.Controllers
{
    public class TimesController : Controller
    {
        // GET: Times
        private ApplicationDbContext _context;

        public TimesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Create()
        {

            var time = _context.times.SingleOrDefault(m => m.id == 1);
            var timeview = new TimeViewModel();
            timeview.time = time;
            //return HttpNotFound();
            return View("_Create",timeview);
        }
        public ActionResult save(Times time)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            _context.times.Add(time);
            var doc = _context.Doctor.FirstOrDefault(m => m.Id == 1);
            if(doc!=null)
            {
                doc.Timesid = time.id;
            }
            _context.SaveChanges();
            return RedirectToAction("index","home");
        }
    }
}