using BridgePatternExcersiceAlternative.Discount;
using BridgePatternExcersiceAlternative.License;
using System;


namespace BridgePatternExcersice.License
{
    public partial class MovieLicense
    {
        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        private readonly Discount _discount;
        private readonly LicenseType _licenseType;
        private readonly SpecialOffer _specialOffer;

        public MovieLicense(string movie, 
                            DateTime purchaseTime, 
                            Discount discount, 
                            LicenseType licenseType, 
                            SpecialOffer specialOffer = SpecialOffer.None)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
            _discount = discount;
            _licenseType = licenseType;
            _specialOffer = specialOffer;
        }

        public decimal GetPrice() {
            int discount = GetDiscount();
            decimal multiplayer = 1 - GetDiscount() / 100m;

            return BasePrice() * multiplayer;
        }

        private int GetDiscount()
        {
            return _discount switch
            {
                Discount.None => 0,
                Discount.Military => 10,
                Discount.Senior => 20,
                _ => 0,
            };
        }

        public decimal BasePrice()
        {
            return _licenseType switch
            {
                LicenseType.TwoDays => 4,
                LicenseType.LifeLong => 8,
                _ => throw new ArgumentException()
            };
        }

        public DateTime? GetExpirationDate()
        {
            var expirationDate = _licenseType switch
            {
                LicenseType.TwoDays => PurchaseTime.AddDays(2) as DateTime?,
                LicenseType.LifeLong => null,
                _ => throw new ArgumentException()
            };

            if(expirationDate is null) return null;

            var specialOffer = GetExpirationDateSpecialOffer();

            return expirationDate.Value.AddDays(specialOffer);
        }

        private DateTime? GetExpirationDateBase()
        {
            return _licenseType switch
            {
                LicenseType.TwoDays => PurchaseTime.AddDays(2),
                LicenseType.LifeLong => null,
                _ => throw new ArgumentException()
            };
        }

        public int GetExpirationDateSpecialOffer()
        {

            if (Discount.Senior != _discount) {
                return 0;
            }
            
            return _specialOffer switch
            {
                SpecialOffer.TwoDays => 2,
                SpecialOffer.None => 0,
                _ => throw new ArgumentException()
            };
        }
    }
}
