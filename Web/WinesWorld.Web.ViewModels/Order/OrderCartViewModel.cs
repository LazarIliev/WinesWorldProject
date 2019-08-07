using System;
using System.Collections.Generic;
using System.Text;

namespace WinesWorld.Web.ViewModels.Order
{
    public class OrderCartViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public byte[] Picture { get; set; }

        public int Quantity { get; set; }
    }
}
