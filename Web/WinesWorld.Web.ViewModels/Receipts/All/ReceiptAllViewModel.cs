using System;
using System.Collections.Generic;
using System.Text;

namespace WinesWorld.Web.ViewModels.Receipts.All
{
    public class ReceiptAllViewModel
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public decimal Total { get; set; }

        public int Wines { get; set; }
    }
}
