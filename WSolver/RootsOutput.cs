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
    public partial class RootsOutput : Form
    {
        //window for showing roots
        public RootsOutput(List<double> roots, string equation)
        {
            InitializeComponent();
            Equation_label.Text = equation;
            foreach(double root in roots)
            {
                listBox1.Items.Add($"x = {root}");
            }
            
        }

    }
}
