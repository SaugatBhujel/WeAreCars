# WeAreCars Rental Management System

![.NET](https://img.shields.io/badge/.NET-6.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Windows](https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![Status](https://img.shields.io/badge/Status-Active-success?style=for-the-badge)
![License](https://img.shields.io/badge/License-Educational-yellow?style=for-the-badge)

A professional Windows Forms application for managing car rentals at WeAreCars. This enterprise-grade system provides a comprehensive solution for processing car rentals, managing bookings, and tracking rental history with a modern, user-friendly interface.

<div align="center">
  <img src="https://user-images.githubusercontent.com/your-username/your-repo/raw/main/screenshots/splash.png" alt="WeAreCars Splash Screen" width="600"/>
</div>

## 🌟 Key Features

- 🔐 Secure staff authentication system
- 📊 Intuitive dashboard interface
- 🚗 Comprehensive vehicle management
- 💰 Dynamic pricing calculator
- 📝 Detailed booking management
- 📈 Real-time rental tracking
- 🎨 Modern UI with animations
- ✅ Robust input validation

## 🚀 Getting Started

### Prerequisites

Before installation, ensure you have the following:

#### Required Software
- **Git** (2.x or later)
  - 📥 [Download Git](https://git-scm.com/downloads)
  - ✔️ Verify: `git --version`

- **.NET 6.0 SDK**
  - 📥 [Download .NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
  - ✔️ Verify: `dotnet --version`

#### System Requirements
- 💻 Windows 10 or later
- 🎮 4GB RAM (8GB recommended)
- 💾 100MB free storage
- 🖥️ 1280x720 or higher resolution

### 📥 Installation

1. **Create Project Directory**
   ```powershell
   # Create and navigate to project folder
   mkdir WeAreCars
   cd WeAreCars
   ```

2. **Clone Repository**
   ```powershell
   git clone https://github.com/SaugatBhujel/WeAreCars.git
   cd WeAreCars
   ```

3. **Build and Run**
   ```powershell
   dotnet build
   dotnet run
   ```

## 🔑 Authentication

Access the system using these credentials:
```
Username: sta001
Password: givemethekeys123
```

## 💻 Usage Guide

### 1. Login Process
- Launch the application
- Enter staff credentials
- Access the main dashboard

### 2. Creating Bookings
- Navigate to "New Booking"
- Fill required customer details
- Select vehicle preferences
- Add optional extras
- Review and confirm

### 3. Managing Rentals
- View all active rentals
- Track booking status
- Access rental history

## 💰 Pricing Structure

### Base Rates
- **Daily Rate:** £25

### Vehicle Surcharges
| Type | Additional Cost |
|------|----------------|
| City Car | No charge |
| Family Car | +£50 |
| Sports Car | +£75 |
| SUV | +£65 |

### Fuel Options
| Type | Additional Cost |
|------|----------------|
| Petrol/Diesel | No charge |
| Hybrid | +£30 |
| Electric | +£50 |

### Optional Extras
- **Unlimited Mileage:** +£10/day
- **Breakdown Cover:** +£2/day

## 🛠️ Troubleshooting

### Common Issues

1. **Git Not Found**
   ```powershell
   # Solution: Reinstall Git and add to PATH
   [Environment]::SetEnvironmentVariable("Path", $env:Path + ";C:\Program Files\Git\cmd", "Machine")
   ```

2. **Dotnet Command Not Found**
   ```powershell
   # Solution: Reinstall .NET SDK and add to PATH
   [Environment]::SetEnvironmentVariable("Path", $env:Path + ";C:\Program Files\dotnet", "Machine")
   ```

3. **Build Errors**
   ```powershell
   dotnet clean
   dotnet restore
   dotnet build
   ```

## 🔄 Updates and Maintenance

Keep your system up to date:
```powershell
git pull origin main
dotnet build
```

## 🤝 Support

Need assistance? Follow these steps:
1. Check the troubleshooting guide
2. Verify system requirements
3. Ensure correct credentials
4. Try restarting the application

## 📝 License

This project is part of an academic assessment and is intended for educational purposes only. All rights reserved.

## 🔍 Technical Details

- **Framework:** .NET 6.0
- **Language:** C# 10.0
- **UI Framework:** Windows Forms
- **Architecture:** Object-Oriented
- **Design Pattern:** Model-View-Controller

## 🏗️ Project Structure

```
WeAreCars/
├── Program.cs          # Application entry point
├── SplashScreen.cs     # Welcome screen
├── LoginForm.cs        # Authentication interface
├── MainForm.cs         # Main application window
├── Booking.cs          # Booking logic and data model
└── README.md          # Documentation
```

## 🌟 Best Practices

- ✨ Modern UI/UX design
- 🔒 Secure authentication
- ♻️ Clean code principles
- 📊 Efficient data management
- 🎯 Input validation
- 🎨 Consistent styling

---

<div align="center">
  Made with ❤️ by Saugat Bhujel
</div> 