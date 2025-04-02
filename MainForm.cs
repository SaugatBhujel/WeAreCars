using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WeAreCars
{
    public class MainForm : Form
    {
        private List<Booking> bookings = new List<Booking>();
        private TabControl tabControl;
        private TabPage bookingPage;
        private TabPage rentalsPage;

        // Booking controls
        private TextBox firstNameTextBox;
        private TextBox surnameTextBox;
        private TextBox addressTextBox;
        private NumericUpDown ageNumericUpDown;
        private CheckBox validLicenseCheckBox;
        private NumericUpDown daysNumericUpDown;
        private ComboBox carTypeComboBox;
        private ComboBox fuelTypeComboBox;
        private CheckBox unlimitedMileageCheckBox;
        private CheckBox breakdownCoverCheckBox;
        private Button calculateButton;
        private Label totalLabel;
        private Button confirmButton;

        // Rentals list
        private ListView rentalsListView;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "WeAreCars - Rental Management System";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };

            // Create booking page
            bookingPage = new TabPage("New Booking");
            InitializeBookingPage();

            // Create rentals page
            rentalsPage = new TabPage("Current Rentals");
            InitializeRentalsPage();

            tabControl.TabPages.Add(bookingPage);
            tabControl.TabPages.Add(rentalsPage);

            this.Controls.Add(tabControl);
        }

        private void InitializeBookingPage()
        {
            int currentY = 20;
            int labelX = 20;
            int controlX = 150;
            int controlWidth = 200;

            // Customer Details Group
            GroupBox customerGroup = new GroupBox
            {
                Text = "Customer Details",
                Location = new Point(10, currentY),
                Size = new Size(740, 200)
            };

            // First Name
            Label firstNameLabel = new Label
            {
                Text = "First Name *",
                Location = new Point(labelX, 30)
            };
            firstNameTextBox = new TextBox
            {
                Location = new Point(controlX, 30),
                Width = controlWidth
            };

            // Surname
            Label surnameLabel = new Label
            {
                Text = "Surname *",
                Location = new Point(labelX, 60)
            };
            surnameTextBox = new TextBox
            {
                Location = new Point(controlX, 60),
                Width = controlWidth
            };

            // Address
            Label addressLabel = new Label
            {
                Text = "Address *",
                Location = new Point(labelX, 90)
            };
            addressTextBox = new TextBox
            {
                Location = new Point(controlX, 90),
                Width = controlWidth,
                Multiline = true,
                Height = 40
            };

            // Age
            Label ageLabel = new Label
            {
                Text = "Age *",
                Location = new Point(labelX, 140)
            };
            ageNumericUpDown = new NumericUpDown
            {
                Location = new Point(controlX, 140),
                Width = 70,
                Minimum = 18,
                Maximum = 99
            };

            // Valid License
            validLicenseCheckBox = new CheckBox
            {
                Text = "Valid Driving License *",
                Location = new Point(controlX, 170)
            };

            customerGroup.Controls.AddRange(new Control[] {
                firstNameLabel, firstNameTextBox,
                surnameLabel, surnameTextBox,
                addressLabel, addressTextBox,
                ageLabel, ageNumericUpDown,
                validLicenseCheckBox
            });

            // Rental Details Group
            GroupBox rentalGroup = new GroupBox
            {
                Text = "Rental Details",
                Location = new Point(10, 230),
                Size = new Size(740, 200)
            };

            // Number of Days
            Label daysLabel = new Label
            {
                Text = "Number of Days *",
                Location = new Point(labelX, 30)
            };
            daysNumericUpDown = new NumericUpDown
            {
                Location = new Point(controlX, 30),
                Width = 70,
                Minimum = 1,
                Maximum = 28
            };

            // Car Type
            Label carTypeLabel = new Label
            {
                Text = "Car Type *",
                Location = new Point(labelX, 60)
            };
            carTypeComboBox = new ComboBox
            {
                Location = new Point(controlX, 60),
                Width = controlWidth,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            carTypeComboBox.Items.AddRange(Enum.GetNames(typeof(CarType)));

            // Fuel Type
            Label fuelTypeLabel = new Label
            {
                Text = "Fuel Type *",
                Location = new Point(labelX, 90)
            };
            fuelTypeComboBox = new ComboBox
            {
                Location = new Point(controlX, 90),
                Width = controlWidth,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            fuelTypeComboBox.Items.AddRange(Enum.GetNames(typeof(FuelType)));

            // Optional Extras
            unlimitedMileageCheckBox = new CheckBox
            {
                Text = "Unlimited Mileage (+£10 per day)",
                Location = new Point(controlX, 120)
            };

            breakdownCoverCheckBox = new CheckBox
            {
                Text = "Breakdown Cover (+£2 per day)",
                Location = new Point(controlX, 150)
            };

            rentalGroup.Controls.AddRange(new Control[] {
                daysLabel, daysNumericUpDown,
                carTypeLabel, carTypeComboBox,
                fuelTypeLabel, fuelTypeComboBox,
                unlimitedMileageCheckBox,
                breakdownCoverCheckBox
            });

            // Total and Buttons
            calculateButton = new Button
            {
                Text = "Calculate Total",
                Location = new Point(20, 450),
                Width = 120
            };
            calculateButton.Click += CalculateButton_Click;

            totalLabel = new Label
            {
                Location = new Point(150, 455),
                AutoSize = true,
                Font = new Font(this.Font, FontStyle.Bold)
            };

            confirmButton = new Button
            {
                Text = "Confirm Booking",
                Location = new Point(600, 450),
                Width = 120,
                Enabled = false
            };
            confirmButton.Click += ConfirmButton_Click;

            bookingPage.Controls.AddRange(new Control[] {
                customerGroup,
                rentalGroup,
                calculateButton,
                totalLabel,
                confirmButton
            });
        }

        private void InitializeRentalsPage()
        {
            rentalsListView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };

            rentalsListView.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader { Text = "Booking Ref", Width = 100 },
                new ColumnHeader { Text = "Customer Name", Width = 150 },
                new ColumnHeader { Text = "Car Type", Width = 100 },
                new ColumnHeader { Text = "Days", Width = 50 },
                new ColumnHeader { Text = "Total", Width = 100 },
                new ColumnHeader { Text = "Booking Date", Width = 150 }
            });

            rentalsPage.Controls.Add(rentalsListView);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Please fill in all required fields marked with *", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var booking = CreateBookingFromInputs();
            decimal total = booking.CalculateTotal();
            totalLabel.Text = $"Total: £{total:F2}";
            confirmButton.Enabled = true;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            var booking = CreateBookingFromInputs();
            booking.BookingDate = DateTime.Now;
            booking.BookingReference = GenerateBookingReference();

            bookings.Add(booking);
            AddBookingToListView(booking);

            MessageBox.Show($"Booking confirmed!\nReference: {booking.BookingReference}", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(surnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(addressTextBox.Text) ||
                carTypeComboBox.SelectedIndex == -1 ||
                fuelTypeComboBox.SelectedIndex == -1 ||
                !validLicenseCheckBox.Checked)
                return false;

            return true;
        }

        private Booking CreateBookingFromInputs()
        {
            return new Booking
            {
                FirstName = firstNameTextBox.Text,
                Surname = surnameTextBox.Text,
                Address = addressTextBox.Text,
                Age = (int)ageNumericUpDown.Value,
                HasValidLicense = validLicenseCheckBox.Checked,
                NumberOfDays = (int)daysNumericUpDown.Value,
                CarType = (CarType)Enum.Parse(typeof(CarType), carTypeComboBox.Text),
                FuelType = (FuelType)Enum.Parse(typeof(FuelType), fuelTypeComboBox.Text),
                UnlimitedMileage = unlimitedMileageCheckBox.Checked,
                BreakdownCover = breakdownCoverCheckBox.Checked
            };
        }

        private string GenerateBookingReference()
        {
            return $"BK{DateTime.Now:yyyyMMddHHmmss}";
        }

        private void AddBookingToListView(Booking booking)
        {
            var item = new ListViewItem(new[] {
                booking.BookingReference,
                $"{booking.FirstName} {booking.Surname}",
                booking.CarType.ToString(),
                booking.NumberOfDays.ToString(),
                $"£{booking.CalculateTotal():F2}",
                booking.BookingDate.ToString("g")
            });

            rentalsListView.Items.Add(item);
        }

        private void ResetForm()
        {
            firstNameTextBox.Clear();
            surnameTextBox.Clear();
            addressTextBox.Clear();
            ageNumericUpDown.Value = ageNumericUpDown.Minimum;
            validLicenseCheckBox.Checked = false;
            daysNumericUpDown.Value = daysNumericUpDown.Minimum;
            carTypeComboBox.SelectedIndex = -1;
            fuelTypeComboBox.SelectedIndex = -1;
            unlimitedMileageCheckBox.Checked = false;
            breakdownCoverCheckBox.Checked = false;
            totalLabel.Text = "";
            confirmButton.Enabled = false;
        }
    }
} 