using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossScaffold001.Model
{
    public class InvoiceItem : BaseClass
    {
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public int Quantity { get; set; }
    }
}
