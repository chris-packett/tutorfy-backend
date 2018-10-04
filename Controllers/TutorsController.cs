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

        // [HttpGet]
        // [Route("one")]
        // public ActionResult<ResponseObject> GetTutor()
        // {
        //     var _userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

        //     var _tutor = this.db.Tutors.FirstOrDefault(f => f.Auth == _userId);

        //     var _rv = new ResponseObject()
        //     {
        //         WasSuccessful = true,
        //         Results = _tutor
        //     };

        //     return _rv;
        // }
    }
}