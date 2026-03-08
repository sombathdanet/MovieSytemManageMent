// ============================================================
// FILE: Controls/AddBookingDialog.cs
// FINAL UI REFINEMENT: Fixed Label Clipping & Wrap Issues
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MovieSytemManageMent.Controls
{
    public class AddBookingDialog : Form
    {
        public Booking NewBooking { get; private set; }
        private readonly int _movieId;
        private readonly Movie _movie;
        private readonly HashSet<string> _bookedSeats;

        private string _selectedSeat = null;
        private string _hoveredSeat = null;

        private class FoodItem
        {
            public string Emoji { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public int Qty { get; set; }
        }

        private readonly List<FoodItem> _menu = new List<FoodItem>
        {
            new FoodItem { Emoji="🍿", Name="Popcorn Large", Price=4.50 },
            new FoodItem { Emoji="🍿", Name="Popcorn Small", Price=2.50 },
            new FoodItem { Emoji="🥤", Name="Cola Large",    Price=3.50 },
            new FoodItem { Emoji="🥤", Name="Cola Small",    Price=2.00 },
            new FoodItem { Emoji="🧃", Name="Juice",         Price=2.50 },
            new FoodItem { Emoji="☕", Name="Coffee",        Price=3.00 },
            new FoodItem { Emoji="🌭", Name="Hot Dog",       Price=5.00 },
            new FoodItem { Emoji="🍫", Name="Chocolate",     Price=2.00 },
            new FoodItem { Emoji="🍬", Name="Candy",         Price=1.50 },
            new FoodItem { Emoji="💧", Name="Water",         Price=1.50 }
        };

        private readonly Color _navy = Color.FromArgb(18, 26, 60);
        private readonly Color _bgForm = Color.FromArgb(240, 242, 248);
        private readonly Color _accentBlue = Color.FromArgb(41, 98, 196);
        private readonly Color _seatAvail = Color.FromArgb(210, 215, 230);
        private readonly Color _seatSelected = Color.FromArgb(41, 98, 196);
        private readonly Color _seatOccupied = Color.FromArgb(230, 60, 60);

        private TextBox _txtCustomer;
        private Panel _seatGridPanel;
        private ComboBox _cmbPayment, _cmbStatus;
        private NumericUpDown _numTicketPrice;
        private Label _lblSeatDisplay, _lblFoodTotal, _lblGrandTotal;

        public AddBookingDialog(int movieId, Movie movie = null)
        {
            _movieId = movieId;
            _movie = movie ?? new Movie { Id = movieId, Title = "Cinema Movie", Rating = 8.5 };
            _bookedSeats = new HashSet<string>(
                BookingRepository.Instance.GetByMovieId(_movieId)
                .Where(b => b.Status != "Cancelled")
                .Select(b => b.SeatNumber), StringComparer.OrdinalIgnoreCase);

            BuildUI();
            UpdateTotal();
        }
        private void BuildUI()
        {
            this.Size = new Size(1200, 700);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = _bgForm;

            // TOP BAR
            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = _navy };
            pnlTop.MouseDown += DragForm;
            var lblTopTitle = new Label { Text = "Ticket Booking", ForeColor = Color.White, Font = new Font("Segoe UI", 14, FontStyle.Bold), Left = 24, Top = 18, AutoSize = true };
            var btnClose = new Button { Text = "✕", Dock = DockStyle.Right, Width = 60, FlatStyle = FlatStyle.Flat, ForeColor = Color.White, Font = new Font("Arial", 12), Cursor = Cursors.Hand };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();
            pnlTop.Controls.AddRange(new Control[] { lblTopTitle, btnClose });

            // BODY
            var pnlBody = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };

            // Create the panels
            var pnlLeft = BuildLeftPanel();
            var pnlRight = BuildFoodPanel();
            var pnlMiddle = BuildSeatPanel();

            // ✅ SET DOCKING FOR LEFT PANEL (This was missing!)
            pnlLeft.Dock = DockStyle.Left;

            // ✅ ADD ORDER IS CRITICAL:
            // 1. Add docked sides first
            pnlBody.Controls.Add(pnlLeft);
            pnlBody.Controls.Add(pnlRight);
            // 2. Add the "Fill" panel LAST
            pnlBody.Controls.Add(pnlMiddle);

            this.Controls.Add(pnlBody);
            this.Controls.Add(BuildBottomBar());
            this.Controls.Add(pnlTop);
        }

        private Panel BuildLeftPanel()
        {
            var pnl = new Panel { Size = new Size(300, 570), BackColor = Color.White };

            // 1. Error Label (Hidden by default)
            var lblLoadFail = new Label
            {
                Text = "⚠️ Image Not Found",
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(200, 40),
                Location = new Point(50, 130),
                Visible = false
            };

            // 2. PictureBox Setup
            var picPoster = new PictureBox
            {
                Size = new Size(260, 360), // Made it taller for a better cinema look
                Location = new Point(20, 20),
                BackColor = Color.FromArgb(240, 240, 245),
                SizeMode = PictureBoxSizeMode.Zoom,
                WaitOnLoad = false
            };

            // 3. The "Magic" fix for the 404/Loading issue
            picPoster.LoadCompleted += (s, e) => {
                if (e.Error != null) lblLoadFail.Visible = true;
                else picPoster.Invalidate();
            };

            // 4. Load the URL from the _movie object passed in the constructor
            if (_movie != null && !string.IsNullOrEmpty(_movie.PosterUrl))
            {
                try { picPoster.LoadAsync(_movie.PosterUrl); }
                catch { lblLoadFail.Visible = true; }
            }
            else { lblLoadFail.Visible = true; }

            // Apply rounded corners
            picPoster.Region = new Region(RoundedRect(new Rectangle(0, 0, 260, 360), 12));

            // 5. Labels - Adjusted Y coordinates so they don't overlap
            var lblTitle = new Label
            {
                Text = _movie.Title,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = _navy,
                Location = new Point(20, 390), // Moved below the taller PictureBox
                Size = new Size(260, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblCustPrompt = new Label
            {
                Text = "CUSTOMER NAME",
                Font = new Font("Segoe UI", 7, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(25, 480),
                AutoSize = true
            };

            // Ensure _txtCustomer is positioned correctly
            _txtCustomer = new TextBox
            {
                Location = new Point(20, 500),
                Size = new Size(260, 30),
                Font = new Font("Segoe UI", 11)
            };

            // 6. ADD ALL CONTROLS (Order matters!)
            pnl.Controls.Add(lblLoadFail);
            pnl.Controls.Add(picPoster);
            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblCustPrompt);
            pnl.Controls.Add(_txtCustomer);

            lblLoadFail.BringToFront();

            return pnl;
        }

        private void DrawCardBorder(object sender, PaintEventArgs e, Panel pnl)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a rectangle that is slightly smaller than the panel to avoid clipping
            RectangleF rect = new RectangleF(0, 0, pnl.Width - 1, pnl.Height - 1);

            using (GraphicsPath path = RoundedRect(rect, 10))
            using (Pen pen = new Pen(Color.FromArgb(220, 225, 240), 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private Panel BuildSeatPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Fill, BackColor = _bgForm, Padding = new Padding(10) };
            var inner = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            var lblHdr = new Label { Text = "Seat Selection", Dock = DockStyle.Top, Height = 50, Font = new Font("Segoe UI", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };

            _seatGridPanel = new Panel { Dock = DockStyle.Fill };
            _seatGridPanel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(_seatGridPanel, true, null);
            _seatGridPanel.Paint += RenderSeatGrid;
            _seatGridPanel.MouseClick += HandleSeatClick;
            _seatGridPanel.MouseMove += (s, e) => {
                var hit = HitTest(e.Location);
                if (hit != _hoveredSeat) { _hoveredSeat = hit; _seatGridPanel.Invalidate(); }
            };

            inner.Controls.Add(_seatGridPanel);
            inner.Controls.Add(lblHdr);
            pnl.Controls.Add(inner);
            return pnl;
        }

        private Panel BuildFoodPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Right, Width = 230, BackColor = Color.White, Padding = new Padding(5) };
            var lblHdr = new Label { Text = "Food & Drinks", Dock = DockStyle.Top, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
            pnl.Controls.Add(lblHdr);

            var scrollContainer = new Panel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(0, 0, 10, 0) };
            int yPos = 0;

            foreach (var item in _menu)
            {
                var row = new Panel { Width = 200, Height = 55, Top = yPos, Left = 0, BackColor = Color.FromArgb(250, 250, 252), Padding = new Padding(5) };

                var lblInfo = new Label { Text = $"{item.Emoji} {item.Name}\n${item.Price:0.00}", Dock = DockStyle.Left, Width = 110, Font = new Font("Segoe UI", 8, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft, AutoSize = false };

                var btnPlus = new Button { Text = "+", Size = new Size(26, 26), Top = 14, Left = 170, FlatStyle = FlatStyle.Flat, BackColor = _accentBlue, ForeColor = Color.White, Cursor = Cursors.Hand };
                var lblQty = new Label { Text = "0", Size = new Size(25, 26), Top = 14, Left = 145, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
                var btnMinus = new Button { Text = "-", Size = new Size(26, 26), Top = 14, Left = 119, FlatStyle = FlatStyle.Flat, BackColor = Color.LightGray, Cursor = Cursors.Hand };

                btnPlus.FlatAppearance.BorderSize = 0; btnMinus.FlatAppearance.BorderSize = 0;

                btnPlus.Click += (s, e) => { item.Qty++; lblQty.Text = item.Qty.ToString(); UpdateTotal(); };
                btnMinus.Click += (s, e) => { if (item.Qty > 0) { item.Qty--; lblQty.Text = item.Qty.ToString(); UpdateTotal(); } };

                row.Controls.AddRange(new Control[] { lblInfo, btnMinus, lblQty, btnPlus });
                scrollContainer.Controls.Add(row);
                yPos += 58;
            }
            pnl.Controls.Add(scrollContainer);
            return pnl;
        }

        private Panel BuildBottomBar()
        {
            var pnl = new Panel { Dock = DockStyle.Bottom, Height = 80, BackColor = Color.White, Padding = new Padding(10) };

            void AddGroup(Control c, string title, int x, int w)
            {
                var lbl = new Label { Text = title, Left = x, Top = 12, Width = w, Font = new Font("Segoe UI", 7, FontStyle.Bold), ForeColor = Color.Gray };
                c.Left = x; c.Top = 32; c.Width = w;
                pnl.Controls.Add(lbl); pnl.Controls.Add(c);
            }

            _lblSeatDisplay = new Label { Text = "None", Font = new Font("Segoe UI", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, BorderStyle = BorderStyle.FixedSingle, AutoSize = false };
            _cmbPayment = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9) };
            _cmbPayment.Items.AddRange(new[] { "Cash", "ABA Pay", "Credit Card" }); _cmbPayment.SelectedIndex = 0;

            _cmbStatus = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9) };
            _cmbStatus.Items.AddRange(new[] { "Confirmed", "Pending" }); _cmbStatus.SelectedIndex = 0;

            _numTicketPrice = new NumericUpDown { DecimalPlaces = 2, Value = 12.00M, Font = new Font("Segoe UI", 9) };
            _numTicketPrice.ValueChanged += (s, e) => UpdateTotal();

            _lblFoodTotal = new Label { Text = "$0.00", Font = new Font("Segoe UI", 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft, AutoSize = false, Height = 30 };

            // Fixed Grand Total width and AutoSize to prevent clipping
            _lblGrandTotal = new Label { Text = "$0.00", Font = new Font("Segoe UI", 15, FontStyle.Bold), ForeColor = _accentBlue, TextAlign = ContentAlignment.MiddleLeft, AutoSize = false, Height = 35, Width = 160 };

            var btnBook = new Button { Text = "CONFIRM BOOKING", Width = 160, Height = 45, Left = 1010, Top = 18, FlatStyle = FlatStyle.Flat, BackColor = _navy, ForeColor = Color.White, Font = new Font("Segoe UI", 9, FontStyle.Bold), Cursor = Cursors.Hand };
            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.Click += HandleBookClick;

            // Updated coordinates to ensure NO clipping even with large totals
            AddGroup(_lblSeatDisplay, "SEAT", 20, 80);
            AddGroup(_cmbPayment, "PAYMENT", 115, 125);
            AddGroup(_cmbStatus, "STATUS", 255, 115);
            AddGroup(_numTicketPrice, "PRICE ($)", 385, 105);
            AddGroup(_lblFoodTotal, "ADD-ONS", 505, 95);
            AddGroup(_lblGrandTotal, "TOTAL", 615, 160);
            pnl.Controls.Add(btnBook);

            return pnl;
        }

        private void UpdateTotal()
        {
            double food = _menu.Sum(x => x.Qty * x.Price);
            double ticket = (_selectedSeat != null) ? (double)_numTicketPrice.Value : 0;
            _lblFoodTotal.Text = $"${food:0.00}";
            _lblGrandTotal.Text = $"${(food + ticket):0.00}";
            _lblSeatDisplay.Text = _selectedSeat ?? "None";
        }

        private void RenderSeatGrid(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int centerX = _seatGridPanel.Width / 2;
            using (var p = new Pen(Color.Silver, 3))
            {
                g.DrawArc(p, centerX - 200, 10, 400, 50, 200, 140);
                g.DrawString("SCREEN", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Silver, centerX - 25, 35);
            }
            int startX = centerX - (10 * 45 + 16) / 2;
            int startY = 90;
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    string id = $"{(char)('A' + r)}{c + 1}";
                    int x = startX + (c * 45) + (c >= 5 ? 16 : 0);
                    int y = startY + (r * 45);
                    var rect = new Rectangle(x, y, 38, 38);
                    Color fill = _bookedSeats.Contains(id) ? _seatOccupied : (id == _selectedSeat ? _seatSelected : _seatAvail);
                    if (id == _hoveredSeat && !_bookedSeats.Contains(id)) fill = Color.FromArgb(100, _accentBlue);
                    using (var path = GetRoundedRect(rect, 8))
                    {
                        g.FillPath(new SolidBrush(fill), path);
                        g.DrawString(id, new Font("Segoe UI", 7, FontStyle.Bold), Brushes.White, x + 6, y + 12);
                    }
                }
            }
        }

        private string HitTest(Point p)
        {
            int centerX = _seatGridPanel.Width / 2;
            int startX = centerX - (10 * 45 + 16) / 2;
            int startY = 90;
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 10; c++)
                {
                    int x = startX + (c * 45) + (c >= 5 ? 16 : 0);
                    int y = startY + (r * 45);
                    if (new Rectangle(x, y, 38, 38).Contains(p)) return $"{(char)('A' + r)}{c + 1}";
                }
            return null;
        }

        private void HandleSeatClick(object sender, MouseEventArgs e)
        {
            string hit = HitTest(e.Location);
            if (hit == null || _bookedSeats.Contains(hit)) return;
            _selectedSeat = (_selectedSeat == hit) ? null : hit;
            _seatGridPanel.Invalidate();
            UpdateTotal();
        }

        private void HandleBookClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtCustomer.Text) || _selectedSeat == null)
            {
                MessageBox.Show("Please enter name and select a seat."); return;
            }
            NewBooking = new Booking { MovieId = _movieId, CustomerName = _txtCustomer.Text.Trim(), SeatNumber = _selectedSeat, BookingDate = DateTime.Now, TicketPrice = _menu.Sum(x => x.Qty * x.Price) + (double)_numTicketPrice.Value, Status = _cmbStatus.Text };
            this.DialogResult = DialogResult.OK;
        }

        private GraphicsPath GetRoundedRect(Rectangle b, int r)
        {
            var path = new GraphicsPath();
            path.AddArc(b.X, b.Y, r * 2, r * 2, 180, 90);
            path.AddArc(b.Right - r * 2, b.Y, r * 2, r * 2, 270, 90);
            path.AddArc(b.Right - r * 2, b.Bottom - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(b.X, b.Bottom - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();
            return path;
        }

        [DllImport("user32.dll")] private static extern bool ReleaseCapture();
        [DllImport("user32.dll")] private static extern int SendMessage(IntPtr h, int m, int w, int l);
        private void DragForm(object s, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); } }

        private static GraphicsPath RoundedRect(RectangleF r, float rad)
        {
            var p = new GraphicsPath();
            float d = rad * 2;
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }
    }
}
