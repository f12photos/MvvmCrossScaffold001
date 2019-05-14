using System;
using SQLite;
using System.Linq;
using MvvmCrossScaffold001.Core.Models;

namespace MvvmCrossScaffold001.Core
{
    public interface IRepositoryService
    {
        SQLiteConnection GetConnetion();
        void CopyChinookDatabase(string idbPath);
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

        public void CopyChinookDatabase(string idbPath)
        {
            //throw new NotImplementedException();

            using (SQLiteConnection dbChinook = new SQLiteConnection(idbPath))
            {
                var query0 = dbChinook.Table<media_types>().OrderBy(x => x.MediaTypeId);

                foreach (var media in query0)
                {
                    string strName = media.Name;

                    Console.WriteLine("Media : " + media.Name);
                    var m = _sqliteConn.Table<MediaType>().FirstOrDefault(x => x.Name == strName);
                    if(null == m)
                    {
                        MediaType mediaType = new MediaType
                        {
                            Name = strName
                        };
                        _sqliteConn.Insert(mediaType);
                    }
                }

                var query1 = dbChinook.Table<genres>().OrderBy(x => x.GenreId);

                foreach (var genre in query1)
                {
                    string strName = genre.Name;

                    Console.WriteLine("Genre : " + strName);
                    var m = _sqliteConn.Table<Genre>().FirstOrDefault(x => x.Name == strName);
                    if (null == m)
                    {
                        Genre g = new Genre
                        {
                            Name = strName
                        };
                        _sqliteConn.Insert(g);
                    }
                }
            }

        }

    }
}
