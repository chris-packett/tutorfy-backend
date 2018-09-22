using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tutorfy_backend.Models;

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
            var _appointments = this.db.Appointments;

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
        public ActionResult<ResponseObject> Post([FromBody] Appointment appointment)
        {
            var _appointment = new Appointment
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                IsCompleted = false,
                IsCancelled = false,
                Location = appointment.Location
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