using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePatternExcersice.Discount
{
    internal class NoDiscount : IDiscount
    {
        public int discount() => 0;
    }
}
