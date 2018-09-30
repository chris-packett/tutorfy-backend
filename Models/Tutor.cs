using System;

namespace tutorfy_backend.Models
{
    public class Tutor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HourlyRate { get; set; }
        public string ZipCode { get; set; }
        public bool IsActivated { get; set; }
        public bool IsProfileCompleted { get; set; }
    }
}