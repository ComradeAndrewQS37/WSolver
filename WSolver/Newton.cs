using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    /*
     * Method uses tangent lines to approximate the root
     * 1) Start point x_0 is segment's centre
     * 2) Every new tangent line is for point (x_n, f(x_n)), where x_n is current approximation
     *    this tangent's intersection with x-axis is new approximation x_(n+1)
     * 3) Continue until |x_n - x_(n+1)| > eps
     */
    class Newton
    {
        // all found roots
        static List<double> Roots = new List<double>();
        public static List<double> MainSolver(Func<double, double> f)
        {
            DateTime startTime = DateTime.Now;

            Roots = new List<double>();

            double begin = SettingsForm.LeftBorder, end = SettingsForm.RightBorder;
            double searchSegment = end - begin;

            double eps = Math.Pow(0.1, SettingsForm.RootsPrecision); // roots precision 
            const double segmentLength = 0.01;
            double a, b;
            for (int i = 0; i < searchSegment / segmentLength; i++)
            {
                // end execution if method freezes
                double passedSeconds = (DateTime.Now - startTime).TotalSeconds;
                if (passedSeconds > 10)
                {
                    return Roots;
                }

                a = begin + i * segmentLength;
                b = a + segmentLength;

                // going to new segment if this has no roots
                if (!AreRootsOnThisSegment(f, a, b)) { continue;}

                // start point
                double x_0 = (a + b) / 2;

                // first approximation
                double x_n = x_0 - f(x_0) / FirstDerivative(f, x_0);

                while (Math.Abs(x_n - x_0) > eps)
                {
                    x_0 = x_n;
                    x_n = x_0 - f(x_0) / FirstDerivative(f, x_0);
                }

                double newRoot = x_n;

                if (CheckRoot(f, newRoot) && !Roots.Contains(Math.Round(newRoot, SettingsForm.OutputPrecision)))
                {
                    Roots.Add(Math.Round(newRoot, SettingsForm.OutputPrecision));
                }

            }
            return Roots;
        }

        static bool CheckRoot(Func<double, double> f, double x)
        {
            double eps = Math.Pow(10, SettingsForm.RootsPrecision + 3);
            bool isRoot = Math.Abs(f(x)) < eps;
            return isRoot;
        }

        static double FirstDerivative(Func<double, double> f, double x)
        {
            double h = 0.0001;
            return (f(x + h) - f(x - h)) / (2 * h);
        }

        static bool AreRootsOnThisSegment(Func<double, double> f, double a, double b)
        {
            if (f(a) * f(b) > 0 && (f(a)+0.001) * (f(b)+0.001) > 0 && (f(a) - 0.001) * (f(b) - 0.001) > 0) { return false; }

            return true;
        }
       
    }
}

