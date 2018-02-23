using MVCEventCalendar.Models;
using MVCEventCalendar.Models.Extended_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventCalendar.Controllers
{
    public class AdminGroup3Controller : Controller
    {
        //[Authorize]
        public ActionResult AdminGroup3()
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
        public JsonResult SaveGroup3(Group3 e)
        {
            var status = false;
            using (OurDbContext dc = new OurDbContext())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.tblGroup3.Where(a => a.EventID == e.EventID).FirstOrDefault();
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
                    dc.tblGroup3.Add(e);
                }

                dc.SaveChanges();
                //ViewBag.Success = e.Start + " " + "Event is Successfully Created";
                ViewBag.Success = e.Start + " " + " Event is Successfully Created";
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteGroup3Event(int eventID)
        {
            var status = false;
            using (OurDbContext dc = new OurDbContext())
            {
                var v = dc.tblGroup3.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.tblGroup3.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }

}
