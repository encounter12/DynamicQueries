namespace DynamicQueries.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        SourceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        Deleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.SourceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sources");
        }
    }
}
