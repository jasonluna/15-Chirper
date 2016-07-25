namespace Chirper.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChirperUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chirps", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Comments", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Chirps", "UserId");
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Chirps", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chirps", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Chirps", new[] { "UserId" });
            DropColumn("dbo.Comments", "UserId");
            DropColumn("dbo.Chirps", "UserId");
        }
    }
}
