namespace MovieSytemManageMent.ApplicationForm.LoginForm
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private Panel panelLeft;
        private Panel panelRight;
        private Label lblTitle;
        private Label lblSubTitle;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCreateUser;
        private Label lblUsername;
        private Label lblPassword;
        private Panel lineUsername;
        private Panel linePassword;

        private void InitializeComponent()
        {
            // --- ពណ៌ចម្បង (Color Palette) ---
            var primaryNavy = Color.FromArgb(12, 26, 58);     // Navy ស្រស់
            var accentRed = Color.FromArgb(229, 9, 20);      // Netflix Red
            var lightGray = Color.FromArgb(240, 242, 245);   // Light Background
            var mutedText = Color.FromArgb(120, 140, 180);   // Muted Blue/Gray

            // ------------------------ LEFT PANEL (Branding) ------------------------
            panelLeft = new Panel();
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Width = 320;
            panelLeft.BackColor = primaryNavy;

            Label lblLogoIcon = new Label();
            lblLogoIcon.Text = "🎬";
            lblLogoIcon.Font = new Font("Segoe UI", 50);
            lblLogoIcon.ForeColor = Color.White;
            lblLogoIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblLogoIcon.Location = new Point(0, 100);
            lblLogoIcon.Width = panelLeft.Width;

            Label lblMovieLogo = new Label();
            lblMovieLogo.Text = "DRSB CINEMA\nMANAGEMENT";
            lblMovieLogo.Font = new Font("Segoe UI Semibold", 18, FontStyle.Bold);
            lblMovieLogo.ForeColor = Color.White;
            lblMovieLogo.TextAlign = ContentAlignment.MiddleCenter;
            lblMovieLogo.Location = new Point(0, 180);
            lblMovieLogo.Width = panelLeft.Width;
            lblMovieLogo.Height = 80;

            panelLeft.Controls.Add(lblLogoIcon);
            panelLeft.Controls.Add(lblMovieLogo);

            // ------------------------ RIGHT PANEL (Inputs) ------------------------
            panelRight = new Panel();
            panelRight.Dock = DockStyle.Fill;
            panelRight.BackColor = Color.White;
            panelRight.Padding = new Padding(40);

            // Welcome Title
            lblTitle = new Label();
            lblTitle.Text = "Welcome Back";
            lblTitle.Font = new Font("Segoe UI Semibold", 22, FontStyle.Bold);
            lblTitle.ForeColor = primaryNavy;
            lblTitle.Location = new Point(45, 50);
            lblTitle.AutoSize = true;

            lblSubTitle = new Label();
            lblSubTitle.Text = "Please login to manage your theater.";
            lblSubTitle.Font = new Font("Segoe UI", 9);
            lblSubTitle.ForeColor = mutedText;
            lblSubTitle.Location = new Point(48, 90);
            lblSubTitle.AutoSize = true;

            // Username Section
            lblUsername = new Label();
            lblUsername.Text = "USERNAME";
            lblUsername.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblUsername.ForeColor = mutedText;
            lblUsername.Location = new Point(50, 145);

            txtUsername = new TextBox();
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11);
            txtUsername.Location = new Point(53, 168);
            txtUsername.Width = 280;

            lineUsername = new Panel();
            lineUsername.BackColor = Color.LightGray;
            lineUsername.Height = 2;
            lineUsername.Width = 280;
            lineUsername.Location = new Point(50, 192);

            // Password Section
            lblPassword = new Label();
            lblPassword.Text = "PASSWORD";
            lblPassword.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblPassword.ForeColor = mutedText;
            lblPassword.Location = new Point(50, 215);

            txtPassword = new TextBox();
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11);
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Location = new Point(53, 238);
            txtPassword.Width = 280;

            linePassword = new Panel();
            linePassword.BackColor = Color.LightGray;
            linePassword.Height = 2;
            linePassword.Width = 280;
            linePassword.Location = new Point(50, 262);

            // Login Button
            btnLogin = new Button();
            btnLogin.Text = "SIGN IN";
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = accentRed;
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnLogin.Size = new Size(280, 45);
            btnLogin.Location = new Point(50, 305);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Click += BtnLogin_Click;

            // Create Account Button (Secondary)
            btnCreateUser = new Button();
            btnCreateUser.Text = "Don't have an account? Create one";
            btnCreateUser.FlatStyle = FlatStyle.Flat;
            btnCreateUser.FlatAppearance.BorderSize = 0;
            btnCreateUser.ForeColor = primaryNavy;
            btnCreateUser.Font = new Font("Segoe UI", 8, FontStyle.Underline);
            btnCreateUser.Size = new Size(280, 30);
            btnCreateUser.Location = new Point(50, 360);
            btnCreateUser.Cursor = Cursors.Hand;
            btnCreateUser.Click += BtnCreateUser_Click;

            // --- Effects & Logic ---
            txtUsername.GotFocus += (s, e) => { lineUsername.BackColor = accentRed; };
            txtUsername.LostFocus += (s, e) => { lineUsername.BackColor = Color.LightGray; };
            txtPassword.GotFocus += (s, e) => { linePassword.BackColor = accentRed; };
            txtPassword.LostFocus += (s, e) => { linePassword.BackColor = Color.LightGray; };

            // ------------------------ ADD CONTROLS ------------------------
            panelRight.Controls.Add(lblTitle);
            panelRight.Controls.Add(lblSubTitle);
            panelRight.Controls.Add(lblUsername);
            panelRight.Controls.Add(txtUsername);
            panelRight.Controls.Add(lineUsername);
            panelRight.Controls.Add(lblPassword);
            panelRight.Controls.Add(txtPassword);
            panelRight.Controls.Add(linePassword);
            panelRight.Controls.Add(btnLogin);
            panelRight.Controls.Add(btnCreateUser);

            this.Controls.Add(panelRight);
            this.Controls.Add(panelLeft);

            // ------------------------ FORM SETTINGS ------------------------
            this.ClientSize = new Size(750, 480);
            this.Text = "DRSB System - Login";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion
    }
}