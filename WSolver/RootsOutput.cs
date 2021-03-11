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
        public RootsOutput(List<List<double>> allRootsLists, string equation, bool[] checkArray)
        {
            InitializeComponent();
            

            Equation_label.Text = equation;

            string[] methods={"Дихотомия (1)", "Дихотомия (2)","Метод Ньютона","Метод секущих"};

            // number of roots collection which we are output
            int outputNum = 0;

            // number of method which we output
            int methodNum = 1;

            // max number of roots in all collections
            int maxLength = 0;

            foreach (var roots in allRootsLists)
            {
                // find next method that was used
                while (!checkArray[methodNum])
                {
                    methodNum++;
                }

                // update maxLength value
                maxLength = roots.Count > maxLength ? roots.Count : maxLength;

                Label methodNameLabel = new Label
                {
                    AutoSize = true,
                    Location = new Point(430 * outputNum + 45, 60),
                    Text = methods[methodNum - 1],
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
                methodNum++;
            }

            this.Size = new Size(430*outputNum, 180 + maxLength * 28);
            this.MinimumSize = new Size(430*outputNum, 180 + maxLength * 28);
        }
        
    }
}
