using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vamia.Models
{
    public class OrderViewModel
    {
        public UserModel User { get; set; }
        public OrderModel Order { get; set; }
        public string Reference { get; set; }
        public string Hash { get; set; }
        public string ProductId { get; set; }
        public string ItemCode { get; set; }
        public decimal Total { get;  set; }
        public string ReceiptUrl { get;  set; }
        public string MacKey { get; set; }
        public string PaymentPage { get; set; }
    }
}