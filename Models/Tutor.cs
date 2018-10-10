using System;

namespace tutorfy_backend.Models
{
    public class Tutor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal HourlyRate { get; set; }
        public string ZipCode { get; set; }
        public bool IsActivated { get; set; }
        public bool IsProfileCompleted { get; set; }
        public string PictureURL { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int QuizId { get; set; } = 2;
        public Quiz Quiz { get; set; }
    }
}