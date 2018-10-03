using System;

namespace tutorfy_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string AuthServiceId { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public bool isActivated { get; set; }
        public bool isProfileCompleted { get; set; }
        public bool isTutor { get; set; }
        public bool isStudent { get; set; }
    }
}