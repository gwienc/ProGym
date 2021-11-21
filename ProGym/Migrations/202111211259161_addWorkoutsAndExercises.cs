namespace ProGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWorkoutsAndExercises : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ExerciseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RepetitionsNumber = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Workout_WorkoutID = c.Int(),
                    })
                .PrimaryKey(t => t.ExerciseID)
                .ForeignKey("dbo.Workouts", t => t.Workout_WorkoutID)
                .Index(t => t.Workout_WorkoutID);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        WorkoutID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.WorkoutID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Exercises", "Workout_WorkoutID", "dbo.Workouts");
            DropIndex("dbo.Workouts", new[] { "User_Id" });
            DropIndex("dbo.Exercises", new[] { "Workout_WorkoutID" });
            DropTable("dbo.Workouts");
            DropTable("dbo.Exercises");
        }
    }
}
