using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePatternExcersice.Discount
{
    internal class MilitaryDiscount : IDiscount
    {
        public int discount() => 10;
    }
}
