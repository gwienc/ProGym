namespace ProGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTicketPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeOfTickets", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeOfTickets", "Price");
        }
    }
}
