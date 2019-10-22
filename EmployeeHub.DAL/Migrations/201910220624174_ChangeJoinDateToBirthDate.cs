namespace EmployeeHub.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeJoinDateToBirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Employees", "JoinDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "JoinDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Employees", "BirthDate");
        }
    }
}
