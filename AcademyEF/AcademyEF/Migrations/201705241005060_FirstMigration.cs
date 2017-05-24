namespace AcademyEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserCourses",
                c => new
                    {
                        User_ID = c.Guid(nullable: false),
                        Course_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Course_ID })
                .ForeignKey("dbo.Users", t => t.User_ID)
                .ForeignKey("dbo.Courses", t => t.Course_ID)
                .Index(t => t.User_ID)
                .Index(t => t.Course_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.UserCourses", "User_ID", "dbo.Users");
            DropIndex("dbo.UserCourses", new[] { "Course_ID" });
            DropIndex("dbo.UserCourses", new[] { "User_ID" });
            DropTable("dbo.UserCourses");
            DropTable("dbo.Users");
            DropTable("dbo.Courses");
        }
    }
}
