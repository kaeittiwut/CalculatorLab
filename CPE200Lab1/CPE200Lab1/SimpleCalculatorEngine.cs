using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class SimpleCalculatorEngine : CalculatorEngine
    {
        double firstOperand;
        double secondOperand;

        public void setFirstOperand (string num)
        {
            firstOperand = Convert.ToDouble(num);
        }
        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }
        public string calculate(string oper)
        {
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
                    if (secondOperand != 0)
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
                    if (secondOperand != 0)
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
    }
}
