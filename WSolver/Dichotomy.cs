using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    /*
     * 1) Dichotomy(Bisection) method is applied on one big segment
     * 2) to avoid root repetition on every next iteration we use f(x)/(x - x_0) instead of f(x), where x_0 is root found on previous iteration
     * ( we use derivative to decrease the chance to loose roots) 
     */
    class Dichotomy
    {
        // all found roots
        static List<double> roots = new List<double>();
        public static List<double> MainSolver(Func<double, double> f)
        {
            roots = new List<double>();

            System.Random rand = new Random();
            double aDefault = -rand.Next(200,500), bDefault = rand.Next(200, 500);
            double a, b;
            const double eps = 0.00000001; // roots precision 
            // number of algorithm mistakes (criteria for end of work)
            int badRootAmount = 0;
            while (true)
            {
                // roots are searched on [a,b]
                a = aDefault;
                b = bDefault;
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
                

                double newRoot = (a + b) / 2;

                if (CheckRoot(f, newRoot) && !roots.Contains(Math.Round(newRoot, 2)))
                {
                    //badRootAmount = 0;
                    roots.Add(Math.Round(newRoot,2));
                    // new function f(x):=f(x)/(x-x_0)
                    f = FunctionModifier(f, newRoot);
                }
                else
                {
                    badRootAmount++;

                    aDefault -= rand.Next(100, 500);
                    bDefault += rand.Next(100, 500);
                }

                if (badRootAmount > 100 || roots.Count > 50)
                {
                    return roots;
                }

            }
        }

        private static bool CheckRoot(Func<double, double> f, double x)
        {
            const double eps = 0.00001;
            bool isRoot = Math.Abs(f(x)) < eps;
            return isRoot;
        }

        private static double Derivative(Func<double, double> f, double x)
        {
            const double h = 0.001;
            return (f(x + h) - f(x - h)) / (2 * h);
        }

        private static Func<double, double> FunctionModifier(Func<double, double> raw_f, double x_0)
        {
            return (x) => (raw_f(x) / (x - x_0));
        }
    }
}

