// ============================================================
// FILE: Controls/AddBookingDialog.cs
// PURPOSE: Cinema-style booking dialog matching real-world UI
//          Left: movie poster + info | Right: seat grid
//          Bottom: selected seats, payment method, total, book button
// ============================================================
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MovieSytemManageMent.Model;
using MovieSytemManageMent.Repositories.BookingRepository;

namespace MovieSytemManageMent.Controls
{
    public class AddBookingDialog : Form
    {
        // ── Public result ─────────────────────────────────────────────────
        public Booking NewBooking { get; private set; }

        // ── Layout constants ──────────────────────────────────────────────
        private const int ROWS = 6;
        private const int COLS = 10;
        private const int SEAT_SIZE = 38;
        private const int SEAT_GAP = 8;
        private const int AISLE_GAP = 16;
        private static readonly string[] ROW_LABELS = { "A", "B", "C", "D", "E", "F" };

        // ── State ─────────────────────────────────────────────────────────
        private readonly int _movieId;
        private readonly Movie _movie;
        private readonly HashSet<string> _bookedSeats;
        private string _selectedSeat = null;
        private string _hoveredSeat = null;

        // ── Colors ────────────────────────────────────────────────────────
        private readonly Color _bgForm = Color.FromArgb(245, 247, 252);
        private readonly Color _navy = Color.FromArgb(18, 26, 60);
        private readonly Color _blue = Color.FromArgb(41, 98, 196);
        private readonly Color _seatAvail = Color.FromArgb(210, 215, 230);
        private readonly Color _seatOccupied = Color.FromArgb(200, 40, 60);
        private readonly Color _seatSelected = Color.FromArgb(25, 55, 120);
        private readonly Color _seatHover = Color.FromArgb(150, 170, 220);
        private readonly Color _white = Color.White;
        private readonly Color _textDark = Color.FromArgb(20, 30, 60);
        private readonly Color _textMuted = Color.FromArgb(120, 130, 160);

        // ── Controls ──────────────────────────────────────────────────────
        private Panel _seatGridPanel;
        private Label _lblSelectedSeats;
        private ComboBox _cmbPayment;
        private Label _lblTotal;
        private Button _btnBook;
        private TextBox _txtCustomer;
        private NumericUpDown _numPrice;
        private ComboBox _cmbStatus;

        // ── Constructors ──────────────────────────────────────────────────
        // Keep old signature (int only) working so existing callers don't break
        public AddBookingDialog(int movieId) : this(movieId, null) { }

        public AddBookingDialog(int movieId, Movie movie)
        {
            _movieId = movieId;
            _movie = movie ?? new Movie
            { Id = movieId, Title = "Movie", Year = DateTime.Now.Year };

            _bookedSeats = new HashSet<string>(
                BookingRepository.Instance
                    .GetByMovieId(_movieId)
                    .Where(b => b.Status != "Cancelled")
                    .Select(b => b.SeatNumber),
                StringComparer.OrdinalIgnoreCase);

            BuildUI();
        }

