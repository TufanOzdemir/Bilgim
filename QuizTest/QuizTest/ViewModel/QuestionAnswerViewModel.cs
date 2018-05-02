using QuizTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTest.ViewModel
{
    public class QuestionAnswerViewModel
    {
        public QuestionAnswerViewModel()
        {
            AnswerList = new List<Answer>();
        }
        public Question Question { get; set; }
        public List<Answer> AnswerList { get; set; }
    }
}
