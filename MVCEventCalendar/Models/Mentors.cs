using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MVCEventCalendar.Models
{
    public class Mentors
    {
        [Key]
        public int MentorID { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        public string RSAID { get; set; }

        public string Role { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=197.189.255.211;Initial Catalog=ddnappst_TimetableDB;User ID=ddnappst_Admin;Password=Admin123!@#");
        SqlCommand cmd = new SqlCommand();



        public string InsertRegDetails(Mentors _lean)
        {
            // My array of characters
            string[] alphas = new string[52];
            alphas[0] = "a";
            alphas[1] = "b";
            alphas[2] = "c";
            alphas[3] = "d";
            alphas[4] = "e";
            alphas[5] = "f";
            alphas[6] = "g";
            alphas[7] = "h";
            alphas[8] = "i";
            alphas[9] = "j";
            alphas[10] = "k";
            alphas[11] = "l";
            alphas[12] = "m";
            alphas[13] = "n";
            alphas[14] = "o";
            alphas[15] = "p";
            alphas[16] = "q";
            alphas[17] = "r";
            alphas[18] = "s";
            alphas[19] = "t";
            alphas[20] = "u";
            alphas[21] = "v";
            alphas[22] = "w";
            alphas[23] = "x";
            alphas[24] = "y";
            alphas[25] = "z";
            alphas[26] = "A";
            alphas[27] = "B";
            alphas[28] = "C";
            alphas[29] = "D";
            alphas[30] = "E";
            alphas[31] = "F";
            alphas[32] = "G";
            alphas[33] = "H";
            alphas[34] = "I";
            alphas[35] = "J";
            alphas[36] = "K";
            alphas[37] = "L";
            alphas[38] = "M";
            alphas[39] = "N";
            alphas[40] = "O";
            alphas[41] = "P";
            alphas[42] = "Q";
            alphas[43] = "R";
            alphas[44] = "S";
            alphas[45] = "T";
            alphas[46] = "U";
            alphas[47] = "V";
            alphas[48] = "W";
            alphas[49] = "X";
            alphas[50] = "Y";
            alphas[51] = "Z";

            Random r = new Random();
            string randomPassword;
            randomPassword = ((alphas[r.Next(0, 52)] + r.Next(0, 100) + alphas[r.Next(0, 52)] + r.Next(0, 100) + alphas[r.Next(0, 52)] + r.Next(0, 100) + alphas[r.Next(0, 52)]));

            Random rr = new Random();
            int randomN;
            randomN = rr.Next(123, 21344);
            _lean.MentorID = randomN;


            string randomRNS;

            randomRNS = ((alphas[rr.Next(0, 52)] + rr.Next(0, 111) + alphas[rr.Next(0, 52)] + rr.Next(0, 300) + alphas[rr.Next(0, 52)] + rr.Next(0, 200) + alphas[rr.Next(0, 52)]));
            _lean.RSAID = randomRNS;

            cmd.CommandText = "Insert into [Mentors] values('" + _lean.FirstName
                + "','" + _lean.MiddleName
                + "','" + _lean.Surname
                + "','" + _lean.Gender
                + "','" + _lean.DOB
                + "','" + _lean.RSAID
                + "','" + _lean.Role
                + "','" + _lean.Username
                + "','" + randomPassword
                + "','" + _lean.Mobile
                + "','" + _lean.Email
                + "','" + _lean.IsActive + "')";

            MailMessage mail = new MailMessage();
            mail.To.Add(_lean.Email);
            mail.From = new MailAddress("dynamicdnalogbook@gmail.com");
            mail.Subject = ("Mentor's Login Details");
            string Body = ("Hi " + _lean.FirstName + " " + _lean.MiddleName + " " + _lean.Surname + " ,                                                                                                   this is to confirm that you have been registered on the Learners Log System, as a Mentor. Your login details for the Log System are " + "Username: " + _lean.Username + "  Password: " + randomPassword + " Keep the following Confidential Password Retrieval Code to reset your password " + randomRNS + " .Please NOTE that you are permitted change your Password. For any queries please send an email to timetable@ddnappstore.co.za. Click  http://timetable.ddnappstore.co.za/ To login");
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("dynamicdnalogbook@gmail.com", "DDNA123!@#");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            cmd.Connection = con;



            try
            {

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                return "Successfully Registered Mentor ";
            }
            catch (Exception es)
            {
                throw es;
            }
        }


    }
}