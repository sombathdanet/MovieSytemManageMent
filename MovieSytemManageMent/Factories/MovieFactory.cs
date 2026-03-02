using MovieSytemManageMent.Model;

namespace MovieSytemManageMent.Factories
{
    // ── FACTORY PATTERN ──────────────────────────────────────────────────
    // Creates Movie objects cleanly. No need to do "new Movie { ... }"
    // scattered across forms. Just call MovieFactory.Create(...)
    public static class MovieFactory
    {
        public static Movie Create(string title, string genre, int year, double rating, string director, string description)
        {
            return new Movie
            {
                Title = title,
                Genre = genre,
                Year = year,
                Rating = rating,
                Director = director,
                Description = description
            };
        }
    }

    // ── Genre Factory ────────────────────────────────────────────────────
    public static class GenreFactory
    {
        public static Genre Create(string name)
        {
            return new Genre { Name = name };
        }
    }

    // ── Actor Factory ────────────────────────────────────────────────────
    public static class ActorFactory
    {
        public static Actor Create(string fullName, string nationality, int birthYear)
        {
            return new Actor
            {
                FullName = fullName,
                Nationality = nationality,
                BirthYear = birthYear
            };
        }
    }
}