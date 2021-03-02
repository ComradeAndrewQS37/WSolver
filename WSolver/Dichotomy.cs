﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    /*
     * Метод MainSolver получает функцию f(x) и решает уравнение f(x) = 0
     * Нахождение корней производится методом дихотомии(деления на два)
     * Исключение уже найденных корней из поля поиск производится путём введения новой функции f_1(x) = f(x)/(x - x_0), гд x_0 - найденный корень
     * После этого для производится поиск корней уже для функции f_1(x) и так далее, для каждого новго корня
     */
    class Dichotomy
    {
        // все найденные алгоритмом корни
        public static List<double> roots = new List<double>();
        public static List<double> MainSolver(Func<double, double> f)
        {
            roots = new List<double>();
            double a_default = -100, b_default = 101;
            double a, b;
            double eps = 0.00000001; // точность нахождения корней
            bool no_more_roots = false;
            int root_repeat = 0;
            while (!no_more_roots)
            {
                // поиск корней происходит на отрезке [a,b]
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
                    else if (Derrivative(f, a) * Derrivative(f, (a + b) / 2) <= 0)
                    {
                        b = (a + b) / 2;
                    }
                    else if (Derrivative(f, (a + b) / 2) * Derrivative(f, b) <= 0)
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
                    
                    // новая функция f(x) равна f(x)/(x-x_0)
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

