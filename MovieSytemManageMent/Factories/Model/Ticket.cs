using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSytemManageMent.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public User Customer { get; set; }
        public int SeatNumber { get; set; }
        public double FinalPrice { get; set; }

        public Ticket(int id, Movie movie, User customer, int seat, double price)
        {
            Id = id;
            Movie = movie;
            Customer = customer;
            SeatNumber = seat;
            FinalPrice = price;
        }
    }
}
