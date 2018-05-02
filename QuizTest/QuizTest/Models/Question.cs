using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTest.Models
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull]
        public string Description { get; set; }

        [NotNull]
        public QuestionDifficult Difficult { get; set; }

        [NotNull]
        public int Time { get; set; }
    }

    public enum QuestionDifficult
    {
        Easy,
        Medium,
        Hard
    }
}
