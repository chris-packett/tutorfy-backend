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
    public class UsersController : ControllerBase
    {
        private TutorfyDatabaseContext db { get; set; }
        public UsersController(TutorfyDatabaseContext _db)
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
        public ActionResult<ResponseObject> GetUsers()
        {
            var _users = this.db.Users;

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _users
            };
            
            return _rv;
        }

        [HttpGet]
        [Route("one")]
        public ActionResult<ResponseObject> GetUser()
        {
            var _userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            var _user = this.db.Users.FirstOrDefault(f => f.AuthServiceId == _userId);

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _user
            };

            return _rv;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<ResponseObject> Post([FromBody] User user)
        {
            var _userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            var _existedUser = this.db.Users.FirstOrDefault(f => f.AuthServiceId == _userId);

            var _rv = new ResponseObject();

            if (_existedUser == null)
            {
                var _user = new User()
                {
                    AuthServiceId = _userId,
                    Name = user.Name,
                    ZipCode = user.ZipCode,
                    IsStudent = user.IsStudent,
                    IsTutor = user.IsTutor
                };

                this.db.Users.Add(_user);

                this.db.SaveChanges();

                _rv.WasSuccessful = true;
                _rv.Results = _user;
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