using System;

namespace tutorfy_backend.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public string Location { get; set; }
    }
}