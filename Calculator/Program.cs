using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator");
            Console.WriteLine("Insert 'q' to quit anytime");

            while (true)
            {
                Console.WriteLine("Insert your first Number:");
                string input1 = Console.ReadLine();

                if (input1.ToLower() == "q")
                { 
                    break; 
                }
                if(!double.TryParse(input1, out double number1))
                {
                    Console.WriteLine("Invalid Number");
                    continue;
                }
                Console.WriteLine("Now insert a valid Operator(+ - * / %):");
                string inputop = Console.ReadLine();

                if (inputop.ToLower() == "q")
                {
                    break;
                }
                if (!char.TryParse(inputop, out char op))
                {
                    Console.WriteLine("Invalid Operator");
                    continue;
                }
                Console.WriteLine("Insert your second Number:");
                string input2 = Console.ReadLine();
                if (input2.ToLower() == "q")
                {
                    break;
                }
                if (!double.TryParse(input2, out double number2))
                {
                    Console.WriteLine("Invalid Number");
                    continue;
                }

                double result = 0;
                bool validOp = true;
                switch (op)
                {
                    case '+':
                        result = number1 + number2;
                        break;
                    case '-':
                        result = number1 - number2;
                        break;
                    case '*':
                        result = number1 * number2;
                        break;
                    case '/':
                        if (number2 != 0)
                        {
                            result = number1 / number2;
                        }
                        else
                        {
                            Console.WriteLine("error: division / 0!");
                            validOp = false;
                        }
                        break;
                    case '%':
                        result = number1 % number2;
                        break;
                    default:
                        Console.Write("Invalid Operator");
                        validOp = false;
                        break;
                }
                if (validOp == true)
                {
                    Console.WriteLine("Your result is: " + result);
                }
                Console.WriteLine();
            }
        }
    }
}