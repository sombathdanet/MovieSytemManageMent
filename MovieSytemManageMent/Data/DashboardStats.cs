using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ============================================================
// FILE: Models/DashboardStats.cs
// PURPOSE: Simple data model to carry dashboard summary numbers
// ============================================================

namespace MovieSytemManageMent.Data
{
    public class DashboardStats
    {
        public int TotalMovies { get; set; }
        public int NowShowing { get; set; }
        public int ComingSoon { get; set; }
        public int Archived { get; set; }
        public double AverageRating { get; set; }
        public string TopRatedMovie { get; set; }
        public string TopGenre { get; set; }
    }
}