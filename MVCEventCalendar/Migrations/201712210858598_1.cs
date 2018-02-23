namespace MVCEventCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Venue = c.String(),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Group2",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Venue = c.String(),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Group3",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Venue = c.String(),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Level5",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Venue = c.String(),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.MCSAs",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Venue = c.String(),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.MCSDs",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Venue = c.String(),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Mentors",
                c => new
                    {
                        MentorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        Surname = c.String(),
                        Gender = c.String(),
                        DOB = c.DateTime(nullable: false),
                        RSAID = c.String(),
                        Role = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MentorID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        LearnerID = c.Int(nullable: false, identity: true),
                        Names = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false),
                        RSAID = c.String(nullable: false),
                        Learnership = c.String(nullable: false),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(),
                        IsUserActive = c.String(),
                    })
                .PrimaryKey(t => t.LearnerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
            DropTable("dbo.Mentors");
            DropTable("dbo.MCSDs");
            DropTable("dbo.MCSAs");
            DropTable("dbo.Level5");
            DropTable("dbo.Group3");
            DropTable("dbo.Group2");
            DropTable("dbo.Events");
            DropTable("dbo.Administrators");
        }
    }
}
