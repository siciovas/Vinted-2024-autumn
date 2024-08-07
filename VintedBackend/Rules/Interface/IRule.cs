namespace VintedBackend.Rules.Interface
{
    public interface IRule
    {
        public void ApplyDiscount(Shipment shipment, DiscountCalculation discountCalculation, decimal currentPrice);
    }
}
