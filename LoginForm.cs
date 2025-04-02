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
            this.Text = "WeAreCars - Staff Login";
            this.Size = new Size(450, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(30, 41, 59);

            // Create main panel with shadow effect
            Panel mainPanel = new Panel
            {
                Size = new Size(400, 500),
                Location = new Point(25, 50),
                BackColor = Color.FromArgb(15, 23, 42)
            };

            // Company logo/name
            Label logoLabel = new Label
            {
                Text = "WeAreCars",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            logoLabel.Location = new Point((mainPanel.Width - logoLabel.PreferredWidth) / 2, 40);

            Label subtitleLabel = new Label
            {
                Text = "Staff Portal",
                Font = new Font("Segoe UI Light", 14),
                ForeColor = Color.FromArgb(226, 232, 240),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            subtitleLabel.Location = new Point((mainPanel.Width - subtitleLabel.PreferredWidth) / 2, 90);

            // Username input
            Label usernameLabel = new Label
            {
                Text = "USERNAME",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(148, 163, 184),
                Location = new Point(50, 160),
                BackColor = Color.Transparent
            };

            usernameTextBox = new TextBox
            {
                Location = new Point(50, 185),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 12),
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            Panel usernameLine = new Panel
            {
                Location = new Point(50, 210),
                Size = new Size(300, 1),
                BackColor = Color.FromArgb(71, 85, 105)
            };

            // Password input
            Label passwordLabel = new Label
            {
                Text = "PASSWORD",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(148, 163, 184),
                Location = new Point(50, 240),
                BackColor = Color.Transparent
            };

            passwordTextBox = new TextBox
            {
                Location = new Point(50, 265),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 12),
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None,
                PasswordChar = '•'
            };

            Panel passwordLine = new Panel
            {
                Location = new Point(50, 290),
                Size = new Size(300, 1),
                BackColor = Color.FromArgb(71, 85, 105)
            };

            // Login button
            loginButton = new Button
            {
                Text = "LOGIN",
                Location = new Point(50, 350),
                Size = new Size(300, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.Click += LoginButton_Click;

            // Error message
            errorLabel = new Label
            {
                ForeColor = Color.FromArgb(239, 68, 68),
                AutoSize = true,
                Location = new Point(50, 410),
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
                Location = new Point(this.Width - 40, 10),
                AutoSize = true
            };
            closeButton.Click += (s, e) => Application.Exit();

            // Add controls to main panel
            mainPanel.Controls.AddRange(new Control[] {
                logoLabel,
                subtitleLabel,
                usernameLabel,
                usernameTextBox,
                usernameLine,
                passwordLabel,
                passwordTextBox,
                passwordLine,
                loginButton,
                errorLabel
            });

            // Add shadow effect to main panel
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

            this.Controls.AddRange(new Control[] { mainPanel, closeButton });

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