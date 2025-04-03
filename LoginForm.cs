using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeAreCars
{
    public class LoginForm : Form
    {
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label errorLabel;
        private System.Windows.Forms.Timer fadeTimer;

        private const string VALID_USERNAME = "sta001";
        private const string VALID_PASSWORD = "givemethekeys123";

        public LoginForm()
        {
            InitializeComponent();
            SetupFadeEffect();
        }

        private void SetupFadeEffect()
        {
            this.Opacity = 0;
            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 50;
            fadeTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.1;
                }
                else
                {
                    fadeTimer.Stop();
                }
            };
            fadeTimer.Start();
        }

        private void InitializeComponent()
        {
            this.Text = "WeAreCars Login";
            this.Size = new Size(350, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(30, 41, 59);

            // Main panel
            Panel mainPanel = new Panel
            {
                Size = new Size(310, 360),
                Location = new Point(20, 20),
                BackColor = Color.FromArgb(15, 23, 42)
            };

            // Simple logo
            Label logoLabel = new Label
            {
                Text = "WeAreCars",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            logoLabel.Location = new Point((mainPanel.Width - logoLabel.PreferredWidth) / 2, 30);

            // Username
            usernameTextBox = new TextBox
            {
                Location = new Point(40, 100),
                Size = new Size(230, 30),
                Font = new Font("Segoe UI", 11),
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.FromArgb(148, 163, 184),
                BorderStyle = BorderStyle.None,
                PlaceholderText = "Username"
            };

            Panel usernameLine = new Panel
            {
                Location = new Point(40, 125),
                Size = new Size(230, 1),
                BackColor = Color.FromArgb(71, 85, 105)
            };

            // Password
            passwordTextBox = new TextBox
            {
                Location = new Point(40, 160),
                Size = new Size(230, 30),
                Font = new Font("Segoe UI", 11),
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.FromArgb(148, 163, 184),
                BorderStyle = BorderStyle.None,
                PasswordChar = '•',
                PlaceholderText = "Password"
            };

            Panel passwordLine = new Panel
            {
                Location = new Point(40, 185),
                Size = new Size(230, 1),
                BackColor = Color.FromArgb(71, 85, 105)
            };

            // Login button
            loginButton = new Button
            {
                Text = "Login",
                Location = new Point(40, 230),
                Size = new Size(230, 38),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11),
                Cursor = Cursors.Hand
            };
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.MouseEnter += (s, e) => loginButton.BackColor = Color.FromArgb(29, 78, 216);
            loginButton.MouseLeave += (s, e) => loginButton.BackColor = Color.FromArgb(37, 99, 235);
            loginButton.Click += LoginButton_Click;

            // Error message
            errorLabel = new Label
            {
                ForeColor = Color.FromArgb(239, 68, 68),
                AutoSize = true,
                Location = new Point(40, 280),
                Font = new Font("Segoe UI", 9),
                BackColor = Color.Transparent
            };

            // Close button
            Label closeButton = new Label
            {
                Text = "×",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(148, 163, 184),
                Cursor = Cursors.Hand,
                Location = new Point(mainPanel.Width - 25, 10),
                AutoSize = true
            };
            closeButton.MouseEnter += (s, e) => closeButton.ForeColor = Color.FromArgb(239, 68, 68);
            closeButton.MouseLeave += (s, e) => closeButton.ForeColor = Color.FromArgb(148, 163, 184);
            closeButton.Click += (s, e) => Application.Exit();

            // Add controls to main panel
            mainPanel.Controls.AddRange(new Control[] {
                logoLabel,
                usernameTextBox,
                usernameLine,
                passwordTextBox,
                passwordLine,
                loginButton,
                errorLabel,
                closeButton
            });

            // Add shadow effect
            mainPanel.Paint += (sender, e) =>
            {
                const int BORDER_SIZE = 1;
                Color borderColor = Color.FromArgb(50, 255, 255, 255);
                ControlPaint.DrawBorder(e.Graphics, mainPanel.ClientRectangle,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid);
            };

            this.Controls.Add(mainPanel);

            // Enable form dragging
            bool isDragging = false;
            Point dragStart = Point.Empty;

            this.MouseDown += (s, e) =>
            {
                isDragging = true;
                dragStart = new Point(e.X, e.Y);
            };

            this.MouseMove += (s, e) =>
            {
                if (isDragging)
                {
                    Point p = PointToScreen(e.Location);
                    Location = new Point(p.X - dragStart.X, p.Y - dragStart.Y);
                }
            };

            this.MouseUp += (s, e) => isDragging = false;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                errorLabel.Text = "Please enter both username and password.";
                return;
            }

            if (usernameTextBox.Text == VALID_USERNAME && passwordTextBox.Text == VALID_PASSWORD)
            {
                fadeTimer = new System.Windows.Forms.Timer();
                fadeTimer.Interval = 50;
                fadeTimer.Tick += (s, args) =>
                {
                    if (this.Opacity > 0)
                    {
                        this.Opacity -= 0.1;
                    }
                    else
                    {
                        fadeTimer.Stop();
                        MainForm mainForm = new MainForm();
                        this.Hide();
                        mainForm.Show();
                    }
                };
                fadeTimer.Start();
            }
            else
            {
                errorLabel.Text = "Invalid username or password. Please try again.";
                passwordTextBox.Clear();
                passwordTextBox.Focus();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000; // Drop shadow
                return cp;
            }
        }
    }
} 