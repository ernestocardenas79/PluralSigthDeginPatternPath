using System;
using BridgePatternExcersice.License;
using BridgePatternExcersiceAlternative.Discount;
using BridgePatternExcersiceAlternative.License;

namespace BridgePattern
{
    public class Program
    {
        public static void Main()
        {
            DateTime now = DateTime.Now;

            var license1 = new MovieLicense("Secret Life of Pets", now, Discount.None, LicenseType.TwoDays);
            var license2 = new MovieLicense("Matrix", now, Discount.None, LicenseType.LifeLong);

            var license1MilitaryDiscount = new MovieLicense("Secret Life of Pets", now, Discount.Military, LicenseType.TwoDays);
            var license2MilitaryDiscount = new MovieLicense("Matrix", now, Discount.Military, LicenseType.LifeLong);

            var license1SeniorDiscount = new MovieLicense("Secret Life of Pets", now, Discount.Senior, LicenseType.TwoDays);
            var license2SeniorDiscount = new MovieLicense("Matrix", now, Discount.Senior, LicenseType.LifeLong);

            PrintLicenseDetails(license1);
            PrintLicenseDetails(license2);

            PrintLicenseDetails(license1MilitaryDiscount);
            PrintLicenseDetails(license2MilitaryDiscount);

            PrintLicenseDetails(license1SeniorDiscount);
            PrintLicenseDetails(license2SeniorDiscount);


            Console.ReadKey();
        }

        private static void PrintLicenseDetails(MovieLicense license)
        {
            Console.WriteLine($"Movie: {license.Movie}");
            Console.WriteLine($"Price: {GetPrice(license)}");
            Console.WriteLine($"Valid for: {GetValidFor(license)}");

            Console.WriteLine();
        }

        private static string GetPrice(MovieLicense license)
        {
            return $"${license.GetPrice():0.00}";
        }

        private static string GetValidFor(MovieLicense license)
        {
            DateTime? expirationDate = license.GetExpirationDate();

            if (expirationDate == null)
                return "Forever";

            TimeSpan timeSpan = expirationDate.Value - DateTime.Now;

            return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
        }
    }
}
