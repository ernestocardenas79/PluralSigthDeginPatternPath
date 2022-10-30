using BridgePatternExcersice.Discount;
using System;

namespace BridgePatternExcersice.License
{

    public class LifeLongLicense : MovieLicense
    {
        public LifeLongLicense(string movie, DateTime purchaseTime, IDiscount discount)
            : base(movie, purchaseTime, discount)
        {
        }

        protected override decimal BasePrice()
        {
            return 8;
        }

        public override DateTime? GetExpirationDate()
        {
            return null;
        }
    }
}
