using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationModel
{
    public class Calculations
    {
        public string FirstOperand { get; set; } = string.Empty;
        public string SecondOperand { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public string Result { get; private set; } = string.Empty;

        public Calculations() {}
        public Calculations(string firstOperand, string secondOperand, string operation) 
        {
            CheckOperand(firstOperand);
            CheckOperand(secondOperand);
            CheckOperation(operation);
            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operation = operation;
        }

        public void GetResult() 
        {
            CheckOperand(FirstOperand);
            CheckOperand(SecondOperand);
            CheckOperation(Operation);
            switch (Operation)
            {
                case "+":
                    Result = (Convert.ToDouble(FirstOperand) + Convert.ToDouble(SecondOperand)).ToString();
                    break;
                case "-":
                    Result = (Convert.ToDouble(FirstOperand) - Convert.ToDouble(SecondOperand)).ToString();
                    break;
                case "*":
                    Result = (Convert.ToDouble(FirstOperand) * Convert.ToDouble(SecondOperand)).ToString();
                    break;
                case "/":
                    if (SecondOperand == "0") { Result = "Error: numerator is 0"; break; }
                    Result = (Convert.ToDouble(FirstOperand) / Convert.ToDouble(SecondOperand)).ToString();
                    break;
                default:
                    Result = "Unknown error";
                    break;
            }
        }

        private void CheckOperation(string operation)
        {
            switch (operation)
            {
                case "+": 
                case "-":
                case "*":
                case "/":
                    break;
                default:
                    Result = "Error: operation is not correct";
                    throw new ArgumentException();
            }
        }

        private void CheckOperand(string operand)
        {
            try
            {
                Convert.ToDouble(operand);
            }
            catch 
            {
                Result = "Error: operand is not number";
                throw;
            }
        }
    }
}
