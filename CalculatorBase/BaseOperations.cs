using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorBase
{
    public class BaseOperations : SpecializedOperations
    {
        public double Addition(double first, double second)
        {
            return first + second;
        }
        public double Subtraction(double first, double second)
        {
            return first - second;
        }
        public double Multiplication(double first, double second)
        {
            return first * second;
        }
        public double Divison(double first, double second)
        {
            return first / second;
        }
    }
}
