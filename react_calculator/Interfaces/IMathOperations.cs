using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Interfaces
{
    public interface IMathOperations
    {
        public double Minus(double[] numbers);
        public double Pow(double[] numbers);
        public double Sum(double[] numbers);
        public double Multiplication(double[] numbers);
        public double Division(double[] numbers);
    }
}
