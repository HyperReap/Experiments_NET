using System;
using System.Linq;

namespace NoConditionals.IfElseToTable
{
    internal static class SensorValueToMovementConverter
    {
        private static readonly Measure[] Measures =
        {
            new Measure(cc=> cc > 8,  c=> 5*c*c-3),
            new Measure(cc=> cc > 4,  c=> 4*c-3),
            new Measure(cc=> cc >= 0, c=> 3*c-1),
            new Measure(cc=> true,    c=> 2*c),
        };

        internal static int CalculateBasedOnPrecision(int measuredValue)
        {
            return Measures.First(x => x.canCalculate(measuredValue)).calculate(measuredValue);
        }
    }

    internal class Measure
    {
        public Func<int, bool> canCalculate;
        public Func<int, int> calculate;
        public Measure(Func<int, bool> canCalculate, Func<int, int> calculate)
        {
            this.canCalculate = canCalculate;
            this.calculate = calculate;
        }



    }

}