using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSolver
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            if (variableBox.Text == "")
            {
                MessageBox.Show(
                    "Введите имя переменной, по которой будет решаться уравнение",
                    "Имя переменной",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            // no exception thrown
            bool showRootsWindow = true;

            string formula = equationBox.Text;
            string usedVariable = variableBox.Text;

            // lists with roots from various methods
            List<double> dichotomyRoots = new List<double>();
            // List<double> other_method_roots = new List<double>();
            try
            {
                // convert to reverse polish notation
                string parsedFormula = FParser.MainParser(formula, usedVariable);
                // string formula -> function f(x)
                Func<double, double> parsedFunction = FuncConstructor.MainConstructor(parsedFormula, usedVariable);

                // using various solvers
                dichotomyRoots = Dichotomy.MainSolver(parsedFunction);
                //other_method_roots = MethodClass.MethodFunc(parsed_function);
            }
            catch (Exception ex)
            {
                showRootsWindow = false;
                string messageBoxText;

                if (ex is WrongElementException || ex is NotEquationException || ex is SyntaxException || ex is TooManyRootsException)
                {
                    messageBoxText = ex.Message;
                }
                else
                {
                    messageBoxText = "Неизвестная ошибка\nПроверьте введённую формулу ещё раз";
                }
                MessageBox.Show(
                    messageBoxText,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }

            if(showRootsWindow)
            {
                if (dichotomyRoots.Count > 0)
                {
                    RootsOutput dichotomyRootsOutput = new RootsOutput(dichotomyRoots, formula) {Text = "Dichotomy"};
                    dichotomyRootsOutput.Show();

                    /* To include other methods:
                    RootsOutput roots_output_n = new RootsOutput(other_method_roots, formula);
                    roots_output_n.Text = "OtherMethod";
                    roots_output_n.Show();
                     */
                }
                else
                {
                    MessageBox.Show(
                    "Действительных корней не найдено",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            
        }

    }
}
