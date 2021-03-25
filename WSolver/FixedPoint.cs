using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    /*
     * Method replaces equation f(x) = 0 with g(x) = x
     * 1) The most obvious (and universal) g(x) = f(x) + x
     * 2) First root approximation is segment centre
     * 3) Every new approximation x_(n+1) = g(x_n) = f(x_n) + x_n
     * 3) Continue until |x_n - x_(n+1)| > eps
     * Important: approximations sequence converges to root only if |f'(x)| < 1 in root neighborhood
     */
    class FixedPoint
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

            const double eps = 0.0000000001; // roots precision 
            const double segmentLength = 0.01;
            double a, b;

            
            for (int i = 0; i < searchSegment / segmentLength; i++)
            {
                // if method freezes end execution
                double passedSeconds = (DateTime.Now - startTime).TotalSeconds;
                if (passedSeconds > 10)
                {
                    return Roots;
                }

                
                a = begin + i * segmentLength;
                b = a + segmentLength;


                if (Math.Abs(FirstDerivative(f, (a + b) / 2)) > 1)
                {
                    continue;
                }


                // start point
                double x_0 = (a + b) / 2;

                // first approximation
                double x_n = x_0 + f(x_0);
                

                while (Math.Abs(x_n - x_0) > eps)
                {
                    x_0 = x_n;
                    x_n = x_0 + f(x_0);
                    if (x_n > b || x_n < a)
                    {
                        break;
                    }
                }

                double newRoot = x_n;


                if (CheckRoot(f, newRoot) && !Roots.Contains(Math.Round(newRoot, 2)))
                {
                    Roots.Add(Math.Round(newRoot, 2));
                }

            }
            return Roots;
        }
        
        static bool CheckRoot(Func<double, double> f, double x)
        {
            double eps = 0.00000001;
            bool isRoot = Math.Abs(f(x)) < eps;
            return isRoot;
        }

        static double FirstDerivative(Func<double, double> f, double x)
        {
            double h = 0.001;
            return (f(x + h) - f(x - h)) / (2 * h);
        }

    }
}

