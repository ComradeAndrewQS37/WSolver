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
            var directoryInfo = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent;
            if (directoryInfo != null)
            {
                string icoDirectory = directoryInfo.FullName;
                this.Icon = new Icon(icoDirectory+"\\ex.ico");
            }
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
            bool checkNew1 = checkBox1.Checked;
            bool checkNew2 = checkBox2.Checked;
            bool checkNew3 = checkBox3.Checked;



            bool[] checkArray = {closeAll, checkDichotomy, checkSmallSegments, checkNewton, checkSecant, checkNew1, checkNew2, checkNew3 };

            
            // manages all solution processes
            Solver.SolutionManager(formula, usedVariable, checkArray);
        }
        
    }
}
