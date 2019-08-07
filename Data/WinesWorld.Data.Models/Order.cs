using System;
using System.Collections.Generic;
using System.Text;

namespace WinesWorld.Data.Models
{
    public class Order
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string WineId { get; set; }

        public Wine Product { get; set; }

        public int Quantity { get; set; }

        public string IssuerId { get; set; }

        public WinesWorldUser Issuer { get; set; }

        public int StatusId { get; set; }

        public OrderStatus Status { get; set; }
    }
}
