namespace ZerOneUniversityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classroomallocation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
        }
    }
}
