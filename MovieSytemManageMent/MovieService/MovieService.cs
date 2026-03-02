//using MovieSytemManageMent.Model;
//using MovieSytemManageMent.SystemData;
//using System.Collections.Generic;
//using System.Linq;

//namespace MovieManagementSystem.Services
//{
//    public class MovieService
//    {
//        private readonly SystemData _data;

//        public MovieService()
//        {
//            _data = SystemData.Instance;
//        }

//        // CREATE
//        public void AddMovie(Movie movie)
//        {
//            _data.Movies.Add(movie);
//        }

//        // READ (Get all)
//        public List<Movie> GetAllMovies()
//        {
//            return _data.Movies;
//        }

//        // UPDATE
//        public bool UpdateMovie(Movie updatedMovie)
//        {
//            var movie = _data.Movies.FirstOrDefault(m => m.Id == updatedMovie.Id);
//            if (movie == null) return false;

//            movie.Title = updatedMovie.Title;
//            movie.Genre = updatedMovie.Genre;
//            movie.Price = updatedMovie.Price;
//            movie.DurationMinutes = updatedMovie.DurationMinutes;
//            return true;
//        }

//        // DELETE
//        public bool DeleteMovie(int movieId)
//        {
//            var movie = _data.Movies.FirstOrDefault(m => m.Id == movieId);
//            if (movie == null) return false;

//            _data.Movies.Remove(movie);
//            return true;
//        }

//        // SEARCH
//        public List<Movie> SearchMovies(string keyword)
//        {
//            if (string.IsNullOrWhiteSpace(keyword))
//                return _data.Movies;

//            keyword = keyword.ToLower();

//            return _data.Movies
//                .Where(m => m.Title.ToLower().Contains(keyword)
//                         || m.Genre.ToLower().Contains(keyword))
//                .ToList();
//        }
//    }
//}