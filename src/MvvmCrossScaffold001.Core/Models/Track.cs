using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossScaffold001.Core.Models
{
    public class Track : BaseModel
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }

        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public float UnitPrice {get;set;}
    }
}
