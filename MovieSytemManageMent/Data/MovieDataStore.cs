using MovieSytemManageMent.Model;
using System;
using System.Collections.Generic;

namespace MovieSytemManageMent.Data
{
    // ── SINGLETON PATTERN ────────────────────────────────────────────────
    // One shared instance holds all dummy data across the entire app.
    // Access it anywhere with: MovieDataStore.Instance
    public class MovieDataStore
    {
        // ── Singleton instance ───────────────────────────────────────────
        private static MovieDataStore _instance;
        public static MovieDataStore Instance => _instance ?? (_instance = new MovieDataStore());

        // ── OBSERVER PATTERN ─────────────────────────────────────────────
        // Any form can subscribe to these events and auto-refresh when data changes.
        public event EventHandler MoviesChanged;
        public event EventHandler GenresChanged;
        public event EventHandler ActorsChanged;

        // ── Data Lists ───────────────────────────────────────────────────
        public List<Movie> Movies { get; private set; }
        public List<Genre> Genres { get; private set; }
        public List<Actor> Actors { get; private set; }

        // ── Private constructor: loads dummy data on first access ─────────
        private MovieDataStore()
        {
            SeedGenres();
            SeedActors();
            SeedMovies();
        }

        // ════════════════════════════════════════════════════════════════
        //  SEED DATA
        // ════════════════════════════════════════════════════════════════
        private void SeedGenres()
        {
            Genres = new List<Genre>
            {
                new Genre { Id = 1, Name = "Action"      },
                new Genre { Id = 2, Name = "Drama"       },
                new Genre { Id = 3, Name = "Comedy"      },
                new Genre { Id = 4, Name = "Sci-Fi"      },
                new Genre { Id = 5, Name = "Horror"      },
                new Genre { Id = 6, Name = "Romance"     },
                new Genre { Id = 7, Name = "Thriller"    },
                new Genre { Id = 8, Name = "Animation"   },
            };
        }

