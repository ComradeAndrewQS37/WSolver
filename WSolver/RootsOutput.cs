using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WSolver
{
    public partial class RootsOutput : Form
    {
        //window for showing roots
        public RootsOutput(string equation, Dictionary<string, List<double>> allRootsDictionary)
        {
            InitializeComponent();

            // max number of roots in all collections
            int maxLength = 0;

            // number of roots collection which we are output
            int outputNum = 0;

            // label with equation at the top
            Equation_label.Text = equation;
            Dictionary<string, string> methodsNameToOutput = new Dictionary<string, string>()
            {
                {"Bisection (1)", "Бисекция (1)"},
                {"Bisection (2)", "Бисекция (2)"},
                {"Newton", "Метод Ньютона"},
                {"Chord", "Метод хорд"},
                {"Fixed Point", "Метод простых итераций" }
            };
            // iterate over all found roots
            foreach (string method in allRootsDictionary.Keys)
            {
                List<double> roots = allRootsDictionary[method];
                if (roots.Count >= 15)
                {
                    roots = roots.OrderBy(Math.Abs).ToList();
                    roots = roots.Take(15).ToList();
                    roots.Sort();
                }

                // update maxLength value
                maxLength = roots.Count > maxLength ? roots.Count : maxLength;

                Label methodNameLabel = new Label
                {
                    AutoSize = true,
                    Location = new Point(320 * outputNum + 45, 60),
                    Text = methodsNameToOutput[method],
                    Font = new Font(new FontFamily("Arial"), 12, System.Drawing.FontStyle.Regular)
                };
                this.Controls.Add(methodNameLabel);

                // check if any roots were found
                if (roots.Count > 0)
                {
                    // listbox with roots
                    ListBox rootsListBox = new ListBox
                    {
                        Location = new Point(320 * outputNum + 45, 60 + 30),
                        Size = new Size(220, 4 + 28 * roots.Count),
                        Font = new Font(new FontFamily("Arial"), 13.8f, System.Drawing.FontStyle.Regular)
                    };
                    foreach (double root in roots)
                    {
                        rootsListBox.Items.Add($"x = {root}");
                    }
                    this.Controls.Add(rootsListBox);
                }
                else
                {
                    // label showing that no roots were found
                    Label noRootsLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(320 * outputNum + 45, 60 + 30),
                        Text = "Корней не найдено",
                        Font = new Font(new FontFamily("Arial"), 13.8f, System.Drawing.FontStyle.Regular)
                    };
                    this.Controls.Add(noRootsLabel);
                }

                outputNum++;

            }
            
            
            this.Size = new Size(320*outputNum, 180 + maxLength * 28);
            this.MinimumSize = new Size(320*outputNum, 180 + maxLength * 28);
        }
        
    }
}
