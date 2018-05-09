using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTest.Interface
{
    //Dependency ile android ios veritabanları konfigürasyonu yapıldı.
    public interface ISQLite
    {
        SQLiteConnection Connection();
    }
}
