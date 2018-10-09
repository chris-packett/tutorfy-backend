using System;

namespace tutorfy_backend.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int AnswerOne { get; set; }
        public int AnswerTwo { get; set; }
        public int AnswerThree { get; set; }
        public bool isCompleted { get; set; }
    }
}