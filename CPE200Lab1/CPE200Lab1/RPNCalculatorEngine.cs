using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; //can use stack
using System.Threading;
using System.Globalization;

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {

        /*
        public override string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            return base.calculate(operate, firstOperand, secondOperand, maxOutputSize);
        }
        */
        /*
        public void testStackMethod()
        {
            Stack testStack = new Stack();
            testStack.Push("1st element");
            testStack.Push("2nd element");
            testStack.Pop();
            Console.Out.WriteLine(testStack.Pop());
        }
        */
        static void Anc(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string rpn = "3 4 2 * 1 5 - 2 3 ^ ^ / +";
            Console.WriteLine("{0}\n", rpn);

            decimal result = CalculateRPN(rpn);
            Console.WriteLine("\nResult is {0}", result);
        }

        static decimal CalculateRPN(string rpn)
        {
            string[] rpnTokens = rpn.Split(' ');
            Stack<decimal> stack = new Stack<decimal>();
            decimal number = decimal.Zero;

            foreach (string token in rpnTokens)
            {
                if (decimal.TryParse(token, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    switch (token)
                    {
                        case "^":
                        case "pow":
                            {
                                number = stack.Pop();
                                stack.Push((decimal)Math.Pow((double)stack.Pop(), (double)number));
                                break;
                            }
                        case "ln":
                            {
                                stack.Push((decimal)Math.Log((double)stack.Pop(), Math.E));
                                break;
                            }
                        case "sqrt":
                            {
                                stack.Push((decimal)Math.Sqrt((double)stack.Pop()));
                                break;
                            }
                        case "*":
                            {
                                stack.Push(stack.Pop() * stack.Pop());
                                break;
                            }
                        case "/":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() / number);
                                break;
                            }
                        case "+":
                            {
                                stack.Push(stack.Pop() + stack.Pop());
                                break;
                            }
                        case "-":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() - number);
                                break;
                            }
                        default:
                            Console.WriteLine("Error in CalculateRPN(string) Method!");
                            break;
                    }
                }
                PrintState(stack);
            }

            return stack.Pop();
        }

        internal void testStackMethod()
        {
            throw new NotImplementedException();
        }

        static void PrintState(Stack<decimal> stack)
        {
            decimal[] arr = stack.ToArray();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write("{0,-8:F3}", arr[i]);
            }

            Console.WriteLine();

        }
    }
}
