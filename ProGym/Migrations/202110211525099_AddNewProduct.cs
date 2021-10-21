namespace ProGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProducerName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Ingredients", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ShortDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Parameters", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "PhotoFileName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "PhotoFileName", c => c.String());
            AlterColumn("dbo.Products", "Parameters", c => c.String());
            AlterColumn("dbo.Products", "ShortDescription", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Ingredients", c => c.String());
            AlterColumn("dbo.Products", "ProducerName", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
