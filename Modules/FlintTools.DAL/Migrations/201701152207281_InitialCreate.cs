namespace FlintTools.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskItems",
                c => new
                    {
                        TaskId = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(unicode: false),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskItems");
        }
    }
}
