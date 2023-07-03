using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorBase
{
    public class SpecializedOperations : IOperations
    {
        public double SquareRoot(double first)
        {
            return Math.Sqrt(first);
        }
        public double Power(double first, double second)
        {
            return Math.Pow(first, second);
        }

    }
}
