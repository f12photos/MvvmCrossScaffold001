using System;
using SQLite;

namespace MvvmCrossScaffold001.Core
{
    public interface IRepositoryService
    {
        SQLiteConnection GetConnetion();
    }

    //----------------------------------------------------

    public class RepositoryService : IRepositoryService
    {
        private readonly SQLiteConnection _sqliteConn;

        public RepositoryService(string idbPath)
        {
            _sqliteConn = new SQLiteConnection(idbPath);

            // create tables here
        }

        public SQLiteConnection GetConnetion()
        {
            return _sqliteConn;
        }
    }
}
