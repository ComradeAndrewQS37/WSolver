using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    class EqSolver
    {
        public static List<double> roots = new List<double>();
        public static List<double> MainSolver(Func<double, double> f)
        {
            roots = new List<double>(); ;
            double a, b;
            double eps = 0.00000001;
            bool no_more_roots = false;
            while (!no_more_roots)
            {
                a = -200;
                b = 200;
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
                    else if (Derrivative(f,a) * Derrivative(f,(a + b) / 2) <= 0)
                    {
                        b = (a + b) / 2;
                    }
                    else if (Derrivative(f,(a + b) / 2) * Derrivative(f,b) <= 0)
                    {
                        a = (a + b) / 2;
                    }
                    else
                    {
                        Console.WriteLine("No more real roots found");
                        no_more_roots = true;
                        break;
                    }
                }
                if (!no_more_roots)
                {
                    double new_root = (a + b) / 2;

                    if (CheckRoot(f, new_root))
                    {
                        if (!roots.Contains(new_root))
                        {
                            roots.Add(Math.Round(new_root,2));
                        }
                    }
                    f = FunctionModifier(f, new_root);
                }
            }
            return roots;
        }

        static bool CheckRoot(Func<double, double> f, double x)
        {
            double eps = 0.01;
            bool is_root = Math.Abs(f(x)) < eps;
            return is_root;
        }

        static double Derrivative(Func<double, double> f, double x)
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
