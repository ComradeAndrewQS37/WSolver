using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WSolver
{
    // this class takes info from InputForm and manages solution and passing roots to RootsOutput form
    class Solver
    {
        
        // save all opened windows with roots output to close them all if necessary
        private static List<Form> openedRootsWindows = new List<Form>();

        public static void SolutionManager(string formula, string usedVariable, bool closeAll, Dictionary<string, bool> methodsCheckDictionary)
        {
            // check if any methods were used
            if (Array.TrueForAll(methodsCheckDictionary.Values.ToArray(), (x) => (!x)))
            {
                ShowErrorMessageBox("Не выбраны способы решения", "Пожалуйста, отметьте хотя бы один способ решения");
                return;
            }

            // if user wants unused windows to be closed
            if (closeAll)
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

                // dictionary with all methods
                Dictionary<string, Func<Func<double, double>, List<double>>> methodsFuncDictionary = new Dictionary<string, Func<Func<double, double>, List<double>>>()
                {
                    {"Bisection (1)",  Dichotomy.MainSolver},
                    {"Bisection (2)", SmallSegments.MainSolver},
                    {"Newton", Newton.MainSolver},
                    {"Chord", Chords.MainSolver},
                    {"Fixed Point", FixedPoint.MainSolver }
                    //{"New method name", newClass.newSolver}
                };

                // dictionary with lists of roots from all methods {"Method name", foundRootsList}
                Dictionary<string, List<double>> allRootsDictionary = new Dictionary<string, List<double>>();

                // iterate over all used methods
                foreach (string methodName in methodsCheckDictionary.Keys)
                {
                    // if method is not used
                    if (!methodsCheckDictionary[methodName]) continue;

                    List<double> foundRoots = methodsFuncDictionary[methodName](parsedFunction);

                    foundRoots.Sort();
                    allRootsDictionary.Add(methodName, foundRoots);
                }

                // create and show window with roots output
                RootsOutput rootsOutput = new RootsOutput(formula, allRootsDictionary);
                openedRootsWindows.Add(rootsOutput);
                rootsOutput.Show();
                
            }
            catch (Exception ex)
            {
                if (ex is WrongElementException || ex is NotEquationException || ex is SyntaxException || ex is TooManyRootsException)
                {
                    ShowErrorMessageBox("Ошибка", ex.Message);
                }
                else
                {
                    ShowErrorMessageBox("Ошибка", "Неизвестная ошибка\nПроверьте введённую формулу ещё раз или перезапустите программу");
                }
            }

        }

        // function to simplify the code
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
