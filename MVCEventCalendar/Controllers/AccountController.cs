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
    public class AccountController : Controller
    {
        OurDbContext dc = new OurDbContext();
        // GET: Account
        public ActionResult Student()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Student(Students _learners)
        {
            if (ModelState.IsValid)
            {
                Students _lear = new Students();
                EmailDuplicate ed = new EmailDuplicate();
                bool d = ed.CheckDuplicate(_learners.Email);
                if (d == false)
                {
                    string result = _lear.InsertRegDetails(_learners);
                    ViewData["result"] = result;
                    ViewBag.Success = _learners.Names + " " + _learners.Surname + " You are successfully registered, you can now login and use the system";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    ViewBag.Duplicate = "Oops! it looks like this email: " + _learners.Email + " is already registered.";
                    return View();
                }
                
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to register...");
                return View();
            }

        }

        public ActionResult HomeLogin()
        {
            return View();
        }

        //Mentor
          [Authorize]
        public ActionResult RegMentor()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult RegMentor(Mentors _lean)
        {
            if (ModelState.IsValid)
            {
                Mentors _lear = new Mentors();
                string result = _lear.InsertRegDetails(_lean);
                ViewData["result"] = result;
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Could Not Register Mentor");
                return View();
            }
        }


        //For Mentor Login Starts here
     
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]

        public ActionResult Login(Mentors user, string returnurl)
        {
            if (ModelState.IsValid)
            {
                using (dc)
                {
                    string UUsername = user.Username;
                    string email = user.Email;
                    string Password = user.Password;

                    var loggenIn = dc.tblAdmin.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);


                    var Student = dc.tblstudents.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);


                    var Mentor = dc.tblmentors.FirstOrDefault(u => u.Username == user.Username  && u.Password == user.Password);
           
                    if (loggenIn != null)


                    { //check if user exist
                        Session["UserId"] = loggenIn.AdminID;

                        FormsAuthentication.SetAuthCookie(UUsername, false);
                        if (Url.IsLocalUrl(returnurl) && returnurl.Length > 1 && returnurl.StartsWith("/")
                            && !returnurl.StartsWith("//") && !returnurl.StartsWith("/\\"))


                        {
                            return Redirect(returnurl);
                        }


                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }
                    else
                    {
                        //ModelState.AddModelError("", "The user name or password provided is incorrect.");
                        ViewBag.Message = " Username or Password is Invalid";
                    }


                    if (Student != null)


                    { //check if user exist
                        Session["UserId"] = Student.LearnerID;

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
                        ViewBag.Message = " Username or Password is Invalid";
                    }


                    if (Mentor != null)


                    { //check if user exist
                        Session["UserId"] = Mentor.MentorID;

                        FormsAuthentication.SetAuthCookie(UUsername, false);
                        if (Url.IsLocalUrl(returnurl) && returnurl.Length > 1 && returnurl.StartsWith("/")
                            && !returnurl.StartsWith("//") && !returnurl.StartsWith("/\\"))


                        {
                            return Redirect(returnurl);
                        }




                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }



                    }
                    else
                    {
                        //ModelState.AddModelError("", "The user name or password provided is incorrect.");
                        ViewBag.Message = " Username or Password is Invalid";
                    }

                }
            }

            // If we got this far, something failed, redisplay form
            return View(user);
        }


        [Authorize]
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