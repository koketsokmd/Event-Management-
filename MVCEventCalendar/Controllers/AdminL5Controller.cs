using MVCEventCalendar.Models;
using MVCEventCalendar.Models.Extended_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventCalendar.Controllers
{
    public class AdminL5Controller : Controller
    {
        //Group 2 View
        //[Authorize]
        public ActionResult Level5()
        {
            return View();
        }
        public JsonResult CarryEvents()
        {
            using (OurDbContext dc = new OurDbContext())
            {
                var events = dc.tblLevel5.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        //[Authorize]
        public ActionResult AdminL5()
        {
            return View();
        }
        public JsonResult FetchL5()
        {
            using (OurDbContext dc = new OurDbContext())
            {
                var events = dc.tblLevel5.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        [HttpPost]
        public JsonResult SaveL5(Level5 e)
        {
            var status = false;
            using (OurDbContext dc = new OurDbContext())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.tblLevel5.Where(a => a.EventID == e.EventID).FirstOrDefault();
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
                    dc.tblLevel5.Add(e);
                }

                dc.SaveChanges();
                //ViewBag.Success = e.Start + " " + "Event is Successfully Created";
                ViewBag.Success = e.Start + " " + " Event is Successfully Created";
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteL5Event(int eventID)
        {
            var status = false;
            using (OurDbContext dc = new OurDbContext())
            {
                var v = dc.tblLevel5.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.tblLevel5.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}