using Calculator;
using Calculator.Services;
using react_calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace react_calculator.Services
{
    public class GoCalculate
    {
        public void Start (Expression Example)
        {
            var action = new MathOperations();
            action.Calc(Example);
        }

    }
}
