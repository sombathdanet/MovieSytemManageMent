using MovieSytemManageMent.ApplicationForm.Dialog;
using MovieSytemManageMent.Model;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace MovieSytemManageMent.Controls
{
    public class MovieCardControl : UserControl
    {
        public event EventHandler<Movie> OnDetailsClick;
        public event EventHandler<Movie> OnBookClick;

        public Movie Movie { get; private set; }
        private bool _isHovered = false;

        // Theme Colors
        private readonly Color PrimaryNavy = Color.FromArgb(12, 26, 58);
        private readonly Color SecondaryText = Color.FromArgb(100, 110, 130);
        private readonly Color AccentRed = Color.FromArgb(226, 60, 60);
        private readonly Color CardBg = Color.White;
        private readonly Color ShadowColor = Color.FromArgb(30, 0, 0, 0);

        public MovieCardControl(Movie movie)
        {
            Movie = movie ?? throw new ArgumentNullException(nameof(movie));
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(190, 310); // Slightly larger for better breathing room
            this.Margin = new Padding(12);
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;

            // Setup Hover detection for the whole control
            this.MouseEnter += (s, e) => UpdateHover(true);
            this.MouseLeave += (s, e) => {
                if (!this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
                    UpdateHover(false);
            };

            BuildUI();
        }

        private void BuildUI()
        {
            // 1. Poster Container (Rounded)
            var pbPoster = new PictureBox
            {
                Location = new Point(10, 10),
                Size = new Size(170, 200),
                SizeMode = PictureBoxSizeMode.CenterImage,
                BackColor = Color.FromArgb(245, 246, 250),
                Cursor = Cursors.Hand
            };

            // Load Poster
            pbPoster.Image = LoadPosterImage(pbPoster.Width, pbPoster.Height);
            pbPoster.Click += (s, e) => OnDetailsClick?.Invoke(this, Movie);

            // Inside BuildUI()
            pbPoster.Paint += (s, e) => {
                // This clips the image to have rounded corners matching your card
                using (GraphicsPath path = GetRoundedRect(new Rectangle(0, 0, pbPoster.Width, pbPoster.Height), 12f))
                {
                    pbPoster.Region = new Region(path);
                }
            };

            // 2. Title
            var lblTitle = new Label
            {
                Text = Movie.Title,
                Font = new Font("Segoe UI Semibold", 10.5F),
                ForeColor = PrimaryNavy,
                Location = new Point(10, 218),
                Size = new Size(170, 22),
                AutoEllipsis = true
            };

            // 3. Subtitle (Genre • Year)
            var lblSub = new Label
            {
                Text = $"{Movie.Genre} • {Movie.Year}",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = SecondaryText,
                Location = new Point(10, 240),
                Size = new Size(170, 18)
            };

            // 4. Action Buttons Container
            var btnDetails = CreateButton("Details", false, new Point(10, 268));
            var btnBook = CreateButton("Book Now", true, new Point(95, 268));

            btnDetails.Click += (s, e) => OnDetailsClick?.Invoke(this, Movie);
            btnBook.Click += (s, e) => OnBookClick?.Invoke(this, Movie);

            this.Controls.AddRange(new Control[] { pbPoster, lblTitle, lblSub, btnDetails, btnBook });
        }

        private Button CreateButton(string text, bool isPrimary, Point location)
        {
            var btn = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(82, 32),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5F, isPrimary ? FontStyle.Bold : FontStyle.Regular),
                Cursor = Cursors.Hand,
                BackColor = isPrimary ? AccentRed : Color.White,
                ForeColor = isPrimary ? Color.White : PrimaryNavy
            };
            btn.FlatAppearance.BorderSize = isPrimary ? 0 : 1;
            btn.FlatAppearance.BorderColor = isPrimary ? AccentRed : Color.FromArgb(220, 224, 230);
            return btn;
        }

        private void UpdateHover(bool hovered)
        {
            _isHovered = hovered;
            this.Invalidate(); // Redraw shadow and background
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw Card Background with Rounded Corners
            var rect = new Rectangle(5, 5, this.Width - 11, this.Height - 11);
            float radius = 12f;

            using (GraphicsPath path = GetRoundedRect(rect, radius))
            {
                // Draw Shadow if hovered
                if (_isHovered)
                {
                    using (var shadowBrush = new SolidBrush(ShadowColor))
                        e.Graphics.FillPath(shadowBrush, GetRoundedRect(new Rectangle(7, 7, rect.Width, rect.Height), radius));
                }

                using (var brush = new SolidBrush(CardBg))
                    e.Graphics.FillPath(brush, path);

                // Draw Border
                using (var pen = new Pen(_isHovered ? AccentRed : Color.FromArgb(235, 238, 242), 1.5f))
                    e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundedRect(Rectangle bounds, float radius)
        {
            var path = new GraphicsPath();
            float d = radius * 2;
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private Image LoadPosterImage(int w, int h)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Movie.PosterUrl))
                {
                    // Check if it's a web URL
                    if (Movie.PosterUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        return DownloadImage(Movie.PosterUrl, w, h);
                    }
                    // Check if it's a local file
                    else if (File.Exists(Movie.PosterUrl))
                    {
                        using (var img = Image.FromFile(Movie.PosterUrl))
                            return new Bitmap(img, new Size(w, h));
                    }
                }
            }
            catch { /* Log error if needed */ }

            return GenerateModernPlaceholder(w, h);
        }

        private Image DownloadImage(string url, int w, int h)
        {
            try
            {
                using (System.Net.WebClient wc = new System.Net.WebClient())
                {
                    byte[] bytes = wc.DownloadData(url);
                    using (var ms = new MemoryStream(bytes))
                    {
                        using (var img = Image.FromStream(ms))
                        {
                            return new Bitmap(img, new Size(w, h));
                        }
                    }
                }
            }
            catch
            {
                return GenerateModernPlaceholder(w, h);
            }
        }

        private Image GenerateModernPlaceholder(int w, int h)
        {
            var bmp = new Bitmap(w, h);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(240, 242, 245));
                using (var font = new Font("Segoe UI", 24F))
                    g.DrawString("🎬", font, Brushes.Gray, (w / 2) - 20, (h / 2) - 25);
            }
            return bmp;
        }
    }
}