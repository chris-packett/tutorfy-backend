using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tutorfy_backend.Models;
using tutorfy_backend.ViewModels;

namespace tutorfy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private TutorfyDatabaseContext db { get; set; }
        public AppointmentsController()
        {
            this.db = new TutorfyDatabaseContext();
        }

        public class ResponseObject
        {
            public bool WasSuccessful { get; set; }
            public object Results { get; set; }
        }

        //GET api/appointments
        [HttpGet]
        public ActionResult<ResponseObject> Get()
        {
            var _appointments = this.db.Appointments.OrderBy(o => o.StartTime);

            var _rv = new ResponseObject
            {
                WasSuccessful = true,
                Results = _appointments
            };
            
            return _rv;
        }

        //POST api/appointments/add
        [HttpPost]
        [Route("add")]
        public ActionResult<ResponseObject> Post([FromBody] CreateAppointmentViewModel vm)
        {
            var _appointment = new Appointment
            {
                StartTime = vm.StartTime,
                EndTime = vm.StartTime.AddHours(vm.AppointmentLength),
                IsCompleted = false,
                IsCancelled = false,
                Location = vm.Location,
                StudentId = 1,
                TutorId = 2
            }; 

            this.db.Appointments.Add(_appointment);

            this.db.SaveChanges();

            var _rv = new ResponseObject 
            {
                WasSuccessful = true,
                Results = _appointment
            };
            
            return _rv;
        }
    }
}