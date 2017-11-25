using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vamia.Infrastructure.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Customer")]
        public int UserId { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Item> Items { get; set; } = new HashSet<Item>();
        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
    }
}