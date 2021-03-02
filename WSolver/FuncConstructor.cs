using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WSolver
{
    /*
     * Что делает класс:
     * 1) MainConstructor принимает формулу в обратной польской записи
     * 2) Идём по формуле слева направо:
     *      a) Встретив операнд, кладём в стек функцию f_0: (x)=>(операнд)
     *      b) Встретив бинарный оператор, берём из стека два последних операнда f_1 и f_2 и кладём в стек функцию (x)=>(operation(f_1(x),f_2(x)))
     *      c) Встретив унарный оператор, берём из стека последний операнд f_1 и кладём в стек функцию (x)=>(operation(f_1(x)))
     * 3) В конце получаем функцию f(x) как суперпозицию элементарных функций и возвращаем её
     */
    class FuncConstructor
    {
        public static Func<double, double> MainConstructor(string parsed_formula, string variable)
        {
            // все возможные бинарные операторы и сопоставляемые им функции
            string[] BinOpArr = { "+", "-", "*", "/", "^", "log" };
            Dictionary<string, Func<Func<double, double>, Func<double, double>, Func<double, double>>> BinOpDict = new Dictionary<string, Func<Func<double, double>, Func<double, double>, Func<double, double>>>()
            {
                {"+", Plus },
                {"-", Minus },
                {"*", Product },
                {"/", Divide },
                {"^", Power},
                {"log", Log }
            };

            // все возможные унарные операторы и сопоставляемые им функции
            string[] UnOpArr = { "sin", "cos", "tg", "ctg", "ln", "lg" };
            Dictionary<string, Func<Func<double, double>, Func<double, double>>> UnOpDict = new Dictionary<string, Func<Func<double, double>, Func<double, double>>>()
            {
                {"sin", Sin },
                {"cos", Cos },
                {"tg", Tan },
                {"ctg", Cot },
                {"ln", Ln},
                {"lg", Lg }
            };

            Stack<Func<double, double>> Func_Stack = new Stack<Func<double, double>>();
            string[] listed_formula = parsed_formula.Split(' ');
            foreach (string elem in listed_formula)
            {
                //InvalidOperationException выбрасывается при попытке взять элемент из пустого стека
                // если произошла неизвестная ошибка, связанная с вводом, то выбросим SyntaxException
                try
                {
                    if (BinOpArr.Contains(elem))
                    {

                        var s2 = Func_Stack.Pop();
                        var s1 = Func_Stack.Pop();
                        Func_Stack.Push(BinOpDict[elem](s1, s2));
                    }

                    else if (UnOpArr.Contains(elem))
                    {
                        var s1 = Func_Stack.Pop();
                        Func_Stack.Push(UnOpDict[elem](s1));
                    }
                    else
                    {
                        Func_Stack.Push(Liter(elem, variable));
                    }
                }
                catch (InvalidOperationException)
                {
                    throw new SyntaxException("Синтаксическая ошибка в формуле\nПроверьте ещё раз");
                }
            }


            // к концу работы в стеке должна остаться только одна функция, которая и будет f(x)
            try
            {
                return Func_Stack.Pop();
            }
            catch (InvalidOperationException)
            {
                throw new SyntaxException("Синтаксическая ошибка в формуле\nПроверьте ещё раз");
            }
        }

        // получая операнд l возвращает функцию (x)=>(l)
        public static Func<double,double> Liter(string l, string variable)
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

        // далее идут только реализации математических элементарных функций
        // ошибки вроде деления на 0 будут обрабатываться в других блоках (с функциями решений уравнения)
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
        public static Func<double, double> Sin(Func<double, double> s1)
        {
            return (x) => (Math.Sin(s1(x)));
        }
        public static Func<double, double> Cos(Func<double, double> s1)
        {
            return (x) => (Math.Cos(s1(x)));
        }
        public static Func<double, double> Tan(Func<double, double> s1)
        {
            return (x) => (Math.Tan(s1(x)));
        }
        public static Func<double, double> Cot(Func<double, double> s1)
        {
            return (x) => (1 / Math.Tan(s1(x)));
        }
        public static Func<double, double> Ln(Func<double, double> s1)
        {
            return (x) => (Math.Log(s1(x)));
        }
        public static Func<double, double> Lg(Func<double, double> s1)
        {
            return (x) => (Math.Log10(s1(x)));
        }
        public static Func<double, double> Log(Func<double, double> s1, Func<double, double> s2)
        {
            return (x) => (Math.Log(s2(x)) / Math.Log(s1(x)));
        }

    }
}
