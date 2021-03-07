using System;
using System.Collections.Generic;
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
            // checkArray = {closeRootsWindows, Dichotomy} 
            bool isExceptionThrown = false;
            // lists with roots from various methods
            List<double> dichotomyRoots = new List<double>();
            // List<double> other_method_roots = new List<double>();

            // if user wants all unused windows to be closed
            if (checkArray[0])
            {
                foreach (Form f in openedRootsWindows)
                {
                    f.Close();
                }
                openedRootsWindows = new List<Form>();

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

                    // happens usually in case of periodic function
                    // !!! SPECIAL INSPECTIONS NECESSARY !!!
                    if (dichotomyRoots.Count > 10)
                    {
                        dichotomyRoots = dichotomyRoots
                            .OrderBy(Math.Abs)
                            .Take(5)
                            .ToList();
                    }

                    dichotomyRoots.Sort();
                }

                //other_method_roots = MethodClass.MethodFunc(parsed_function);
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
                // if dichotomy solved
                if (checkArray[1])
                {
                    if (dichotomyRoots.Count > 0)
                    {
                        RootsOutput dichotomyRootsOutput = new RootsOutput(dichotomyRoots, formula)
                            {Text = "Dichotomy"};
                        openedRootsWindows.Add(dichotomyRootsOutput);
                        dichotomyRootsOutput.Show();

                        /* To include other methods:
                        RootsOutput roots_output_n = new RootsOutput(other_method_roots, formula);
                        roots_output_n.Text = "OtherMethod";
                        roots_output_n.Show();
                         */
                    }
                    else
                    {
                        ShowErrorMessageBox("Корней не найдено", "Действительных корней не найдено");
                    }
                }
                // if no methods were used
                else
                {
                    ShowErrorMessageBox("Не выбраны способы решения", "Пожалуйста, отметьте хотя бы один способ решения");
                }
            }
        }

        // just to simplify the code
        public static void ShowErrorMessageBox(string caption, string messageText)
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
