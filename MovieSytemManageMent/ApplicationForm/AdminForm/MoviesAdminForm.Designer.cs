// ============================================================
// FILE: ApplicationForm/AdminForm/MoviesAdminForm.Designer.cs
// FIXES:
//   1. BuildStatCard() now called with correct positions
//   2. BuildActionBtn() now called with correct positions  
//   3. DataGridView columns have proper names + HeaderText
//   4. DGV properly configured (ReadOnly, MultiSelect, etc.)
//   5. All stat labels wired into their parent panels
// ============================================================
using System.Drawing;
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
            // ── Declare controls ──────────────────────────────────────────
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            lblFormSubtitle = new Label();
            pnlLeft = new Panel();
            pnlLeftHeader = new Panel();
            lblMovieListTitle = new Label();
            lblMovieListCount = new Label();
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
            lblStatConfirmedNum = new Label();
            lblStatConfirmedTxt = new Label();
            pnlStatPending = new Panel();
            lblStatPendingNum = new Label();
            lblStatPendingTxt = new Label();
            pnlStatCancelled = new Panel();
            lblStatCancelledNum = new Label();
            lblStatCancelledTxt = new Label();
            pnlStatRevenue = new Panel();
            lblStatRevenueNum = new Label();
            lblStatRevenueTxt = new Label();
            pnlBookingActions = new Panel();
            btnAddBooking = new Button();
            btnDeleteBooking = new Button();
            btnChangeStatus = new Button();
            dgvBookings = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            pnlStatusBar = new Panel();
            lblStatus = new Label();
            // ── Colours ───────────────────────────────────────────────────
            Color navy = Color.FromArgb(12, 26, 58);
            Color blue = Color.FromArgb(41, 98, 196);
            Color white = Color.White;
            Color bg = Color.FromArgb(238, 242, 252);
            Color muted = Color.FromArgb(120, 140, 180);
            Color green = Color.FromArgb(34, 170, 130);
            Color orange = Color.FromArgb(230, 130, 30);
            Color red = Color.FromArgb(214, 60, 60);
            Color border = Color.FromArgb(215, 222, 240);
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlSearchBox.SuspendLayout();
            pnlLeftHeader.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlBookingHeader.SuspendLayout();
            pnlBookingStats.SuspendLayout();
            pnlBookingActions.SuspendLayout();
            pnlStatusBar.SuspendLayout();
            SuspendLayout();
            // ════════════════════════════════════════════════════════════
            // HEADER
            // ════════════════════════════════════════════════════════════
            pnlHeader.BackColor = navy;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 65;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Controls.AddRange(new Control[] { lblFormTitle, lblFormSubtitle });
            lblFormTitle.Text = "🎬  Movies Admin";
            lblFormTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFormTitle.ForeColor = white;
            lblFormTitle.AutoSize = true;
            lblFormTitle.Location = new Point(20, 12);
            lblFormTitle.Name = "lblFormTitle";
            lblFormSubtitle.Text = "Manage movie inventories and real-time bookings";
            lblFormSubtitle.Font = new Font("Segoe UI", 8.5F);
            lblFormSubtitle.ForeColor = Color.FromArgb(140, 170, 230);
            lblFormSubtitle.AutoSize = true;
            lblFormSubtitle.Location = new Point(22, 38);
            lblFormSubtitle.Name = "lblFormSubtitle";
            // ════════════════════════════════════════════════════════════
            // STATUS BAR
            // ════════════════════════════════════════════════════════════
            pnlStatusBar.BackColor = white;
            pnlStatusBar.Dock = DockStyle.Bottom;
            pnlStatusBar.Height = 30;
            pnlStatusBar.Name = "pnlStatusBar";
            pnlStatusBar.Controls.Add(lblStatus);
            lblStatus.Text = "Ready — select a movie to view its bookings.";
            lblStatus.Font = new Font("Segoe UI", 8.5F);
            lblStatus.ForeColor = muted;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(15, 7);
            lblStatus.Name = "lblStatus";
            // ════════════════════════════════════════════════════════════
            // LEFT PANEL — movie list
            // ════════════════════════════════════════════════════════════
            pnlLeft.BackColor = white;
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Width = 300;
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Controls.AddRange(new Control[] { lstMovies, pnlSearchBox, pnlLeftHeader });
            // Left header
            pnlLeftHeader.BackColor = white;
            pnlLeftHeader.Dock = DockStyle.Top;
            pnlLeftHeader.Height = 45;
            pnlLeftHeader.Padding = new Padding(15, 0, 0, 0);
            pnlLeftHeader.Name = "pnlLeftHeader";
            pnlLeftHeader.Controls.AddRange(new Control[] { lblMovieListTitle, lblMovieListCount });
            lblMovieListTitle.Text = "Catalog";
            lblMovieListTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMovieListTitle.ForeColor = navy;
            lblMovieListTitle.AutoSize = true;
            lblMovieListTitle.Location = new Point(15, 12);
            lblMovieListTitle.Name = "lblMovieListTitle";
            lblMovieListCount.Text = "(0)";
            lblMovieListCount.Font = new Font("Segoe UI", 9F);
            lblMovieListCount.ForeColor = muted;
            lblMovieListCount.AutoSize = true;
            lblMovieListCount.Location = new Point(92, 14);
            lblMovieListCount.Name = "lblMovieListCount";
            // Search box
            pnlSearchBox.BackColor = white;
            pnlSearchBox.Dock = DockStyle.Top;
            pnlSearchBox.Height = 50;
            pnlSearchBox.Padding = new Padding(15, 5, 15, 10);
            pnlSearchBox.Name = "pnlSearchBox";
            pnlSearchBox.Controls.Add(txtMovieSearch);
            txtMovieSearch.Dock = DockStyle.Fill;
            txtMovieSearch.Font = new Font("Segoe UI", 10F);
            txtMovieSearch.ForeColor = muted;
            txtMovieSearch.BorderStyle = BorderStyle.FixedSingle;
            txtMovieSearch.Text = "Search movies...";
            txtMovieSearch.Name = "txtMovieSearch";
            // Movie ListBox
            lstMovies.BackColor = white;
            lstMovies.BorderStyle = BorderStyle.None;
            lstMovies.Dock = DockStyle.Fill;
            lstMovies.DrawMode = DrawMode.OwnerDrawFixed;
            lstMovies.Font = new Font("Segoe UI", 10F);
            lstMovies.ForeColor = navy;
            lstMovies.ItemHeight = 60;
            lstMovies.Name = "lstMovies";
            // Splitter
            splitter.BackColor = border;
            splitter.Dock = DockStyle.Left;
            splitter.Width = 1;
            splitter.Name = "splitter";
            // ════════════════════════════════════════════════════════════
            // RIGHT PANEL
            // ════════════════════════════════════════════════════════════
            pnlRight.BackColor = bg;
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Name = "pnlRight";
            // Order: Fill first, then Top panels
            pnlRight.Controls.AddRange(new Control[] { dgvBookings, pnlBookingActions, pnlBookingStats, pnlBookingHeader });
            // ── Booking header ────────────────────────────────────────────
            pnlBookingHeader.BackColor = bg;
            pnlBookingHeader.Dock = DockStyle.Top;
            pnlBookingHeader.Height = 60;
            pnlBookingHeader.Padding = new Padding(20, 15, 20, 0);
            pnlBookingHeader.Name = "pnlBookingHeader";
            pnlBookingHeader.Controls.AddRange(new Control[] { lblBookingTitle, lblSelectedMovie });
            lblBookingTitle.Text = "Active Bookings";
            lblBookingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBookingTitle.ForeColor = navy;
            lblBookingTitle.AutoSize = true;
            lblBookingTitle.Location = new Point(20, 10);
            lblBookingTitle.Name = "lblBookingTitle";
            lblSelectedMovie.Text = "Select a movie to filter results";
            lblSelectedMovie.Font = new Font("Segoe UI", 9F);
            lblSelectedMovie.ForeColor = muted;
            lblSelectedMovie.AutoSize = true;
            lblSelectedMovie.Location = new Point(22, 33);
            lblSelectedMovie.Name = "lblSelectedMovie";
            // ── Stat cards row ────────────────────────────────────────────
            pnlBookingStats.BackColor = bg;
            pnlBookingStats.Dock = DockStyle.Top;
            pnlBookingStats.Height = 100;
            pnlBookingStats.Padding = new Padding(20, 10, 20, 20);
            pnlBookingStats.Name = "pnlBookingStats";
            pnlBookingStats.Controls.AddRange(new Control[] { pnlStatConfirmed, pnlStatPending, pnlStatCancelled, pnlStatRevenue });
            // ✅ FIX 1: Actually CALL BuildStatCard() for each card
            // This was the main bug — cards were declared but never positioned/styled
            BuildStatCard(pnlStatConfirmed, lblStatConfirmedNum, lblStatConfirmedTxt, "0", "Confirmed", green, 0);
            BuildStatCard(pnlStatPending, lblStatPendingNum, lblStatPendingTxt, "0", "Pending", orange, 155);
            BuildStatCard(pnlStatCancelled, lblStatCancelledNum, lblStatCancelledTxt, "0", "Cancelled", red, 310);
            BuildStatCard(pnlStatRevenue, lblStatRevenueNum, lblStatRevenueTxt, "$0.00", "Revenue", blue, 465);
            // ── Action buttons bar ────────────────────────────────────────
            pnlBookingActions.BackColor = white;
            pnlBookingActions.Dock = DockStyle.Top;
            pnlBookingActions.Height = 55;
            pnlBookingActions.Padding = new Padding(20, 5, 20, 10);
            pnlBookingActions.Name = "pnlBookingActions";
            pnlBookingActions.Controls.AddRange(new Control[] { btnAddBooking, btnDeleteBooking, btnChangeStatus });
            // ✅ FIX 2: Actually CALL BuildActionBtn() for each button
            // This was the second bug — buttons all stacked at Point(0,0)
            BuildActionBtn(btnAddBooking, "➕  Add Booking", blue, 0);
            BuildActionBtn(btnDeleteBooking, "🗑  Delete", red, 150);
            BuildActionBtn(btnChangeStatus, "🔄  Change Status", orange, 300);
            // ════════════════════════════════════════════════════════════
            // DATAGRIDVIEW
            // ════════════════════════════════════════════════════════════
            dgvBookings.Dock = DockStyle.Fill;
            dgvBookings.BackgroundColor = white;
            dgvBookings.BorderStyle = BorderStyle.None;
            dgvBookings.Name = "dgvBookings";
            // ✅ FIX 3: Missing DGV configuration
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.ReadOnly = true;
            dgvBookings.MultiSelect = false;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.RowTemplate.Height = 38;
            dgvBookings.Font = new Font("Segoe UI", 9.5F);
            dgvBookings.GridColor = border;
            dgvBookings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            // Alternating row colour
            dgvBookings.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 252);
            // Selection colour
            dgvBookings.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 215, 245);
            dgvBookings.DefaultCellStyle.SelectionForeColor = navy;
            dgvBookings.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgvBookings.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            // Header style
            dgvBookings.EnableHeadersVisualStyles = false;
            dgvBookings.ColumnHeadersHeight = 42;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBookings.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvBookings.ColumnHeadersDefaultCellStyle.ForeColor = white;
            dgvBookings.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvBookings.ColumnHeadersDefaultCellStyle.SelectionBackColor = navy;
            dgvBookings.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            // ✅ FIX 4: Columns get proper names + HeaderText
            // Code-behind uses "colId", "colCustomer" etc. — must match exactly
            dataGridViewTextBoxColumn1.Name = "colId";
            dataGridViewTextBoxColumn1.HeaderText = "#";
            dataGridViewTextBoxColumn1.FillWeight = 5;
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn2.Name = "colCustomer";
            dataGridViewTextBoxColumn2.HeaderText = "Customer Name";
            dataGridViewTextBoxColumn2.FillWeight = 25;
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn3.Name = "colSeat";
            dataGridViewTextBoxColumn3.HeaderText = "Seat";
            dataGridViewTextBoxColumn3.FillWeight = 8;
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn4.Name = "colDate";
            dataGridViewTextBoxColumn4.HeaderText = "Booking Date";
            dataGridViewTextBoxColumn4.FillWeight = 18;
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn5.Name = "colPrice";
            dataGridViewTextBoxColumn5.HeaderText = "Ticket Price";
            dataGridViewTextBoxColumn5.FillWeight = 14;
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn6.Name = "colStatus";
            dataGridViewTextBoxColumn6.HeaderText = "Status";
            dataGridViewTextBoxColumn6.FillWeight = 15;
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // ✅ FIX 5: Actually ADD columns to the DataGridView
            dgvBookings.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            // ════════════════════════════════════════════════════════════
            // FORM
            // ════════════════════════════════════════════════════════════
            BackColor = bg;
            ClientSize = new Size(1100, 720);
            MinimumSize = new Size(860, 520);
            Font = new Font("Segoe UI", 9.5F);
            Name = "MoviesAdminForm";
            Text = "MovieBase — Movies Admin";
            StartPosition = FormStartPosition.CenterScreen;
            // Order matters: Fill → Left → Top → Bottom
            Controls.Add(pnlRight);
            Controls.Add(splitter);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);
            Controls.Add(pnlStatusBar);
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlSearchBox.ResumeLayout(false);
            pnlSearchBox.PerformLayout();
            pnlLeftHeader.ResumeLayout(false);
            pnlLeftHeader.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlBookingHeader.ResumeLayout(false);
            pnlBookingHeader.PerformLayout();
            pnlBookingStats.ResumeLayout(false);
            pnlBookingActions.ResumeLayout(false);
            pnlStatusBar.ResumeLayout(false);
            pnlStatusBar.PerformLayout();
            ResumeLayout(false);
        }

        // ════════════════════════════════════════════════════════════════
        //  BuildStatCard — styles + positions one stat card
        //  Called from InitializeComponent() above
        // ════════════════════════════════════════════════════════════════
        private void BuildStatCard(Panel pnl, Label numLbl, Label txtLbl,
                                    string num, string label,
                                    Color accent, int x)
        {
            pnl.BackColor = Color.White;
            pnl.Size = new Size(145, 70);
            pnl.Location = new Point(x + 20, 10);

            var bar = new Panel
            {
                BackColor = accent,
                Size = new Size(4, 70),
                Dock = DockStyle.Left
            };

            numLbl.Text = num;
            numLbl.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            numLbl.ForeColor = Color.FromArgb(12, 26, 58);
            numLbl.AutoSize = true;
            numLbl.Location = new Point(15, 10);

            txtLbl.Text = label.ToUpper();
            txtLbl.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            txtLbl.ForeColor = Color.Gray;
            txtLbl.AutoSize = true;
            txtLbl.Location = new Point(17, 40);

            pnl.Controls.AddRange(new Control[] { bar, numLbl, txtLbl });
        }

        // ════════════════════════════════════════════════════════════════
        //  BuildActionBtn — styles + positions one action button
        //  Called from InitializeComponent() above
        // ════════════════════════════════════════════════════════════════
        private void BuildActionBtn(Button btn, string text, Color back, int x)
        {
            btn.Text = text;
            btn.Size = new Size(130, 35);
            btn.Location = new Point(x + 20, 10);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = back;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        #endregion

        // ── Fields (all original names kept) ─────────────────────────────
        private Panel pnlHeader, pnlLeft, pnlRight;
        private Panel pnlLeftHeader, pnlSearchBox;
        private Panel pnlBookingHeader, pnlBookingStats, pnlBookingActions;
        private Panel pnlStatusBar;
        private Panel pnlStatConfirmed, pnlStatPending, pnlStatCancelled, pnlStatRevenue;
        private Splitter splitter;
        private Label lblFormTitle, lblFormSubtitle;
        private Label lblMovieListTitle, lblMovieListCount;
        private Label lblBookingTitle, lblSelectedMovie;
        private Label lblStatConfirmedNum, lblStatConfirmedTxt;
        private Label lblStatPendingNum, lblStatPendingTxt;
        private Label lblStatCancelledNum, lblStatCancelledTxt;
        private Label lblStatRevenueNum, lblStatRevenueTxt;
        private Label lblStatus;
        private TextBox txtMovieSearch;
        private ListBox lstMovies;
        private DataGridView dgvBookings;
        private Button btnAddBooking, btnDeleteBooking, btnChangeStatus;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}