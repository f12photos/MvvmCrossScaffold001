using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            using (SQLiteConnection sqliteconn = new SQLiteConnection("chinook.db"))
            {

            }
        }

        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");

            // Open the connection:
            try
            {
                sqlite_conn.();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }
    }
}
