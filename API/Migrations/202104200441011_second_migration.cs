namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_M_Department",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Division_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TB_M_Division", t => t.Division_id, cascadeDelete: true)
                .Index(t => t.Division_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_M_Department", "Division_id", "dbo.TB_M_Division");
            DropIndex("dbo.TB_M_Department", new[] { "Division_id" });
            DropTable("dbo.TB_M_Department");
        }
    }
}
