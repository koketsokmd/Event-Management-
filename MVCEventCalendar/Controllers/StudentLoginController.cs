using MVCEventCalendar.Models;
using MVCEventCalendar.Models.Extended_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCEventCalendar.Controllers
{
    public class StudentLoginController : Controller
    {
        OurDbContext dc = new OurDbContext();

    
        public ActionResult StudentLogin()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public ActionResult StudentLogin(Students user, string returnurl)
        {
            if (ModelState.IsValid)
            {
                using (dc)
                {
                    string UUsername = user.Username;
                    string Password = user.Password;

                    var loggenIn = dc.tblstudents.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

                    if (loggenIn != null)


                    { //check if user exist
                        Session["UserId"] = loggenIn.LearnerID;

                        FormsAuthentication.SetAuthCookie(UUsername, false);
                        if (Url.IsLocalUrl(returnurl) && returnurl.Length > 1 && returnurl.StartsWith("/")
                            && !returnurl.StartsWith("//") && !returnurl.StartsWith("/\\"))


                        {
                            return Redirect(returnurl);
                        }




                        else
                        {
                            return RedirectToAction("Group1", "Home");
                        }


                    }
                    else
                    {
                        //ModelState.AddModelError("", "The user name or password provided is incorrect.");
                        ViewBag.Message = " Username or Password is Invalid ";
                    }


                }
            }

            // If we got this far, something failed, redisplay form
            return View(user);
        }


        public ActionResult LogOff()
        {

            Session["UserId"] = null;
            FormsAuthentication.SignOut();
            Session.Clear();  // This may not be needed -- but can't hurt
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}