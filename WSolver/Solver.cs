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

        public static void SolutionManager(string formula, string usedVariable, bool[] checkArray)
        {
            // checkArray = {closeRootsWindows, Dichotomy, SmallSegments, Newton, checkSecant} 
            
            // if user wants unused windows to be closed
            if (checkArray[0])
            {
                foreach (var f in openedRootsWindows)
                {
                    f.Close();
                }
            }

            // List with lists of roots from all methods
            List<List<double>> allRootsLists = new List<List<double>>();

            try
            {
                // convert to reverse polish notation
                string parsedFormula = FParser.MainParser(formula, usedVariable);

                // string formula -> function f(x)
                Func<double, double> parsedFunction = FuncConstructor.MainConstructor(parsedFormula, usedVariable);

                // list with all methods
                List<Func<Func<double, double>, List<double>>> methodsList = new List<Func<Func<double, double>, List<double>>>()
                {
                    Dichotomy.MainSolver,
                    SmallSegments.MainSolver,
                    Newton.MainSolver,
                    Secant.MainSolver
                    // newClass.newSolver
                };

                //using different methods
                for (int i = 0; i < methodsList.Count;i++)
                {
                    // if method is not used
                    if (!checkArray[i + 1]) continue;

                    List<double> foundRoots= methodsList[i](parsedFunction);
                    
                    foundRoots.Sort();
                    allRootsLists.Add(foundRoots);
                }

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

                return;
            }
            
            // check if any methods were used
            if (Array.TrueForAll(checkArray.Skip(1).ToArray(),  (x)=>(!x)))
            {
                ShowErrorMessageBox("Не выбраны способы решения", "Пожалуйста, отметьте хотя бы один способ решения");
            }
            else
            {
                // create and show window with roots output
                RootsOutput rootsOutput = new RootsOutput(allRootsLists, formula, checkArray);
                openedRootsWindows.Add(rootsOutput);
                rootsOutput.Show();
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
