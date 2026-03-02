
// ============================================================
// FILE: ApplicationForm/Movies/AddBookingDialog.cs
// PURPOSE: Simple popup dialog to add a new booking
//          Called from MoviesAdminForm.BtnAddBooking_Click()
// ============================================================
using System;
using System.Drawing;
using System.Windows.Forms;
using MovieSytemManageMent.Model;

namespace MovieSytemManageMent.Controls
{
    public class AddBookingDialog : Form
    {
        // ── The booking created by this dialog ────────────────────────────
        public Booking NewBooking { get; private set; }

        // ── Controls ──────────────────────────────────────────────────────
        private TextBox txtCustomer;
        private TextBox txtSeat;
        private NumericUpDown numPrice;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;

        private readonly int _movieId;

        public AddBookingDialog(int movieId)
        {
            _movieId = movieId;
            BuildUI();
        }

        private void BuildUI()
        {
            var navy = Color.FromArgb(12, 26, 58);
            var blue = Color.FromArgb(41, 98, 196);
            var white = Color.White;
            var bg = Color.FromArgb(238, 242, 252);

            this.Text = "Add Booking";
            this.ClientSize = new Size(380, 320);
            this.BackColor = white;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new Font("Segoe UI", 9.5F);

            // Header
            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = navy
            };
            var lblTitle = new Label
            {
                Text = "➕  New Booking",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = white,
                AutoSize = true,
                Location = new Point(16, 14)
            };
            pnlHeader.Controls.Add(lblTitle);

            // Fields
            int lx = 24, fx = 24, fw = 332, y = 70, gap = 52;

            txtCustomer = AddField("Customer Name *", lx, y, fx, fw, navy); y += gap;
            txtSeat = AddField("Seat Number *", lx, y, fx, fw, navy); y += gap;

            AddLabel("Ticket Price ($) *", lx, y, navy);
            numPrice = new NumericUpDown
            {
                Location = new Point(fx, y + 20),
                Size = new Size(fw, 28),
                Font = new Font("Segoe UI", 10F),
                Minimum = 0,
                Maximum = 500,
                DecimalPlaces = 2,
                Value = 12.50M,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(numPrice);
            y += gap;

            AddLabel("Status *", lx, y, navy);
            cmbStatus = new ComboBox
            {
                Location = new Point(fx, y + 20),
                Size = new Size(fw, 28),
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat
            };
            cmbStatus.Items.AddRange(new object[] { "Confirmed", "Pending", "Cancelled" });
            cmbStatus.SelectedIndex = 0;
            this.Controls.Add(cmbStatus);

            // Buttons
            btnSave = new Button
            {
                Text = "Save Booking",
                Size = new Size(130, 34),
                Location = new Point(24, 272),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = white,
                BackColor = blue,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Cancel",
                Size = new Size(90, 34),
                Location = new Point(166, 272),
                Font = new Font("Segoe UI", 10F),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[]
            { pnlHeader, btnSave, btnCancel });
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomer.Text))
            { MessageBox.Show("Customer name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); DialogResult = DialogResult.None; return; }

            if (string.IsNullOrWhiteSpace(txtSeat.Text))
            { MessageBox.Show("Seat number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); DialogResult = DialogResult.None; return; }

            NewBooking = new Booking
            {
                MovieId = _movieId,
                CustomerName = txtCustomer.Text.Trim(),
                SeatNumber = txtSeat.Text.Trim().ToUpper(),
                BookingDate = DateTime.Today,
                TicketPrice = (double)numPrice.Value,
                Status = cmbStatus.Text
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────
        private TextBox AddField(string label, int lx, int y, int fx, int fw, Color navy)
        {
            AddLabel(label, lx, y, navy);
            var txt = new TextBox
            {
                Location = new Point(fx, y + 20),
                Size = new Size(fw, 28),
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(txt);
            return txt;
        }

        private void AddLabel(string text, int x, int y, Color color)
        {
            this.Controls.Add(new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(x, y),
                AutoSize = true
            });
        }
    }
}