namespace ProGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWorkoutIdAndUserId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Workouts", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Workouts", name: "IX_User_Id", newName: "IX_UserId");
            AddColumn("dbo.Exercises", "WorkoutID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "WorkoutID");
            RenameIndex(table: "dbo.Workouts", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Workouts", name: "UserId", newName: "User_Id");
        }
    }
}
