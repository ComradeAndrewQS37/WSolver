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
    public partial class SettingsForm : Form
    {
        private const int OutputPrecisionDefault = 3;
        private const int RootsPrecisionDefault = -7;
        private const double LeftDefault = -1000;
        private const double RightDefault = 1000;


        public static int OutputPrecision = OutputPrecisionDefault;
        public static int RootsPrecision = RootsPrecisionDefault;
        public static double LeftBorder = LeftDefault;
        public static double RightBorder = RightDefault;
        public SettingsForm()
        {
            InitializeComponent();
            outputPrecisionNum.Value = OutputPrecision;
            rootPrecisionNum.Value = RootsPrecision;
            leftBorderNum.Value = (decimal)LeftBorder;
            rightBorderNum.Value = (decimal)RightBorder;
        }

        private void setDefaultButton_Click(object sender, EventArgs e)
        {
            outputPrecisionNum.Value = OutputPrecisionDefault;
            rootPrecisionNum.Value = RootsPrecisionDefault;
            leftBorderNum.Value = (decimal)LeftDefault;
            rightBorderNum.Value = (decimal)RightDefault;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            OutputPrecision = (int)outputPrecisionNum.Value;
            RootsPrecision = (int)rootPrecisionNum.Value;
            LeftBorder = (double)leftBorderNum.Value;
            RightBorder = (double)rightBorderNum.Value;

            Close();
        }
    }
}
