using System;
using System.Collections.Generic;
using System.Text;

namespace WinesWorld.Services.Models
{
    public class OrderServiceModel
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string WineId { get; set; }

        public WineServiceModel Wine { get; set; }

        public int Quantity { get; set; }

        public string IssuerId { get; set; }

        public WinesWorldUserServiceModel Issuer { get; set; }

        public int StatusId { get; set; }

        public OrderStatusServiceModel Status { get; set; }
    }
}