        // ════════════════════════════════════════════════════════════════
        //  BUILD UI
        // ════════════════════════════════════════════════════════════════
        private void BuildUI()
        {
            this.Text = "Ticket Booking";
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = _bgForm;
            this.Size = new Size(1000, 680);
            this.DoubleBuffered = true;

            this.Load += (s, e) =>
            {
                this.Region = new Region(
                    RoundedRect(new Rectangle(0, 0, Width, Height), 16));
            };

            // ── Top bar ───────────────────────────────────────────────────
            var pnlTop = new Panel
            { Dock = DockStyle.Top, Height = 56, BackColor = _navy };
            pnlTop.MouseDown += DragForm;

            var lblAppTitle = new Label
            {
                Text = "Ticket Booking",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = _white,
                AutoSize = true,
                Location = new Point(24, 16)
            };
            var lblWelcome = new Label
            {
                Text = "Welcome, Admin",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(180, 200, 240),
                AutoSize = true,
                Location = new Point(720, 19)
            };
            var btnClose = new Button
            {
                Text = "✕",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(160, 180, 220),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(30, 30),
                Location = new Point(960, 13),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            pnlTop.Controls.AddRange(new Control[] { lblAppTitle, lblWelcome, btnClose });

            // ── Body ──────────────────────────────────────────────────────
            var pnlBody = new Panel
            { Dock = DockStyle.Fill, BackColor = Color.Transparent };

            // ── LEFT panel ────────────────────────────────────────────────
            var pnlLeft = new Panel
            {
                Size = new Size(300, 560),
                Location = new Point(20, 16),
                BackColor = _white
            };
            pnlLeft.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(new Pen(Color.FromArgb(220, 225, 240), 1),
                    RoundedRect(new Rectangle(0, 0, pnlLeft.Width - 1, pnlLeft.Height - 1), 10));
            };

            // Poster
            var picPoster = new Panel
            {
                Size = new Size(260, 290),
                Location = new Point(20, 16),
                BackColor = Color.FromArgb(50, 60, 100)
            };
            picPoster.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using var br = new LinearGradientBrush(picPoster.ClientRectangle,
                    Color.FromArgb(80, 90, 130), Color.FromArgb(30, 40, 80),
                    LinearGradientMode.Vertical);
                g.FillRectangle(br, picPoster.ClientRectangle);
                using var sf = new StringFormat
                { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("🎬", new Font("Segoe UI Emoji", 40F),
                    new SolidBrush(Color.FromArgb(100, 140, 200)),
                    picPoster.ClientRectangle, sf);
            };
            picPoster.Region = new Region(RoundedRect(new Rectangle(0, 0, 260, 290), 8));

            var lblMovieTitle = new Label
            {
                Text = _movie.Title,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = _textDark,
                AutoSize = false,
                Size = new Size(260, 30),
                Location = new Point(20, 316),
                TextAlign = ContentAlignment.MiddleCenter
            };

            int iy = 354;
            void InfoRow(string k, string v)
            {
                pnlLeft.Controls.Add(new Label
                {
                    Text = k,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = _textMuted,
                    Location = new Point(20, iy),
                    AutoSize = true
                });
                pnlLeft.Controls.Add(new Label
                {
                    Text = v,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = _textDark,
                    Location = new Point(165, iy),
                    AutoSize = true
                });
                iy += 26;
            }
            InfoRow("Date:", DateTime.Today.ToString("yyyy-MM-dd"));
            InfoRow("Time:", "19:30");
            InfoRow("Hall:", "Hall 1");
            InfoRow("Rating:", _movie.Rating > 0 ? $"{_movie.Rating:0.0}" : "N/A");

            iy += 8;
            pnlLeft.Controls.Add(new Label
            {
                Text = "Customer Name:",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = _textDark,
                Location = new Point(20, iy),
                AutoSize = true
            });
            iy += 20;
            _txtCustomer = new TextBox
            {
                Location = new Point(20, iy),
                Size = new Size(260, 26),
                Font = new Font("Segoe UI", 9.5F),
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlLeft.Controls.Add(_txtCustomer);
            pnlLeft.Controls.AddRange(new Control[] { picPoster, lblMovieTitle });

            // ── RIGHT panel (seat grid) ───────────────────────────────────
            var pnlRight = new Panel
            {
                Size = new Size(640, 560),
                Location = new Point(336, 16),
                BackColor = _white
            };
            pnlRight.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(new Pen(Color.FromArgb(220, 225, 240), 1),
                    RoundedRect(new Rectangle(0, 0, pnlRight.Width - 1, pnlRight.Height - 1), 10));
            };

            // Section header
            var pnlSecHeader = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(640, 46),
                BackColor = _navy
            };
            pnlSecHeader.Paint += (s, e) =>
            {
                var path = new GraphicsPath();
                path.AddArc(0, 0, 20, 20, 180, 90);
                path.AddArc(620 - 20, 0, 20, 20, 270, 90);
                path.AddLine(620, 46, 0, 46);
                path.CloseFigure();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(_navy), path);
            };
            pnlSecHeader.Controls.Add(new Label
            {
                Text = "Seat Selection",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = _white,
                AutoSize = true,
                Location = new Point(20, 12)
            });

