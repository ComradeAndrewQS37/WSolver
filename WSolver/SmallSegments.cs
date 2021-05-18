using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    /*
     * 1) segment, where roots are searched is divided into many little segments(little enough, so we can assume that every segment has no more than one root)
     * 2) apply Dichotomy(Bisection) method on every little segment
     * 3) return roots from all segments
     */ 
    class SmallSegments
    {
        // all found roots
        static List<double> Roots = new List<double>();
        public static List<double> MainSolver(Func<double, double> f)
        {
            DateTime startTime = DateTime.Now;
            
            Roots = new List<double>();

            double begin = SettingsForm.LeftBorder, end = SettingsForm.RightBorder;
            double searchSegment = end - begin;

            double eps = Math.Pow(10, SettingsForm.RootsPrecision); // roots precision 
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
                    else
                    {
                        break;
                    }
                }
                
                double newRoot = (a + b) / 2;

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
