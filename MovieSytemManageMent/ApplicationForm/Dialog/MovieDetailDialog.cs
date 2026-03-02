using MovieSytemManageMent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSytemManageMent.ApplicationForm.Dialog
{
    public partial class MovieDetailDialog : Form
    {
        public MovieDetailDialog(Movie movie)
        {
            InitializeComponent(movie);
        }

        private void InitializeComponent(Movie movie)
        {
            this.Size = new Size(850, 550);
            this.Text = $"{movie.Title} - Details";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.MaximizeBox = false;

            // 1. Poster Image
            PictureBox picPoster = new PictureBox
            {
                Size = new Size(320, 480),
                Location = new Point(20, 20),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(240, 240, 240),
                ImageLocation = movie.PosterUrl // Picsum seed works great here
            };

            // 2. Title & Year
            Label lblTitle = new Label
            {
                Text = movie.Title.ToUpper(),
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.FromArgb(12, 26, 58),
                Location = new Point(360, 25),
                AutoSize = true
            };

            Label lblMeta = new Label
            {
                Text = $"{movie.Year}  •  {movie.Genre}  •  {movie.Duration}",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.Gray,
                Location = new Point(362, 70),
                AutoSize = true
            };

            // 3. Rating Badge
            Label lblRating = new Label
            {
                Text = $"⭐ {movie.Rating}/10",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 165, 0),
                Location = new Point(362, 105),
                AutoSize = true
            };

            // 4. Description Header
            Label lblDescTitle = new Label { Text = "OVERVIEW", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DarkGray, Location = new Point(362, 150), AutoSize = true };

            Label lblDesc = new Label
            {
                Text = movie.Description,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(362, 175),
                Size = new Size(450, 100),
                TextAlign = ContentAlignment.TopLeft
            };

            // 5. Details Table (Director, Cast, Language)
            void AddDetailRow(string label, string val, int y)
            {
                Label l = new Label { Text = label, Font = new Font("Segoe UI", 9, FontStyle.Bold), Location = new Point(362, y), ForeColor = Color.Black, AutoSize = true };
                Label v = new Label { Text = val, Font = new Font("Segoe UI", 9), Location = new Point(460, y), ForeColor = Color.FromArgb(80, 80, 80), AutoSize = true };
                this.Controls.Add(l); this.Controls.Add(v);
            }

            AddDetailRow("Director", movie.Director, 300);
            AddDetailRow("Cast", movie.Cast, 330);
            AddDetailRow("Language", movie.Language, 360);
            AddDetailRow("Released", movie.ReleaseDate.ToString("MMMM dd, yyyy"), 390);

            // 6. Close Button
            Button btnClose = new Button
            {
                Text = "Close",
                Size = new Size(120, 40),
                Location = new Point(680, 450),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(41, 98, 196),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { picPoster, lblTitle, lblMeta, lblRating, lblDescTitle, lblDesc, btnClose });
        }
    }
}