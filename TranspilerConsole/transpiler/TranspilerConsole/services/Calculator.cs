using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranspilerConsole.TInterface;

namespace TranspilerConsole.services
{
    public class Calculator : ICalculator
    {
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        public int Divide(int number1, int number2)
        {
            return number1 / number2;
        }
    }
    
}
