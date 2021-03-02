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
        // all found roots
        public static List<double> roots = new List<double>();
        public static List<double> MainSolver(Func<double, double> f)
        {
            roots = new List<double>();
            double a_default = -100, b_default = 101;
            double a, b;
            double eps = 0.00000001; // roots precision 
            bool no_more_roots = false;
            int root_repeat = 0;
            while (!no_more_roots)
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
                        no_more_roots = true;
                        break;
                    }
                }
                if (!no_more_roots)
                {
                    double new_root = (a + b) / 2;


                    if (CheckRoot(f, new_root) && !roots.Contains(new_root))
                    {
                        root_repeat = 0;
                        roots.Add(Math.Round(new_root, 2));
                    }
                    else
                    {
                        root_repeat++;
                    }

                    if (root_repeat > 100)
                    {
                        return roots;
                    }
                    
                    // new function f(x):=f(x)/(x-x_0)
                    f = FunctionModifier(f, new_root);
                }
                
            }
            return roots;
        }

        static bool CheckRoot(Func<double, double> f, double x)
        {
            double eps = 0.001;
            bool is_root = Math.Abs(f(x)) < eps;
            return is_root;
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

