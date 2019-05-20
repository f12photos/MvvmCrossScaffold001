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
                CopyMediaType(dbChinook);
                CopyGenre(dbChinook);
                CopyPlaylists(dbChinook);
                CopyPlaylistTrack(dbChinook);
                CopyTracks(dbChinook);
                CopyArtists(dbChinook);
                CopyInvoices(dbChinook);
                CopyInvoiceItems(dbChinook);
                CopyAlbums(dbChinook);
                CopyCustomers(dbChinook);
                CopyEmployees(dbChinook);
            }
        }

        private void CopyMediaType(SQLiteConnection iSrcConn)
        {
            var query = iSrcConn.Table<media_types>().OrderBy(x => x.MediaTypeId);

            foreach (var obj in query)
            {
                string strName = obj.Name;

                Console.WriteLine("Object : " + strName);
                var m = _sqliteConn.Table<MediaType>().FirstOrDefault(x => x.Name == strName);
                if (null == m)
                {
                    MediaType g = new MediaType
                    {
                        Id = obj.MediaTypeId,
                        Name = strName
                    };
                    _sqliteConn.Insert(g);
                }
            }
        }

        private void CopyGenre(SQLiteConnection iSrcConn)
        {
            var query = iSrcConn.Table<genres>().OrderBy(x => x.GenreId);

            foreach (var obj in query)
            {
                string strName = obj.Name;

                Console.WriteLine("Object : " + strName);
                var m = _sqliteConn.Table<Genre>().FirstOrDefault(x => x.Name == strName);
                if (null == m)
                {
                    Genre g = new Genre
                    {
                        Id = obj.GenreId,
                        Name = strName
                    };
                    _sqliteConn.Insert(g);
                }
            }
        }

        private void CopyPlaylists(SQLiteConnection iSrcConn)
        {
            var query = iSrcConn.Table<playlists>().OrderBy(x => x.PlaylistId);

            foreach (var obj in query)
            {
                string strName = obj.Name;

                Console.WriteLine("Object : " + strName);
                var m = _sqliteConn.Table<PlayList>().FirstOrDefault(x => x.Name == strName);
                if (null == m)
                {
                    PlayList g = new PlayList
                    {
                        Id = obj.PlaylistId,
                        Name = strName
                    };
                    _sqliteConn.Insert(g);
                }
            }
        }

        private void CopyPlaylistTrack(SQLiteConnection iSrcConn)
        {
            var query = iSrcConn.Table<playlist_track>().OrderBy(x => x.PlaylistId);

            foreach (var obj in query)
            {
                var m = _sqliteConn.Table<PlayListTrack>().FirstOrDefault(x => x.PlaylistId == obj.PlaylistId && x.TrackId == obj.TrackId);
                if (null == m)
                {
                    PlayListTrack g = new PlayListTrack
                    {
                        PlaylistId = obj.PlaylistId,
                        TrackId = obj.TrackId
                    };
                    _sqliteConn.Insert(g);
                }
            }
        }

        private void CopyTracks(SQLiteConnection iSrcConn)
        {
            var query = iSrcConn.Table<tracks>().OrderBy(x => x.TrackId);

            foreach (var obj in query)
            {
                string strName = obj.Name;

                Console.WriteLine("Object : " + strName);
                var m = _sqliteConn.Table<Track>().FirstOrDefault(x => x.Id == obj.TrackId);
                if (null == m)
                {
                    Track g = new Track
                    {
                        Id = obj.TrackId,
                        Name = obj.Name,
                        AlbumId = obj.AlbumId,
                        MediaTypeId = obj.MediaTypeId,
                        GenreId = obj.GenreId,
                        Composer = obj.Composer,
                        Milliseconds = obj.Milliseconds,
                        Bytes = obj.Bytes,
                        UnitPrice = obj.UnitPrice
                    };
                    _sqliteConn.Insert(g);
                }
            }
        }

        private void CopyArtists(SQLiteConnection iSrcConn)
        {
            var query = iSrcConn.Table<artists>().OrderBy(x => x.ArtistId);

            foreach (var obj in query)
            {
                string strName = obj.Name;

                Console.WriteLine("Object : " + strName);
                var m = _sqliteConn.Table<Artist>().FirstOrDefault(x => x.Id == obj.ArtistId);
                if (null == m)
                {
                    Artist g = new Artist
                    {
                        Id = obj.ArtistId,
                        Name = obj.Name,
                    };
                    _sqliteConn.Insert(g);
                }
            }
        }

        private void CopyInvoices(SQLiteConnection iSrcConn)
        {
            var query = iSrcConn.Table<invoices>().OrderBy(x => x.InvoiceId);

            foreach (var obj in query)
            {
                string strName = obj.InvoiceId.ToString();

                Console.WriteLine("Object : " + strName);
                var m = _sqliteConn.Table<Invoice>().FirstOrDefault(x => x.Id == obj.InvoiceId);
                if (null == m)
                {
                    Invoice g = new Invoice
                    {
                        Id = obj.InvoiceId,
                        CustomerId = obj.CustomerId,
                        InvoiceDate = obj.InvoiceDate,
                        BillingAddress = obj.BillingAdress,
                        BillingCity = obj.BillingCity,
                        BillingCountry = obj.BillingCountry,
                        BillingState = obj.BillingState,
                        BillingPostalCode = obj.BillingPostalCode,
                        Total = obj.Total
                    };
                    _sqliteConn.Insert(g);
                }
            }
        }

        private void CopyInvoiceItems(SQLiteConnection iSrcConn)
        {
            var query = iSrcConn.Table<invoice_items>().OrderBy(x => x.InvoiceItemId);

            foreach (var obj in query)
            {
                string strName = obj.InvoiceItemId.ToString();

                Console.WriteLine("Object : " + strName);
                var m = _sqliteConn.Table<InvoiceItem>().FirstOrDefault(x => x.Id == obj.InvoiceItemId);
                if (null == m)
                {
                    InvoiceItem g = new InvoiceItem
                    {
                        Id = obj.InvoiceItemId,
                        InvoiceId = obj.InvoiceId,
                        TrackId = obj.TrackId,
                        UnitPrice = obj.UnitPrice,
                        Quantity = obj.Quantity
                        
                    };
                    _sqliteConn.Insert(g);
                }
            }
        }

        private void CopyAlbums(SQLiteConnection iSrcConn)
        {
            var query = iSrcConn.Table<albums>().OrderBy(x => x.AlbumId);

            foreach (var obj in query)
            {
                string strName = obj.AlbumId.ToString();

                Console.WriteLine("Object : " + strName);
                var m = _sqliteConn.Table<Album>().FirstOrDefault(x => x.Id == obj.AlbumId);
                if (null == m)
                {
                    Album g = new Album
                    {
                        Id = obj.AlbumId,
                        Name = obj.Title,
                        ArtistId = obj.ArtistId
                    };
                    _sqliteConn.Insert(g);
                }
            }
        }

        private void CopyCustomers(SQLiteConnection iSrcConn)
        {
            var query = iSrcConn.Table<customers>().OrderBy(x => x.CustomerId);

            foreach (var obj in query)
            {
                string strName = obj.CustomerId.ToString();

                Console.WriteLine("Object : " + strName);
                var m = _sqliteConn.Table<Customer>().FirstOrDefault(x => x.Id == obj.CustomerId);
                if (null == m)
                {
                    Customer g = new Customer
                    {
                        Id = obj.CustomerId,
                        FirstName = obj.FirstName,
                        LastName = obj.LastName,
                        Company = obj.Company,
                        Address = obj.Address,
                        City = obj.City,
                        State = obj.State,
                        Country = obj.Country,
                        PostalCode = obj.PostalCode,
                        Phone = obj.Phone,
                        Fax = obj.Fax,
                        Email = obj.Email,
                        SupportRepId = obj.SupportRepId
                    };
                    _sqliteConn.Insert(g);
                }
            }
        }

        private void CopyEmployees(SQLiteConnection iSrcConn)
        {
            var query = iSrcConn.Table<employees>().OrderBy(x => x.EmployeeId);

            foreach (var obj in query)
            {
                string strName = obj.EmployeeId.ToString();

                Console.WriteLine("Object : " + strName);
                var m = _sqliteConn.Table<Employee>().FirstOrDefault(x => x.Id == obj.EmployeeId);
                if (null == m)
                {
                    Employee g = new Employee
                    {
                        Id = obj.EmployeeId,
                        FirstName = obj.FirstName,
                        LastName = obj.LastName,
                        Title = obj.Title,
                        ReportsTo = obj.ReportsTo,
                        BirthDate = obj.BirthDate,
                        HireDate = obj.HireDate,
                        Address = obj.Address,
                        City = obj.City,
                        State = obj.State,
                        Country = obj.Country,
                        PostalCode = obj.PostalCode,
                        Phone = obj.Phone,
                        Fax = obj.Fax,
                        Email = obj.Email
                    };
                    _sqliteConn.Insert(g);
                }
            }
        }
    }
}
