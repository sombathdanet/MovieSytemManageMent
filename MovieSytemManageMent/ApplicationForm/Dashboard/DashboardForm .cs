// ============================================================
// FILE: ApplicationForm/Dashboard/DashboardForm.cs
// PURPOSE: Full dashboard with embedded page navigation
//          Designer file does NOT need any changes
// ============================================================
using MovieSytemManageMent.ApplicationForm.AdminForm;
using MovieSytemManageMent.Controls;
using MovieSytemManageMent.Data;
using MovieSytemManageMent.Model;
using MovieSytemManageMent.Repositories;
using MovieSytemManageMent.Repositories.BookingRepository;
using MovieSytemManageMent.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MovieSytemManageMent.ApplicationForm.Dashboard
{
    public partial class DashboardForm : Form
    {
        // ── Repositories ──────────────────────────────────────────────────
        private readonly IMovieRepository _movieRepo;

        // ── Searcher (Strategy Pattern) ───────────────────────────────────
        private readonly MovieSearcher _searcher;

        // ── Track active nav button ───────────────────────────────────────
        private Button _activeNavBtn;

        // ── Store original dashboard controls so we can restore them ──────
        private List<Control> _dashboardControls;

        private bool _isPerformingManualUpdate = false;

        // ── Constructor ───────────────────────────────────────────────────
        public DashboardForm()
        {
            InitializeComponent();

            _movieRepo = new MovieRepository();
            _searcher = new MovieSearcher(new SearchByTitle());

            // OBSERVER: auto-refresh when data changes
            MovieDataStore.Instance.MoviesChanged += OnMoviesChanged;

            // Wire up events
            btnSearch.Click += btnSearch_Click;
            btnAddMovie.Click += btnAddMovie_Click;
            cmbSortBy.SelectedIndexChanged += cmbSortBy_Changed;

            // ── Nav buttons ───────────────────────────────────────────────
            btnNavDashboard.Click += btnNavDashboard_Click;
            btnNavMovies.Click += btnNavMovies_Click;
            btnNavGenres.Click += btnNavGenres_Click;
            btnNavActors.Click += btnNavActors_Click;
            btnNavReports.Click += btnNavReports_Click;
            btnNavLogout.Click += btnNavLogout_Click;

            // Search placeholder behaviour
            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == "Search movies...")
                    txtSearch.Text = "";
            };
            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                    txtSearch.Text = "Search movies...";
            };

            // ── Save dashboard controls so we can restore them later ──────
            // Must be done AFTER InitializeComponent()
            _dashboardControls = new List<Control>
            {
                flpMovieCards,
                pnlSectionHeader,
                pnlStatRow
            };

            // ── Set Dashboard as default active nav ───────────────────────
            _activeNavBtn = btnNavDashboard;

            // ── Initial load ──────────────────────────────────────────────
            LoadStats();
            LoadMovieCards(_movieRepo.GetAll());
        }

        // ════════════════════════════════════════════════════════════════
        //  EMBED FORM — loads any Form inside pnlMain as a full page
        //  This is the key method that replaces Show() / ShowDialog()
        // ════════════════════════════════════════════════════════════════
        private void EmbedForm(Form form)
        {
            foreach (Control ctrl in pnlMain.Controls)
                if (ctrl is Form f) f.Close();
            pnlMain.Controls.Clear();

            // ✅ Hide dashboard-only top bar controls
            txtSearch.Visible = false;
            btnSearch.Visible = false;
            cmbSortBy.Visible = false;

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Visible = true;
            pnlMain.Controls.Add(form);
        }

        private void RestoreDashboard()
        {
            foreach (Control ctrl in pnlMain.Controls)
                if (ctrl is Form f) f.Close();
            pnlMain.Controls.Clear();

            // ✅ Restore dashboard-only top bar controls
            txtSearch.Visible = true;
            btnSearch.Visible = true;
            cmbSortBy.Visible = true;

            pnlMain.Controls.Add(flpMovieCards);
            pnlMain.Controls.Add(pnlSectionHeader);
            pnlMain.Controls.Add(pnlStatRow);

            LoadStats();
            LoadMovieCards(_movieRepo.GetAll());
        }

        // ════════════════════════════════════════════════════════════════
        //  NAV BUTTON HANDLERS
        // ════════════════════════════════════════════════════════════════
        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            ActivateNav(btnNavDashboard, "🎬 Dashboard");
            RestoreDashboard();
        }

        private void btnNavMovies_Click(object sender, EventArgs e)
        {
            ActivateNav(btnNavMovies, "🎬 Movies");
            EmbedForm(new MoviesAdminForm());
        }

        private void btnNavGenres_Click(object sender, EventArgs e)
        {
            ActivateNav(btnNavGenres, "🏷 Genres");
            // EmbedForm(new GenresForm());   // ← uncomment when ready
            ShowComingSoon("Genres");
        }

        private void btnNavActors_Click(object sender, EventArgs e)
        {
            ActivateNav(btnNavActors, "👤 Actors");
            // EmbedForm(new ActorsForm());   // ← uncomment when ready
            ShowComingSoon("Actors");
        }

        private void btnNavReports_Click(object sender, EventArgs e)
        {
            ActivateNav(btnNavReports, "📊 Reports");
            // EmbedForm(new ReportsForm());  // ← uncomment when ready
            ShowComingSoon("Reports");
        }

        private void btnNavLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
                Application.Exit();
        }

        // ════════════════════════════════════════════════════════════════
        //  ACTIVATE NAV — highlights the clicked sidebar button
        // ════════════════════════════════════════════════════════════════
        private void ActivateNav(Button clicked, string pageTitle)
        {
            var navButtons = new[]
            {
                btnNavDashboard, btnNavMovies, btnNavGenres,
                btnNavActors, btnNavReports
            };

            // Reset ALL nav buttons to default style
            foreach (var btn in navButtons)
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(180, 210, 255);
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }

            // Highlight the active one
            clicked.BackColor = Color.FromArgb(41, 98, 196);
            clicked.ForeColor = Color.White;
            clicked.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Update top bar title
            lblPageTitle.Text = pageTitle;

            _activeNavBtn = clicked;
        }

        // ════════════════════════════════════════════════════════════════
        //  OBSERVER CALLBACK
        // ════════════════════════════════════════════════════════════════
        private void OnMoviesChanged(object sender, EventArgs e)
        {
            // If we just added the movie ourselves, don't clear the whole screen!
            if (_isPerformingManualUpdate) return;

            // Otherwise (e.g., deleted from Admin form), reload everything
            LoadStats();
            LoadMovieCards(ApplySort(_movieRepo.GetAll()));
        }

        // ════════════════════════════════════════════════════════════════
        //  STATS
        // ════════════════════════════════════════════════════════════════
        private void LoadStats()
        {
            var store = MovieDataStore.Instance;
            lblCardTotalValue.Text = store.Movies.Count.ToString();
            lblCardGenresValue.Text = store.Genres.Count.ToString();
            lblCardActorsValue.Text = store.Actors.Count.ToString();
            lblCardNewValue.Text = store.Movies
                .FindAll(m => m.Year == DateTime.Now.Year).Count.ToString();
        }

        // ════════════════════════════════════════════════════════════════
        //  LOAD MOVIE CARDS
        // ════════════════════════════════════════════════════════════════
        private void LoadMovieCards(List<Movie> movies)
        {
            flpMovieCards.SuspendLayout();

            foreach (Control ctrl in flpMovieCards.Controls)
                ctrl.Dispose();
            flpMovieCards.Controls.Clear();

            lblMovieCount.Text = $"{movies.Count} movie{(movies.Count != 1 ? "s" : "")}";

            if (movies.Count == 0)
            {
                var lblEmpty = new Label
                {
                    Text = "😕  No movies found.",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.FromArgb(160, 170, 190),
                    AutoSize = true,
                    Margin = new Padding(20, 60, 0, 0)
                };
                flpMovieCards.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var movie in movies)
                {
                    var card = new MovieCardControl(movie);

                    // Details -> show movie details dialog
                    card.OnDetailsClick += Card_OnDetailsClick;

                    // Book -> show booking dialog (keeps your existing behavior)
                    card.OnBookClick += Card_OnBookClick;

                    flpMovieCards.Controls.Add(card);
                }
            }

            flpMovieCards.ResumeLayout();
        }

        // ════════════════════════════════════════════════════════════════
        //  CARD EVENTS
        // ════════════════════════════════════════════════════════════════
        //private void Card_OnEdit(object sender, Movie movie)
        //{
        //    MessageBox.Show($"✏ Edit: {movie.Title}\n\nOpen your EditMovieForm here.",
        //        "Edit Movie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        //private void Card_OnDelete(object sender, Movie movie)
        //{
        //    _movieRepo.Delete(movie.Id);
        //}

        // ════════════════════════════════════════════════════════════════
        //  SEARCH
        // ════════════════════════════════════════════════════════════════
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword) || keyword == "Search movies...")
            {
                LoadMovieCards(ApplySort(_movieRepo.GetAll()));
                return;
            }

            _searcher.SetStrategy(int.TryParse(keyword, out _)
                ? (ISearchStrategy)new SearchByYear()
                : new SearchByTitle());

            var results = _searcher.Search(_movieRepo.GetAll(), keyword);
            LoadMovieCards(ApplySort(results));
        }

        // ════════════════════════════════════════════════════════════════
        //  SORT
        // ════════════════════════════════════════════════════════════════
        private void cmbSortBy_Changed(object sender, EventArgs e)
        {
            LoadMovieCards(ApplySort(_movieRepo.GetAll()));
        }

        private List<Movie> ApplySort(List<Movie> movies)
        {
            switch (cmbSortBy.SelectedIndex)
            {
                case 1: return movies.OrderBy(m => m.Title).ToList();
                case 2: return movies.OrderByDescending(m => m.Year).ToList();
                case 3: return movies.OrderByDescending(m => m.Rating).ToList();
                default: return movies;
            }
        }

        // ════════════════════════════════════════════════════════════════
        //  ADD MOVIE
        // ════════════════════════════════════════════════════════════════
        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            using (var dlg = new MovieSytemManageMent.ApplicationForm.Dialog.AddMovieDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK && dlg.NewMovie != null)
                {
                    _isPerformingManualUpdate = true; // Block the observer from reloading everything
                    try
                    {
                        _movieRepo.Add(dlg.NewMovie); // This triggers MoviesChanged
                        AppendMovieCard(dlg.NewMovie);
                        LoadStats();
                    }
                    finally
                    {
                        _isPerformingManualUpdate = false;
                    }
                }
            }
        }

        private void AppendMovieCard(Movie movie)
        {
            // Remove "no movies" empty label if showing
            var emptyLbl = flpMovieCards.Controls
                .OfType<Label>()
                .FirstOrDefault(l => l.Text.Contains("No movies"));
            if (emptyLbl != null)
                flpMovieCards.Controls.Remove(emptyLbl);

            // Build card offscreen first
            var card = new MovieCardControl(movie);
            card.OnDetailsClick += Card_OnDetailsClick;
            card.OnBookClick += Card_OnBookClick;

            // Suspend layout — add — resume: no repaint until done
            flpMovieCards.SuspendLayout();
            flpMovieCards.Controls.Add(card);
            flpMovieCards.ResumeLayout(false);
            flpMovieCards.PerformLayout();

            // Update count label
            int count = flpMovieCards.Controls.OfType<MovieCardControl>().Count();
            lblMovieCount.Text = $"{count} movie{(count != 1 ? "s" : "")}";

            // Smooth scroll to new card without jumping
            flpMovieCards.ScrollControlIntoView(card);
        }

        // ════════════════════════════════════════════════════════════════
        //  COMING SOON placeholder — shown for unbuilt pages
        // ════════════════════════════════════════════════════════════════
        private void ShowComingSoon(string pageName)
        {
            pnlMain.Controls.Clear();

            var pnl = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(238, 242, 252) };
            var lbl = new Label
            {
                Text = $"🚧  {pageName} page coming soon!",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 98, 196),
                AutoSize = true
            };

            pnl.Controls.Add(lbl);
            pnl.Layout += (s, e) =>
            {
                lbl.Left = (pnl.Width - lbl.Width) / 2;
                lbl.Top = (pnl.Height - lbl.Height) / 2;
            };

            pnlMain.Controls.Add(pnl);
        }

        // ════════════════════════════════════════════════════════════════
        //  CLEANUP
        // ════════════════════════════════════════════════════════════════
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            MovieDataStore.Instance.MoviesChanged -= OnMoviesChanged;
            base.OnFormClosed(e);
        }

        private void Card_OnDetailsClick(object sender, Movie movie)
        {
            if (movie == null) return;

            using var dlg = new MovieSytemManageMent.ApplicationForm.Dialog.MovieDetailDialog(movie);
            dlg.ShowDialog(this);
        }

        private void Card_OnBookClick(object sender, Movie movie)
        {
            if (movie == null) return;

            // ✅ FIX: Pass BOTH the ID and the MOVIE object
            using var dlg = new AddBookingDialog(movie.Id, movie);

            var dr = dlg.ShowDialog(this);
            if (dr == DialogResult.OK && dlg.NewBooking != null)
            {
                BookingRepository.Instance.Add(dlg.NewBooking);

                MessageBox.Show($"Booking created for \"{movie.Title}\" ({dlg.NewBooking.CustomerName}).",
                    "Booking Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStats();
            }
        }
    }
}