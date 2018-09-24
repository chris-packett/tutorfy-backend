
using System;

namespace tutorfy_backend.ViewModels
{
    public class CreateAppointmentViewModel
    {
        public DateTime StartTime { get; set; }
        public int AppointmentLength { get; set; }
        public string Location { get; set; }
    }
}