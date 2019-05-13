using System;
using SQLite;
using MvvmCrossScaffold001.Core.Models;

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
            _sqliteConn.CreateTable<Album>();
            _sqliteConn.CreateTable<Artist>();
            _sqliteConn.CreateTable<Customer>();
            _sqliteConn.CreateTable<Employee>();
            _sqliteConn.CreateTable<Genre>();
            _sqliteConn.CreateTable<Invoice>();
            _sqliteConn.CreateTable<InvoiceItem>();
            _sqliteConn.CreateTable<MediaType>();
            _sqliteConn.CreateTable<PlayList>();
            _sqliteConn.CreateTable<PlayListTrack>();
            _sqliteConn.CreateTable<Track>();
        }

        public SQLiteConnection GetConnetion()
        {
            return _sqliteConn;
        }
    }
}
