using MovieSytemManageMent.Model;

namespace MovieSytemManageMent.Strategies
{
    // ── STRATEGY PATTERN ─────────────────────────────────────────────────
    // Each search strategy is swappable. The form doesn't care HOW
    // the search works — it just calls Execute(keyword).

    // ── Interface ────────────────────────────────────────────────────────
    public interface ISearchStrategy
    {
        List<Movie> Execute(List<Movie> movies, string keyword);
    }

    // ── Search by Title ──────────────────────────────────────────────────
    public class SearchByTitle : ISearchStrategy
    {
        public List<Movie> Execute(List<Movie> movies, string keyword)
        {
            return movies
                .Where(m => m.Title.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }
    }

    // ── Search by Genre ──────────────────────────────────────────────────
    public class SearchByGenre : ISearchStrategy
    {
        public List<Movie> Execute(List<Movie> movies, string keyword)
        {
            return movies
                .Where(m => m.Genre.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }
    }

    // ── Search by Year ───────────────────────────────────────────────────
    public class SearchByYear : ISearchStrategy
    {
        public List<Movie> Execute(List<Movie> movies, string keyword)
        {
            if (int.TryParse(keyword, out int year))
                return movies.Where(m => m.Year == year).ToList();
            return new List<Movie>();
        }
    }

    // ── Search by Director ───────────────────────────────────────────────
    public class SearchByDirector : ISearchStrategy
    {
        public List<Movie> Execute(List<Movie> movies, string keyword)
        {
            return movies
                .Where(m => m.Director.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }
    }

    // ── Context: used in forms ───────────────────────────────────────────
    // Usage:
    //   var searcher = new MovieSearcher(new SearchByTitle());
    //   var results  = searcher.Search(allMovies, "inception");
    public class MovieSearcher
    {
        private ISearchStrategy _strategy;

        public MovieSearcher(ISearchStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(ISearchStrategy strategy)
        {
            _strategy = strategy;
        }

        public List<Movie> Search(List<Movie> movies, string keyword)
        {
            return _strategy.Execute(movies, keyword);
        }
    }
}