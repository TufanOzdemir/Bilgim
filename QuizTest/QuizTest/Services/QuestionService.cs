using QuizTest.Data;
using QuizTest.Models;
using QuizTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizTest.Services
{
    public class QuestionService
    {
        DataContext<Question> _dataContext;
        AnswerService aws;

        public QuestionService()
        {
            _dataContext = new DataContext<Question>();
            aws = new AnswerService();
        }

        public void Create(QuestionAnswerViewModel vm)
        {
            try
            {
                _dataContext.Save(vm.Question);
                aws.CreateList(vm.AnswerList);
            }
            catch (Exception ex)
            {

            }
        }

        public List<Question> GetAll()
        {
            List<Question> result;
            try
            {
                result = _dataContext.GetAll();
            }
            catch (Exception ex)
            {
                result = new List<Question>();
            }
            return result;
        }

        public Question GetRandomQuestion(QuestionDifficult difficulty)
        {
            try
            {
                Random random = new Random();
                var k = GetAll();
                var tata = k.Where(i => i.Difficult == difficulty).ToList();
                return tata[random.Next(0, 4)];
            }
            catch
            {
                return new Question();
            }
        }
       
    }
}
