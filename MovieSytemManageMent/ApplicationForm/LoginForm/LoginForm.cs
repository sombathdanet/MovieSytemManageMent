// ============================================================
// FILE: ApplicationForm/LoginForm/LoginForm.cs
// ADDED: "Create User" button that opens a simple dialog
// ============================================================
using System;
using System.Drawing;
using System.Windows.Forms;
using MovieSytemManageMent.ApplicationForm.Dashboard;

namespace MovieSytemManageMent.ApplicationForm.LoginForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // btnLogin.Click is already wired in Designer — do NOT add again
        }

        // ????????????????????????????????????????????????????????????????
        //  LOGIN
        // ????????????????????????????????????????????????????????????????
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;

            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            bool success = LoginManager.Instance.Login(user, pass);

            if (success)
            {
                MessageBox.Show("Login Successful!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DashboardForm dash = new DashboardForm();
                dash.Show();
                this.Hide();
                dash.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                btnLogin.Enabled = true;
            }
        }

        // ????????????????????????????????????????????????????????????????
        //  CREATE USER — opens the inline dialog
        // ????????????????????????????????????????????????????????????????
        private void BtnCreateUser_Click(object sender, EventArgs e)
        {
            using var dlg = new CreateUserDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                bool created = LoginManager.Instance.CreateUser(
                    dlg.NewUsername, dlg.NewPassword);

                if (created)
                {
                    MessageBox.Show(
                        $"User \"{dlg.NewUsername}\" created successfully!\nYou can now log in.",
                        "User Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        $"Username \"{dlg.NewUsername}\" already exists.\nPlease choose a different username.",
                        "Username Taken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }

    // ????????????????????????????????????????????????????????????????????
    //  CREATE USER DIALOG
    //  Inline class — no separate file needed
    // ????????????????????????????????????????????????????????????????????
    public class CreateUserDialog : Form
    {
        // ?? Outputs ???????????????????????????????????????????????????????
        public string NewUsername { get; private set; }
        public string NewPassword { get; private set; }

        // ?? Controls ??????????????????????????????????????????????????????
        private TextBox txtNewUsername;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button btnCreate;
        private Button btnCancel;

        public CreateUserDialog()
        {
            BuildUI();
        }

        private void BuildUI()
        {
            var navy = Color.FromArgb(12, 26, 58);
            var blue = Color.FromArgb(41, 98, 196);
            var white = Color.White;
            var muted = Color.FromArgb(120, 140, 180);
            var bg = Color.FromArgb(238, 242, 252);

            // ?? Form ??????????????????????????????????????????????????????
            this.Text = "Create New User";
            this.ClientSize = new Size(380, 340);
            this.BackColor = white;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new Font("Segoe UI", 9.5F);

            // ?? Header ????????????????????????????????????????????????????
            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 55,
                BackColor = navy
            };
            pnlHeader.Controls.Add(new Label
            {
                Text = "??  Create New User",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = white,
                AutoSize = true,
                Location = new Point(16, 15)
            });

            // ?? Fields ????????????????????????????????????????????????????
            int y = 75;

            AddLabel("Username *", 24, y, navy);
            txtNewUsername = new TextBox
            {
                Location = new Point(24, y + 22),
                Size = new Size(332, 28),
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle
            };

            y += 62;
            AddLabel("Password *", 24, y, navy);
            txtNewPassword = new TextBox
            {
                Location = new Point(24, y + 22),
                Size = new Size(332, 28),
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle,
                PasswordChar = '?'
            };

            y += 62;
            AddLabel("Confirm Password *", 24, y, navy);
            txtConfirmPassword = new TextBox
            {
                Location = new Point(24, y + 22),
                Size = new Size(332, 28),
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle,
                PasswordChar = '?'
            };

            // ?? Buttons ???????????????????????????????????????????????????
            btnCreate = new Button
            {
                Text = "Create User",
                Size = new Size(130, 36),
                Location = new Point(24, 288),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = white,
                BackColor = blue,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.Click += BtnCreate_Click;

            btnCancel = new Button
            {
                Text = "Cancel",
                Size = new Size(90, 36),
                Location = new Point(166, 288),
                Font = new Font("Segoe UI", 10F),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Cancel
            };

            // ?? Add to form ???????????????????????????????????????????????
            this.Controls.AddRange(new Control[]
            {
                pnlHeader,
                txtNewUsername,
                txtNewPassword,
                txtConfirmPassword,
                btnCreate,
                btnCancel
            });

            this.AcceptButton = btnCreate;
            this.CancelButton = btnCancel;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text.Trim();
            string password = txtNewPassword.Text;
            string confirm = txtConfirmPassword.Text;

            // ?? Validation ????????????????????????????????????????????????
            if (string.IsNullOrWhiteSpace(username))
            {
                Warn("Username cannot be empty.");
                txtNewUsername.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            if (username.Length < 3)
            {
                Warn("Username must be at least 3 characters.");
                txtNewUsername.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                Warn("Password cannot be empty.");
                txtNewPassword.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            if (password.Length < 3)
            {
                Warn("Password must be at least 3 characters.");
                txtNewPassword.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            if (password != confirm)
            {
                Warn("Passwords do not match.\nPlease re-enter your password.");
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            // ?? All good — set outputs ????????????????????????????????????
            NewUsername = username;
            NewPassword = password;
        }

        private void Warn(string msg)
            => MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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