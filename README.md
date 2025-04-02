# WeAreCars Rental Management System

A Windows Forms application for managing car rentals at WeAreCars.

## Features

- Staff login system
- Car rental booking management
- Multiple car types and fuel options
- Optional extras (unlimited mileage, breakdown cover)
- Rental history tracking
- Input validation and error handling
- Professional user interface

## Requirements

- .NET 6.0 SDK or later
- Windows operating system

## Setup Instructions

1. Install the .NET 6.0 SDK from https://dotnet.microsoft.com/download/dotnet/6.0
2. Clone or download this repository
3. Open a terminal in the project directory
4. Run `dotnet build` to compile the application
5. Run `dotnet run` to start the application

## Login Credentials

- Username: sta001
- Password: givemethekeys123

## Usage

1. Launch the application
2. Log in using the staff credentials
3. Navigate between the booking and rentals pages using the tabs
4. To create a new booking:
   - Fill in all required customer details
   - Select rental options
   - Click "Calculate Total" to see the price
   - Click "Confirm Booking" to complete the rental
5. View all current rentals in the "Current Rentals" tab

## Pricing

- Base rate: £25 per day
- Car type surcharges:
  - City car: No extra charge
  - Family car: +£50
  - Sports car: +£75
  - SUV: +£65
- Fuel type surcharges:
  - Petrol/Diesel: No extra charge
  - Hybrid: +£30
  - Full electric: +£50
- Optional extras:
  - Unlimited mileage: +£10 per day
  - Breakdown cover: +£2 per day 