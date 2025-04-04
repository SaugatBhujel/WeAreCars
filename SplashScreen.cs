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
        private PictureBox logoBox;
        
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
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            // GIF Logo PictureBox - Make it the main focus
            logoBox = new PictureBox
            {
                Size = new Size(400, 400), // Larger size for the GIF
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Location = new Point((this.Width - 400) / 2, (this.Height - 400) / 2)
            };

            // Loading text at the bottom
            Label loadingLabel = new Label
            {
                Text = "Loading...",
                Font = new Font("Segoe UI Light", 12),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            loadingLabel.Location = new Point((this.Width - loadingLabel.PreferredWidth) / 2, logoBox.Bottom + 10);

            // Add controls to form
            this.Controls.AddRange(new Control[] {
                logoBox,
                loadingLabel
            });

            // Add subtle shadow to form
            this.Paint += (sender, e) =>
            {
                const int BORDER_SIZE = 1;
                Color borderColor = Color.FromArgb(30, 0, 0, 0);
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid,
                    borderColor, BORDER_SIZE, ButtonBorderStyle.Solid);
            };

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // 3 seconds display time
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void SetLogoGif(string gifPath)
        {
            try
            {
                if (System.IO.File.Exists(gifPath))
                {
                    logoBox.Image = Image.FromFile(gifPath);
                }
                else
                {
                    MessageBox.Show($"GIF file not found at path: {gifPath}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading GIF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    if (logoBox.Image != null)
                    {
                        logoBox.Image.Dispose();
                        logoBox.Image = null;
                    }
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