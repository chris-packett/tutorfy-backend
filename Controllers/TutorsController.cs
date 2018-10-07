using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tutorfy_backend.Models;

namespace tutorfy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class TutorsController : ControllerBase
    {
        private TutorfyDatabaseContext db { get; set; }
        public TutorsController(TutorfyDatabaseContext _db)
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
        public ActionResult<ResponseObject> GetTutors()
        {
            var _tutors = this.db.Tutors;

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _tutors
            };

            return _rv;
        }

        [HttpGet]
        [Route("top/{amt}")]
        public ActionResult<ResponseObject> GetTopThreeTutors(int amt)
        {
            var _tutors = this.db.Tutors.Take(amt);

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _tutors
            };

            return _rv;
        }

        [HttpGet]
        [Route("one")]
        public ActionResult<ResponseObject> GetTutorByAuthId()
        {
            var _userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            var _tutor = this.db.Tutors.FirstOrDefault(f => f.User.AuthServiceId == _userId);

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _tutor
            };

            return _rv;
        }

        [HttpGet]
        [Route("profile/{id}")]
        public ActionResult<ResponseObject> getTutorById(int id)
        {
            var _tutor = this.db.Tutors.FirstOrDefault(f => f.Id == id);

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _tutor
            };

            return _rv;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<ResponseObject> Post([FromBody] Tutor tutor)
        {
            var _userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            var _user = this.db.Users.FirstOrDefault(f => f.AuthServiceId == _userId);

            var _existedTutor = this.db.Tutors.FirstOrDefault(f => f.User.AuthServiceId == _userId);

            var _rv = new ResponseObject();

            if (_existedTutor == null)
            {
                var _tutor = new Tutor()
                {
                    Name = tutor.Name,
                    HourlyRate = 30.00m,
                    ZipCode = tutor.ZipCode,
                    IsActivated = true,
                    IsProfileCompleted = false,
                    UserId = _user.Id
                };

                this.db.Tutors.Add(_tutor);

                this.db.SaveChanges();

                _rv.WasSuccessful = true;
                _rv.Results = _tutor;
            }
            else
            {
                _rv.WasSuccessful = true;
                _rv.Results = null;
            }

            return _rv;
        }
    }
}