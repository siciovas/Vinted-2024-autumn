using Constant = VintedBackend.Constants.Constants;

namespace VintedBackend
{
    public class DiscountCalculation
    {
        public DateTime PreviousDate;
        private decimal _discount = Constant.MonthlyDiscount;
        public decimal LpShipmentTimes { get; set; } = Constant.LpShipmentCounter;

        public decimal DiscountBalance(decimal givenDiscount)
        {
            if (givenDiscount > _discount)
            {
                decimal partialDiscount = _discount;
                _discount = 0;

                return partialDiscount;
            }

            _discount -= givenDiscount;

            return givenDiscount;
        }

        public void ValidateShipment(Shipment shipment)
        {
            if (shipment.Date.IsNextMonth(PreviousDate))
            {
                _discount = Constant.MonthlyDiscount;
                LpShipmentTimes = Constant.LpShipmentCounter;
            }
            PreviousDate = shipment.Date;
        }
    }
}
