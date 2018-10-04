using System;

namespace tutorfy_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string AuthServiceId { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public bool IsActivated { get; set; } = true;
        public bool IsProfileCompleted { get; set; }
        public bool IsTutor { get; set; }
        public bool IsStudent { get; set; }
    }
}