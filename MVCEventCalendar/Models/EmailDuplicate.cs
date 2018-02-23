using MVCEventCalendar.Models.Extended_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEventCalendar.Models
{
    public class EmailDuplicate
    {
        OurDbContext db = new OurDbContext();
        public bool CheckDuplicate(string email)
        {
            var duplicate = (from users in db.tblstudents
                            where users.Email == email
                            select users);
            string hey="";
            foreach (var item in duplicate)
            {
                hey = item.Email;
            }

            if (string.IsNullOrEmpty(hey) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}