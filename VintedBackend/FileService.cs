using Constant = VintedBackend.Constants.Constants;

namespace VintedBackend
{
    public static class FileService
    {
        public static string[] ReadLinesFromFile(string fileName = Constant.FileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("The file does not exist!");
                return [];
            }

            var lines = File.ReadAllLines(fileName);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty!");
                return [];
            }

            return lines;
        }

        public static Shipment? ParseLines(string line)
        {
            string[] parts = line.Split(' ');

            if (parts.Length != 3)
            {
                Console.WriteLine(Constant.IgnoredLine, line);

                return null;
            }

            bool isLineValid = Validators.ValidateAndBuildShipment(parts, out var shipment);

            if (isLineValid)
            {
                return shipment;
            }

            Console.WriteLine(Constant.IgnoredLine, line);

            return null;
        }

        public static string FormatLines(this Shipment shipment)
        {
            var discount = shipment.Discount == 0 ? "-" : shipment.Discount.ToString();

            return $"{shipment.Date.ToString(Constant.DateFormat)} {shipment.Size} {shipment.Provider} {shipment.DiscountPrice:F2} {discount:F2}";
        }
    }
}
