namespace ProGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketsAndTypeOfTickets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        DateOfPurchase = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        TypeOfTicket_TypeOfTicketId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.TypeOfTickets", t => t.TypeOfTicket_TypeOfTicketId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TypeOfTicket_TypeOfTicketId);
            
            CreateTable(
                "dbo.TypeOfTickets",
                c => new
                    {
                        TypeOfTicketId = c.Int(nullable: false, identity: true),
                        TypeTicket = c.Int(nullable: false),
                        PeriodOfValidity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TypeOfTicketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "TypeOfTicket_TypeOfTicketId", "dbo.TypeOfTickets");
            DropIndex("dbo.Tickets", new[] { "TypeOfTicket_TypeOfTicketId" });
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropTable("dbo.TypeOfTickets");
            DropTable("dbo.Tickets");
        }
    }
}
