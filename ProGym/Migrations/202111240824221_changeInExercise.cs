namespace ProGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInExercise : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercises", "Workout_WorkoutID", "dbo.Workouts");
            DropIndex("dbo.Exercises", new[] { "Workout_WorkoutID" });
            DropColumn("dbo.Exercises", "WorkoutID");
            RenameColumn(table: "dbo.Exercises", name: "Workout_WorkoutID", newName: "WorkoutID");
            AlterColumn("dbo.Exercises", "WorkoutID", c => c.Int(nullable: false));
            AlterColumn("dbo.Exercises", "WorkoutID", c => c.Int(nullable: false));
            CreateIndex("dbo.Exercises", "WorkoutID");
            AddForeignKey("dbo.Exercises", "WorkoutID", "dbo.Workouts", "WorkoutID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "WorkoutID", "dbo.Workouts");
            DropIndex("dbo.Exercises", new[] { "WorkoutID" });
            AlterColumn("dbo.Exercises", "WorkoutID", c => c.Int());
            AlterColumn("dbo.Exercises", "WorkoutID", c => c.String());
            RenameColumn(table: "dbo.Exercises", name: "WorkoutID", newName: "Workout_WorkoutID");
            AddColumn("dbo.Exercises", "WorkoutID", c => c.String());
            CreateIndex("dbo.Exercises", "Workout_WorkoutID");
            AddForeignKey("dbo.Exercises", "Workout_WorkoutID", "dbo.Workouts", "WorkoutID");
        }
    }
}
