using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    class FuncConstructor
    {
        public static Func<double,double> MainConstructor(string parsed_formula, string variable)
        {
            Stack<Func<double, double>> Func_Stack = new Stack<Func<double, double>>();
            string[] listed_formula = parsed_formula.Split(' ');

            foreach (string elem in listed_formula)
            {
                if (elem == "+")
                {
                    var s2 = Func_Stack.Pop();
                    var s1 = Func_Stack.Pop();
                    Func_Stack.Push(Plus(s1, s2));
                }
                else if (elem == "-")
                {
                    var s2 = Func_Stack.Pop();
                    var s1 = Func_Stack.Pop();
                    Func_Stack.Push(Minus(s1, s2));
                }
                else if (elem == "*")
                {
                    var s2 = Func_Stack.Pop();
                    var s1 = Func_Stack.Pop();
                    Func_Stack.Push(Product(s1, s2));
                }
                else if (elem == "/")
                {
                    var s2 = Func_Stack.Pop();
                    var s1 = Func_Stack.Pop();
                    Func_Stack.Push(Divide(s1, s2));
                }
                else if (elem == "^")
                {
                    var s2 = Func_Stack.Pop();
                    var s1 = Func_Stack.Pop();
                    Func_Stack.Push(Power(s1, s2));
                }
                else
                {
                    Func_Stack.Push(Liter(elem, variable));
                }
            }
            return Func_Stack.Pop();
        }

        public static Func<double,double> Liter(string l, string variable)
        {
            if (l == variable)
            {
                return (x) => (x);
            }
            else if (l == "e")
            {
                return (x) => (Math.E);
            }
            else if (l == "pi")
            {
                return (x) => (Math.PI);
            }
            else
            {
                return (x) => (Convert.ToDouble(l.Replace(".", ",")));
            }
        }

        public static Func<double, double> Plus(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) => (s1(x) + s2(x));
        }

        public static Func<double, double> Minus(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) => (s1(x) - s2(x));
        }

        public static Func<double, double> Product(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) => (s1(x) * s2(x));
        }

        public static Func<double, double> Divide(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) => (s1(x) / s2(x));
        }
        public static Func<double, double> Power(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) => (Math.Pow(s1(x), s2(x)));
        }

    }
}
