using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_HM
{
    public class Currency
    {
        public readonly int _dollars;
        public readonly int _cents;

        public Currency() : this(0, 0) { }
        public Currency(int dollars, int cents)
        {
            _dollars = dollars;
            _cents = cents;
        }

        public Currency(double currency)
        {
            _dollars = (int)currency;
            _cents = Int32.Parse(currency.ToString().Split(',')[1]);
        }

        public double ToDouble()
        {
            return Double.Parse($"{_dollars},{_cents}");
        }

        public Currency Add(Currency currency)
        {
            var sum = this.ToDouble() + currency.ToDouble();
            return new Currency(sum);
        }

        public Currency Myltiply(int multiplier)
        {
            return new Currency(this.ToDouble() * multiplier);
        }

        public override string ToString()
        {
            return $"{_dollars}.{_cents}";
        }
    }
}
