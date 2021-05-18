using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    /*
     * Method uses chords to approximate the root
     * 1) Start point x_0 is segment's right point b
     * 2) Every new chord is between points (a, f(a)) and (x_n, f(x_n))
     *    this chord's intersection with x-axis is new approximation x_(n+1)
     * 3) Continue until |x_n - x_(n+1)| > eps
     */
    class Chords
    {
        // all found roots
        static List<double> Roots = new List<double>();

        public static List<double> MainSolver(Func<double, double> f)
        {
            DateTime startTime = DateTime.Now;

            Roots = new List<double>();

            System.Random rand = new Random();
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
                if (!AreRootsOnThisSegment(f, a, b)) { continue; }

                // start point
                double x_0 = b;

                // first approximation
                double x_n = x_0 - f(x_0) / (f(x_0) - f(a)) * (x_0 - a);

                while (Math.Abs(x_n - x_0) > eps)
                {
                    x_0 = x_n;
                    x_n = x_0 - f(x_0) / (f(x_0) - f(a)) * (x_0 - a);

                    if (x_n > b || x_n < a)
                    {
                        break;
                    }
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
        static bool AreRootsOnThisSegment(Func<double, double> f, double a, double b)
        {
            if (f(a) * f(b) > 0 && (f(a) + 0.001) * (f(b) + 0.001) > 0 && (f(a) - 0.001) * (f(b) - 0.001) > 0) { return false; }

            return true;
        }
    }
}