        private void SeedActors()
        {
            Actors = new List<Actor>
            {
                new Actor { Id = 1, FullName = "Tom Hanks",        Nationality = "American", BirthYear = 1956 },
                new Actor { Id = 2, FullName = "Meryl Streep",     Nationality = "American", BirthYear = 1949 },
                new Actor { Id = 3, FullName = "Leonardo DiCaprio",Nationality = "American", BirthYear = 1974 },
                new Actor { Id = 4, FullName = "Scarlett Johansson",Nationality = "American",BirthYear = 1984 },
                new Actor { Id = 5, FullName = "Cate Blanchett",   Nationality = "Australian",BirthYear = 1969},
                new Actor { Id = 6, FullName = "Morgan Freeman",   Nationality = "American", BirthYear = 1937 },
                new Actor { Id = 7, FullName = "Natalie Portman",  Nationality = "Israeli",  BirthYear = 1981 },
                new Actor { Id = 8, FullName = "Robert Downey Jr.",Nationality = "American", BirthYear = 1965 },
            };
        }
        private void SeedMovies()
        {
            string baseUrl = "https://picsum.photos/seed/";
            string size = "/300/450";

            Movies = new List<Movie>
    {
        new Movie {
            Id=1, Title="The Dark Knight", Genre="Action", Year=2008, Rating=9.0,
            Director="Christopher Nolan",
            Description="Batman faces the Joker, a criminal mastermind who wants to plunge Gotham City into anarchy.",
            PosterUrl=$"{baseUrl}darkknight{size}",
            Cast="Christian Bale, Heath Ledger, Aaron Eckhart",
            Duration="2h 32m",
            Language="English",
            ReleaseDate=new DateTime(2008,7,18)
        },
        new Movie {
            Id=2, Title="Forrest Gump", Genre="Drama", Year=1994, Rating=8.8,
            Director="Robert Zemeckis",
            Description="A kind-hearted man with a low IQ experiences major historical events in America.",
            PosterUrl=$"{baseUrl}forrestgump{size}",
            Cast="Tom Hanks, Robin Wright",
            Duration="2h 22m",
            Language="English",
            ReleaseDate=new DateTime(1994,7,6)
        },
        new Movie {
            Id=3, Title="Inception", Genre="Sci-Fi", Year=2010, Rating=8.8,
            Director="Christopher Nolan",
            Description="A skilled thief enters dreams to steal secrets and plant ideas.",
            PosterUrl=$"{baseUrl}inception{size}",
            Cast="Leonardo DiCaprio, Joseph Gordon-Levitt",
            Duration="2h 28m",
            Language="English",
            ReleaseDate=new DateTime(2010,7,16)
        },
        new Movie {
            Id=4, Title="The Shawshank Redemption", Genre="Drama", Year=1994, Rating=9.3,
            Director="Frank Darabont",
            Description="Two imprisoned men bond over years, finding hope and redemption.",
            PosterUrl=$"{baseUrl}shawshank{size}",
            Cast="Tim Robbins, Morgan Freeman",
            Duration="2h 22m",
            Language="English",
            ReleaseDate=new DateTime(1994,9,23)
        },
        new Movie {
            Id=5, Title="Interstellar", Genre="Sci-Fi", Year=2014, Rating=8.6,
            Director="Christopher Nolan",
            Description="Explorers travel through a wormhole in space to ensure humanity’s survival.",
            PosterUrl=$"{baseUrl}interstellar{size}",
            Cast="Matthew McConaughey, Anne Hathaway",
            Duration="2h 49m",
            Language="English",
            ReleaseDate=new DateTime(2014,11,7)
        },
        new Movie {
            Id=6, Title="The Avengers", Genre="Action", Year=2012, Rating=8.0,
            Director="Joss Whedon",
            Description="Earth's mightiest heroes unite to stop a global alien invasion.",
            PosterUrl=$"{baseUrl}avengers{size}",
            Cast="Robert Downey Jr., Chris Evans, Scarlett Johansson",
            Duration="2h 23m",
            Language="English",
            ReleaseDate=new DateTime(2012,5,4)
        },
        new Movie {
            Id=7, Title="The Mask", Genre="Comedy", Year=1994, Rating=6.9,
            Director="Chuck Russell",
            Description="A shy banker discovers a magical mask that transforms him into a wild trickster.",
            PosterUrl=$"{baseUrl}mask{size}",
            Cast="Jim Carrey, Cameron Diaz",
            Duration="1h 41m",
            Language="English",
            ReleaseDate=new DateTime(1994,7,29)
        },
        new Movie {
            Id=8, Title="Get Out", Genre="Horror", Year=2017, Rating=7.7,
            Director="Jordan Peele",
            Description="A young man uncovers disturbing secrets when visiting his girlfriend’s family.",
            PosterUrl=$"{baseUrl}getout{size}",
            Cast="Daniel Kaluuya, Allison Williams",
            Duration="1h 44m",
            Language="English",
            ReleaseDate=new DateTime(2017,2,24)
        },
        new Movie {
            Id=9, Title="La La Land", Genre="Romance", Year=2016, Rating=8.0,
            Director="Damien Chazelle",
            Description="A jazz musician and an aspiring actress fall in love while chasing dreams.",
            PosterUrl=$"{baseUrl}lalaland{size}",
            Cast="Ryan Gosling, Emma Stone",
            Duration="2h 8m",
            Language="English",
            ReleaseDate=new DateTime(2016,12,9)
        },
        new Movie {
            Id=10, Title="Gone Girl", Genre="Thriller", Year=2014, Rating=8.1,
            Director="David Fincher",
            Description="A husband becomes the prime suspect after his wife mysteriously disappears.",
            PosterUrl=$"{baseUrl}gonegirl{size}",
            Cast="Ben Affleck, Rosamund Pike",
            Duration="2h 29m",
            Language="English",
            ReleaseDate=new DateTime(2014,10,3)
        },
        new Movie {
            Id=11, Title="Toy Story", Genre="Animation", Year=1995, Rating=8.3,
            Director="John Lasseter",
            Description="A cowboy doll feels threatened when a new spaceman toy arrives.",
            PosterUrl=$"{baseUrl}toystory{size}",
            Cast="Tom Hanks, Tim Allen",
            Duration="1h 21m",
            Language="English",
            ReleaseDate=new DateTime(1995,11,22)
        },
        new Movie {
            Id=12, Title="Iron Man", Genre="Action", Year=2008, Rating=7.9,
            Director="Jon Favreau",
            Description="A billionaire engineer builds a high-tech suit to become a hero.",
            PosterUrl=$"{baseUrl}ironman{size}",
            Cast="Robert Downey Jr., Gwyneth Paltrow",
            Duration="2h 6m",
            Language="English",
            ReleaseDate=new DateTime(2008,5,2)
        }
    };
        }

        // ════════════════════════════════════════════════════════════════
        //  MOVIE CRUD — fires MoviesChanged event after each operation
        // ════════════════════════════════════════════════════════════════
        public void AddMovie(Movie movie)
        {
            movie.Id = Movies.Count + 1;
            Movies.Add(movie);
            MoviesChanged?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateMovie(Movie updated)
        {
            var existing = Movies.Find(m => m.Id == updated.Id);
            if (existing == null) return;
            existing.Title = updated.Title;
            existing.Genre = updated.Genre;
            existing.Year = updated.Year;
            existing.Rating = updated.Rating;
            existing.Director = updated.Director;
            existing.Description = updated.Description;
            MoviesChanged?.Invoke(this, EventArgs.Empty);
        }

        public void DeleteMovie(int id)
        {
            Movies.RemoveAll(m => m.Id == id);
            MoviesChanged?.Invoke(this, EventArgs.Empty);
        }

        // ════════════════════════════════════════════════════════════════
        //  GENRE CRUD
        // ════════════════════════════════════════════════════════════════
        public void AddGenre(Genre genre)
        {
            genre.Id = Genres.Count + 1;
            Genres.Add(genre);
            GenresChanged?.Invoke(this, EventArgs.Empty);
        }

        public void DeleteGenre(int id)
        {
            Genres.RemoveAll(g => g.Id == id);
            GenresChanged?.Invoke(this, EventArgs.Empty);
        }

        // ════════════════════════════════════════════════════════════════
        //  ACTOR CRUD
        // ════════════════════════════════════════════════════════════════
        public void AddActor(Actor actor)
        {
            actor.Id = Actors.Count + 1;
            Actors.Add(actor);
            ActorsChanged?.Invoke(this, EventArgs.Empty);
        }

        public void DeleteActor(int id)
        {
            Actors.RemoveAll(a => a.Id == id);
            ActorsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}