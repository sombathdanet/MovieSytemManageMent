using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MovieSytemManageMent.ApplicationForm.AdminForm
{
    partial class MoviesAdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ── 1. Create Instances ──────────────────────────────────────
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            lblFormSubtitle = new Label();
            pnlLeft = new Panel();
            pnlSearchBox = new Panel();
            txtMovieSearch = new TextBox();
            lstMovies = new ListBox();
            splitter = new Splitter();
            pnlRight = new Panel();
            pnlBookingHeader = new Panel();
            lblBookingTitle = new Label();
            lblSelectedMovie = new Label();
            pnlBookingStats = new Panel();
            pnlStatConfirmed = new Panel();
            pnlStatPending = new Panel();
            pnlStatCancelled = new Panel();
            pnlStatRevenue = new Panel();
            lblStatConfirmedNum = new Label();
            lblStatConfirmedTxt = new Label();
            lblStatPendingNum = new Label();
            lblStatPendingTxt = new Label();
            lblStatCancelledNum = new Label();
            lblStatCancelledTxt = new Label();
            lblStatRevenueNum = new Label();
            lblStatRevenueTxt = new Label();
            pnlBookingActions = new Panel();
            btnAddBooking = new Button();
            btnDeleteBooking = new Button();
            btnChangeStatus = new Button();
            dgvBookings = new DataGridView();
            pnlStatusBar = new Panel();
            lblStatus = new Label();

            // ── 2. Color Palette & Styles ────────────────────────────────
            var navy = Color.FromArgb(28, 35, 64);
            var accentBlue = Color.FromArgb(54, 105, 255);
            var bgGray = Color.FromArgb(242, 245, 250);
            var mutedText = Color.FromArgb(140, 150, 180);

            // ── 3. Header ────────────────────────────────────────────────
            pnlHeader.BackColor = Color.White;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 85;
            pnlHeader.Controls.AddRange(new Control[] { lblFormTitle, lblFormSubtitle });

            // ADD THIS LINE BELOW:
            lblMovieListCount = new Label();

            lblFormTitle.Text = "MovieBase Admin";
            lblFormTitle.Font = new Font("Segoe UI Semibold", 16F);
            lblFormTitle.ForeColor = navy;
            lblFormTitle.Location = new Point(25, 20);
            lblFormTitle.AutoSize = true;

            lblFormSubtitle.Text = "Manage your cinema catalog and track live bookings";
            lblFormSubtitle.Font = new Font("Segoe UI", 9F);
            lblFormSubtitle.ForeColor = mutedText;
            lblFormSubtitle.Location = new Point(27, 52);
            lblFormSubtitle.AutoSize = true;

            // ── 4. Left Sidebar ──────────────────────────────────────────
            pnlLeft.BackColor = Color.White;
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Width = 320;

            pnlSearchBox.Dock = DockStyle.Top;
            pnlSearchBox.Height = 70;
            pnlSearchBox.Padding = new Padding(20, 20, 20, 10);

            txtMovieSearch.BackColor = Color.FromArgb(245, 247, 251);
            txtMovieSearch.BorderStyle = BorderStyle.FixedSingle;
            txtMovieSearch.Dock = DockStyle.Fill;
            txtMovieSearch.Font = new Font("Segoe UI", 11F);
            txtMovieSearch.ForeColor = Color.FromArgb(120, 140, 180);
            txtMovieSearch.Text = "Search movies...";
            pnlSearchBox.Controls.Add(txtMovieSearch);

            lstMovies.BorderStyle = BorderStyle.None;
            lstMovies.Dock = DockStyle.Fill;
            lstMovies.DrawMode = DrawMode.OwnerDrawFixed;
            lstMovies.ItemHeight = 70;
            lstMovies.Font = new Font("Segoe UI", 10F);
            pnlLeft.Controls.Add(lstMovies);
            pnlLeft.Controls.Add(pnlSearchBox);

            splitter.Dock = DockStyle.Left;
            splitter.Width = 1;
            splitter.BackColor = Color.FromArgb(230, 233, 240);

            // ── 5. Right Content Area ────────────────────────────────────
            pnlRight.BackColor = bgGray;
            pnlRight.Dock = DockStyle.Fill;

            pnlBookingHeader.Dock = DockStyle.Top;
            pnlBookingHeader.Height = 70;
            pnlBookingHeader.Padding = new Padding(25, 20, 0, 0);
            pnlBookingHeader.Controls.AddRange(new Control[] { lblBookingTitle, lblSelectedMovie });

            lblBookingTitle.Text = "Booking Details";
            lblBookingTitle.Font = new Font("Segoe UI Bold", 13F);
            lblBookingTitle.ForeColor = navy;
            lblBookingTitle.Location = new Point(25, 15);
            lblBookingTitle.AutoSize = true;

            lblSelectedMovie.Text = "Select a movie to see performance";
            lblSelectedMovie.Font = new Font("Segoe UI", 9F);
            lblSelectedMovie.ForeColor = mutedText;
            lblSelectedMovie.Location = new Point(27, 40);
            lblSelectedMovie.AutoSize = true;

            // ── 6. Stat Cards Row ────────────────────────────────────────
            pnlBookingStats.Dock = DockStyle.Top;
            pnlBookingStats.Height = 120;
            pnlBookingStats.Padding = new Padding(20, 10, 20, 10);

            BuildStatCard(pnlStatConfirmed, lblStatConfirmedNum, lblStatConfirmedTxt, "0", "Confirmed", Color.FromArgb(46, 204, 113));
            BuildStatCard(pnlStatPending, lblStatPendingNum, lblStatPendingTxt, "0", "Pending", Color.FromArgb(241, 196, 15));
            BuildStatCard(pnlStatCancelled, lblStatCancelledNum, lblStatCancelledTxt, "0", "Cancelled", Color.FromArgb(231, 76, 60));
            BuildStatCard(pnlStatRevenue, lblStatRevenueNum, lblStatRevenueTxt, "$0.00", "Revenue", accentBlue);

            pnlBookingStats.Controls.AddRange(new Control[] { pnlStatRevenue, pnlStatCancelled, pnlStatPending, pnlStatConfirmed });
            pnlBookingStats.Resize += (s, e) => RepositionStatCards();

            // ── 7. Action Buttons ────────────────────────────────────────
            pnlBookingActions.Dock = DockStyle.Top;
            pnlBookingActions.Height = 65;
            pnlBookingActions.Padding = new Padding(25, 10, 25, 10);

            BuildActionBtn(btnAddBooking, "Add Booking", accentBlue, 0);
            BuildActionBtn(btnChangeStatus, "Cycle Status", Color.White, 1);
            btnChangeStatus.ForeColor = navy;
            btnChangeStatus.FlatAppearance.BorderSize = 1;
            btnChangeStatus.FlatAppearance.BorderColor = Color.FromArgb(200, 210, 230);

            BuildActionBtn(btnDeleteBooking, "Delete", Color.Transparent, 2);
            btnDeleteBooking.ForeColor = Color.FromArgb(231, 76, 60);

            pnlBookingActions.Controls.AddRange(new Control[] { btnChangeStatus, btnAddBooking, btnDeleteBooking });

            // ── 8. Data Grid ─────────────────────────────────────────────
            dgvBookings.Dock = DockStyle.Fill;
            dgvBookings.BackgroundColor = Color.White;
            dgvBookings.BorderStyle = BorderStyle.None;
            dgvBookings.RowTemplate.Height = 45;
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.ReadOnly = true;
            dgvBookings.RowHeadersVisible = false;

            Panel gridWrapper = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 0, 25, 20), BackColor = bgGray };
            gridWrapper.Controls.Add(dgvBookings);

            pnlRight.Controls.Add(gridWrapper);
            pnlRight.Controls.Add(pnlBookingActions);
            pnlRight.Controls.Add(pnlBookingStats);
            pnlRight.Controls.Add(pnlBookingHeader);

            // ── 9. Status Bar ────────────────────────────────────────────
            pnlStatusBar.Dock = DockStyle.Bottom;
            pnlStatusBar.Height = 30;
            pnlStatusBar.BackColor = Color.White;
            lblStatus.Text = "System Ready";
            lblStatus.Font = new Font("Segoe UI", 8F);
            lblStatus.ForeColor = mutedText;
            lblStatus.Location = new Point(15, 7);
            pnlStatusBar.Controls.Add(lblStatus);

            // ── 10. Final Form Setup ─────────────────────────────────────
            this.ClientSize = new Size(1150, 750);
            this.Controls.Add(pnlRight);
            this.Controls.Add(splitter);
            this.Controls.Add(pnlLeft);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlStatusBar);
            this.Text = "Movie System Admin";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Shown += (s, e) => RepositionStatCards();

            InitializeGridColumns();
        }

        private void InitializeGridColumns()
        {
            dgvBookings.Columns.Clear();
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "#", FillWeight = 30 });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCustomer", HeaderText = "Customer", FillWeight = 150 });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSeat", HeaderText = "Seat", FillWeight = 60 });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDate", HeaderText = "Date", FillWeight = 100 });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrice", HeaderText = "Price", FillWeight = 80 });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Status", FillWeight = 100 });
        }

        private void BuildStatCard(Panel pnl, Label num, Label txt, string val, string label, Color accent)
        {
            pnl.BackColor = Color.White;
            pnl.Size = new Size(200, 90);
            num.Text = val;
            num.Font = new Font("Segoe UI Bold", 18F);
            num.Location = new Point(15, 10);
            num.AutoSize = true;
            txt.Text = label.ToUpper();
            txt.Font = new Font("Segoe UI Semibold", 7F);
            txt.ForeColor = Color.FromArgb(160, 170, 190);
            txt.Location = new Point(18, 55);
            pnl.Controls.AddRange(new Control[] { num, txt });
            pnl.Paint += (s, e) => {
                e.Graphics.FillRectangle(new SolidBrush(accent), 0, 0, 4, pnl.Height);
            };
        }

        private void RepositionStatCards()
        {
            var cards = new[] { pnlStatConfirmed, pnlStatPending, pnlStatCancelled, pnlStatRevenue };
            int margin = 25;
            int gap = 15;
            int availableWidth = pnlBookingStats.Width - (margin * 2) - (gap * (cards.Length - 1));
            int cardWidth = availableWidth / cards.Length;

            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Width = cardWidth;
                cards[i].Location = new Point(margin + i * (cardWidth + gap), 15);
            }
        }

        private void BuildActionBtn(Button btn, string text, Color bg, int idx)
        {
            btn.Text = text;
            btn.Size = new Size(140, 40);
            btn.Location = new Point(25 + (idx * 155), 12);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = bg;
            btn.ForeColor = bg == Color.White ? Color.Black : Color.White;
            btn.Font = new Font("Segoe UI Semibold", 9F);
            btn.Cursor = Cursors.Hand;
        }

        #endregion

        // All fields preserved to ensure logic file works
        private Panel pnlHeader, pnlLeft, pnlRight, pnlSearchBox, pnlBookingHeader, pnlBookingStats, pnlBookingActions, pnlStatusBar;
        private Panel pnlStatConfirmed, pnlStatPending, pnlStatCancelled, pnlStatRevenue;
        private Label lblFormTitle, lblFormSubtitle, lblBookingTitle, lblSelectedMovie, lblStatus, lblMovieListCount;
        private Label lblStatConfirmedNum, lblStatConfirmedTxt, lblStatPendingNum, lblStatPendingTxt, lblStatCancelledNum, lblStatCancelledTxt, lblStatRevenueNum, lblStatRevenueTxt;
        private TextBox txtMovieSearch;
        private ListBox lstMovies;
        private DataGridView dgvBookings;
        private Button btnAddBooking, btnDeleteBooking, btnChangeStatus;
        private Splitter splitter;
    }
}