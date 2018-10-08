using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tutorfy_backend.Models;
using tutorfy_backend.ViewModels;

namespace tutorfy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private TutorfyDatabaseContext db { get; set; }
        public AppointmentsController(TutorfyDatabaseContext _db)
        {
            this.db = _db;
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
            var _userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            var _user = this.db.Users.FirstOrDefault(f => f.AuthServiceId == _userId);

            var _student = this.db.Students.FirstOrDefault(f => f.UserId == _user.Id);

            var _appointments = this.db.Appointments.Where(w => w.StudentId == _student.Id).OrderBy(o => o.StartTime);

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
            var _userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            var _user = this.db.Users.FirstOrDefault(f => f.AuthServiceId == _userId);

            var _student = this.db.Students.FirstOrDefault(f => f.UserId == _user.Id);

            var _appointment = new Appointment
            {
                StartTime = vm.StartTime,
                EndTime = vm.StartTime.AddHours(vm.AppointmentLength),
                IsCompleted = false,
                IsCancelled = false,
                Location = vm.Location,
                StudentId = _student.Id,
                TutorId = vm.TutorId
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