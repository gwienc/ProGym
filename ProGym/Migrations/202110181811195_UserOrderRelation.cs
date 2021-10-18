namespace ProGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserOrderRelation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Orders", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
