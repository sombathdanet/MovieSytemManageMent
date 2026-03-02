

namespace MovieSytemManageMent.ApplicationForm.LoginForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent(); // This is REQUIRED!
            this.Load += Form1_Load; // Optional: hook up the Load event
            btnLogin.Click += BtnLogin_Click; // Hook up the click event
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Your load code here
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            bool success = LoginManager.Instance.Login(user, pass);

            if (success)
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Should this be LoginForm or a different form (like MainForm)?
                // If it's supposed to open the main application form:
                // MainForm mainForm = new MainForm();
                // mainForm.Show();
                LoginForm mainForm = new LoginForm(); // This seems wrong - creates another login form
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}