using MVCEventCalendar.Models;
using MVCEventCalendar.Models.Extended_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventCalendar.Controllers
{
    public class AdminMCSDController : Controller
    {

        public ActionResult MCSDLLearner()
        {
            return View();
        }
        public JsonResult CatchEvents()
        {
            using (OurDbContext dc = new OurDbContext())
            {
                var events = dc.tblMCSD.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        //[Authorize]
        public ActionResult AdminMCSD()
        {
            return View();
        }
        public JsonResult FetchMSCD()
        {
            using (OurDbContext dc = new OurDbContext())
            {
                var events = dc.tblMCSD.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        [HttpPost]
        public JsonResult SaveMSCD(MCSD e)
        {
            var status = false;
            using (OurDbContext dc = new OurDbContext())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.tblMCSD.Where(a => a.EventID == e.EventID).FirstOrDefault();
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
                    dc.tblMCSD.Add(e);
                }

                dc.SaveChanges();
                //ViewBag.Success = e.Start + " " + "Event is Successfully Created";
                ViewBag.Success = e.Start + " " + " Event is Successfully Created";
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteMCSDEvent(int eventID)
        {
            var status = false;
            using (OurDbContext dc = new OurDbContext())
            {
                var v = dc.tblMCSD.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.tblMCSD.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}