using MovieSytemManageMent.Data;
using MovieSytemManageMent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSytemManageMent.Repositories
{
    // ── Interface ────────────────────────────────────────────────────────
    public interface IGenreRepository
    {
        List<Genre> GetAll();
        void Add(Genre genre);
        void Delete(int id);
    }

    // ── Implementation ───────────────────────────────────────────────────
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieDataStore _store = MovieDataStore.Instance;

        public List<Genre> GetAll() => _store.Genres;
        public void Add(Genre genre) => _store.AddGenre(genre);
        public void Delete(int id) => _store.DeleteGenre(id);
    }
}