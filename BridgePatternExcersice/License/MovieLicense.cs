using BridgePatternExcersice.Discount;
using System;

namespace BridgePatternExcersice.License
{
    public abstract class MovieLicense
    {
        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        private readonly IDiscount _discount; 

        protected MovieLicense(string movie, DateTime purchaseTime, IDiscount discount )
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
            _discount = discount ?? new NoDiscount();
        }

        public decimal GetPrice() {
            int discount = _discount.discount();
            decimal multiplayer = 1 - discount / 100m;

            return BasePrice() * multiplayer;
        }

        protected abstract decimal BasePrice();
        public abstract DateTime? GetExpirationDate();
    }
}
