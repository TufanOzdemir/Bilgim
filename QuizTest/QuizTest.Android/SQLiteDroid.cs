using System;
using SQLite.Net;
using QuizTest.Interface;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(QuizTest.Droid.SQLiteDroid))]
namespace QuizTest.Droid
{
    public class SQLiteDroid : ISQLite
    {
        public SQLiteConnection Connection()
        {
            var sqliteFilename = "mydb1.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            Console.WriteLine(path);
            if (!File.Exists(path)) File.Create(path);
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLiteConnection(plat, path);
            // Return the database connection 
            return conn;
        }
    }
}