

// ============================================================
// FILE: ApplicationForm/Movies/MoviesAdminForm.cs
// PURPOSE: Movies Admin form — movie list + bookings per movie
//          Uses Repository Pattern + Observer Pattern
// ============================================================
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MovieSytemManageMent.Controls;
using MovieSytemManageMent.Data;
using MovieSytemManageMent.Model;
using MovieSytemManageMent.Repositories;
using MovieSytemManageMent.Repositories.BookingRepository;

namespace MovieSytemManageMent.ApplicationForm.AdminForm
{
    public partial class MoviesAdminForm : Form
    {
        // ── Repositories ──────────────────────────────────────────────────
        private readonly IMovieRepository _movieRepo;
        private readonly IBookingRepository _bookingRepo;

        // ── State ─────────────────────────────────────────────────────────
        private Movie _selectedMovie;
        private List<Movie> _allMovies;
        private List<Booking> _currentBookings;

        // ── Constructor ───────────────────────────────────────────────────
        public MoviesAdminForm()
        {
            InitializeComponent();

            _movieRepo = new MovieRepository();
            _bookingRepo = BookingRepository.Instance;

            // Observer: refresh if movies change elsewhere
            MovieDataStore.Instance.MoviesChanged += (s, e) => LoadMovieList();

            // Wire events
            lstMovies.SelectedIndexChanged += LstMovies_SelectedIndexChanged;
            lstMovies.DrawItem += LstMovies_DrawItem;

            txtMovieSearch.GotFocus += (s, e) =>
            {
                // ✅ Check ForeColor instead of text string
                // — avoids emoji/spacing mismatch bugs
                if (txtMovieSearch.ForeColor == Color.FromArgb(120, 140, 180))
                {
                    txtMovieSearch.Text = "";
                    txtMovieSearch.ForeColor = Color.FromArgb(12, 26, 58);
                }
            };
            txtMovieSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtMovieSearch.Text))
                {
                    txtMovieSearch.Text = "Search movies...";
                    txtMovieSearch.ForeColor = Color.FromArgb(120, 140, 180);
                }
            };
            txtMovieSearch.TextChanged += (s, e) =>
            {
                // If placeholder is showing — do nothing
                if (txtMovieSearch.ForeColor == Color.FromArgb(120, 140, 180))
                    return;

                // If text is empty — show all movies back
                if (string.IsNullOrWhiteSpace(txtMovieSearch.Text))
                    LoadMovieList("");
                else
                    FilterMovies();
            };

            btnAddBooking.Click += BtnAddBooking_Click;
            btnDeleteBooking.Click += BtnDeleteBooking_Click;
            btnChangeStatus.Click += BtnChangeStatus_Click;

            // DataGridView cell painting for Status column
            dgvBookings.CellPainting += DgvBookings_CellPainting;

            // Initial load
            LoadMovieList();
            SetStatus("Select a movie from the list to view its bookings.");
        }

        // ════════════════════════════════════════════════════════════════
        //  LOAD MOVIE LIST
        // ════════════════════════════════════════════════════════════════
        private void LoadMovieList(string filter = "")
        {
            _allMovies = _movieRepo.GetAll();

            var filtered = string.IsNullOrWhiteSpace(filter)
                ? _allMovies
                : _allMovies.Where(m =>
                    m.Title.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0
                  ).ToList();

            lstMovies.Items.Clear();
            foreach (var m in filtered)
                lstMovies.Items.Add(m);

            lblMovieListCount.Text = $"{filtered.Count} movie{(filtered.Count != 1 ? "s" : "")}";
        }

        private void FilterMovies()
        {
            string q = txtMovieSearch.Text;
            if (q == "🔍  Search movies...") q = "";
            LoadMovieList(q);
        }

        // ════════════════════════════════════════════════════════════════
        //  CUSTOM LISTBOX DRAW — shows title + genre badge
        // ════════════════════════════════════════════════════════════════
        private void LstMovies_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lstMovies.Items.Count) return;

            var navy = Color.FromArgb(12, 26, 58);
            var blue = Color.FromArgb(41, 98, 196);
            var bgSel = Color.FromArgb(220, 230, 250);
            var white = Color.White;
            var muted = Color.FromArgb(120, 140, 180);

            bool selected = (e.State & DrawItemState.Selected) != 0;
            var movie = lstMovies.Items[e.Index] as Movie;
            if (movie == null) return;

            // ── Background ────────────────────────────────────────────────
            e.Graphics.FillRectangle(
                new SolidBrush(selected ? bgSel : white),
                e.Bounds);

            // ── Left blue accent bar (only when selected) ─────────────────
            if (selected)
                e.Graphics.FillRectangle(
                    new SolidBrush(blue),
                    new Rectangle(e.Bounds.X, e.Bounds.Y, 4, e.Bounds.Height));

            int textX = e.Bounds.X + 14;   // left padding
            int lineY = e.Bounds.Y;         // top of this item

            // ── ROW 1: Movie title (Y = top + 8) ─────────────────────────
            e.Graphics.DrawString(
                movie.Title,
                new Font("Segoe UI", 10.5F, selected ? FontStyle.Bold : FontStyle.Regular),
                new SolidBrush(navy),
                new PointF(textX, lineY + 8));

            // ── ROW 2: Genre pill (Y = top + 28) ─────────────────────────
            string genre = movie.Genre ?? "";
            var pillFont = new Font("Segoe UI", 7.5F);
            var pillSize = e.Graphics.MeasureString(genre, pillFont);
            var pillRect = new RectangleF(textX, lineY + 30, pillSize.Width + 10, 16);

            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(220, 230, 250)), pillRect);
            e.Graphics.DrawString(genre, pillFont,
                new SolidBrush(blue),
                pillRect.X + 5, pillRect.Y + 1);

            // ── Booking count badge (right side, vertically centred) ──────
            int count = _bookingRepo.GetByMovieId(movie.Id).Count;
            string badge = $"{count} 🎟";
            var badgeFont = new Font("Segoe UI", 8F);
            var badgeSize = e.Graphics.MeasureString(badge, badgeFont);

            e.Graphics.DrawString(badge, badgeFont,
                new SolidBrush(muted),
                e.Bounds.Right - badgeSize.Width - 10,
                lineY + (e.Bounds.Height / 2) - (badgeSize.Height / 2));

            // ── Bottom divider line ───────────────────────────────────────
            e.Graphics.DrawLine(
                new Pen(Color.FromArgb(235, 240, 252)),
                e.Bounds.X, e.Bounds.Bottom - 1,
                e.Bounds.Right, e.Bounds.Bottom - 1);
        }

        // ════════════════════════════════════════════════════════════════
        //  MOVIE SELECTED → load its bookings
        // ════════════════════════════════════════════════════════════════
        private void LstMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMovies.SelectedItem is Movie movie)
            {
                _selectedMovie = movie;
                lblSelectedMovie.Text = $"📽  {movie.Title}  ({movie.Year})  —  {movie.Genre}";
                LoadBookings(movie.Id);
                SetStatus($"Showing bookings for: {movie.Title}");
            }
        }

        // ════════════════════════════════════════════════════════════════
        //  LOAD BOOKINGS INTO DATAGRIDVIEW
        // ════════════════════════════════════════════════════════════════
        private void LoadBookings(int movieId)
        {
            dgvBookings.Rows.Clear();
            _currentBookings = _bookingRepo.GetByMovieId(movieId);

            foreach (var b in _currentBookings)
            {
                dgvBookings.Rows.Add(
                    b.Id,             // colId
                    b.CustomerName,   // colCustomer
                    b.SeatNumber,     // colSeat
                    b.BookingDate.ToString("dd MMM yyyy"), // colDate
                    $"${b.TicketPrice:0.00}", // colPrice
                    b.Status          // colStatus
                );
            }
            UpdateBookingStats(_currentBookings);
        }
        // ════════════════════════════════════════════════════════════════
        //  UPDATE MINI STAT CARDS
        // ════════════════════════════════════════════════════════════════
        private void UpdateBookingStats(List<Booking> bookings)
        {
            lblStatConfirmedNum.Text = bookings.Count(b => b.Status == "Confirmed").ToString();
            lblStatPendingNum.Text = bookings.Count(b => b.Status == "Pending").ToString();
            lblStatCancelledNum.Text = bookings.Count(b => b.Status == "Cancelled").ToString();
            lblStatRevenueNum.Text = $"${bookings.Where(b => b.Status == "Confirmed").Sum(b => b.TicketPrice):0.00}";
        }

        // ════════════════════════════════════════════════════════════════
        //  STATUS CELL COLOUR CODING
        // ════════════════════════════════════════════════════════════════
        private void DgvBookings_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dgvBookings.Columns[e.ColumnIndex].Name != "colStatus") return;

            string status = e.Value?.ToString() ?? "";
            Color bgColor, fgColor;

            switch (status)
            {
                case "Confirmed":
                    bgColor = Color.FromArgb(210, 245, 228);
                    fgColor = Color.FromArgb(20, 120, 70);
                    break;
                case "Pending":
                    bgColor = Color.FromArgb(255, 240, 200);
                    fgColor = Color.FromArgb(160, 90, 0);
                    break;
                case "Cancelled":
                    bgColor = Color.FromArgb(255, 220, 220);
                    fgColor = Color.FromArgb(180, 30, 30);
                    break;
                default:
                    return;
            }

            e.PaintBackground(e.ClipBounds, true);

            // Draw coloured pill
            var rect = new Rectangle(
                e.CellBounds.X + 6,
                e.CellBounds.Y + 6,
                e.CellBounds.Width - 12,
                e.CellBounds.Height - 12);

            using var brush = new SolidBrush(bgColor);
            e.Graphics.FillRectangle(brush, rect);

            using var sf = new System.Drawing.StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(status,
                new Font("Segoe UI", 8.5F, FontStyle.Bold),
                new SolidBrush(fgColor), rect, sf);

            e.Handled = true;
        }

        // ════════════════════════════════════════════════════════════════
        //  ADD BOOKING
        // ════════════════════════════════════════════════════════════════
        private void BtnAddBooking_Click(object sender, EventArgs e)
        {
            if (_selectedMovie == null)
            {
                MessageBox.Show("Please select a movie first.",
                    "No Movie Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dlg = new AddBookingDialog(_selectedMovie.Id);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _bookingRepo.Add(dlg.NewBooking);
                LoadBookings(_selectedMovie.Id);
                lstMovies.Invalidate(); // refresh booking count badge
                SetStatus($"✔ Booking added for {_selectedMovie.Title}.");
            }
        }

        // ════════════════════════════════════════════════════════════════
        //  DELETE BOOKING
        // ════════════════════════════════════════════════════════════════
        private void BtnDeleteBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to delete.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["colId"].Value);
            var customer = dgvBookings.SelectedRows[0].Cells["colCustomer"].Value?.ToString();

            var confirm = MessageBox.Show(
                $"Delete booking for \"{customer}\"?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _bookingRepo.Delete(id);
                LoadBookings(_selectedMovie.Id);
                lstMovies.Invalidate();
                SetStatus($"🗑 Booking deleted.");
            }
        }

        // ════════════════════════════════════════════════════════════════
        //  CHANGE STATUS
        // ════════════════════════════════════════════════════════════════
        private void BtnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to change its status.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["colId"].Value);
            var booking = _bookingRepo.GetById(id);
            if (booking == null) return;

            // Cycle: Pending → Confirmed → Cancelled → Pending
            booking.Status = booking.Status switch
            {
                "Pending" => "Confirmed",
                "Confirmed" => "Cancelled",
                _ => "Pending"
            };

            _bookingRepo.Update(booking);
            LoadBookings(_selectedMovie.Id);
            SetStatus($"🔄 Status changed to: {booking.Status}");
        }

        // ════════════════════════════════════════════════════════════════
        //  HELPERS
        // ════════════════════════════════════════════════════════════════
        private void SetStatus(string msg) => lblStatus.Text = msg;

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            MovieDataStore.Instance.MoviesChanged -= (s, ev) => LoadMovieList();
            base.OnFormClosed(e);
        }
    }
}