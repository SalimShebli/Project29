using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Poject2.Models;
namespace Poject2.Controllers.api
{
    public class NotificationController : Controller
    {
         ApplicationDbContext _context;
         public NotificationController()
        {
            _context = new ApplicationDbContext();

        }
        public enum NotificationType
        {
            AcceptedAppointment = 1,
            DeletedAppointment=2,
            LikesGetOnPost=3,
            CommentsGetOnPost=4,
            AppointmentReminder=5
        };
        //
        // GET: /Notification/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public bool CreateNotification(int SenderPersonID,int ResieverPersonId,int notifType,string notifContent)
        {
             var Sender = _context.Person.FirstOrDefault(m => m.Id == SenderPersonID);
            var Res=_context.Person.FirstOrDefault(m=>m.Id==ResieverPersonId);
            Notifaciton notification = new Notifaciton();
            notification.id_resiever = Res.Id;
            notification.id_sender = Sender.Id;
           
            notification.Content = notifContent;
            notification.type = notifType;
            _context.Notifaction.Add(notification);
            _context.SaveChanges();
            return true;
        }
        public ActionResult GetUnreadedNotification(int PersonId)
        {
            var notifications= _context.Notifaction.Where(m => m.id_resiever == PersonId&&!m.seen).ToList();

            return View(notifications);
        }
        public ActionResult ReadNotification(Notifaciton notification)
        {
            notification.seen = true;
            _context.SaveChanges();
            switch(notification.type)
            {
                case (int)NotificationType.AcceptedAppointment:
                    {


                        break;
                    }
                case (int)NotificationType.DeletedAppointment:
                    {


                        break;
                    }
                case (int)NotificationType.LikesGetOnPost:
                    {


                        break;
                    }
                case (int)NotificationType.CommentsGetOnPost:
                    {


                        break;
                    }
                case (int)NotificationType.AppointmentReminder:
                    {


                        break;
                    }
            }
            return View();
        }
	}
}