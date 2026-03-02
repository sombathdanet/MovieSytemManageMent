// ============================================================
// FILE: Repositories/IBookingRepository.cs
// PURPOSE: Repository Pattern — contract for booking data access
// ============================================================

using MovieSytemManageMent.Model;

namespace MovieSytemManageMent.Repositories.BookingRepository
{
    public interface IBookingRepository
    {
        List<Booking> GetAll();
        List<Booking> GetByMovieId(int movieId);
        Booking GetById(int id);
        void Add(Booking booking);
        void Update(Booking booking);
        void Delete(int id);
    }
}