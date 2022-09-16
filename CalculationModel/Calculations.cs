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
        private bool isAtomar;

        public Calculations() {}
        public Calculations(string firstOperand, string secondOperand, string operation) 
        {
            CheckOperand(firstOperand);
            if (!isAtomar) CheckOperand(secondOperand);
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

            try
            {
                switch (Operation)
                {
                    case "+":
                        Result = checked(Convert.ToDouble(FirstOperand) + Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case "-":
                        Result = checked(Convert.ToDouble(FirstOperand) - Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case "*":
                        Result = checked(Convert.ToDouble(FirstOperand) * Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case "/":
                        if (SecondOperand == "0")
                        {
                            Result = "Error: numerator is 0";
                            throw new ArgumentException();
                        }
                        Result = checked(Convert.ToDouble(FirstOperand) / Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case "sqrt":
                        double x = Convert.ToDouble(FirstOperand);
                        if (x < 0)
                        {
                            Result = "Error: number is less than zero";
                            throw new ArgumentException();
                        }
                        Result = Math.Sqrt(x).ToString();
                        break;
                    default:
                        Result = "Unknown error";
                        throw new Exception();
                }
            }
            catch (OverflowException) 
            {
                Result = "Error: overflow";
                throw;
            }
            catch
            {
                Result = "Unknown error";
                throw;
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
                    isAtomar = false;
                    break;
                case "sqrt":
                    isAtomar = true;
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
