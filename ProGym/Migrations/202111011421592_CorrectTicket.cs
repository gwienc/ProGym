namespace ProGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectTicket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "TypeOfTicket_TypeOfTicketId", "dbo.TypeOfTickets");
            DropIndex("dbo.Tickets", new[] { "TypeOfTicket_TypeOfTicketId" });
            RenameColumn(table: "dbo.Tickets", name: "TypeOfTicket_TypeOfTicketId", newName: "TypeOfTicketId");
            AlterColumn("dbo.Tickets", "TypeOfTicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "TypeOfTicketId");
            AddForeignKey("dbo.Tickets", "TypeOfTicketId", "dbo.TypeOfTickets", "TypeOfTicketId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TypeOfTicketId", "dbo.TypeOfTickets");
            DropIndex("dbo.Tickets", new[] { "TypeOfTicketId" });
            AlterColumn("dbo.Tickets", "TypeOfTicketId", c => c.Int());
            RenameColumn(table: "dbo.Tickets", name: "TypeOfTicketId", newName: "TypeOfTicket_TypeOfTicketId");
            CreateIndex("dbo.Tickets", "TypeOfTicket_TypeOfTicketId");
            AddForeignKey("dbo.Tickets", "TypeOfTicket_TypeOfTicketId", "dbo.TypeOfTickets", "TypeOfTicketId");
        }
    }
}
