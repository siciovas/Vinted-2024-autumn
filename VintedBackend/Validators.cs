using System.Globalization;
using VintedBackend.Enums;
using Constant = VintedBackend.Constants.Constants;

namespace VintedBackend
{
    public static class Validators
    {
        public static bool ValidateAndBuildShipment(string[] input, out Shipment? shipment)
        {
            shipment = null;

            if (IsValidDate(input[0], out var date)
                && IsValidSize(input[1], out var size)
                && IsValidProvider(input[2], out var provider))
            {
                shipment = new Shipment(date, size, provider);

                return true;
            }

            return false;
        }

        public static bool IsValidDate(string input, out DateTime date)
        {
            return DateTime.TryParseExact(input, Constant.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        public static bool IsValidSize(string input, out Size size)
        {
            return Enum.TryParse(input, out size);
        }

        public static bool IsValidProvider(string input, out Provider provider)
        {
            return Enum.TryParse(input, out provider);
        }

        public static bool IsNextMonth(this DateTime shipmentDate, DateTime previousDate)
        {
            return shipmentDate.Date.Year != previousDate.Year || shipmentDate.Date.Month != previousDate.Month;
        }
    }
}
