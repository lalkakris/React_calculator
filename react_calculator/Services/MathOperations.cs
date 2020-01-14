using Calculator.Interfaces;
using react_calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class MathOperations : IMathOperations, IAdd
    {
        public void Processing()
        {
            using (var context = new HistoryContext())
            {
                var request = new Expression();
                var toDo = new MathOperations();
                request.Example = Console.ReadLine();
                double[] numbers = request.Example.Split('+', '-', '*', '/', '^').Select(double.Parse).ToArray();
                string[] operats = request.Example.Split(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, StringSplitOptions.RemoveEmptyEntries);

                switch (operats[0])
                {
                    case "+":
                        request.Solution = toDo.Sum(numbers);
                        break;
                    case "-":
                        request.Solution = toDo.Minus(numbers);
                        break;
                    case "*":
                        request.Solution = toDo.Multiplication(numbers);
                        break;
                    case "/":
                        request.Solution = toDo.Division(numbers);
                        break;
                    case "^":
                        request.Solution = toDo.Pow(numbers);
                        break;
                }
                Console.WriteLine($"The answer is {request.Solution}!");
                toDo.AddRequest(request);
            }
        }

        public void AddRequest(Expression item)
        {
            using (var context = new HistoryContext())
            {
                context.Expressions.Add(item);
                context.SaveChanges();
            }
        }

        public double Sum(double[] numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result += numbers[i];
            }
            return result;
        }

        public double Minus(double[] numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result -= numbers[i];
            }
            return result;
        }

        public double Pow(double[] numbers)
        {
            double result = Math.Pow(numbers[0], numbers[1]);
            return result;
        }

        public double Multiplication(double[] numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result *= numbers[i];
            }
            return result;
        }

        public double Division(double[] numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result /= numbers[i];
            }
            return result;
        }

    }
}
