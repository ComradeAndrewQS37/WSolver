using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
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

            const double eps = 0.0000001; // roots precision 
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


                double c = 2/(Math.Round(FirstDerivative(f, (a+b)/2) +1) + Math.Round(FirstDerivative(f, (a + b) / 2) - 1));

                // start point
                double x_0 = (a + b) / 2;

                // first approximation
                double x_n = x_0 + c * f(x_0);

                int j = 0;
                while (Math.Abs(x_n - x_0) > eps)
                {
                    x_0 = x_n;
                    x_n = x_0 + c * f(x_0);
                    if (j++ > 200)
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
            double eps = 0.00001;
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

