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
    public class QuizzesController : ControllerBase
    {
        private TutorfyDatabaseContext db { get; set; }
        public QuizzesController(TutorfyDatabaseContext _db)
        {
            this.db = _db;
        }

        public class ResponseObject
        {
            public bool WasSuccessful { get; set; }
            public object Results { get; set; }
        }

        //GET api/quizzes
        [HttpGet]
        public ActionResult<ResponseObject> Get()
        {
            var _quizzes = this.db.Quizzes;

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _quizzes
            };

            return _rv;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<ResponseObject> Post([FromBody] Quiz quiz)
        {
            var _quiz = new Quiz()
            {
                AnswerOne = quiz.AnswerOne,
                AnswerTwo = quiz.AnswerTwo,
                AnswerThree = quiz.AnswerThree, 
                isCompleted = true
            };

            this.db.Quizzes.Add(_quiz);

            this.db.SaveChanges();

            var _rv = new ResponseObject()
            {
                WasSuccessful = true,
                Results = _quiz
            };

            return _rv;
        }
    }
}