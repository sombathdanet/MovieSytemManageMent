
using MovieSytemManageMent.Model;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace MovieSytemManageMent.ApplicationForm.Dialog
{
    public partial class AddMovieDialog : Form
    {
        public Movie NewMovie { get; private set; }

        // Form Controls
        private TextBox txtTitle, txtGenre, txtYear, txtRating, txtDirector, txtPosterUrl, txtCast, txtDuration, txtLang;
        private RichTextBox rtbDesc;
        private Button btnSave, btnCancel;

        public AddMovieDialog()
        {
            InitializeComponentManual();
        }

        private void InitializeComponentManual()
        {
            this.Text = "Add New Movie";
            this.Size = new Size(450, 650);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;

            int labelX = 20, inputX = 150, currentY = 20, gap = 40;

            // Simple helper to add rows
            void AddRow(string labelText, out TextBox tb, string placeholder = "")
            {
                var lbl = new Label { Text = labelText, Location = new Point(labelX, currentY), AutoSize = true, Font = new Font("Segoe UI", 9) };
                tb = new TextBox { Location = new Point(inputX, currentY - 3), Width = 250, Text = placeholder, Font = new Font("Segoe UI", 10) };
                this.Controls.Add(lbl); this.Controls.Add(tb);
                currentY += gap;
            }

            AddRow("Title:", out txtTitle);
            AddRow("Genre:", out txtGenre, "Action, Drama...");
            AddRow("Year:", out txtYear, DateTime.Now.Year.ToString());
            AddRow("Rating (0-10):", out txtRating, "8.5");
            AddRow("Director:", out txtDirector);
            AddRow("Poster URL:", out txtPosterUrl, "https://i.pinimg.com/...");
            AddRow("Cast:", out txtCast);
            AddRow("Duration:", out txtDuration, "2h 15m");
            AddRow("Language:", out txtLang, "English");

            var lblDesc = new Label { Text = "Description:", Location = new Point(labelX, currentY), AutoSize = true };
            rtbDesc = new RichTextBox { Location = new Point(inputX, currentY), Size = new Size(250, 80), Font = new Font("Segoe UI", 9) };
            this.Controls.Add(lblDesc); this.Controls.Add(rtbDesc);

            btnSave = new Button
            {
                Text = "Save Movie",
                Location = new Point(150, 550),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(41, 98, 196),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(280, 550),
                Size = new Size(120, 40),
                FlatStyle = FlatStyle.Flat
            };

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] { btnSave, btnCancel });
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter at least a title.");
                return;
            }

            NewMovie = new Movie
            {
                Title = txtTitle.Text,
                Genre = txtGenre.Text,
                Year = int.TryParse(txtYear.Text, out int y) ? y : DateTime.Now.Year,
                Rating = double.TryParse(txtRating.Text, out double r) ? r : 0.0,
                Director = txtDirector.Text,
                PosterUrl = txtPosterUrl.Text,
                Cast = txtCast.Text,
                Duration = txtDuration.Text,
                Language = txtLang.Text,
                Description = rtbDesc.Text,
                ReleaseDate = DateTime.Now
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}