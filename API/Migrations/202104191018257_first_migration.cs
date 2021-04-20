namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_M_Division",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        about = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_M_Division");
        }
    }
}
