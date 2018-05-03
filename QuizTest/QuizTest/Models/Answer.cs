using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTest.Models
{
    public class Answer
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull]
        public string Description { get; set; }

        [NotNull]
        public bool IsCorrect { get; set; }

        [NotNull]
        public int QuestionID { get; set; }
    }
}
