using System;
namespace MvvmCrossScaffold001.Core.Models
{
    public class ChinookModel
    {
        public ChinookModel()
        {
        }
    }

    public class albums
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
    }

    public class artists
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }

    public class media_types
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }
    }

    public class genres
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
    }

    public class playlists
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }

    }

    public class playlist_track
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
    }

    public class tracks
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public double UnitPrice { get; set; }
    }

    public class invoices
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingAdress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public double Total { get; set; }
    }

    public class invoice_items
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }

    public class customers
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int SupportRepId { get; set; }
    }

    public class employees
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int ReportsTo { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int SupportRepId { get; set; }
    }
}
