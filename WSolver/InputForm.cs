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
            this.MinimumSize = new Size(710, 280);

        }

        
        private void SolveButtonClick(object sender, EventArgs e)
        {
            string formula = equationBox.Text;
            string usedVariable = variableBox.Text;

            bool closeAll = checkBoxCloseRoots.Checked;
            bool checkDichotomy = checkBoxDichotomy.Checked;
            bool checkSmallSegments = smallSegmentsCheckBox.Checked;
            bool checkNewton = NewtonCheckBox.Checked;
            bool checkSecant = secantCheckBox.Checked;
            /* if we want to add new methods
            bool checkNew1 = checkBox1.Checked;
            bool checkNew2 = checkBox2.Checked;
            bool checkNew3 = checkBox3.Checked;
            */


            Dictionary<string, bool> methodsCheckDictionary = new Dictionary<string, bool>()
            {
                {"Bisection (1)", checkDichotomy},
                {"Bisection (2)", checkSmallSegments},
                {"Newton", checkNewton},
                {"Secant", checkSecant}
                //{"New method name", checkNewMethod}
            };

            // manages all solution processes
            Solver.SolutionManager(formula, usedVariable, closeAll, methodsCheckDictionary);
        }
        
    }
}
