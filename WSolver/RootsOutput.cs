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

            // setting an icon
            var directoryInfo = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent;
            if (directoryInfo != null)
            {
                string icoDirectory = directoryInfo.FullName;
                this.Icon = new Icon(icoDirectory + "\\ex.ico");
            }
            Equation_label.Text = equation;

            string[] methods={"Дихотомия (1)", "Дихотомия (2)","Метод Ньютона","Метод секущих"};

            int i = 0;
            int methodNum = 1;
            int maxLength = 0;
            foreach (var roots in allRootsLists)
            {
                while (!checkArray[methodNum])
                {
                    methodNum++;
                }
                maxLength = roots.Count > maxLength ? roots.Count : maxLength;

                if (roots.Count > 0)
                {
                    // listbox with roots
                    ListBox newLb = new ListBox
                    {
                        Location = new Point(430 * i + 45, 90),
                        Size = new Size(330, 4 + 28 * roots.Count),
                        Font = new Font(new FontFamily("Arial"), 13.8f, System.Drawing.FontStyle.Regular)
                    };
                    foreach (double root in roots)
                    {
                        newLb.Items.Add($"x = {root}");
                    }
                    this.Controls.Add(newLb);
                }
                else
                {
                    // label showing that no roots were found
                    Label noRootsLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(430 * i + 45, 90),
                        Text = "Корней не найдено",
                        Font = new Font(new FontFamily("Arial"), 13.8f, System.Drawing.FontStyle.Regular)
                    };
                    this.Controls.Add(noRootsLabel);
                }

                Label methodNameLabel = new Label
                {
                    AutoSize = true,
                    Location = new Point(430 * i + 45, 90 - 30),
                    Text = methods[methodNum-1],
                    Font = new Font(new FontFamily("Arial"), 12, System.Drawing.FontStyle.Regular)
                };
                this.Controls.Add(methodNameLabel);

                i++;
                methodNum++;
            }

            this.Size = new Size(430*i, 180 + maxLength * 28);
            this.MinimumSize = new Size(430*i, 180 + maxLength * 28);


        }
        
    }
}
