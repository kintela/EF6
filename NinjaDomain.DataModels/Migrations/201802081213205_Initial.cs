namespace NinjaDomain.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClanName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ninjas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ServedInOniwaban = c.Boolean(nullable: false),
                        ClanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clans", t => t.ClanID, cascadeDelete: true)
                .Index(t => t.ClanID);
            
            CreateTable(
                "dbo.NinjaEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Ninja_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ninjas", t => t.Ninja_Id, cascadeDelete: true)
                .Index(t => t.Ninja_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NinjaEquipments", "Ninja_Id", "dbo.Ninjas");
            DropForeignKey("dbo.Ninjas", "ClanID", "dbo.Clans");
            DropIndex("dbo.NinjaEquipments", new[] { "Ninja_Id" });
            DropIndex("dbo.Ninjas", new[] { "ClanID" });
            DropTable("dbo.NinjaEquipments");
            DropTable("dbo.Ninjas");
            DropTable("dbo.Clans");
        }
    }
}
