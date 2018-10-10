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
        [Route("matched")]
        public ActionResult<ResponseObject> GetTutorMatchesForStudent()
        {
            //get _userId of who is requesting (student)
            var _userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            //get _student based on f.User.AuthServiceId == _userId
            var _student = this.db.Students.FirstOrDefault(f => f.User.AuthServiceId == _userId);
            //get _studentAnswerOne based on _student.Quiz.AnswerOne, get _studentAnswerTwo, get _studentAnswerThree
            var _studentQuiz = this.db.Quizzes.FirstOrDefault(f => f.Id == _student.QuizId);

            var _studentAnswerOne = _studentQuiz.AnswerOne;
            var _studentAnswerTwo = _studentQuiz.AnswerTwo;
            var _studentAnswerThree = _studentQuiz.AnswerThree;

            var _tutors = this.db.Tutors.Where(w => w.IsProfileCompleted == true).ToList();

            var _tutorsWithScores = _tutors.Select(_tutor => {
                var _tutorQuiz = this.db.Quizzes.FirstOrDefault(f => f.Id == _tutor.QuizId);

                var _score = 0;

                if (_tutorQuiz.AnswerOne == _studentAnswerOne)
                {
                    _score++;
                }

                if (_tutorQuiz.AnswerTwo == _studentAnswerTwo)
                {
                    _score++;
                }

                if (_tutorQuiz.AnswerThree == _studentAnswerThree)
                {
                    _score++;
                }

                var _tutorWithScore = new {
                    tutor = _tutor,
                    score = _score
                };

                return _tutorWithScore;
            });

            var _tutorsByRank = _tutorsWithScores.OrderBy(o => o.score);

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _tutorsByRank
                // Results = _studentAnswerOne
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

        [HttpGet]
        [Route("profile_complete")]
        public ActionResult<ResponseObject> GetTutorProfileCompletion()
        {
            var _userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            var _tutor = this.db.Tutors.FirstOrDefault(f => f.User.AuthServiceId == _userId);

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _tutor.IsProfileCompleted
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
                    PictureURL = tutor.PictureURL,
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

        //PATCH api/tutors/quiz/add/{quizId}
        [HttpPatch]
        [Route("quiz/add/{quizId}")]
        public ActionResult<ResponseObject> Patch(int quizId)
        {
            var _userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            var _user = this.db.Users.FirstOrDefault(f => f.AuthServiceId == _userId);

            var _tutor = this.db.Tutors.FirstOrDefault(f => f.UserId == _user.Id);

            _tutor.QuizId = quizId;

            _tutor.IsProfileCompleted = true;

            this.db.SaveChanges();

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _tutor
            };

            return _rv;
        }
    }
}