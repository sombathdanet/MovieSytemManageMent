using MovieSytemManageMent.Data;
using MovieSytemManageMent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieSytemManageMent.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDataStore _store = MovieDataStore.Instance;

        public List<Movie> GetAll() => _store.Movies;
        public Movie GetById(int id) => _store.Movies.Find(m => m.Id == id);
        public void Add(Movie movie) => _store.AddMovie(movie);
        public void Update(Movie movie) => _store.UpdateMovie(movie);
        public void Delete(int id) => _store.DeleteMovie(id);
    }
}