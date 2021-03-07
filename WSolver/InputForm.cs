using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            this.Text = "WSolver";
        }

        
        private void SolveButtonClick(object sender, EventArgs e)
        {
            string formula = equationBox.Text;
            string usedVariable = variableBox.Text;

            bool closeAll = checkBoxCloseRoots.Checked;
            bool checkDichotomy = checkBoxDichotomy.Checked;
            bool[] checkArray = {closeAll, checkDichotomy};



            if (usedVariable == "")
            {
                Solver.ShowErrorMessageBox("Имя переменной","Введите имя переменной, по которой будет решаться уравнение");
                return;
            }

            if (!formula.Contains(usedVariable))
            {
                Solver.ShowErrorMessageBox("Переменная", "В выражении отстутсвует переменная, по которой будет решаться уравнение\nПроверьте введённую формулу ещё раз");
                return;
            }
            
            // manages all solution processes
            Solver.SolutionManager(formula, usedVariable, checkArray);
            
            
        }
        
    }
}
