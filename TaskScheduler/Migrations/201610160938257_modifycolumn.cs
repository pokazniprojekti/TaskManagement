namespace TaskScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifycolumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkingTasks", "IsActive", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkingTasks", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
