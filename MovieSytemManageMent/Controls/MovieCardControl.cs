 // 👈 1. ADD THIS NAMESPACE
using MovieSytemManageMent.ApplicationForm.Dialog;
using MovieSytemManageMent.Model;

namespace MovieSytemManageMent.Controls
{
    public class MovieCardControl : UserControl
    {
        // ── Events ───────────────────────────────────────────────────────
        public event EventHandler<Movie> OnEdit;
        public event EventHandler<Movie> OnDelete;

        public Movie Movie { get; private set; }

        // ── Controls ─────────────────────────────────────────────────────
        private PictureBox pbPoster;
        private Label lblGenreBadge;
        private Label lblTitle;
        private Label lblRatingYear;
        private Button btnEdit;
        private Button btnDelete;

        // ── Genre → accent color ─────────────────────────────────────────
        private static Color GenreColor(string genre)
        {
            switch ((genre ?? "").ToLower())
            {
                case "action": return Color.FromArgb(220, 60, 60);
                case "drama": return Color.FromArgb(41, 98, 196);
                case "comedy": return Color.FromArgb(230, 160, 30);
                case "sci-fi": return Color.FromArgb(30, 170, 200);
                case "horror": return Color.FromArgb(100, 20, 140);
                case "romance": return Color.FromArgb(220, 80, 120);
                case "thriller": return Color.FromArgb(50, 60, 80);
                case "animation": return Color.FromArgb(40, 180, 100);
                default: return Color.FromArgb(80, 100, 140);
            }
        }

        public MovieCardControl(Movie movie)
        {
            Movie = movie;
            BuildCard();

            // 👈 2. REGISTER THE DETAIL CLICK HANDLER
            SetupClickEvents();
        }

        private void SetupClickEvents()
        {
            // Define the action
            Action openDetails = () => {
                using (var detailDialog = new MovieDetailDialog(Movie))
                {
                    detailDialog.ShowDialog();
                }
            };

            // Apply to the card itself
            this.Click += (s, e) => openDetails();

            // Apply to info labels and poster (excluding buttons)
            pbPoster.Click += (s, e) => openDetails();
            lblTitle.Click += (s, e) => openDetails();
            lblRatingYear.Click += (s, e) => openDetails();
        }

