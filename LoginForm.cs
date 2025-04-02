using System;
using System.Drawing;
using System.Windows.Forms;

namespace WeAreCars
{
    public class LoginForm : Form
    {
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label errorLabel;

        private const string VALID_USERNAME = "sta001";
        private const string VALID_PASSWORD = "givemethekeys123";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "WeAreCars - Staff Login";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label titleLabel = new Label
            {
                Text = "Staff Login",
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(140, 20)
            };

            Label usernameLabel = new Label
            {
                Text = "Username:",
                Location = new Point(50, 80)
            };

            usernameTextBox = new TextBox
            {
                Location = new Point(150, 80),
                Size = new Size(180, 20)
            };

            Label passwordLabel = new Label
            {
                Text = "Password:",
                Location = new Point(50, 120)
            };

            passwordTextBox = new TextBox
            {
                Location = new Point(150, 120),
                Size = new Size(180, 20),
                PasswordChar = '•'
            };

            loginButton = new Button
            {
                Text = "Login",
                Location = new Point(150, 170),
                Size = new Size(100, 30)
            };
            loginButton.Click += LoginButton_Click;

            errorLabel = new Label
            {
                ForeColor = Color.Red,
                AutoSize = true,
                Location = new Point(50, 220)
            };

            this.Controls.AddRange(new Control[] { 
                titleLabel, 
                usernameLabel, 
                usernameTextBox, 
                passwordLabel, 
                passwordTextBox, 
                loginButton, 
                errorLabel 
            });
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == VALID_USERNAME && passwordTextBox.Text == VALID_PASSWORD)
            {
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.Show();
            }
            else
            {
                errorLabel.Text = "Invalid username or password. Please try again.";
            }
        }
    }
} 