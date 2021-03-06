// <auto-generated />
using System;
using Mefit_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mefit_API.Migrations
{
    [DbContext(typeof(MefitDbContext))]
    [Migration("20220422104003_initial-db")]
    partial class initialdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GoalWorkout", b =>
                {
                    b.Property<int>("GoalsId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutsId")
                        .HasColumnType("int");

                    b.HasKey("GoalsId", "WorkoutsId");

                    b.HasIndex("WorkoutsId");

                    b.ToTable("GoalWorkout");
                });

            modelBuilder.Entity("Mefit_API.Models.Domain.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A push-up is a common calisthenics exercise beginning from the prone position. By raising and lowering the body using the arms, push-ups exercise the pectoral muscles, triceps, and anterior deltoids, with ancillary benefits to the rest of the deltoids, serratus anterior, coracobrachialis and the midsection as a whole.",
                            Name = "Push-up"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The sit-up is an abdominal endurance training exercise to strengthen, tighten and tone the abdominal muscles. It is similar to a crunch (crunches target the rectus abdominis and also work the external and internal obliques), but sit-ups have a fuller range of motion and condition additional muscles.",
                            Name = "Sit-up"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent of a squat, the hip and knee joints flex while the ankle joint dorsiflexes; conversely the hip and knee joints extend and the ankle joint plantarflexes when standing up.",
                            Name = "Squat"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The plank (also called a front hold, hover, or abdominal bridge) is an isometric core strength exercise that involves maintaining a position similar to a push-up for the maximum possible time.",
                            Name = "30s Plank"
                        },
                        new
                        {
                            Id = 5,
                            Description = "A lunge can refer to any position of the human body where one leg is positioned forward with knee bent and foot flat on the ground while the other leg is positioned behind. It is used by athletes in cross-training for sports, by weight-trainers as a fitness exercise, and by practitioners of yoga as part of an asana regimen.",
                            Name = "Lunge"
                        });
                });

            modelBuilder.Entity("Mefit_API.Models.Domain.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProgrammeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammeId");

                    b.ToTable("Goals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Completed = false,
                            EndDate = new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProgrammeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Completed = false,
                            EndDate = new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProgrammeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Completed = false,
                            EndDate = new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProgrammeId = 3
                        });
                });

            modelBuilder.Entity("Mefit_API.Models.Domain.Programme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Programmes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Light Program"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium Program"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Heavy Program"
                        });
                });

            modelBuilder.Entity("Mefit_API.Models.Domain.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseRepetition")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Sets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseId = 1,
                            ExerciseRepetition = 1
                        },
                        new
                        {
                            Id = 2,
                            ExerciseId = 1,
                            ExerciseRepetition = 10
                        },
                        new
                        {
                            Id = 3,
                            ExerciseId = 2,
                            ExerciseRepetition = 1
                        },
                        new
                        {
                            Id = 4,
                            ExerciseId = 2,
                            ExerciseRepetition = 10
                        },
                        new
                        {
                            Id = 5,
                            ExerciseId = 3,
                            ExerciseRepetition = 1
                        },
                        new
                        {
                            Id = 6,
                            ExerciseId = 3,
                            ExerciseRepetition = 10
                        },
                        new
                        {
                            Id = 7,
                            ExerciseId = 4,
                            ExerciseRepetition = 1
                        },
                        new
                        {
                            Id = 8,
                            ExerciseId = 4,
                            ExerciseRepetition = 10
                        },
                        new
                        {
                            Id = 9,
                            ExerciseId = 5,
                            ExerciseRepetition = 1
                        },
                        new
                        {
                            Id = 10,
                            ExerciseId = 5,
                            ExerciseRepetition = 10
                        });
                });

            modelBuilder.Entity("Mefit_API.Models.Domain.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SetId");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Completed = false,
                            Name = "Light Push-up",
                            SetId = 1
                        },
                        new
                        {
                            Id = 2,
                            Completed = false,
                            Name = "Heavy Push-up",
                            SetId = 2
                        },
                        new
                        {
                            Id = 3,
                            Completed = false,
                            Name = "Light Sit-up",
                            SetId = 3
                        },
                        new
                        {
                            Id = 4,
                            Completed = false,
                            Name = "Heavy Sit-up",
                            SetId = 4
                        },
                        new
                        {
                            Id = 5,
                            Completed = false,
                            Name = "Light Squat",
                            SetId = 5
                        },
                        new
                        {
                            Id = 6,
                            Completed = false,
                            Name = "Heavy Squat",
                            SetId = 6
                        },
                        new
                        {
                            Id = 7,
                            Completed = false,
                            Name = "Light Plank",
                            SetId = 7
                        },
                        new
                        {
                            Id = 8,
                            Completed = false,
                            Name = "Heavy Plank",
                            SetId = 8
                        },
                        new
                        {
                            Id = 9,
                            Completed = false,
                            Name = "Light Lunge",
                            SetId = 9
                        },
                        new
                        {
                            Id = 10,
                            Completed = false,
                            Name = "Heavy Lunge",
                            SetId = 10
                        });
                });

            modelBuilder.Entity("Mefit_API.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CurrentGoalId")
                        .HasColumnType("int");

                    b.Property<int?>("GoalId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoalId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("Mefit_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsAdmin")
                        .HasColumnType("int");

                    b.Property<string>("KeycloakId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProgrammeWorkout", b =>
                {
                    b.Property<int>("ProgrammesId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutsId")
                        .HasColumnType("int");

                    b.HasKey("ProgrammesId", "WorkoutsId");

                    b.HasIndex("WorkoutsId");

                    b.ToTable("ProgrammeWorkout");

                    b.HasData(
                        new
                        {
                            ProgrammesId = 1,
                            WorkoutsId = 1
                        },
                        new
                        {
                            ProgrammesId = 1,
                            WorkoutsId = 3
                        },
                        new
                        {
                            ProgrammesId = 1,
                            WorkoutsId = 5
                        },
                        new
                        {
                            ProgrammesId = 1,
                            WorkoutsId = 7
                        },
                        new
                        {
                            ProgrammesId = 1,
                            WorkoutsId = 9
                        },
                        new
                        {
                            ProgrammesId = 2,
                            WorkoutsId = 1
                        },
                        new
                        {
                            ProgrammesId = 2,
                            WorkoutsId = 3
                        },
                        new
                        {
                            ProgrammesId = 2,
                            WorkoutsId = 5
                        },
                        new
                        {
                            ProgrammesId = 2,
                            WorkoutsId = 8
                        },
                        new
                        {
                            ProgrammesId = 2,
                            WorkoutsId = 10
                        },
                        new
                        {
                            ProgrammesId = 3,
                            WorkoutsId = 2
                        },
                        new
                        {
                            ProgrammesId = 3,
                            WorkoutsId = 4
                        },
                        new
                        {
                            ProgrammesId = 3,
                            WorkoutsId = 6
                        },
                        new
                        {
                            ProgrammesId = 3,
                            WorkoutsId = 8
                        },
                        new
                        {
                            ProgrammesId = 3,
                            WorkoutsId = 10
                        });
                });

            modelBuilder.Entity("GoalWorkout", b =>
                {
                    b.HasOne("Mefit_API.Models.Domain.Goal", null)
                        .WithMany()
                        .HasForeignKey("GoalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mefit_API.Models.Domain.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mefit_API.Models.Domain.Goal", b =>
                {
                    b.HasOne("Mefit_API.Models.Domain.Programme", "Programme")
                        .WithMany()
                        .HasForeignKey("ProgrammeId");

                    b.Navigation("Programme");
                });

            modelBuilder.Entity("Mefit_API.Models.Domain.Set", b =>
                {
                    b.HasOne("Mefit_API.Models.Domain.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("Mefit_API.Models.Domain.Workout", b =>
                {
                    b.HasOne("Mefit_API.Models.Domain.Set", "Set")
                        .WithMany()
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Set");
                });

            modelBuilder.Entity("Mefit_API.Models.Profile", b =>
                {
                    b.HasOne("Mefit_API.Models.Domain.Goal", "Goal")
                        .WithMany()
                        .HasForeignKey("GoalId");

                    b.HasOne("Mefit_API.Models.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Mefit_API.Models.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProgrammeWorkout", b =>
                {
                    b.HasOne("Mefit_API.Models.Domain.Programme", null)
                        .WithMany()
                        .HasForeignKey("ProgrammesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mefit_API.Models.Domain.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mefit_API.Models.User", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
