using QuizTest.Interface;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace QuizTest.Data
{
    public class DataContext<T> where T : class
    {
        SQLiteConnection dbConn;
        public DataContext()
        {
            dbConn = DependencyService.Get<ISQLite>().Connection();
            // create the table(s)
            dbConn.CreateTable<T>();
        }
        public List<T> GetAll()
        {
            var Ttype = typeof(T).ToString();
            var splitType = Ttype.Split('.');
            return dbConn.Query<T>($"Select * From [{splitType.Last()}]");
        }
        public T GetByID(int id)
        {
            var Ttype = typeof(T).ToString();
            var splitType = Ttype.Split('.');
            return dbConn.Query<T>($"Select * From [{splitType.Last()}] Where[ID == {id}]").FirstOrDefault();
        }
        public int Save(T model)
        {
            return dbConn.Insert(model);
        }
        public int Delete(T model)
        {
            return dbConn.Delete(model);
        }
        public int Edit(T model)
        {
            return dbConn.Update(model);
        }
    }
}
