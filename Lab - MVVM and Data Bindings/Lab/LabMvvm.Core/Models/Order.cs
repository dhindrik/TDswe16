using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMvvm.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Customer { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.InProgress;
        public string OrderText { get; set; }
    }
  
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public enum OrderStatus
    {
        InProgress = 0,
        Ordered = 1,
        Shipped = 2
    }
}
