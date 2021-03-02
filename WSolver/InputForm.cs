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
            string formula = textBox3.Text;
            Func<double, double> AlF = FuncConstructor.MainConstructor(FParser.ToListParser(formula), textBox4.Text);
            List<double> roots = EqSolver.MainSolver(AlF);
            if (roots.Count > 0)
            {
                textBox2.Text = Convert.ToString(roots[0]);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
