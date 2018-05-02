using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTest.Interface
{
    public interface ISQLite
    {
        SQLiteConnection Connection();
    }
}
