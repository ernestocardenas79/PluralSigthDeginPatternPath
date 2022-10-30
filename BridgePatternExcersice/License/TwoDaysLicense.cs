using BridgePatternExcersice.Discount;
using System;

namespace BridgePatternExcersice.License
{
    public class TwoDaysLicense : MovieLicense
    {
        public TwoDaysLicense(string movie, DateTime purchaseTime, IDiscount discount)
            : base(movie, purchaseTime, discount){}

        protected override decimal BasePrice()=>4;

        public override DateTime? GetExpirationDate()=>PurchaseTime.AddDays(2);
    }
}
