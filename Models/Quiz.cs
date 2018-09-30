using System;

namespace tutorfy_backend.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public bool IsStudent { get; set; }
        public bool IsTutor { get; set; }
        public int AnswerOne { get; set; }
        public int AnswerTwo { get; set; }
        public int AnswerThree { get; set; }
        public int AnswerFour { get; set; }
        public int AnswerFive { get; set; }
        public bool isCompleted { get; set; }
    }
}