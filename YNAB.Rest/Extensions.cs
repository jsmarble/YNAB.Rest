using System;
using System.Collections.Generic;
using System.Text;

namespace YNAB.Rest
{
    public static class Extensions
    {
        public static decimal YnabIntToDecimal(this int source) => ((decimal)source) / 1000;
    }
}
