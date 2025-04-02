using System;

namespace WeAreCars
{
    public class Booking
    {
        // Customer details
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public bool HasValidLicense { get; set; }

        // Rental details
        public int NumberOfDays { get; set; }
        public CarType CarType { get; set; }
        public FuelType FuelType { get; set; }
        public bool UnlimitedMileage { get; set; }
        public bool BreakdownCover { get; set; }

        // Booking metadata
        public DateTime BookingDate { get; set; }
        public string BookingReference { get; set; }

        public decimal CalculateTotal()
        {
            decimal total = 0;

            // Base rate per day
            total += NumberOfDays * 25;

            // Car type charges
            switch (CarType)
            {
                case CarType.Family:
                    total += 50;
                    break;
                case CarType.Sports:
                    total += 75;
                    break;
                case CarType.SUV:
                    total += 65;
                    break;
            }

            // Fuel type charges
            switch (FuelType)
            {
                case FuelType.Hybrid:
                    total += 30;
                    break;
                case FuelType.Electric:
                    total += 50;
                    break;
            }

            // Optional extras
            if (UnlimitedMileage)
                total += NumberOfDays * 10;
            if (BreakdownCover)
                total += NumberOfDays * 2;

            return total;
        }

        public bool ValidateBooking()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(Surname) ||
                string.IsNullOrWhiteSpace(Address))
                return false;

            if (Age < 18)
                return false;

            if (!HasValidLicense)
                return false;

            if (NumberOfDays < 1 || NumberOfDays > 28)
                return false;

            return true;
        }
    }

    public enum CarType
    {
        City,
        Family,
        Sports,
        SUV
    }

    public enum FuelType
    {
        Petrol,
        Diesel,
        Hybrid,
        Electric
    }
} 