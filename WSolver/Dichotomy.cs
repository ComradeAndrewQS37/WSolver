using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    /*
     * MainSolver receives function f(x) and solves f(x) = 0 with dichotomy method
     * After finding new root we work with new function f_1(x) := f(x)/(x - x_0), where x_0 is found root
     * This helps to avoid roots repetition
     */
    class Dichotomy
    {
        public static System.Random Rand = new Random();
        // all found roots
        public static List<double> roots = new List<double>();
        public static List<double> MainSolver(Func<double, double> f)
        {
            roots = new List<double>();
            double a_default = -Rand.Next(100,200), b_default = Rand.Next(100, 200);
            double a, b;
            double eps = 0.00000001; // roots precision 
            int rootRepeat = 0;
            while (true)
            {
                // roots are searched on [a,b]
                a = a_default;
                b = b_default;
                while (b - a > eps)
                {
                    if (f(a) * f((a + b) / 2) <= 0)
                    {
                        b = (a + b) / 2;
                    }
                    else if (f((a + b) / 2) * f(b) <= 0)
                    {
                        a = (a + b) / 2;
                    }
                    else if (Derivative(f, a) * Derivative(f, (a + b) / 2) <= 0)
                    {
                        b = (a + b) / 2;
                    }
                    else if (Derivative(f, (a + b) / 2) * Derivative(f, b) <= 0)
                    {
                        a = (a + b) / 2;
                    }
                    else
                    {
                        break;
                    }
                }
                

                double new_root = (a + b) / 2;

                if (CheckRoot(f, new_root) && !roots.Contains(Math.Round(new_root, 2)))
                {
                    rootRepeat = 0;
                    roots.Add(Math.Round(new_root,2));
                    // new function f(x):=f(x)/(x-x_0)
                    f = FunctionModifier(f, new_root);
                }
                else
                {
                    rootRepeat++;

                    a_default += Rand.Next(100, 500);
                    b_default -= Rand.Next(100, 500);
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

        static Func<double, double> FunctionModifier(Func<double, double> raw_f, double x_0)
        {
            return (x) => (raw_f(x) / (x - x_0));
        }
    }
}

