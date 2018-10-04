﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tutorfy_backend;

namespace tutorfybackend.Migrations
{
    [DbContext(typeof(TutorfyDatabaseContext))]
    [Migration("20181004161738_AddedUserForeignKeysToTutorAndStudentTables")]
    partial class AddedUserForeignKeysToTutorAndStudentTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("tutorfy_backend.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("IsCancelled");

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("Location");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("StudentId");

                    b.Property<int>("TutorId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TutorId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("tutorfy_backend.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnswerFive");

                    b.Property<int>("AnswerFour");

                    b.Property<int>("AnswerOne");

                    b.Property<int>("AnswerThree");

                    b.Property<int>("AnswerTwo");

                    b.Property<bool>("IsStudent");

                    b.Property<bool>("IsTutor");

                    b.Property<bool>("isCompleted");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("tutorfy_backend.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActivated");

                    b.Property<bool>("IsProfileCompleted");

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("tutorfy_backend.Models.Tutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("HourlyRate");

                    b.Property<bool>("IsActivated");

                    b.Property<bool>("IsProfileCompleted");

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("tutorfy_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthServiceId");

                    b.Property<bool>("IsActivated");

                    b.Property<bool>("IsProfileCompleted");

                    b.Property<bool>("IsStudent");

                    b.Property<bool>("IsTutor");

                    b.Property<string>("Name");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("tutorfy_backend.Models.Appointment", b =>
                {
                    b.HasOne("tutorfy_backend.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tutorfy_backend.Models.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("tutorfy_backend.Models.Student", b =>
                {
                    b.HasOne("tutorfy_backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("tutorfy_backend.Models.Tutor", b =>
                {
                    b.HasOne("tutorfy_backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}