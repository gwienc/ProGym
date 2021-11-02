namespace ProGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectTypeOfTicket2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TypeOfTickets", "TicketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TypeOfTickets", "TicketId", c => c.Int(nullable: false));
        }
    }
}
