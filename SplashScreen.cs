using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeAreCars
{
    public class SplashScreen : Form
    {
        private System.Windows.Forms.Timer timer;
        private int opacity = 0;
        private System.Windows.Forms.Timer fadeTimer;
        
        public SplashScreen()
        {
            InitializeComponent();
            SetupFadeEffect();
        }

        private void SetupFadeEffect()
        {
            this.Opacity = 0;
            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 50;
            fadeTimer.Tick += FadeTimer_Tick;
            fadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.1;
            }
            else
            {
                fadeTimer.Stop();
            }
        }

        private void InitializeComponent()
        {
            this.Text = "Welcome to WeAreCars";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            // Create gradient background
            this.Paint += (sender, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    this.ClientRectangle,
                    Color.FromArgb(30, 41, 59),   // Dark blue
                    Color.FromArgb(15, 23, 42),   // Darker blue
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            };

            // Company Name
            Label companyLabel = new Label
            {
                Text = "WeAreCars",
                Font = new Font("Segoe UI", 36, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            companyLabel.Location = new Point((this.Width - companyLabel.PreferredWidth) / 2, 50);

            // Tagline
            Label taglineLabel = new Label
            {
                Text = "Professional Car Rental Management System",
                Font = new Font("Segoe UI Light", 16),
                ForeColor = Color.FromArgb(226, 232, 240),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            taglineLabel.Location = new Point((this.Width - taglineLabel.PreferredWidth) / 2, 120);

            // Instructions Panel
            Panel instructionsPanel = new Panel
            {
                Location = new Point(50, 180),
                Size = new Size(700, 250),
                BackColor = Color.FromArgb(30, 255, 255, 255)
            };

            Label instructionsTitle = new Label
            {
                Text = "Getting Started",
                Font = new Font("Segoe UI Semibold", 14),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(20, 20)
            };

            Label instructionsLabel = new Label
            {
                Text = "1. Login using your staff credentials (Username: sta001)\n\n" +
                      "2. Navigate through the intuitive dashboard interface\n\n" +
                      "3. Process new bookings with comprehensive customer details\n\n" +
                      "4. Select from our range of vehicles and customization options\n\n" +
                      "5. Track all rentals and manage bookings efficiently",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.FromArgb(226, 232, 240),
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(20, 60)
            };

            // Version info
            Label versionLabel = new Label
            {
                Text = "Version 1.0.0",
                Font = new Font("Segoe UI Light", 9),
                ForeColor = Color.FromArgb(148, 163, 184),
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(10, this.Height - 30)
            };

            // Loading indicator
            Label loadingLabel = new Label
            {
                Text = "Loading...",
                Font = new Font("Segoe UI Light", 10),
                ForeColor = Color.FromArgb(226, 232, 240),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            loadingLabel.Location = new Point(this.Width - loadingLabel.PreferredWidth - 20, this.Height - 30);

            instructionsPanel.Controls.AddRange(new Control[] { instructionsTitle, instructionsLabel });

            this.Controls.AddRange(new Control[] {
                companyLabel,
                taglineLabel,
                instructionsPanel,
                versionLabel,
                loadingLabel
            });

            // Add shadow border
            this.Paint += (sender, e) =>
            {
                const int BORDER_SIZE = 1;
                Color borderColor = Color.FromArgb(50, 255, 255, 255);
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid);
            };

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
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
                    LoginForm loginForm = new LoginForm();
                    this.Hide();
                    loginForm.Show();
                }
            };
            fadeTimer.Start();
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