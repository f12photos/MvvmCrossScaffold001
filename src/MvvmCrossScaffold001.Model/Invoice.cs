﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossScaffold001.Model
{
    public class Invoice : BaseClass
    {
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string City { get; set; }
    }
}
