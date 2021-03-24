using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WSolver
{
    /*
     * 1) MainConstructor receives reverse polish notation of formula
     * 2) go from left to right:
     *      a) if operand put function (x)=>(operand) in the stack
     *      b) if unary operator take the latest operand from stack and put function (x)=>(operation(op(x))) there
     *      c) if binary operator take two latest operands from stack and put function (x)=>(operation(op_1(x), op_2(x))) there
     * 3) in the end receive f(x) as superposition for primary functions
     */
    class FuncConstructor
    {
        public static Func<double, double> MainConstructor(string parsedFormula, string variable)
        {
            // all binary operators and their functions
            string[] binOpArr = { "+", "-", "*", "/", "^", "log" };
            Dictionary<string, Func<Func<double, double>, Func<double, double>, Func<double, double>>> binOpDict =
                new Dictionary<string, Func<Func<double, double>, Func<double, double>, Func<double, double>>>()
                {
                    {"+", Plus},
                    {"-", Minus},
                    {"*", Multiply},
                    {"/", Divide},
                    {"^", Power},
                    {"log", Log}
                };

            // all unary operators and their functions
            string[] unOpArr = { "sin", "cos", "tg", "ctg", "ln", "lg", "sqrt", "arcsin", "arccos", "arctg", "arcctg" };
            Dictionary<string, Func<Func<double, double>, Func<double, double>>> unOpDict =
                new Dictionary<string, Func<Func<double, double>, Func<double, double>>>()
                {
                    {"sin", Sin},
                    {"cos", Cos},
                    {"tg", Tan},
                    {"ctg", Cot},
                    {"ln", Ln},
                    {"lg", Lg},
                    {"sqrt", Sqrt},
                    {"arcsin", ASin},
                    {"arccos", ACos},
                    {"arctg", ATan},
                    {"arcctg", ACot}
                };

            Stack<Func<double, double>> funcStack = new Stack<Func<double, double>>();
            string[] listedFormula = parsedFormula.Split(' ');
            foreach (string elem in listedFormula)
            {
                try
                {
                    if (binOpArr.Contains(elem))
                    {
                        // if operator is binary
                        var s2 = funcStack.Pop();
                        var s1 = funcStack.Pop();
                        funcStack.Push(binOpDict[elem](s1, s2));
                    }

                    else if (unOpArr.Contains(elem))
                    {
                        // if operator is unary
                        var s1 = funcStack.Pop();
                        funcStack.Push(unOpDict[elem](s1));
                    }
                    else
                    {
                        // if it is variable or constant
                        funcStack.Push(Liter(elem, variable));
                    }
                }
                catch (InvalidOperationException)
                {
                    // in case of unknown input error
                    //InvalidOperationException is thrown if we try pop() or peak() empty stack
                    throw new SyntaxException("Синтаксическая ошибка в формуле\nПроверьте ещё раз");
                }
            }


            // in the end only f(x) must be left in Func_Stack
            try
            {
                return funcStack.Pop();
            }
            catch (InvalidOperationException)
            {
                throw new SyntaxException("Синтаксическая ошибка в формуле\nПроверьте ещё раз");
            }
        }

        // receives operand, returns function (x)=>(l)
        private static Func<double,double> Liter(string l, string variable)
        {
            
            if (l == variable)
            {
                return (x) => (x);
            }
            else if (l == "-" + variable)
            {
                return (x) => (-x);
            }
            else if (l == "e")
            {
                return (x) => (Math.E);
            }
            else if (l == "-e")
            {
                return (x) => (-Math.E);
            }
            else if (l == "pi")
            {
                return (x) => (Math.PI);
            }
            else if (l == "-pi")
            {
                return (x) => (-Math.PI);
            }
            else
            {
                try
                {
                    return (x) => (Convert.ToDouble(l.Replace(".", ",")));
                }
                catch (InvalidCastException)
                {
                    string num_pattern = @"^[0-9]+[\.,]?[0-9]*$";
                    if (Regex.IsMatch(l, num_pattern, RegexOptions.IgnoreCase))
                    {
                        throw new WrongElementException("Неизвестное число: " + l + "\nПроверьте выражение ещё раз");
                    }
                    else
                    {
                        throw new WrongElementException("Неизвестная последовательность символов: " + l + "\nПроверьте выражение ещё раз");
                    }
                }
            }
        }

        // primary math functions implementations
        private static Func<double, double> Plus(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) => (s1(x) + s2(x));
        }

        private static Func<double, double> Minus(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) => (s1(x) - s2(x));
        }

        public static Func<double, double> Multiply(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) => (s1(x) * s2(x));
        }

        private static Func<double, double> Divide(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) => (s1(x) / s2(x));
        }

        private static Func<double, double> Power(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) => (Math.Pow(s1(x), s2(x)));
        }

        private static Func<double, double> Sin(Func<double, double> s1)
        {
            return (x) => (Math.Sin(s1(x)));
        }

        private static Func<double, double> Cos(Func<double, double> s1)
        {
            return (x) => (Math.Cos(s1(x)));
        }

        private static Func<double, double> Tan(Func<double, double> s1)
        {
            return (x) => (Math.Tan(s1(x)));
        }

        private static Func<double, double> Cot(Func<double, double> s1)
        {
            return (x) => (1 / Math.Tan(s1(x)));
        }

        private static Func<double, double> Ln(Func<double, double> s1)
        {
            return (x) => (Math.Log(s1(x)));
        }

        private static Func<double, double> Lg(Func<double, double> s1)
        {
            return (x) => (Math.Log10(s1(x)));
        }

        private static Func<double, double> Log(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) =>
                (Math.Log(s2(x)) / Math.Log(s1(x)));
        }

        private static Func<double, double> Sqrt(Func<double, double> s1)
        {
            return (x) => (Math.Sqrt(s1(x)));
        }

        private static Func<double, double> ASin(Func<double, double> s1)
        {
            return (x) => (Math.Asin(s1(x)));
        }

        private static Func<double, double> ACos(Func<double, double> s1)
        {
            return (x) => (Math.Acos(s1(x)));
        }

        private static Func<double, double> ATan(Func<double, double> s1)
        {
            return (x) => (Math.Atan(s1(x)));
        }

        private static Func<double, double> ACot(Func<double, double> s1)
        {
            return (x) => (Math.PI/2 - Math.Atan(s1(x)));
        }
    }
}
