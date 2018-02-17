using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ellen_Conversion_M_1
{
    public class Availability
    {
        public int CustomerID { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerName { get; set; }

        public int BookingID { get; set; }
        public string CustomerEmail2 { get; set; }

        public DateTime Date { get; set; }
        public int NoOfGuests { get; set; }
        public int RoomID { get; set; }

        public string RoomName { get; set; }
        public decimal RoomCost { get; set; }


    }  // end class Availability
}  // end Namespace