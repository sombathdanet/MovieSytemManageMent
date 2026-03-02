namespace MovieSytemManageMent.ApplicationForm.Dashboard
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblAppSubtitle = new System.Windows.Forms.Label();
            this.pnlAvatarCircle = new System.Windows.Forms.Panel();
            this.lblAvatarInitial = new System.Windows.Forms.Label();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavMovies = new System.Windows.Forms.Button();
            this.btnNavGenres = new System.Windows.Forms.Button();
            this.btnNavActors = new System.Windows.Forms.Button();
            this.btnNavReports = new System.Windows.Forms.Button();
            this.btnNavLogout = new System.Windows.Forms.Button();

            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();

            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlStatRow = new System.Windows.Forms.Panel();
            this.pnlCardTotal = new System.Windows.Forms.Panel();
            this.lblCardTotalTitle = new System.Windows.Forms.Label();
            this.lblCardTotalValue = new System.Windows.Forms.Label();
            this.lblCardTotalIcon = new System.Windows.Forms.Label();
            this.pnlCardNew = new System.Windows.Forms.Panel();
            this.lblCardNewTitle = new System.Windows.Forms.Label();
            this.lblCardNewValue = new System.Windows.Forms.Label();
            this.lblCardNewIcon = new System.Windows.Forms.Label();
            this.pnlCardGenres = new System.Windows.Forms.Panel();
            this.lblCardGenresTitle = new System.Windows.Forms.Label();
            this.lblCardGenresValue = new System.Windows.Forms.Label();
            this.lblCardGenresIcon = new System.Windows.Forms.Label();
            this.pnlCardActors = new System.Windows.Forms.Panel();
            this.lblCardActorsTitle = new System.Windows.Forms.Label();
            this.lblCardActorsValue = new System.Windows.Forms.Label();
            this.lblCardActorsIcon = new System.Windows.Forms.Label();

            this.pnlSectionHeader = new System.Windows.Forms.Panel();
            this.lblMovieSectionTitle = new System.Windows.Forms.Label();
            this.lblMovieCount = new System.Windows.Forms.Label();
            this.btnAddMovie = new System.Windows.Forms.Button();

            this.flpMovieCards = new System.Windows.Forms.FlowLayoutPanel();

            this.pnlSidebar.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlStatRow.SuspendLayout();
            this.pnlSectionHeader.SuspendLayout();
            this.SuspendLayout();

            // ── SIDEBAR ──────────────────────────────────────────────────
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(12, 26, 58);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 220;
            this.pnlSidebar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlAvatarCircle, this.lblAppTitle, this.lblAppSubtitle,
                this.btnNavDashboard, this.btnNavMovies, this.btnNavGenres,
                this.btnNavActors, this.btnNavReports, this.btnNavLogout
            });

            this.pnlAvatarCircle.BackColor = System.Drawing.Color.FromArgb(41, 98, 196);
            this.pnlAvatarCircle.Size = new System.Drawing.Size(64, 64);
            this.pnlAvatarCircle.Location = new System.Drawing.Point(78, 22);
            this.pnlAvatarCircle.Controls.Add(this.lblAvatarInitial);

            this.lblAvatarInitial.Text = "🎬";
            this.lblAvatarInitial.Font = new System.Drawing.Font("Segoe UI Emoji", 24F);
            this.lblAvatarInitial.AutoSize = false;
            this.lblAvatarInitial.Size = new System.Drawing.Size(64, 64);
            this.lblAvatarInitial.Location = new System.Drawing.Point(0, 0);
            this.lblAvatarInitial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblAppTitle.Text = "MovieBase";
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.AutoSize = false;
            this.lblAppTitle.Size = new System.Drawing.Size(220, 28);
            this.lblAppTitle.Location = new System.Drawing.Point(0, 98);
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblAppSubtitle.Text = "Management System";
            this.lblAppSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblAppSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 140, 210);
            this.lblAppSubtitle.AutoSize = false;
            this.lblAppSubtitle.Size = new System.Drawing.Size(220, 18);
            this.lblAppSubtitle.Location = new System.Drawing.Point(0, 126);
            this.lblAppSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            System.Drawing.Font navFont = new System.Drawing.Font("Segoe UI", 10F);
            void StyleNav(System.Windows.Forms.Button btn, string text, int y, bool active = false)
            {
                btn.Text = text;
                btn.Font = navFont;
                btn.ForeColor = active ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(180, 210, 255);
                btn.BackColor = active ? System.Drawing.Color.FromArgb(41, 98, 196) : System.Drawing.Color.Transparent;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Size = new System.Drawing.Size(220, 48); // Increased height slightly
                btn.Location = new System.Drawing.Point(0, y);
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0); // Reduced padding to give text more room
                btn.TextImageRelation = TextImageRelation.ImageBeforeText; // Ensures icon and text stay together
                btn.Cursor = System.Windows.Forms.Cursors.Hand;
            }

            StyleNav(btnNavDashboard, "⬛ Dashboard", 164, true);
            StyleNav(btnNavMovies, "🎬 Movies", 212);
            StyleNav(btnNavGenres, "🏷 Genres", 260);
            StyleNav(btnNavActors, "👤 Actors", 308);
            StyleNav(btnNavReports, "📊 Reports", 356);
            StyleNav(btnNavLogout, "🚪 Logout", 452);

            // ── TOP BAR ──────────────────────────────────────────────────
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Height = 65;
            this.pnlTopBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPageTitle, this.cmbSortBy, this.txtSearch, this.btnSearch
            });

            this.lblPageTitle.Text = "🎬 Dashboard";
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(12, 26, 58);
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Location = new System.Drawing.Point(20, 18);

            this.cmbSortBy.Items.AddRange(new object[] { "Sort: Default", "Sort: Title A-Z", "Sort: Year ↓", "Sort: Rating ↓" });
            this.cmbSortBy.SelectedIndex = 0;
            this.cmbSortBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSortBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortBy.Size = new System.Drawing.Size(140, 28);
            this.cmbSortBy.Location = new System.Drawing.Point(280, 18);

            this.txtSearch.Size = new System.Drawing.Size(220, 28);
            this.txtSearch.Location = new System.Drawing.Point(435, 18);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(130, 140, 160);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Text = "Search movies...";

            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(41, 98, 196);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
            this.btnSearch.Location = new System.Drawing.Point(665, 18);

            // ── MAIN PANEL (DOCKS FILL) ──────────────────────────────────
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(238, 242, 252);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlMain.Controls.Add(this.flpMovieCards); // Grid at bottom
            this.pnlMain.Controls.Add(this.pnlSectionHeader);
            this.pnlMain.Controls.Add(this.pnlStatRow);

            // ── STAT ROW (DOCKS TOP) ─────────────────────────────────────
            this.pnlStatRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatRow.Height = 110;
            this.pnlStatRow.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlCardTotal, this.pnlCardNew, this.pnlCardGenres, this.pnlCardActors
            });

            void StyleStat(System.Windows.Forms.Panel pnl, System.Windows.Forms.Label lblT, System.Windows.Forms.Label lblV, System.Windows.Forms.Label lblI, string title, string val, string icon, System.Drawing.Color accent, int x)
            {
                pnl.BackColor = System.Drawing.Color.White;
                pnl.Size = new System.Drawing.Size(185, 96);
                pnl.Location = new System.Drawing.Point(x, 0);

                // Sidebar accent strip
                pnl.Controls.Add(new System.Windows.Forms.Panel { BackColor = accent, Size = new System.Drawing.Size(5, 96), Location = new Point(0, 0) });

                // Icon - Move it slightly so it doesn't overlap text
                lblI.Text = icon;
                lblI.Font = new System.Drawing.Font("Segoe UI Emoji", 18F); // Slightly smaller icon
                lblI.Size = new Size(40, 40);
                lblI.Location = new Point(135, 10); // Move to top right
                lblI.TextAlign = ContentAlignment.MiddleCenter;
                pnl.Controls.Add(lblI);

                // Title
                lblT.Text = title;
                lblT.Font = new System.Drawing.Font("Segoe UI", 8.5F, FontStyle.Bold);
                lblT.ForeColor = Color.FromArgb(140, 150, 170);
                lblT.Location = new Point(15, 15);
                lblT.AutoSize = true; // IMPORTANT: Let the title size itself
                pnl.Controls.Add(lblT);

                // Value (The Number)
                lblV.Text = val;
                lblV.Font = new System.Drawing.Font("Segoe UI", 22F, FontStyle.Bold); // 22 is safer than 26
                lblV.ForeColor = Color.FromArgb(12, 26, 58);
                lblV.Location = new Point(12, 40);
                lblV.AutoSize = true; // IMPORTANT: This prevents the number from clipping
                pnl.Controls.Add(lblV);
            }

            StyleStat(pnlCardTotal, lblCardTotalTitle, lblCardTotalValue, lblCardTotalIcon, "Total Movies", "0", "🎬", Color.FromArgb(41, 98, 196), 0);
            StyleStat(pnlCardNew, lblCardNewTitle, lblCardNewValue, lblCardNewIcon, "Added 2026", "0", "🆕", Color.FromArgb(34, 170, 130), 200);
            StyleStat(pnlCardGenres, lblCardGenresTitle, lblCardGenresValue, lblCardGenresIcon, "Genres", "0", "🏷", Color.FromArgb(230, 130, 30), 400);
            StyleStat(pnlCardActors, lblCardActorsTitle, lblCardActorsValue, lblCardActorsIcon, "Actors", "0", "👤", Color.FromArgb(160, 50, 200), 600);

            // ── SECTION HEADER (DOCKS TOP) ───────────────────────────────
            this.pnlSectionHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSectionHeader.Height = 50;
            this.pnlSectionHeader.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMovieSectionTitle, this.lblMovieCount, this.btnAddMovie
            });

            this.lblMovieSectionTitle.Text = "🎥 Movie Collection";
            this.lblMovieSectionTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMovieSectionTitle.Location = new Point(0, 10);
            this.lblMovieSectionTitle.AutoSize = true;

            this.lblMovieCount.Text = "0 movies";
            this.lblMovieCount.Location = new Point(220, 15);
            this.lblMovieCount.ForeColor = Color.FromArgb(120, 140, 180);

            this.btnAddMovie.Text = "+ Add Movie";
            this.btnAddMovie.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.btnAddMovie.Size = new Size(110, 32);
            this.btnAddMovie.Location = new Point(690, 8);
            this.btnAddMovie.BackColor = Color.FromArgb(41, 98, 196);
            this.btnAddMovie.ForeColor = Color.White;
            this.btnAddMovie.FlatStyle = FlatStyle.Flat;

            // ── MOVIE GRID (DOCKS FILL + AUTO SCROLL) ───────────────────
            this.flpMovieCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMovieCards.AutoScroll = true;
            this.flpMovieCards.WrapContents = true;
            this.flpMovieCards.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpMovieCards.BackColor = System.Drawing.Color.Transparent;
            this.flpMovieCards.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);

            // ── FORM SETTINGS ─────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Text = "MovieBase – Dashboard";
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSidebar);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlStatRow.ResumeLayout(false);
            this.pnlSectionHeader.ResumeLayout(false);
            this.pnlSectionHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // All Private Variables Kept Same
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblAppSubtitle;
        private System.Windows.Forms.Panel pnlAvatarCircle;
        private System.Windows.Forms.Label lblAvatarInitial;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavMovies;
        private System.Windows.Forms.Button btnNavGenres;
        private System.Windows.Forms.Button btnNavActors;
        private System.Windows.Forms.Button btnNavReports;
        private System.Windows.Forms.Button btnNavLogout;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlStatRow;
        private System.Windows.Forms.Panel pnlCardTotal;
        private System.Windows.Forms.Label lblCardTotalTitle;
        private System.Windows.Forms.Label lblCardTotalValue;
        private System.Windows.Forms.Label lblCardTotalIcon;
        private System.Windows.Forms.Panel pnlCardNew;
        private System.Windows.Forms.Label lblCardNewTitle;
        private System.Windows.Forms.Label lblCardNewValue;
        private System.Windows.Forms.Label lblCardNewIcon;
        private System.Windows.Forms.Panel pnlCardGenres;
        private System.Windows.Forms.Label lblCardGenresTitle;
        private System.Windows.Forms.Label lblCardGenresValue;
        private System.Windows.Forms.Label lblCardGenresIcon;
        private System.Windows.Forms.Panel pnlCardActors;
        private System.Windows.Forms.Label lblCardActorsTitle;
        private System.Windows.Forms.Label lblCardActorsValue;
        private System.Windows.Forms.Label lblCardActorsIcon;
        private System.Windows.Forms.Panel pnlSectionHeader;
        private System.Windows.Forms.Label lblMovieSectionTitle;
        private System.Windows.Forms.Label lblMovieCount;
        private System.Windows.Forms.Button btnAddMovie;
        private System.Windows.Forms.FlowLayoutPanel flpMovieCards;
    }
}