﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        protected Stack<string> myStack;

        public string calculate(string oper)
        {
            string secondOperand = myStack.Pop();
            string firstOperand = myStack.Pop();
            

            int maxOutputSize = 8;
            switch (oper)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        if (Convert.ToDouble(firstOperand) % Convert.ToDouble(secondOperand) == 0)
                        {
                            return result.ToString();
                        }

                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }

                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =

                        if ((Convert.ToDouble(firstOperand) % Convert.ToDouble(secondOperand)) == 0)
                        {
                            return Convert.ToString(Convert.ToInt32(result));
                        }
                        //string.Format("{0:G29}", decimal.Parse(Convert.ToString(result)));
                        //decimal.Parse(result).ToString("G29");
                        double r;
                        string h;
                        h = result.ToString("N4");
                        string[] deci = h.Split('.');
                        r = Convert.ToDouble(deci[1]);
                        if (r % 10 == 0 || Convert.ToDouble(deci[1]) % 100 == 0 || Convert.ToDouble(deci[1]) % 1000 == 0 || Convert.ToDouble(deci[1]) % 10000 == 0)
                        {
                            //return result.ToString("N4");
                            return result.ToString("G29");
                        }
                        //return result.ToString("G29");
                        return result.ToString("N4");
                    }
                    break;
                case "%":
                    //your code here
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = ((Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)) / 100);
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }
        public new string Process(string str)
        {
            if (str == null || str == "")
            {
                return "E";
            }

            if (str == "0")
            {
                return "0";
            }




            myStack = new Stack<string>();
            //Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            if (parts.Count < 3)
            {
                return "E";
            }

            string result;
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                //if (token == "√" || token == "1/x")
                //{

                //    firstOperand = myStack.Pop().ToString();
                //    result = calculate(token);
                //    myStack.Push(result);
                //}
                //else if (token == "%")
                //{
                //    secondOperand = myStack.Pop().ToString();
                //    if (myStack.Count == 0)
                //        return "E";
                //    firstOperand = myStack.Pop().ToString();
                //    myStack.Push(firstOperand.ToString());
                //    result = calculate(token);
                //    myStack.Push(result);

                //}
                //else 
                if (isNumber(token))
                {
                    myStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    if (myStack.Count == 0 || myStack.Count == 1)
                    {
                        return "E";
                    }
                        
                    //secondOperand= myStack.Pop();
                    //firstOperand = myStack.Pop();
                    result = calculate(token);
                    if (result is "E")
                    {
                        return result;
                    }
                    myStack.Push(result);
                    
                }
                
            }
           

            //FIXME, what if there is more than one, or zero, items in the stack?
            if (myStack.Count != 0)
            {
                result = myStack.Pop();
            }
            else
            {
                result = "E";
            }
            return result;
        }
    }
}
