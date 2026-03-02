using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MovieSytemManageMent.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public int MovieId { get; set; }   // FK → Movie.Id
        public string CustomerName { get; set; }
        public string SeatNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public double TicketPrice { get; set; }
        public string Status { get; set; }   // Confirmed / Pending / Cancelled

        public override string ToString()
            => $"[{Id}] {CustomerName} — Seat {SeatNumber}";
    }
}