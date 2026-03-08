using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSytemManageMent.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }

        // NEW FIELDS for Detailed View
        public string Cast { get; set; }        // e.g., "Christian Bale, Heath Ledger"
        public string Duration { get; set; }    // e.g., "2h 32m"
        public string Language { get; set; }    // e.g., "English"
        public DateTime ReleaseDate { get; set; }
    }
}

