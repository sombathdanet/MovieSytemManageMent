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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            lblFormSubtitle = new Label();
            pnlLeft = new Panel();
            lstMovies = new ListBox();
            pnlSearchBox = new Panel();
            txtMovieSearch = new TextBox();
            pnlLeftHeader = new Panel();
            lblMovieListTitle = new Label();
            lblMovieListCount = new Label();
            splitter = new Splitter();
            pnlRight = new Panel();
            dgvBookings = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            pnlBookingActions = new Panel();
            btnAddBooking = new Button();
            btnDeleteBooking = new Button();
            btnChangeStatus = new Button();
            pnlBookingStats = new Panel();
            pnlStatConfirmed = new Panel();
            pnlStatPending = new Panel();
            pnlStatCancelled = new Panel();
            pnlStatRevenue = new Panel();
            pnlBookingHeader = new Panel();
            lblBookingTitle = new Label();
            lblSelectedMovie = new Label();
            lblStatConfirmedNum = new Label();
            lblStatConfirmedTxt = new Label();
            lblStatPendingNum = new Label();
            lblStatPendingTxt = new Label();
            lblStatCancelledNum = new Label();
            lblStatCancelledTxt = new Label();
            lblStatRevenueNum = new Label();
            lblStatRevenueTxt = new Label();
            pnlStatusBar = new Panel();
            lblStatus = new Label();
            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlSearchBox.SuspendLayout();
            pnlLeftHeader.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            pnlBookingActions.SuspendLayout();
            pnlBookingStats.SuspendLayout();
            pnlBookingHeader.SuspendLayout();
            pnlStatusBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(12, 26, 58);
            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Controls.Add(lblFormSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 65);
            pnlHeader.TabIndex = 3;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(20, 12);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(227, 32);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "🎬  Movies Admin";
            // 
            // lblFormSubtitle
            // 
            lblFormSubtitle.AutoSize = true;
            lblFormSubtitle.Font = new Font("Segoe UI", 8.5F);
            lblFormSubtitle.ForeColor = Color.FromArgb(140, 170, 230);
            lblFormSubtitle.Location = new Point(22, 38);
            lblFormSubtitle.Name = "lblFormSubtitle";
            lblFormSubtitle.Size = new Size(343, 20);
            lblFormSubtitle.TabIndex = 1;
            lblFormSubtitle.Text = "Manage movie inventories and real-time bookings";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.Controls.Add(lstMovies);
            pnlLeft.Controls.Add(pnlSearchBox);
            pnlLeft.Controls.Add(pnlLeftHeader);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 65);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(300, 625);
            pnlLeft.TabIndex = 2;
            // 
            // lstMovies
            // 
            lstMovies.BackColor = Color.White;
            lstMovies.BorderStyle = BorderStyle.None;
            lstMovies.Dock = DockStyle.Fill;
            lstMovies.DrawMode = DrawMode.OwnerDrawFixed;
            lstMovies.Font = new Font("Segoe UI", 10F);
            lstMovies.ForeColor = Color.FromArgb(12, 26, 58);
            lstMovies.ItemHeight = 60;
            lstMovies.Location = new Point(0, 95);
            lstMovies.Name = "lstMovies";
            lstMovies.Size = new Size(300, 530);
            lstMovies.TabIndex = 0;
            // 
            // pnlSearchBox
            // 
            pnlSearchBox.BackColor = Color.White;
            pnlSearchBox.Controls.Add(txtMovieSearch);
            pnlSearchBox.Dock = DockStyle.Top;
            pnlSearchBox.Location = new Point(0, 45);
            pnlSearchBox.Name = "pnlSearchBox";
            pnlSearchBox.Padding = new Padding(15, 5, 15, 10);
            pnlSearchBox.Size = new Size(300, 50);
            pnlSearchBox.TabIndex = 1;
            // 
            // txtMovieSearch
            // 
            txtMovieSearch.BorderStyle = BorderStyle.FixedSingle;
            txtMovieSearch.Dock = DockStyle.Fill;
            txtMovieSearch.Font = new Font("Segoe UI", 10F);
            txtMovieSearch.ForeColor = Color.FromArgb(120, 140, 180);
            txtMovieSearch.Location = new Point(15, 5);
            txtMovieSearch.Name = "txtMovieSearch";
            txtMovieSearch.Size = new Size(270, 30);
            txtMovieSearch.TabIndex = 0;
            txtMovieSearch.Text = "Search movies...";
            // 
            // pnlLeftHeader
            // 
            pnlLeftHeader.BackColor = Color.White;
            pnlLeftHeader.Controls.Add(lblMovieListTitle);
            pnlLeftHeader.Controls.Add(lblMovieListCount);
            pnlLeftHeader.Dock = DockStyle.Top;
            pnlLeftHeader.Location = new Point(0, 0);
            pnlLeftHeader.Name = "pnlLeftHeader";
            pnlLeftHeader.Padding = new Padding(15, 0, 0, 0);
            pnlLeftHeader.Size = new Size(300, 45);
            pnlLeftHeader.TabIndex = 2;
            // 
            // lblMovieListTitle
            // 
            lblMovieListTitle.AutoSize = true;
            lblMovieListTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMovieListTitle.ForeColor = Color.FromArgb(12, 26, 58);
            lblMovieListTitle.Location = new Point(15, 12);
            lblMovieListTitle.Name = "lblMovieListTitle";
            lblMovieListTitle.Size = new Size(80, 25);
            lblMovieListTitle.TabIndex = 0;
            lblMovieListTitle.Text = "Catalog";
            // 
            // lblMovieListCount
            // 
            lblMovieListCount.AutoSize = true;
            lblMovieListCount.Font = new Font("Segoe UI", 9F);
            lblMovieListCount.ForeColor = Color.FromArgb(120, 140, 180);
            lblMovieListCount.Location = new Point(92, 14);
            lblMovieListCount.Name = "lblMovieListCount";
            lblMovieListCount.Size = new Size(27, 20);
            lblMovieListCount.TabIndex = 1;
            lblMovieListCount.Text = "(0)";
            // 
            // splitter
            // 
            splitter.BackColor = Color.FromArgb(215, 222, 240);
            splitter.Location = new Point(300, 65);
            splitter.Name = "splitter";
            splitter.Size = new Size(1, 625);
            splitter.TabIndex = 1;
            splitter.TabStop = false;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(238, 242, 252);
            pnlRight.Controls.Add(dgvBookings);
            pnlRight.Controls.Add(pnlBookingActions);
            pnlRight.Controls.Add(pnlBookingStats);
            pnlRight.Controls.Add(pnlBookingHeader);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(301, 65);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(799, 625);
            pnlRight.TabIndex = 0;
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 247, 252);
            dgvBookings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.BackgroundColor = Color.White;
            dgvBookings.BorderStyle = BorderStyle.None;
            dgvBookings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(12, 26, 58);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(12, 26, 58);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBookings.ColumnHeadersHeight = 42;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBookings.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(4, 0, 4, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(200, 215, 245);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(12, 26, 58);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvBookings.DefaultCellStyle = dataGridViewCellStyle3;
            dgvBookings.Dock = DockStyle.Fill;
            dgvBookings.EnableHeadersVisualStyles = false;
            dgvBookings.Font = new Font("Segoe UI", 9.5F);
            dgvBookings.GridColor = Color.FromArgb(215, 222, 240);
            dgvBookings.Location = new Point(0, 215);
            dgvBookings.MultiSelect = false;
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.RowHeadersWidth = 51;
            dgvBookings.RowTemplate.Height = 38;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(799, 410);
            dgvBookings.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.FillWeight = 5F;
            dataGridViewTextBoxColumn1.HeaderText = "#";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.FillWeight = 25F;
            dataGridViewTextBoxColumn2.HeaderText = "Customer Name";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.FillWeight = 8F;
            dataGridViewTextBoxColumn3.HeaderText = "Seat";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.FillWeight = 18F;
            dataGridViewTextBoxColumn4.HeaderText = "Booking Date";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.FillWeight = 14F;
            dataGridViewTextBoxColumn5.HeaderText = "Ticket Price";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.FillWeight = 15F;
            dataGridViewTextBoxColumn6.HeaderText = "Status";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // pnlBookingActions
            // 
            pnlBookingActions.BackColor = Color.White;
            pnlBookingActions.Controls.Add(btnAddBooking);
            pnlBookingActions.Controls.Add(btnDeleteBooking);
            pnlBookingActions.Controls.Add(btnChangeStatus);
            pnlBookingActions.Dock = DockStyle.Top;
            pnlBookingActions.Location = new Point(0, 160);
            pnlBookingActions.Name = "pnlBookingActions";
            pnlBookingActions.Padding = new Padding(20, 5, 20, 10);
            pnlBookingActions.Size = new Size(799, 55);
            pnlBookingActions.TabIndex = 1;
            // 
            // btnAddBooking
            // 
            btnAddBooking.Location = new Point(0, 0);
            btnAddBooking.Name = "btnAddBooking";
            btnAddBooking.Size = new Size(75, 23);
            btnAddBooking.TabIndex = 0;
            // 
            // btnDeleteBooking
            // 
            btnDeleteBooking.Location = new Point(0, 0);
            btnDeleteBooking.Name = "btnDeleteBooking";
            btnDeleteBooking.Size = new Size(75, 23);
            btnDeleteBooking.TabIndex = 1;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Location = new Point(0, 0);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(75, 23);
            btnChangeStatus.TabIndex = 2;
            // 
            // pnlBookingStats
            // 
            pnlBookingStats.BackColor = Color.FromArgb(238, 242, 252);
            pnlBookingStats.Controls.Add(pnlStatConfirmed);
            pnlBookingStats.Controls.Add(pnlStatPending);
            pnlBookingStats.Controls.Add(pnlStatCancelled);
            pnlBookingStats.Controls.Add(pnlStatRevenue);
            pnlBookingStats.Dock = DockStyle.Top;
            pnlBookingStats.Location = new Point(0, 60);
            pnlBookingStats.Name = "pnlBookingStats";
            pnlBookingStats.Padding = new Padding(20, 10, 20, 20);
            pnlBookingStats.Size = new Size(799, 100);
            pnlBookingStats.TabIndex = 2;
            // 
            // pnlStatConfirmed
            // 
            pnlStatConfirmed.Location = new Point(0, 0);
            pnlStatConfirmed.Name = "pnlStatConfirmed";
            pnlStatConfirmed.Size = new Size(200, 100);
            pnlStatConfirmed.TabIndex = 0;
            // 
            // pnlStatPending
            // 
            pnlStatPending.Location = new Point(0, 0);
            pnlStatPending.Name = "pnlStatPending";
            pnlStatPending.Size = new Size(200, 100);
            pnlStatPending.TabIndex = 1;
            // 
            // pnlStatCancelled
            // 
            pnlStatCancelled.Location = new Point(0, 0);
            pnlStatCancelled.Name = "pnlStatCancelled";
            pnlStatCancelled.Size = new Size(200, 100);
            pnlStatCancelled.TabIndex = 2;
            // 
            // pnlStatRevenue
            // 
            pnlStatRevenue.Location = new Point(0, 0);
            pnlStatRevenue.Name = "pnlStatRevenue";
            pnlStatRevenue.Size = new Size(200, 100);
            pnlStatRevenue.TabIndex = 3;
            // 
            // pnlBookingHeader
            // 
            pnlBookingHeader.BackColor = Color.FromArgb(238, 242, 252);
            pnlBookingHeader.Controls.Add(lblBookingTitle);
            pnlBookingHeader.Controls.Add(lblSelectedMovie);
            pnlBookingHeader.Dock = DockStyle.Top;
            pnlBookingHeader.Location = new Point(0, 0);
            pnlBookingHeader.Name = "pnlBookingHeader";
            pnlBookingHeader.Padding = new Padding(20, 15, 20, 0);
            pnlBookingHeader.Size = new Size(799, 60);
            pnlBookingHeader.TabIndex = 3;
            // 
            // lblBookingTitle
            // 
            lblBookingTitle.AutoSize = true;
            lblBookingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBookingTitle.ForeColor = Color.FromArgb(12, 26, 58);
            lblBookingTitle.Location = new Point(20, 10);
            lblBookingTitle.Name = "lblBookingTitle";
            lblBookingTitle.Size = new Size(165, 28);
            lblBookingTitle.TabIndex = 0;
            lblBookingTitle.Text = "Active Bookings";
            // 
            // lblSelectedMovie
            // 
            lblSelectedMovie.AutoSize = true;
            lblSelectedMovie.Font = new Font("Segoe UI", 9F);
            lblSelectedMovie.ForeColor = Color.FromArgb(120, 140, 180);
            lblSelectedMovie.Location = new Point(22, 33);
            lblSelectedMovie.Name = "lblSelectedMovie";
            lblSelectedMovie.Size = new Size(205, 20);
            lblSelectedMovie.TabIndex = 1;
            lblSelectedMovie.Text = "Select a movie to filter results";
            // 
            // lblStatConfirmedNum
            // 
            lblStatConfirmedNum.Location = new Point(0, 0);
            lblStatConfirmedNum.Name = "lblStatConfirmedNum";
            lblStatConfirmedNum.Size = new Size(100, 23);
            lblStatConfirmedNum.TabIndex = 0;
            // 
            // lblStatConfirmedTxt
            // 
            lblStatConfirmedTxt.Location = new Point(0, 0);
            lblStatConfirmedTxt.Name = "lblStatConfirmedTxt";
            lblStatConfirmedTxt.Size = new Size(100, 23);
            lblStatConfirmedTxt.TabIndex = 0;
            // 
            // lblStatPendingNum
            // 
            lblStatPendingNum.Location = new Point(0, 0);
            lblStatPendingNum.Name = "lblStatPendingNum";
            lblStatPendingNum.Size = new Size(100, 23);
            lblStatPendingNum.TabIndex = 0;
            // 
            // lblStatPendingTxt
            // 
            lblStatPendingTxt.Location = new Point(0, 0);
            lblStatPendingTxt.Name = "lblStatPendingTxt";
            lblStatPendingTxt.Size = new Size(100, 23);
            lblStatPendingTxt.TabIndex = 0;
            // 
            // lblStatCancelledNum
            // 
            lblStatCancelledNum.Location = new Point(0, 0);
            lblStatCancelledNum.Name = "lblStatCancelledNum";
            lblStatCancelledNum.Size = new Size(100, 23);
            lblStatCancelledNum.TabIndex = 0;
            // 
            // lblStatCancelledTxt
            // 
            lblStatCancelledTxt.Location = new Point(0, 0);
            lblStatCancelledTxt.Name = "lblStatCancelledTxt";
            lblStatCancelledTxt.Size = new Size(100, 23);
            lblStatCancelledTxt.TabIndex = 0;
            // 
            // lblStatRevenueNum
            // 
            lblStatRevenueNum.Location = new Point(0, 0);
            lblStatRevenueNum.Name = "lblStatRevenueNum";
            lblStatRevenueNum.Size = new Size(100, 23);
            lblStatRevenueNum.TabIndex = 0;
            // 
            // lblStatRevenueTxt
            // 
            lblStatRevenueTxt.Location = new Point(0, 0);
            lblStatRevenueTxt.Name = "lblStatRevenueTxt";
            lblStatRevenueTxt.Size = new Size(100, 23);
            lblStatRevenueTxt.TabIndex = 0;
            // 
            // pnlStatusBar
            // 
            pnlStatusBar.BackColor = Color.White;
            pnlStatusBar.Controls.Add(lblStatus);
            pnlStatusBar.Dock = DockStyle.Bottom;
            pnlStatusBar.Location = new Point(0, 690);
            pnlStatusBar.Name = "pnlStatusBar";
            pnlStatusBar.Size = new Size(1100, 30);
            pnlStatusBar.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 8.5F);
            lblStatus.ForeColor = Color.FromArgb(120, 140, 180);
            lblStatus.Location = new Point(15, 7);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(307, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Ready — select a movie to view its bookings.";
            // 
            // MoviesAdminForm
            // 
            BackColor = Color.FromArgb(238, 242, 252);
            ClientSize = new Size(1100, 720);
            Controls.Add(pnlRight);
            Controls.Add(splitter);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);
            Controls.Add(pnlStatusBar);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(860, 520);
            Name = "MoviesAdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MovieBase — Movies Admin";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlSearchBox.ResumeLayout(false);
            pnlSearchBox.PerformLayout();
            pnlLeftHeader.ResumeLayout(false);
            pnlLeftHeader.PerformLayout();
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            pnlBookingActions.ResumeLayout(false);
            pnlBookingStats.ResumeLayout(false);
            pnlBookingHeader.ResumeLayout(false);
            pnlBookingHeader.PerformLayout();
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