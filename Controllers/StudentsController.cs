using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tutorfy_backend.Models;

namespace tutorfy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private TutorfyDatabaseContext db { get; set; }
        public StudentsController(TutorfyDatabaseContext _db)
        {
            this.db = _db;
        }

        public class ResponseObject
        {
            public bool WasSuccessful { get; set; }
            public object Results { get; set; }
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<ResponseObject> GetStudents()
        {
            var _students = this.db.Students;

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _students
            };

            return _rv;
        }

        [HttpGet]
        [Route("one")]
        public ActionResult<ResponseObject> GetStudent()
        {
            var _userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            var _student = this.db.Students.FirstOrDefault(f => f.User.AuthServiceId == _userId);

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _student
            };

            return _rv;
        }
    }
}