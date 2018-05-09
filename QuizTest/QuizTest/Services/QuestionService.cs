using QuizTest.Data;
using QuizTest.Models;
using QuizTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizTest.Services
{
    //Soruların veritabanı işlemi için yardımcı sınıf
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
                var id = _dataContext.GetAll().Last().ID;
                vm.AnswerList.ForEach(i => { i.QuestionID = id; });
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
                return tata[random.Next(0, 14)];
            }
            catch
            {
                return new Question();
            }
        }

        internal void DeleteAll()
        {
            foreach (var item in _dataContext.GetAll())
            {
                _dataContext.Delete(item);
            }
        }
    }
}
