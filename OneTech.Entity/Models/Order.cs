using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public EnumOrderState OrderState { get; set; }
        public List<OrderItem> OderItems { get; set; }
    }
    public enum EnumOrderState
    {
        waiting = 0,
        unpaid = 1,
        completed = 2,
    }
}
