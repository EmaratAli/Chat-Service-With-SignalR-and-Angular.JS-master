namespace ChatService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ConnectionTime = c.String(),
                        ConnectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ConnectionId, cascadeDelete: true)
                .Index(t => t.ConnectionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ConnectionTime = c.String(),
                        ConnectionId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ConnectionId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "ConnectionId" });
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
        }
    }
}
