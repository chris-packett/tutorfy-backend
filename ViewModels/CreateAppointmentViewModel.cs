using System;

namespace tutorfy_backend.ViewModels
{
    public class CreateAppointmentViewModel
    {
        public DateTime StartTime { get; set; }
        public double AppointmentLength { get; set; }
        public string Location { get; set; }
        public int TutorId { get; set; }
    }
}