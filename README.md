# WeAreCars Rental Management System

A Windows Forms application for managing car rentals at WeAreCars. This system allows staff members to process car rentals, manage bookings, and track rental history.

## Features

- Staff login system with secure authentication
- Car rental booking management system
- Multiple car types and fuel options
- Optional extras (unlimited mileage, breakdown cover)
- Rental history tracking with booking references
- Input validation and error handling
- Professional user interface with intuitive layout

## Prerequisites

Before you begin, ensure you have the following installed:
1. **Git** 
   - Download from: https://git-scm.com/downloads
   - To verify installation, open PowerShell and type: `git --version`

2. **.NET 6.0 SDK**
   - Download from: https://dotnet.microsoft.com/download/dotnet/6.0
   - Choose the x64 version for Windows
   - To verify installation, open PowerShell and type: `dotnet --version`

## Step-by-Step Installation Guide

1. **Create a Project Folder**
   - Open File Explorer
   - Go to a location where you want to store the project (e.g., Desktop or Documents)
   - Create a new folder (e.g., "WeAreCars")

2. **Open Terminal/PowerShell**
   - Press `Windows + R`
   - Type `powershell` and press Enter
   - OR right-click Start button and select "Windows PowerShell"

3. **Navigate to Your Project Folder**
   ```powershell
   # If folder is on Desktop:
   cd C:\Users\YOUR_USERNAME\Desktop\WeAreCars
   # Replace YOUR_USERNAME with your Windows username
   ```

4. **Clone the Repository**
   ```powershell
   git clone https://github.com/SaugatBhujel/WeAreCars.git
   cd WeAreCars
   ```

5. **Build and Run the Application**
   ```powershell
   dotnet build
   dotnet run
   ```

## Login Credentials

To access the system, use these credentials:
- **Username:** sta001
- **Password:** givemethekeys123

## Using the Application

1. **Launch and Login**
   - Start the application
   - Enter the staff credentials
   - Wait for the main interface to load

2. **Creating a New Booking**
   - Click on the "New Booking" tab
   - Fill in all required customer details (marked with *)
   - Select rental options:
     - Number of days (1-28 days)
     - Car type
     - Fuel type
     - Optional extras

3. **Calculate and Confirm Booking**
   - Click "Calculate Total" to see the price
   - Review the booking details
   - Click "Confirm Booking" to complete the rental
   - Note down the booking reference number

4. **View Rentals**
   - Click on the "Current Rentals" tab
   - View all active rentals and their details

## Pricing Structure

### Base Rate
- £25 per day

### Car Type Surcharges
- City car: No extra charge
- Family car: +£50
- Sports car: +£75
- SUV: +£65

### Fuel Type Surcharges
- Petrol: No extra charge
- Diesel: No extra charge
- Hybrid: +£30
- Full electric: +£50

### Optional Extras
- Unlimited mileage: +£10 per day
- Breakdown cover: +£2 per day

## Troubleshooting

1. **Git Not Recognized**
   - Reinstall Git
   - Add Git to system PATH
   - Restart PowerShell

2. **Dotnet Command Not Found**
   - Reinstall .NET 6.0 SDK
   - Add .NET to system PATH
   - Restart PowerShell

3. **Build Errors**
   - Ensure you have the correct .NET SDK version
   - Try cleaning the solution: `dotnet clean`
   - Rebuild: `dotnet build`

## System Requirements

- Operating System: Windows 10 or later
- RAM: 4GB minimum (8GB recommended)
- Storage: 100MB free space
- Display: 1280x720 or higher resolution

## Support

If you encounter any issues:
1. Check the troubleshooting section
2. Verify all prerequisites are installed
3. Ensure you're using the correct credentials
4. Try restarting the application

## Updates and Maintenance

To get the latest updates:
```powershell
git pull origin main
dotnet build
```

## License

This project is part of an academic assessment and is intended for educational purposes only. 