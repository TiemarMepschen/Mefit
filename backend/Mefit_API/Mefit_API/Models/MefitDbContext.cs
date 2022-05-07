using Mefit_API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Mefit_API.Models
{
    public class MefitDbContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public MefitDbContext(DbContextOptions options) : base(options)
        {

        }

        // Seeding database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Exercises

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 1,
                Name = "Push-up",
                Description = "A push-up is a common calisthenics exercise beginning from the prone position. " + 
                "By raising and lowering the body using the arms, push-ups exercise the pectoral muscles, triceps, and anterior deltoids, " + 
                "with ancillary benefits to the rest of the deltoids, serratus anterior, coracobrachialis and the midsection as a whole."
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 2,
                Name = "Sit-up",
                Description = "The sit-up is an abdominal endurance training exercise to strengthen, tighten and tone the abdominal muscles. " + 
                "It is similar to a crunch (crunches target the rectus abdominis and also work the external and internal obliques), " + 
                "but sit-ups have a fuller range of motion and condition additional muscles."
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 3,
                Name = "Squat",
                Description = "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. " +
                "During the descent of a squat, the hip and knee joints flex while the ankle joint dorsiflexes; "
                + "conversely the hip and knee joints extend and the ankle joint plantarflexes when standing up."
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 4,
                Name = "30s Plank",
                Description = "The plank (also called a front hold, hover, or abdominal bridge) is an isometric core strength exercise that involves " + 
                "maintaining a position similar to a push-up for the maximum possible time."
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 5,
                Name = "Lunge",
                Description = "A lunge can refer to any position of the human body where one leg is positioned forward with knee bent and " +
                "foot flat on the ground while the other leg is positioned behind. It is used by athletes in cross-training for sports, " + 
                "by weight-trainers as a fitness exercise, and by practitioners of yoga as part of an asana regimen."
            });

            #endregion

            #region Sets

            modelBuilder.Entity<Set>().HasData(new Set
            {
                Id = 1,
                ExerciseRepetition = 1,
                ExerciseId = 1
            });

            modelBuilder.Entity<Set>().HasData(new Set
            {
                Id = 2,
                ExerciseRepetition = 10,
                ExerciseId = 1
            });

            modelBuilder.Entity<Set>().HasData(new Set
            {
                Id = 3,
                ExerciseRepetition = 1,
                ExerciseId = 2
            });

            modelBuilder.Entity<Set>().HasData(new Set
            {
                Id = 4,
                ExerciseRepetition = 10,
                ExerciseId = 2
            });

            modelBuilder.Entity<Set>().HasData(new Set
            {
                Id = 5,
                ExerciseRepetition = 1,
                ExerciseId = 3
            });

            modelBuilder.Entity<Set>().HasData(new Set
            {
                Id = 6,
                ExerciseRepetition = 10,
                ExerciseId = 3
            });

            modelBuilder.Entity<Set>().HasData(new Set
            {
                Id = 7,
                ExerciseRepetition = 1,
                ExerciseId = 4
            });

            modelBuilder.Entity<Set>().HasData(new Set
            {
                Id = 8,
                ExerciseRepetition = 10,
                ExerciseId = 4
            });

            modelBuilder.Entity<Set>().HasData(new Set
            {
                Id = 9,
                ExerciseRepetition = 1,
                ExerciseId = 5
            });

            modelBuilder.Entity<Set>().HasData(new Set
            {
                Id = 10,
                ExerciseRepetition = 10,
                ExerciseId = 5
            });

            #endregion

            #region Workouts

            modelBuilder.Entity<Workout>().HasData(new Workout
            {
                Id = 1,
                Name = "Light Push-up",
                Completed = false,
                SetId = 1
            });

            modelBuilder.Entity<Workout>().HasData(new Workout
            {
                Id = 2,
                Name = "Heavy Push-up",
                Completed = false,
                SetId = 2
            });

            modelBuilder.Entity<Workout>().HasData(new Workout
            {
                Id = 3,
                Name = "Light Sit-up",
                Completed = false,
                SetId = 3
            });

            modelBuilder.Entity<Workout>().HasData(new Workout
            {
                Id = 4,
                Name = "Heavy Sit-up",
                Completed = false,
                SetId = 4
            });

            modelBuilder.Entity<Workout>().HasData(new Workout
            {
                Id = 5,
                Name = "Light Squat",
                Completed = false,
                SetId = 5
            });

            modelBuilder.Entity<Workout>().HasData(new Workout
            {
                Id = 6,
                Name = "Heavy Squat",
                Completed = false,
                SetId = 6
            });

            modelBuilder.Entity<Workout>().HasData(new Workout
            {
                Id = 7,
                Name = "Light Plank",
                Completed = false,
                SetId = 7
            });

            modelBuilder.Entity<Workout>().HasData(new Workout
            {
                Id = 8,
                Name = "Heavy Plank",
                Completed = false,
                SetId = 8
            });

            modelBuilder.Entity<Workout>().HasData(new Workout
            {
                Id = 9,
                Name = "Light Lunge",
                Completed = false,
                SetId = 9
            });

            modelBuilder.Entity<Workout>().HasData(new Workout
            {
                Id = 10,
                Name = "Heavy Lunge",
                Completed = false,
                SetId = 10
            });

            #endregion

            #region Programmes

            modelBuilder.Entity<Programme>().HasData(new Programme
            {
                Id = 1,
                Name = "Light Program"
            });

            modelBuilder.Entity<Programme>().HasData(new Programme
            {
                Id = 2,
                Name = "Medium Program"
            });

            modelBuilder.Entity<Programme>().HasData(new Programme
            {
                Id = 3,
                Name = "Heavy Program"
            });

            #endregion

            #region Goals

            modelBuilder.Entity<Goal>().HasData(new Goal
            {
                Id = 1,
                EndDate = new DateTime(2022, 4, 15),
                Completed = false,
                ProgrammeId = 1
            });

            modelBuilder.Entity<Goal>().HasData(new Goal
            {
                Id = 2,
                EndDate = new DateTime(2022, 4, 22),
                Completed = false,
                ProgrammeId = 2
            });

            modelBuilder.Entity<Goal>().HasData(new Goal
            {
                Id = 3,
                EndDate = new DateTime(2022, 4, 29),
                Completed = false,
                ProgrammeId = 3
            });

            #endregion

            #region Many to many seeding

            modelBuilder.Entity<Programme>()
                .HasMany(p => p.Workouts)
                .WithMany(w => w.Programmes)
                .UsingEntity<Dictionary<string, object>>(
                    "ProgrammeWorkout",
                    r => r.HasOne<Workout>().WithMany().HasForeignKey("WorkoutsId"),
                    l => l.HasOne<Programme>().WithMany().HasForeignKey("ProgrammesId"),
                    je =>
                    {
                        je.HasKey("ProgrammesId", "WorkoutsId");
                        je.HasData(
                            new { ProgrammesId = 1, WorkoutsId = 1 },
                            new { ProgrammesId = 1, WorkoutsId = 3 },
                            new { ProgrammesId = 1, WorkoutsId = 5 },
                            new { ProgrammesId = 1, WorkoutsId = 7 },
                            new { ProgrammesId = 1, WorkoutsId = 9 },
                            new { ProgrammesId = 2, WorkoutsId = 1 },
                            new { ProgrammesId = 2, WorkoutsId = 3 },
                            new { ProgrammesId = 2, WorkoutsId = 5 },
                            new { ProgrammesId = 2, WorkoutsId = 8 },
                            new { ProgrammesId = 2, WorkoutsId = 10 },
                            new { ProgrammesId = 3, WorkoutsId = 2 },
                            new { ProgrammesId = 3, WorkoutsId = 4 },
                            new { ProgrammesId = 3, WorkoutsId = 6 },
                            new { ProgrammesId = 3, WorkoutsId = 8 },
                            new { ProgrammesId = 3, WorkoutsId = 10 }
                        );
                    });

            #endregion

        }
    }
}
