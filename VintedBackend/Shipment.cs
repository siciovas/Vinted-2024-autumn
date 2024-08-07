using VintedBackend.Enums;

namespace VintedBackend
{
    public class Shipment(DateTime date, Size size, Provider provider)
    {
        public DateTime Date { get; set; } = date;
        public Size Size { get; set; } = size;
        public Provider Provider { get; set; } = provider;
        public decimal DiscountPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
