using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    /*
    * !!!UNDER CONSTRUCTION!!!
    */
    class Newton
    {
        public static System.Random Rand = new Random();
        // all found roots
        public static List<double> roots = new List<double>();
        public static List<double> MainSolver(Func<double, double> f)
        {
            roots = new List<double>();
            double a_default = -Rand.Next(100, 200), b_default = Rand.Next(100, 200), x_0;
            //x_0 - приблеженное значение

            double a, b;
            double eps = 0.00000001; // roots precision 
            int rootRepeat = 0;
            while (true)
            {
                // roots are searched on [a,b]
                a = a_default;
                b = b_default;
                // условие на сходимость
                if (f(a) * SecondDerivative(f, a) > 0)
                {
                    x_0 = FindRoot(f, a);
                }
                else if (f(b) * SecondDerivative(f, b) > 0)
                {
                    x_0 = FindRoot(f, b);
                }
                else
                {
                    break;
                }
                

                double new_root = x_0;

                if (CheckRoot(f, new_root) && !roots.Contains(Math.Round(new_root, 2)))
                {
                    rootRepeat = 0;
                    roots.Add(Math.Round(new_root, 2));
                    // new function f(x):=f(x)/(x-x_0)
                    f = FunctionModifier(f, new_root);
                }
                else
                {
                    rootRepeat++;

                    a_default -= Rand.Next(100, 500);
                    b_default += Rand.Next(100, 500);
                }

                if (rootRepeat > 100 || roots.Count > 50)
                {
                    return roots;
                }

            }
            return roots;
        }

        static bool CheckRoot(Func<double, double> f, double x)
        {
            double eps = 0.00001;
            bool isRoot = Math.Abs(f(x)) < eps;
            return isRoot;
        }

        static double Derivative(Func<double, double> f, double x)
        {
            double h = 0.001;
            return (f(x + h) - f(x - h)) / (2 * h);
        }
        static double SecondDerivative(Func<double, double> f, double x)
        {
            double deltaX = 0.001;
            double v1 = Derivative(f, x);
            double v2 = Derivative(f, x + deltaX);
            return (v2 - v1) / deltaX; // какая-то формула
        }

        static Func<double, double> FunctionModifier(Func<double, double> raw_f, double x_0)
        {
            return (x) => (raw_f(x) / (x - x_0));
        }
        // функция находит корень
        static double FindRoot(Func<double, double> f, double x)
        {
            while (!CheckRoot(f, x))
            {
                x = x - f(x) / Derivative(f, x);
            }
            return x;
        }
    }
}