        private void BuildCard()
        {
            Color accent = GenreColor(Movie.Genre);

            this.Size = new Size(170, 274);
            this.Margin = new Padding(6, 6, 6, 6);
            this.BackColor = Color.White;
            this.Cursor = Cursors.Hand;

            // Poster area
            pbPoster = new PictureBox();
            pbPoster.Size = new Size(170, 184);
            pbPoster.Location = new Point(0, 0);
            pbPoster.SizeMode = PictureBoxSizeMode.Normal;
            pbPoster.Image = GeneratePoster(170, 184, accent, Movie.Title, Movie.Genre);

            // Genre badge
            lblGenreBadge = new Label();
            lblGenreBadge.Text = Movie.Genre;
            lblGenreBadge.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            lblGenreBadge.ForeColor = Color.White;
            lblGenreBadge.BackColor = accent;
            lblGenreBadge.AutoSize = false;
            lblGenreBadge.Size = new Size(62, 20);
            lblGenreBadge.Location = new Point(102, 8);
            lblGenreBadge.TextAlign = ContentAlignment.MiddleCenter;
            pbPoster.Controls.Add(lblGenreBadge);

            // Accent line
            var accentLine = new Panel();
            accentLine.BackColor = accent;
            accentLine.Size = new Size(170, 3);
            accentLine.Location = new Point(0, 184);

            // Info panel
            var pnlInfo = new Panel();
            pnlInfo.Size = new Size(170, 87);
            pnlInfo.Location = new Point(0, 187);
            pnlInfo.BackColor = Color.White;

            lblTitle = new Label();
            lblTitle.Text = Movie.Title;
            lblTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(12, 26, 58);
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(152, 32);
            lblTitle.Location = new Point(9, 6);
            lblTitle.AutoEllipsis = true;

            lblRatingYear = new Label();
            lblRatingYear.Text = $"⭐ {Movie.Rating:0.0}   •   {Movie.Year}";
            lblRatingYear.Font = new Font("Segoe UI", 7.5F);
            lblRatingYear.ForeColor = Color.FromArgb(120, 130, 155);
            lblRatingYear.AutoSize = false;
            lblRatingYear.Size = new Size(152, 18);
            lblRatingYear.Location = new Point(9, 40);

            btnEdit = new Button();
            btnEdit.Text = "✏ Edit";
            btnEdit.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.BackColor = accent;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Size = new Size(72, 24);
            btnEdit.Location = new Point(9, 58);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Click += (s, e) => OnEdit?.Invoke(this, Movie);

            btnDelete = new Button();
            btnDelete.Text = "🗑 Del";
            btnDelete.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(200, 50, 50);
            btnDelete.BackColor = Color.FromArgb(255, 240, 240);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 1;
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(220, 180, 180);
            btnDelete.Size = new Size(72, 24);
            btnDelete.Location = new Point(89, 58);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += (s, e) =>
            {
                if (MessageBox.Show($"Delete \"{Movie.Title}\"?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    OnDelete?.Invoke(this, Movie);
            };

            pnlInfo.Controls.AddRange(new Control[] { lblTitle, lblRatingYear, btnEdit, btnDelete });

            // 👈 3. ADD HOVER EFFECTS FOR BETTER UX
            this.MouseEnter += (s, e) => {
                this.BackColor = Color.FromArgb(243, 247, 255);
                pnlInfo.BackColor = Color.FromArgb(243, 247, 255);
            };
            this.MouseLeave += (s, e) => {
                this.BackColor = Color.White;
                pnlInfo.BackColor = Color.White;
            };

            this.Controls.Add(pbPoster);
            this.Controls.Add(accentLine);
            this.Controls.Add(pnlInfo);
        }

        private static Image GeneratePoster(int w, int h, Color accent, string title, string genre)
        {
            var bmp = new Bitmap(w, h);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                var dark = Color.FromArgb(
                    Math.Max(0, accent.R - 80),
                    Math.Max(0, accent.G - 80),
                    Math.Max(0, accent.B - 80));
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Rectangle(0, 0, w, h), dark, accent,
                    System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                {
                    g.FillRectangle(brush, 0, 0, w, h);
                }

                using (var overlay = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                    g.FillRectangle(overlay, 0, h / 2, w, h / 2);

                string icon = GenreIcon(genre);
                using (var iconFont = new Font("Segoe UI Emoji", 38F))
                {
                    var iconSize = g.MeasureString(icon, iconFont);
                    float ix = (w - iconSize.Width) / 2f;
                    float iy = (h / 2f) - iconSize.Height / 2f - 14;
                    g.DrawString(icon, iconFont, Brushes.White, ix, iy);
                }

                using (var titleFont = new Font("Segoe UI", 8F, FontStyle.Bold))
                {
                    var fmt = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisWord };
                    var titleRect = new RectangleF(6, h - 68, w - 12, 60);
                    using (var shadow = new SolidBrush(Color.FromArgb(120, 0, 0, 0)))
                        g.DrawString(title, titleFont, shadow, RectangleF.Inflate(titleRect, 1, 1), fmt);
                    g.DrawString(title, titleFont, Brushes.White, titleRect, fmt);
                }
            }
            return bmp;
        }

        private static string GenreIcon(string genre)
        {
            switch ((genre ?? "").ToLower())
            {
                case "action": return "💥";
                case "drama": return "🎭";
                case "comedy": return "😂";
                case "sci-fi": return "🚀";
                case "horror": return "👻";
                case "romance": return "💕";
                case "thriller": return "🔪";
                case "animation": return "✨";
                default: return "🎬";
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && pbPoster?.Image != null)
            {
                var img = pbPoster.Image;
                pbPoster.Image = null;
                img.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}