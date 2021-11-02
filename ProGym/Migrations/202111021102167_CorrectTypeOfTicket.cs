namespace ProGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectTypeOfTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeOfTickets", "TicketId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeOfTickets", "TicketId");
        }
    }
}
