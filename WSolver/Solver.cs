using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSolver
{
    // this class takes info from InputForm and manages solution and passing roots to RootsOutput form
    class Solver
    {
        // save all opened windows with roots output to close them all if necessary
        private static List<Form> openedRootsWindows = new List<Form>();

        public static void SolutionManager(string formula, string usedVariable, bool[] checkArray)
        {
            // checkArray = {closeRootsWindows, Dichotomy, SmallSegments, Newton, checkSecant} 
            bool isExceptionThrown = false;
            // lists with roots from various methods
            List<double> dichotomyRoots = new List<double>();
            List<double> smallSegmentsRoots = new List<double>();
            List<double> newtonRoots = new List<double>();
            List<double> secantRoots = new List<double>();
            List<double> new1Roots = new List<double>();
            List<double> new2Roots = new List<double>();
            List<double> new3Roots = new List<double>();




            // if user wants unused window to be closed
            if (checkArray[0])
            {
                foreach (var f in openedRootsWindows)
                {
                    f.Close();
                }
            }

            try
            {
                // convert to reverse polish notation
                string parsedFormula = FParser.MainParser(formula, usedVariable);
                // string formula -> function f(x)
                Func<double, double> parsedFunction = FuncConstructor.MainConstructor(parsedFormula, usedVariable);

                // using various solvers
                if (checkArray[1])
                {
                    List<double> buffDichotomyRoots;
                    // do 10 iterations as method sometimes finds not all roots
                    for (int i = 0; i < 10; i++)
                    {
                        buffDichotomyRoots = Dichotomy.MainSolver(parsedFunction);
                        if (dichotomyRoots.Count < buffDichotomyRoots.Count)
                        {
                            dichotomyRoots = buffDichotomyRoots;
                        }

                    }

                    dichotomyRoots.Sort();
                }

                if (checkArray[2])
                {
                    smallSegmentsRoots = SmallSegments.MainSolver(parsedFunction);

                    smallSegmentsRoots.Sort();

                }

                if (checkArray[3])
                {
                    newtonRoots = Newton.MainSolver(parsedFunction);

                    newtonRoots.Sort();
                }

                if (checkArray[4])
                {
                    secantRoots = Secant.MainSolver(parsedFunction);

                    secantRoots.Sort();
                }
                /*
                if (checkArray[5])
                {
                    new1Roots = <newClass>.<newFunc>(parsedFunction);

                    new1Roots.Sort();
                }
                if (checkArray[6])
                {
                    new2Roots = <newClass>.<newFunc>(parsedFunction);

                    new2Roots.Sort();
                }
                if (checkArray[7])
                {
                    new3Roots = <newClass>.<newFunc>(parsedFunction);

                    new3Roots.Sort();
                }*/

            }
            catch (Exception ex)
            {
                isExceptionThrown = true;

                if (ex is WrongElementException || ex is NotEquationException || ex is SyntaxException || ex is TooManyRootsException)
                {
                    ShowErrorMessageBox("Ошибка", ex.Message);
                }
                else
                {
                    ShowErrorMessageBox("Ошибка", "Неизвестная ошибка\nПроверьте введённую формулу ещё раз");
                }
            }

            if (!isExceptionThrown)
            {
                List<List<double>> allRootsLists = new List<List<double>>();
                if (checkArray[1])
                {
                    allRootsLists.Add(dichotomyRoots);
                }
                if (checkArray[2])
                {
                    allRootsLists.Add(smallSegmentsRoots);
                }
                if (checkArray[3])
                {
                    allRootsLists.Add(newtonRoots);
                }
                if (checkArray[4])
                {
                    allRootsLists.Add(secantRoots);
                }/*
                if (checkArray[5])
                {
                    allRootsLists.Add(new1Roots);
                }
                if (checkArray[6])
                {
                    allRootsLists.Add(new2Roots);
                }
                if (checkArray[7])
                {
                    allRootsLists.Add(new2Roots);
                }*/
                
                // if no methods were used
                if (!checkArray[0] && !checkArray[1] && !checkArray[2] && !checkArray[3] && !checkArray[4] && !checkArray[5] && !checkArray[6] && !checkArray[7])
                {
                    ShowErrorMessageBox("Не выбраны способы решения", "Пожалуйста, отметьте хотя бы один способ решения");
                }
                else
                {
                    RootsOutput rootsOutput = new RootsOutput(allRootsLists, formula, checkArray);
                    openedRootsWindows.Add(rootsOutput);
                    rootsOutput.Show();
                }
            }
        }

        // just to simplify the code
        private static void ShowErrorMessageBox(string caption, string messageText)
        {
            MessageBox.Show(
                messageText,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        
    }
}
