using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver {
    class Secant
    {
        static System.Random Rand = new Random();
        // all found roots
        static List<double> roots = new List<double>();
        public static List<double> MainSolver(Func<double, double> f)
        {
            roots = new List<double>();
            double a_default = -Rand.Next(100, 200), b_default = Rand.Next(100, 200);
            const double eps = 0.000000001;
            double a, b;
            int rootRepeat = 0;
            while (true)
            {
                // roots are searched on [a,b]
                a = a_default;
                b = b_default;

                while (Math.Abs(b - a) > eps)
                {
                    a = b - (b - a) * f(b) / (f(b) - f(a));
                    b = a - (a - b) * f(a) / (f(a) - f(b));
                }

                double new_root = b;

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
        }

        static bool CheckRoot(Func<double, double> f, double x)
        {
            double eps = 0.00001;
            bool isRoot = Math.Abs(f(x)) < eps;
            return isRoot;
        }
        
        static Func<double, double> FunctionModifier(Func<double, double> raw_f, double x_0)
        {
            return (x) => (raw_f(x) / (x - x_0));
        }
    }
}