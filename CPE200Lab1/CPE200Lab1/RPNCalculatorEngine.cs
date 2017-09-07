using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // to use stack class

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {
        public string RpnProcess(string stringInput)
        {
            string[] parts = stringInput.Split(' ');
            string result = null;
            Stack rpnStack = new Stack();

            //loop?
            foreach (string input in parts)
            //for(int i = 0; i < parts.Length; i++)
            {
                //string input = parts[i]; //each part one-by-one
                if (isNumber(input))
                {
                    rpnStack.Push(input);
                }
                else if (isOperator(input))
                {
                    string rpnOperate = input;
                    string secondRPNOperand = rpnStack.Pop().ToString();
                    string firstRPNOperand = rpnStack.Pop().ToString();
                    result = calculate(rpnOperate, firstRPNOperand, secondRPNOperand);
                    //rpnStack.Push(result);
                }
                else if(input == "√" || input == "1/x")
                {
                    string rpnOperate = input;
                    string firstRPNOperand = rpnStack.Pop().ToString();
                    result = unaryCalculate(rpnOperate, firstRPNOperand);
                }
                else if(input == "%")
                {
                    string rpnOperate = input;
                    string secondRPNOperand = rpnStack.Pop().ToString();
                    string firstRPNOperand = rpnStack.Pop().ToString();
                    result = calculate(rpnOperate, firstRPNOperand, secondRPNOperand);
                }
                
            }
            return result;
        }
    }
}
