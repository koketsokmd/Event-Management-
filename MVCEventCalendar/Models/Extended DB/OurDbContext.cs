using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCEventCalendar.Models.Extended_DB
{
    public class OurDbContext : DbContext
    {
        public DbSet<Students> tblstudents { get; set; }

        public DbSet<Mentors> tblmentors { get; set; }

        public DbSet<Events> tblEvents { get; set; }

        public DbSet<Group2> tblGroup2 { get; set; }

        public DbSet<Group3> tblGroup3 { get; set; }

        public DbSet<Administrator> tblAdmin { get; set; }

        public DbSet<Level5> tblLevel5{ get; set; }

        public DbSet<MCSA> tblMCSA { get; set; }

        public DbSet<MCSD> tblMCSD { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{


        //    modelBuilder.Entity<Students>().ToTable("tblstudents");
        //    modelBuilder.Entity<Students>().HasKey(x => x.LearnerID);

        //    modelBuilder.Entity<Mentors>().ToTable("tblmentors");
        //    modelBuilder.Entity<Mentors>().HasKey(x => x.MentorID);

        //    modelBuilder.Entity<Events>().ToTable("tblEvents");
        //    modelBuilder.Entity<Events>().HasKey(x => x.EventID);
        //}

    }
}