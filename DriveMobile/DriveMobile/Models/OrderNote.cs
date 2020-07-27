using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMobile.Models
{
    public class OrderNote
    {
        public int OrderId { get; set; }
        public string Text { get; set; }
        public bool IsForDriver { get; set; }
        public bool IsForDispatch { get; set; }
        public bool IsForBilling { get; set; }
        public bool PrintOnInvoice { get; set; }
        public int Id { get; set; }
    }
}
