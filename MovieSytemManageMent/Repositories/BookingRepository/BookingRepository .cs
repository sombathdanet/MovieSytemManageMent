using MovieSytemManageMent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieSytemManageMent.Repositories.BookingRepository
{
    public class BookingRepository : IBookingRepository
    {
        // ── Singleton ─────────────────────────────────────────────────────
        private static BookingRepository _instance;
        public  static BookingRepository Instance
            => _instance ?? (_instance = new BookingRepository());

        private BookingRepository() { SeedData(); }

        // ── In-memory store ───────────────────────────────────────────────
        private readonly List<Booking> _bookings = new List<Booking>();
        private int _nextId = 1;

        // ── Seed dummy data (MovieId matches your seeded movies) ──────────
        private void SeedData()
        {
            var today = DateTime.Today;

            _bookings.AddRange(new[]
            {
                // Movie 1
                new Booking { Id=_nextId++, MovieId=1, CustomerName="Alice Johnson",  SeatNumber="A1",  BookingDate=today.AddDays(-5), TicketPrice=12.50, Status="Confirmed"  },
                new Booking { Id=_nextId++, MovieId=1, CustomerName="Bob Smith",      SeatNumber="A2",  BookingDate=today.AddDays(-5), TicketPrice=12.50, Status="Confirmed"  },
                new Booking { Id=_nextId++, MovieId=1, CustomerName="Carol White",    SeatNumber="B3",  BookingDate=today.AddDays(-3), TicketPrice=12.50, Status="Pending"    },

                // Movie 2
                new Booking { Id=_nextId++, MovieId=2, CustomerName="David Lee",      SeatNumber="C1",  BookingDate=today.AddDays(-2), TicketPrice=15.00, Status="Confirmed"  },
                new Booking { Id=_nextId++, MovieId=2, CustomerName="Eva Martinez",   SeatNumber="C2",  BookingDate=today.AddDays(-2), TicketPrice=15.00, Status="Cancelled"  },

                // Movie 3
                new Booking { Id=_nextId++, MovieId=3, CustomerName="Frank Brown",    SeatNumber="D4",  BookingDate=today.AddDays(-1), TicketPrice=10.00, Status="Confirmed"  },
                new Booking { Id=_nextId++, MovieId=3, CustomerName="Grace Kim",      SeatNumber="D5",  BookingDate=today,             TicketPrice=10.00, Status="Pending"    },
                new Booking { Id=_nextId++, MovieId=3, CustomerName="Henry Davis",    SeatNumber="E1",  BookingDate=today,             TicketPrice=10.00, Status="Confirmed"  },

                // Movie 4
                new Booking { Id=_nextId++, MovieId=4, CustomerName="Isla Thompson",  SeatNumber="F2",  BookingDate=today.AddDays(-4), TicketPrice=13.00, Status="Confirmed"  },
                new Booking { Id=_nextId++, MovieId=4, CustomerName="Jack Wilson",    SeatNumber="F3",  BookingDate=today.AddDays(-4), TicketPrice=13.00, Status="Pending"    },
            });
        }

        // ── CRUD ──────────────────────────────────────────────────────────
        public List<Booking> GetAll()
            => new List<Booking>(_bookings);

        public List<Booking> GetByMovieId(int movieId)
            => _bookings.Where(b => b.MovieId == movieId).ToList();

        public Booking GetById(int id)
            => _bookings.FirstOrDefault(b => b.Id == id);

        public void Add(Booking booking)
        {
            booking.Id = _nextId++;
            _bookings.Add(booking);
        }

        public void Update(Booking booking)
        {
            int i = _bookings.FindIndex(b => b.Id == booking.Id);
            if (i >= 0) _bookings[i] = booking;
        }

        public void Delete(int id)
            => _bookings.RemoveAll(b => b.Id == id);
    }
}