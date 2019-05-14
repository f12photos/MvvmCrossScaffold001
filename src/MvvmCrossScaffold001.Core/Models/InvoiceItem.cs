using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossScaffold001.Core.Models
{
    public class InvoiceItem : BaseModel
    {
        //public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
