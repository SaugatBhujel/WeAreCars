using System;
using System.Drawing;
using System.Windows.Forms;

namespace WeAreCars
{
    public class SplashScreen : Form
    {
        private System.Windows.Forms.Timer timer;
        
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Welcome to WeAreCars";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            Label welcomeLabel = new Label
            {
                Text = "Welcome to WeAreCars Rental System",
                Font = new Font("Arial", 20, FontStyle.Bold),
                AutoSize = true
            };
            welcomeLabel.Location = new Point((this.Width - welcomeLabel.PreferredWidth) / 2, 50);

            Label instructionsLabel = new Label
            {
                Text = "Instructions:\n\n" +
                      "1. Login using your staff credentials\n" +
                      "2. View available cars and current rentals\n" +
                      "3. Process new bookings by entering customer details\n" +
                      "4. Select car type and additional options\n" +
                      "5. Review booking summary before confirmation",
                Font = new Font("Arial", 12),
                AutoSize = true
            };
            instructionsLabel.Location = new Point(50, 150);

            this.Controls.Add(welcomeLabel);
            this.Controls.Add(instructionsLabel);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // 3 seconds
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
        }
    }
} 