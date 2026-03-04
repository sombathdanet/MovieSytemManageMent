
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MovieSytemManageMent.Model;
using MovieSytemManageMent.Repositories.BookingRepository;

namespace MovieSytemManageMent.Controls
{
    public class SeatSelectionDialog : Form
    {
        private readonly int _movieId;
        private readonly HashSet<string> _bookedSeats;
        private readonly TableLayoutPanel _grid;
        private readonly Button _btnConfirm;
        public string SelectedSeat { get; private set; }

        // simple layout: rows A..F and seats 1..10 (adjust if you need different layout)
        private static readonly char[] Rows = new[] { 'A', 'B', 'C', 'D', 'E', 'F' };
        private const int Cols = 10;

        public SeatSelectionDialog(int movieId)
        {
            _movieId = movieId;
            _bookedSeats = new HashSet<string>(
                BookingRepository.Instance.GetByMovieId(movieId).Select(b => b.SeatNumber.ToUpper())
            );

            this.Text = "Select a Seat";
            this.Size = new Size(520, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            var lbl = new Label
            {
                Text = "Choose an available seat (gray = available, red = booked).",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(12, 12),
                ForeColor = Color.FromArgb(30, 30, 30)
            };
            this.Controls.Add(lbl);

            _grid = new TableLayoutPanel
            {
                Location = new Point(12, 40),
                Size = new Size(480, 300),
                ColumnCount = Cols,
                RowCount = Rows.Length,
                BackColor = Color.Transparent,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                AutoSize = false
            };

            // set column/row styles
            for (int c = 0; c < Cols; c++)
                _grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / Cols));
            for (int r = 0; r < Rows.Length; r++)
                _grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / Rows.Length));

            BuildSeatButtons();

            this.Controls.Add(_grid);

            _btnConfirm = new Button
            {
                Text = "Confirm",
                Size = new Size(110, 34),
                Location = new Point(this.ClientSize.Width - 134, this.ClientSize.Height - 54),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Enabled = false,
                BackColor = Color.FromArgb(41, 98, 196),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            _btnConfirm.FlatAppearance.BorderSize = 0;
            _btnConfirm.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };

            var btnCancel = new Button
            {
                Text = "Cancel",
                Size = new Size(90, 34),
                Location = new Point(this.ClientSize.Width - 250, this.ClientSize.Height - 54),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(245, 245, 247),
                ForeColor = Color.FromArgb(30, 30, 30),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.Add(_btnConfirm);
            this.Controls.Add(btnCancel);

            // make layout adapt when resized slightly
            this.ClientSizeChanged += (s, e) =>
            {
                _btnConfirm.Location = new Point(this.ClientSize.Width - 134, this.ClientSize.Height - 54);
                btnCancel.Location = new Point(this.ClientSize.Width - 250, this.ClientSize.Height - 54);
                _grid.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 120);
            };
        }

        private void BuildSeatButtons()
        {
            _grid.Controls.Clear();

            for (int r = 0; r < Rows.Length; r++)
            {
                for (int c = 1; c <= Cols; c++)
                {
                    string seat = $"{Rows[r]}{c}";
                    var btn = new Button
                    {
                        Text = seat,
                        Dock = DockStyle.Fill,
                        Margin = new Padding(4),
                        Tag = seat,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                        Cursor = Cursors.Hand
                    };

                    if (_bookedSeats.Contains(seat.ToUpper()))
                    {
                        btn.BackColor = Color.FromArgb(220, 80, 80); // booked = red
                        btn.ForeColor = Color.White;
                        btn.Enabled = false;
                    }
                    else
                    {
                        btn.BackColor = Color.FromArgb(220, 220, 225); // available = gray
                        btn.ForeColor = Color.FromArgb(30, 30, 30);
                        btn.Click += SeatButton_Click;
                    }

                    _grid.Controls.Add(btn, c - 1, r);
                }
            }
        }

        private void SeatButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // clear previous selection highlight
                foreach (Control ctl in _grid.Controls)
                {
                    if (ctl is Button b && b.Enabled)
                    {
                        b.FlatAppearance.BorderSize = 0;
                        b.Padding = new Padding(0);
                    }
                }

                // mark selected
                btn.FlatAppearance.BorderSize = 2;
                btn.FlatAppearance.BorderColor = Color.FromArgb(34, 47, 80);
                btn.Padding = new Padding(0, 0, 0, 0);
                SelectedSeat = btn.Tag.ToString();
                _btnConfirm.Enabled = true;
            }
        }
    }
}