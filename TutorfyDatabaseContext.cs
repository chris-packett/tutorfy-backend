using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using tutorfy_backend.Models;

namespace tutorfy_backend
{
    public partial class TutorfyDatabaseContext : DbContext
    {
        public TutorfyDatabaseContext()
        {
        }

        public TutorfyDatabaseContext(DbContextOptions<TutorfyDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conn = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "server=localhost;database=TutorfyDatabase";
                optionsBuilder.UseNpgsql(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
