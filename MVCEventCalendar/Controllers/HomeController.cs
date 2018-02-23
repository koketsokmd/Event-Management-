using MVCEventCalendar.Models;
using MVCEventCalendar.Models.Extended_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventCalendar.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (OurDbContext dc = new OurDbContext())
            {
                var events = dc.tblEvents.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        //Group 1 View
        //[Authorize]
        public ActionResult Group1()
        {
            return View();
        }


        //Group 2 View
        //[Authorize]
        public ActionResult Group2()
        {
            return View();
        }
        public JsonResult FindEvents()
        {
            using (OurDbContext dc = new OurDbContext())
            {
                var events = dc.tblGroup2.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }



        //End here Group 3 View
        //[Authorize]
        public ActionResult Group3()
        {
            return View();
        }
        public JsonResult FetchEvents()
        {
            using (OurDbContext dc = new OurDbContext())
            {
                var events = dc.tblGroup3.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var status = false;
            using (OurDbContext dc = new OurDbContext())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.tblEvents.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.Venue = e.Venue;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.tblEvents.Add(e);
                }

                dc.SaveChanges();
                //ViewBag.Success = e.Start + " " + "Event is Successfully Created";
                ViewBag.Success = e.Subject + " " + " Event is Successfully Created";
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (OurDbContext dc = new OurDbContext())
            {
                var v = dc.tblEvents.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.tblEvents.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status} };
        }
    }
}