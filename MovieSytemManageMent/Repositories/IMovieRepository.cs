using MovieSytemManageMent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieSytemManageMent.Repositories
{
    // ── REPOSITORY PATTERN ───────────────────────────────────────────────
    // Interface defines the contract. UI only talks to this interface,
    // never directly to MovieDataStore.
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}