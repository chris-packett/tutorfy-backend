using System;

namespace tutorfy_backend.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public bool IsActivated { get; set; }
        public bool IsProfileCompleted { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int QuizId { get; set; } = 2;
        public Quiz Quiz { get; set; }
    }
}