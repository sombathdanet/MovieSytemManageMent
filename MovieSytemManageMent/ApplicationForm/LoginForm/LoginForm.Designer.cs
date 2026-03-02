


namespace MovieSytemManageMent.ApplicationForm.LoginForm
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private Panel panelLeft;
        private Panel panelRight;
        private Label lblTitle;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblUsername;
        private Label lblPassword;


        private void InitializeComponent()
        {
            // ------------------------ LEFT PANEL ------------------------
            panelLeft = new Panel();
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Width = 300;
            panelLeft.BackColor = Color.FromArgb(30, 30, 60); // dark movie blue

            // Optional: add movie logo here
            Label lblMovieLogo = new Label();
            lblMovieLogo.Text = "🎬\nMovie System";
            lblMovieLogo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblMovieLogo.ForeColor = Color.White;
            lblMovieLogo.TextAlign = ContentAlignment.MiddleCenter;
            lblMovieLogo.Dock = DockStyle.Fill;
            panelLeft.Controls.Add(lblMovieLogo);

            // ------------------------ RIGHT PANEL ------------------------
            panelRight = new Panel();
            panelRight.Dock = DockStyle.Fill;
            panelRight.BackColor = Color.WhiteSmoke;

            // Title
            lblTitle = new Label();
            lblTitle.Text = "Welcome Back!";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 30, 30);
            lblTitle.AutoSize = false;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 80;

            // Username Label & TextBox
            lblUsername = new Label();
            lblUsername.Text = "Username";
            lblUsername.Location = new Point(50, 120);
            lblUsername.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            txtUsername = new TextBox();
            txtUsername.Location = new Point(50, 150);
            txtUsername.Width = 250;
            txtUsername.Font = new Font("Segoe UI", 10);
            txtUsername.GotFocus += (s, e) => { txtUsername.BackColor = Color.LightYellow; };
            txtUsername.LostFocus += (s, e) => { txtUsername.BackColor = Color.White; };

            // Password Label & TextBox
            lblPassword = new Label();
            lblPassword.Text = "Password";
            lblPassword.Location = new Point(50, 200);
            lblPassword.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            txtPassword = new TextBox();
            txtPassword.Location = new Point(50, 230);
            txtPassword.Width = 250;
            txtPassword.Font = new Font("Segoe UI", 10);
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.GotFocus += (s, e) => { txtPassword.BackColor = Color.LightYellow; };
            txtPassword.LostFocus += (s, e) => { txtPassword.BackColor = Color.White; };

            // Login Button
            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new Point(50, 300);
            btnLogin.Width = 250;
            btnLogin.Height = 45;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.BackColor = Color.FromArgb(230, 60, 60);
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnLogin.FlatAppearance.BorderSize = 0;

            // Hover effect
            btnLogin.MouseEnter += (s, e) => { btnLogin.BackColor = Color.FromArgb(255, 90, 90); };
            btnLogin.MouseLeave += (s, e) => { btnLogin.BackColor = Color.FromArgb(230, 60, 60); };
            btnLogin.Click += BtnLogin_Click;

            // ------------------------ ADD CONTROLS ------------------------
            panelRight.Controls.Add(lblTitle);
            panelRight.Controls.Add(lblUsername);
            panelRight.Controls.Add(txtUsername);
            panelRight.Controls.Add(lblPassword);
            panelRight.Controls.Add(txtPassword);
            panelRight.Controls.Add(btnLogin);

            this.Controls.Add(panelRight);
            this.Controls.Add(panelLeft);

            // ------------------------ FORM SETTINGS ------------------------
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(700, 450);
            this.Text = "Movie Management Login";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        #endregion
    }
}
