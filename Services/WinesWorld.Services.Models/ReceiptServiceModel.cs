using System;
using System.Collections.Generic;
using System.Text;

namespace WinesWorld.Services.Models
{
    public class ReceiptServiceModel
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public List<OrderServiceModel> Orders { get; set; }

        public string RecipientId { get; set; }

        public WinesWorldUserServiceModel Recipient { get; set; }
    }
}
