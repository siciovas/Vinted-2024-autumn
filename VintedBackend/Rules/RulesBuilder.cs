using VintedBackend.Rules.Interface;
using static VintedBackend.PackageInformation;

namespace VintedBackend.Rules
{
    public class RulesBuilder
    {
        private readonly List<IRule> rules = [];

        public void RuleRegistration(IRule rule)
        {
            rules.Add(rule);
        }

        public void RuleApplication(Shipment shipment, DiscountCalculation discountCalculation)
        {
            var currentPrice = GetCurrentShipmentPrice(shipment);
            shipment.DiscountPrice = currentPrice;

            foreach (var rule in rules)
            {
                rule.ApplyDiscount(shipment, discountCalculation, currentPrice);
            }
        }

        private decimal GetCurrentShipmentPrice(Shipment shipment)
        {
            return Packages.Single(packageInfo => packageInfo.Provider == shipment.Provider && packageInfo.Size == shipment.Size).Price;
        }
    }
}
