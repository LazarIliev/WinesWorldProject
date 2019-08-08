using System;
using System.Collections.Generic;
using System.Text;

namespace WinesWorld.Web.ViewModels.Receipts.Details
{
    public class ReceiptDetailsViewModel
    {
        public string Id { get; set; }

        public string Recipient { get; set; }

        public DateTime IssuedOn { get; set; }

        public List<ReceiptDetailsOrderViewModel> Orders { get; set; }

    }
}
