using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MVCEventCalendar.Models
{
    public class Students
    {
        [Key]
        public int LearnerID { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$", ErrorMessage = "Names cannot contain numeric values")]
        public string Names { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$", ErrorMessage = "Surname cannot contain numeric values")]
        public string Surname { get; set; }

        [Required]
        public string Gender { get; set; }
        //public DateTime? DOB { get; set; }

        [Required]
        public string RSAID { get; set; }

        [Required]
        public string Learnership { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid. Do not include space")]
        public string Mobile { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+(@dynamicdna.co.za)$", ErrorMessage = "Registration is limited to dynamicdna email address only")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Compare("Email", ErrorMessage = "The Email and Username do not match.")]
        [Display(Name = "Email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+(@dynamicdna.co.za)$", ErrorMessage = "Registration is limited to dynamicdna email address only.")]
        public string Username { get; set; }

        public string Password { get; set; }
        public string IsUserActive { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=197.189.255.211;Initial Catalog=ddnappst_TimetableDB;User ID=ddnappst_Admin;Password=Admin123!@#");
        //SqlConnection con = new SqlConnection(@"Data Source=DVTL8VR1R72\SQL;Initial Catalog=EventManagement.Extended DB.OurDbContext;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        SqlCommand cmd = new SqlCommand();



        public string InsertRegDetails(Students _lean)
        {
          
            cmd.CommandText = "Insert into [Students] values('" + _lean.Names
                + "','" + _lean.Surname
                + "','" + _lean.Gender
                //+ "','" + _lean.DOB
                + "','" + _lean.RSAID
                + "','" + _lean.Learnership
                + "','" + _lean.Mobile
                + "','" + _lean.Email
                + "','" + _lean.Username
                + "','" + _lean.Password
                + "','" + _lean.IsUserActive + "')";

            MailMessage mail = new MailMessage();

            mail.To.Add(_lean.Email);
            mail.From = new MailAddress("timetable.dynamicdna@gmail.com");
            mail.Subject = ("Learner's Login Details");
            string Body = ("Hello " + _lean.Names + " " + _lean.Surname + "<br/><br/>" + "This is to confirm that you have been registered on the Dynamic DNA Event Management System. Your login details for the Event System are " + "<br/><br/>" + "Username: " + _lean.Username + "<br/><br/>" + "  Password: " + _lean.Password  + "<br/><br/>" + "Please NOTE that you can change your Password anytime. For any queries please send an email to  mtunzihuna@dynamicdna.co.za or info@dynamicdna.co.za click the link to login http://timetable.ddnappstore.co.za");
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("timetable.dynamicdna@gmail.com", "Admin123!@#");



            smtp.EnableSsl = true;
            smtp.Send(mail);

            cmd.Connection = con;



            try
            {

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                return "Successfully Registered " + _lean.Names + " " + _lean.Surname;
            }
            catch (Exception es)
            {
                throw es;
            }
        }


    }
}