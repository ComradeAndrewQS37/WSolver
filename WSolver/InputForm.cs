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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
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

            bool show_roots_window = true;
            string formula = textBox3.Text;
            string used_variable = textBox4.Text;
            List<double> dichotomy_roots = new List<double>();
            // List<double> other_method_roots = new List<double>();
            try
            {
                // перевод в обратную польскую запись
                string parsed_formula = FParser.MainParser(formula, used_variable);
                //текстовая формула -> функция f(x)
                Func<double, double> parsed_function = FuncConstructor.MainConstructor(parsed_formula, used_variable);

                // использование различных методов
                dichotomy_roots = Dichotomy.MainSolver(parsed_function);
                //other_method_roots = MethodClass.MethodFunc(parsed_function);
            }
            catch (Exception ex)
            {
                show_roots_window = false;
                string message_box_text;

                if (ex is WrongElementException || ex is NotEquationException || ex is SyntaxException || ex is TooManyRootsException)
                {
                    message_box_text = ex.Message;
                }
                else
                {
                    message_box_text = "Неизвестная ошибка\nПроверьте введённую формулу ещё раз";
                }
                MessageBox.Show(
                    message_box_text,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }

            if(show_roots_window)
            {
                if (dichotomy_roots.Count > 0)
                {
                    RootsOutput roots_output = new RootsOutput(dichotomy_roots, formula);
                    roots_output.Text = "Dichotomy";
                    roots_output.Show();

                    /* Остальные методы включаются как:
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
