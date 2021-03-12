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

            // iterate over all found roots
            foreach (string method in allRootsDictionary.Keys)
            {
                List<double> roots = allRootsDictionary[method];

                // update maxLength value
                maxLength = roots.Count > maxLength ? roots.Count : maxLength;

                Label methodNameLabel = new Label
                {
                    AutoSize = true,
                    Location = new Point(430 * outputNum + 45, 60),
                    Text = method,
                    Font = new Font(new FontFamily("Arial"), 12, System.Drawing.FontStyle.Regular)
                };
                this.Controls.Add(methodNameLabel);

                // check if any roots were found
                if (roots.Count > 0)
                {
                    // listbox with roots
                    ListBox rootsListBox = new ListBox
                    {
                        Location = new Point(430 * outputNum + 45, 60 + 30),
                        Size = new Size(330, 4 + 28 * roots.Count),
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
                        Location = new Point(430 * outputNum + 45, 60 + 30),
                        Text = "Корней не найдено",
                        Font = new Font(new FontFamily("Arial"), 13.8f, System.Drawing.FontStyle.Regular)
                    };
                    this.Controls.Add(noRootsLabel);
                }

                outputNum++;

            }
            

            this.Size = new Size(430*outputNum, 180 + maxLength * 28);
            this.MinimumSize = new Size(430*outputNum, 180 + maxLength * 28);
        }
        
    }
}
