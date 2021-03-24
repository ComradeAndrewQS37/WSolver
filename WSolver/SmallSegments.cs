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

            System.Random rand = new Random();
            double begin = -rand.Next(500, 1000), end = rand.Next(500, 1000);
            double searchSegment = end - begin;

            const double eps = 0.000000001; // roots precision 
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

                if (CheckRoot(f, newRoot) && !Roots.Contains(Math.Round(newRoot, 2)))
                {
                    Roots.Add(Math.Round(newRoot, 2));
                }
                
            }

            return Roots;
        }

        static bool CheckRoot(Func<double, double> f, double x)
        {
            double eps = 0.0000001;
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