            // Seat grid panel
            _seatGridPanel = new Panel
            {
                Location = new Point(0, 46),
                Size = new Size(640, 440),
                BackColor = Color.Transparent
            };
            // Enable double-buffering via reflection
            typeof(Panel).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance)
                ?.SetValue(_seatGridPanel, true);

            _seatGridPanel.Paint += SeatGrid_Paint;
            _seatGridPanel.MouseMove += SeatGrid_MouseMove;
            _seatGridPanel.MouseLeave += (s, e) =>
            { _hoveredSeat = null; _seatGridPanel.Invalidate(); };
            _seatGridPanel.MouseClick += SeatGrid_Click;

            // Legend panel
            var pnlLegend = new Panel
            {
                Location = new Point(0, 488),
                Size = new Size(640, 36),
                BackColor = Color.Transparent
            };
            pnlLegend.Paint += DrawLegend;

            pnlRight.Controls.AddRange(new Control[]
                { pnlSecHeader, _seatGridPanel, pnlLegend });

            pnlBody.Controls.AddRange(new Control[] { pnlLeft, pnlRight });

            // ── Bottom bar ────────────────────────────────────────────────
            var pnlBottom = new Panel
            { Dock = DockStyle.Bottom, Height = 64, BackColor = _white };
            pnlBottom.Paint += (s, e) =>
                e.Graphics.DrawLine(new Pen(Color.FromArgb(220, 225, 240)), 0, 0, pnlBottom.Width, 0);

            // Selected seats
            AddBottomLabel(pnlBottom, "Selected Seats", 24, 8);
            _lblSelectedSeats = new Label
            {
                Text = "None",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = _textMuted,
                Location = new Point(24, 28),
                Size = new Size(160, 26),
                TextAlign = ContentAlignment.MiddleLeft,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = _bgForm
            };

            // Payment method
            AddBottomLabel(pnlBottom, "Payment Method", 210, 8);
            _cmbPayment = new ComboBox
            {
                Location = new Point(210, 28),
                Size = new Size(160, 26),
                Font = new Font("Segoe UI", 9.5F),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat
            };
            _cmbPayment.Items.AddRange(new object[]
                { "Credit Card", "Debit Card", "Cash", "Online Transfer" });
            _cmbPayment.SelectedIndex = 0;

            // Status
            AddBottomLabel(pnlBottom, "Status", 396, 8);
            _cmbStatus = new ComboBox
            {
                Location = new Point(396, 28),
                Size = new Size(120, 26),
                Font = new Font("Segoe UI", 9.5F),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat
            };
            _cmbStatus.Items.AddRange(new object[] { "Confirmed", "Pending", "Cancelled" });
            _cmbStatus.SelectedIndex = 0;

            // Price
            AddBottomLabel(pnlBottom, "Price ($)", 536, 8);
            _numPrice = new NumericUpDown
            {
                Location = new Point(536, 28),
                Size = new Size(90, 26),
                Font = new Font("Segoe UI", 9.5F),
                Minimum = 0,
                Maximum = 500,
                DecimalPlaces = 2,
                Value = 12.50M,
                BorderStyle = BorderStyle.FixedSingle
            };
            _numPrice.ValueChanged += (s, e) => UpdateTotal();

            // Total
            AddBottomLabel(pnlBottom, "Total Amount", 648, 8);
            _lblTotal = new Label
            {
                Text = "$0.00",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(180, 30, 30),
                Location = new Point(648, 26),
                AutoSize = true
            };

            // Cancel
            var btnCancel = new Button
            {
                Text = "Cancel",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = _textMuted,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 42),
                Location = new Point(796, 10),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            // Book
            _btnBook = new Button
            {
                Text = "Booking",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = _white,
                BackColor = _navy,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(110, 42),
                Location = new Point(880, 10),
                Cursor = Cursors.Hand
            };
            _btnBook.FlatAppearance.BorderSize = 0;
            _btnBook.Click += BtnBook_Click;

            pnlBottom.Controls.AddRange(new Control[]
            {
                _lblSelectedSeats, _cmbPayment, _cmbStatus,
                _numPrice, _lblTotal, btnCancel, _btnBook
            });

            this.Controls.AddRange(new Control[] { pnlBottom, pnlBody, pnlTop });
            this.CancelButton = btnCancel;
        }

        // ════════════════════════════════════════════════════════════════
        //  SEAT GRID PAINT
        // ════════════════════════════════════════════════════════════════
        private void SeatGrid_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int panelW = _seatGridPanel.Width;
            int totalGridW = COLS * (SEAT_SIZE + SEAT_GAP) + AISLE_GAP - SEAT_GAP;
            int startX = (panelW - totalGridW - 50) / 2 + 20;
            int startY = 62;

            // ── SCREEN ────────────────────────────────────────────────────
            int screenW = 380, screenX = (panelW - screenW) / 2;
            using var screenPen = new Pen(Color.FromArgb(160, 180, 220), 3);
            screenPen.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
            g.DrawArc(screenPen, new Rectangle(screenX, 14, screenW, 24), 180, 180);
            using var sf0 = new StringFormat
            { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString("SCREEN", new Font("Segoe UI", 7.5F, FontStyle.Bold),
                new SolidBrush(Color.FromArgb(120, 140, 180)),
                new RectangleF(screenX, 20, screenW, 16), sf0);

            // ── SEATS ─────────────────────────────────────────────────────
            for (int row = 0; row < ROWS; row++)
            {
                int y = startY + row * (SEAT_SIZE + SEAT_GAP);

                // Left label
                g.DrawString(ROW_LABELS[row], new Font("Segoe UI", 9F, FontStyle.Bold),
                    new SolidBrush(_textMuted),
                    new PointF(startX - 22, y + SEAT_SIZE / 2f - 8));

                for (int col = 0; col < COLS; col++)
                {
                    string id = $"{ROW_LABELS[row]}{col + 1}";
                    int ao = col >= 5 ? AISLE_GAP : 0;
                    int x = startX + col * (SEAT_SIZE + SEAT_GAP) + ao;
                    var rect = new Rectangle(x, y, SEAT_SIZE, SEAT_SIZE);

                    bool booked = _bookedSeats.Contains(id);
                    bool selected = id == _selectedSeat;
                    bool hovered = id == _hoveredSeat && !booked;

                    Color fill = booked ? _seatOccupied
                               : selected ? _seatSelected
                               : hovered ? _seatHover
                               : _seatAvail;

                    var path = RoundedRect(rect, 6);
                    g.FillPath(new SolidBrush(fill), path);

                    // Highlight strip at top of seat (backrest illusion)
                    g.FillPath(new SolidBrush(Color.FromArgb(40, Color.White)),
                        RoundedRect(new Rectangle(rect.X + 4, rect.Y + 2,
                            rect.Width - 8, rect.Height / 3), 4));

                    // Border
                    var borderCol = booked ? Color.FromArgb(220, 60, 80)
                                  : selected ? Color.FromArgb(80, 120, 200)
                                  : Color.FromArgb(60, 140, 150, 180);
                    g.DrawPath(new Pen(borderCol, 1f), path);

                    // X for occupied
                    if (booked)
                    {
                        using var xp = new Pen(Color.FromArgb(200, _white), 2f);
                        g.DrawLine(xp, rect.X + 8, rect.Y + 8, rect.Right - 8, rect.Bottom - 8);
                        g.DrawLine(xp, rect.Right - 8, rect.Y + 8, rect.X + 8, rect.Bottom - 8);
                    }
                }

                // Right label
                int rightX = startX + COLS * (SEAT_SIZE + SEAT_GAP) + AISLE_GAP - SEAT_GAP + 4;
                g.DrawString(ROW_LABELS[row], new Font("Segoe UI", 9F, FontStyle.Bold),
                    new SolidBrush(_textMuted),
                    new PointF(rightX, y + SEAT_SIZE / 2f - 8));
            }
        }

        // ════════════════════════════════════════════════════════════════
        //  INTERACTIONS
        // ════════════════════════════════════════════════════════════════
        private void SeatGrid_MouseMove(object sender, MouseEventArgs e)
        {
            string hit = HitTest(e.Location);
            if (hit == _hoveredSeat) return;
            _hoveredSeat = hit;
            _seatGridPanel.Invalidate();
            _seatGridPanel.Cursor = (hit != null && !_bookedSeats.Contains(hit))
                ? Cursors.Hand : Cursors.Default;
        }

        private void SeatGrid_Click(object sender, MouseEventArgs e)
        {
            string hit = HitTest(e.Location);
            if (hit == null || _bookedSeats.Contains(hit)) return;
            _selectedSeat = (_selectedSeat == hit) ? null : hit;
            _seatGridPanel.Invalidate();
            UpdateTotal();
            _lblSelectedSeats.Text = _selectedSeat ?? "None";
            _lblSelectedSeats.ForeColor = _selectedSeat != null ? _textDark : _textMuted;
        }

        private void DrawLegend(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int cx = ((Panel)sender).Width / 2;

            void Item(int x, Color c, string label)
            {
                g.FillPath(new SolidBrush(c),
                    RoundedRect(new Rectangle(x, 10, 18, 18), 4));
                g.DrawString(label, new Font("Segoe UI", 8.5F),
                    new SolidBrush(_textMuted), x + 24, 11);
            }
            Item(cx - 200, _seatAvail, "Available");
            Item(cx - 50, _seatSelected, "Selected");
            Item(cx + 100, _seatOccupied, "Occupied");
        }

        private string HitTest(Point p)
        {
            int panelW = _seatGridPanel.Width;
            int totalGridW = COLS * (SEAT_SIZE + SEAT_GAP) + AISLE_GAP - SEAT_GAP;
            int startX = (panelW - totalGridW - 50) / 2 + 20;
            int startY = 62;

            for (int row = 0; row < ROWS; row++)
            {
                int y = startY + row * (SEAT_SIZE + SEAT_GAP);
                for (int col = 0; col < COLS; col++)
                {
                    int ao = col >= 5 ? AISLE_GAP : 0;
                    int x = startX + col * (SEAT_SIZE + SEAT_GAP) + ao;
                    if (new Rectangle(x, y, SEAT_SIZE, SEAT_SIZE).Contains(p))
                        return $"{ROW_LABELS[row]}{col + 1}";
                }
            }
            return null;
        }

        private void UpdateTotal()
        {
            double total = _selectedSeat != null ? (double)_numPrice.Value : 0;
            _lblTotal.Text = $"${total:0.00}";
        }

        // ════════════════════════════════════════════════════════════════
        //  BOOK / SAVE  — same Booking object your repos expect
        // ════════════════════════════════════════════════════════════════
        private void BtnBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtCustomer.Text))
            {
                MessageBox.Show("Please enter a customer name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_selectedSeat == null)
            {
                MessageBox.Show("Please select a seat from the grid.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NewBooking = new Booking
            {
                MovieId = _movieId,
                CustomerName = _txtCustomer.Text.Trim(),
                SeatNumber = _selectedSeat,
                BookingDate = DateTime.Today,
                TicketPrice = (double)_numPrice.Value,
                Status = _cmbStatus.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        // ════════════════════════════════════════════════════════════════
        //  HELPERS
        // ════════════════════════════════════════════════════════════════
        private static GraphicsPath RoundedRect(Rectangle r, int rad)
        {
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, rad * 2, rad * 2, 180, 90);
            p.AddArc(r.Right - rad * 2, r.Y, rad * 2, rad * 2, 270, 90);
            p.AddArc(r.Right - rad * 2, r.Bottom - rad * 2, rad * 2, rad * 2, 0, 90);
            p.AddArc(r.X, r.Bottom - rad * 2, rad * 2, rad * 2, 90, 90);
            p.CloseFigure();
            return p;
        }

        private static void AddBottomLabel(Panel p, string text, int x, int y)
        {
            p.Controls.Add(new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(120, 130, 160),
                Location = new Point(x, y),
                AutoSize = true
            });
        }

        private void DragForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); }
        }

        [DllImport("user32.dll")] private static extern bool ReleaseCapture();
        [DllImport("user32.dll")] private static extern int SendMessage(IntPtr h, int m, int w, int l);
    }
}