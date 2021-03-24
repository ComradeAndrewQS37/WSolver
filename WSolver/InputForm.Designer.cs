
namespace WSolver
{
    partial class InputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            this.solveButton = new System.Windows.Forms.Button();
            this.equationBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.variableBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxDichotomy = new System.Windows.Forms.CheckBox();
            this.checkBoxCloseRoots = new System.Windows.Forms.CheckBox();
            this.smallSegmentsCheckBox = new System.Windows.Forms.CheckBox();
            this.NewtonCheckBox = new System.Windows.Forms.CheckBox();
            this.chordCheckBox = new System.Windows.Forms.CheckBox();
            this.fixedPointCheckBox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // solveButton
            // 
            this.solveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.solveButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.solveButton.Location = new System.Drawing.Point(81, 58);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(259, 49);
            this.solveButton.TabIndex = 1;
            this.solveButton.Text = "Решить";
            this.solveButton.UseMnemonic = false;
            this.solveButton.UseVisualStyleBackColor = false;
            this.solveButton.Click += new System.EventHandler(this.SolveButtonClick);
            // 
            // equationBox
            // 
            this.equationBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.equationBox.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equationBox.Location = new System.Drawing.Point(281, 32);
            this.equationBox.Name = "equationBox";
            this.equationBox.Size = new System.Drawing.Size(477, 44);
            this.equationBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя переменной\r\n";
            // 
            // variableBox
            // 
            this.variableBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.variableBox.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variableBox.Location = new System.Drawing.Point(75, 32);
            this.variableBox.Name = "variableBox";
            this.variableBox.Size = new System.Drawing.Size(48, 44);
            this.variableBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(435, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Введите уравнение";
            // 
            // checkBoxDichotomy
            // 
            this.checkBoxDichotomy.AutoSize = true;
            this.checkBoxDichotomy.Location = new System.Drawing.Point(50, 17);
            this.checkBoxDichotomy.Name = "checkBoxDichotomy";
            this.checkBoxDichotomy.Size = new System.Drawing.Size(115, 21);
            this.checkBoxDichotomy.TabIndex = 6;
            this.checkBoxDichotomy.Text = "Бисекция (1)";
            this.checkBoxDichotomy.UseVisualStyleBackColor = true;
            // 
            // checkBoxCloseRoots
            // 
            this.checkBoxCloseRoots.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxCloseRoots.AutoSize = true;
            this.checkBoxCloseRoots.Location = new System.Drawing.Point(168, 31);
            this.checkBoxCloseRoots.Name = "checkBoxCloseRoots";
            this.checkBoxCloseRoots.Size = new System.Drawing.Size(169, 21);
            this.checkBoxCloseRoots.TabIndex = 7;
            this.checkBoxCloseRoots.Text = "Закрыть другие окна";
            this.checkBoxCloseRoots.UseVisualStyleBackColor = true;
            // 
            // smallSegmentsCheckBox
            // 
            this.smallSegmentsCheckBox.AutoSize = true;
            this.smallSegmentsCheckBox.Location = new System.Drawing.Point(50, 52);
            this.smallSegmentsCheckBox.Name = "smallSegmentsCheckBox";
            this.smallSegmentsCheckBox.Size = new System.Drawing.Size(115, 21);
            this.smallSegmentsCheckBox.TabIndex = 8;
            this.smallSegmentsCheckBox.Text = "Бисекция (2)";
            this.smallSegmentsCheckBox.UseVisualStyleBackColor = true;
            // 
            // NewtonCheckBox
            // 
            this.NewtonCheckBox.AutoSize = true;
            this.NewtonCheckBox.Location = new System.Drawing.Point(50, 89);
            this.NewtonCheckBox.Name = "NewtonCheckBox";
            this.NewtonCheckBox.Size = new System.Drawing.Size(134, 21);
            this.NewtonCheckBox.TabIndex = 9;
            this.NewtonCheckBox.Text = "Метод Ньютона";
            this.NewtonCheckBox.UseVisualStyleBackColor = true;
            // 
            // chordCheckBox
            // 
            this.chordCheckBox.AutoSize = true;
            this.chordCheckBox.Location = new System.Drawing.Point(191, 52);
            this.chordCheckBox.Name = "chordCheckBox";
            this.chordCheckBox.Size = new System.Drawing.Size(106, 21);
            this.chordCheckBox.TabIndex = 10;
            this.chordCheckBox.Text = "Метод хорд";
            this.chordCheckBox.UseVisualStyleBackColor = true;
            // 
            // fixedPointCheckBox
            // 
            this.fixedPointCheckBox.AutoSize = true;
            this.fixedPointCheckBox.Location = new System.Drawing.Point(191, 8);
            this.fixedPointCheckBox.Name = "fixedPointCheckBox";
            this.fixedPointCheckBox.Size = new System.Drawing.Size(130, 38);
            this.fixedPointCheckBox.TabIndex = 11;
            this.fixedPointCheckBox.Text = "Метод простых\r\nитераций\r\n";
            this.fixedPointCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.variableBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.equationBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 95);
            this.panel2.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.checkBoxCloseRoots);
            this.panel1.Controls.Add(this.solveButton);
            this.panel1.Location = new System.Drawing.Point(440, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 106);
            this.panel1.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 153);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chordCheckBox);
            this.panel4.Controls.Add(this.NewtonCheckBox);
            this.panel4.Controls.Add(this.smallSegmentsCheckBox);
            this.panel4.Controls.Add(this.fixedPointCheckBox);
            this.panel4.Controls.Add(this.checkBoxDichotomy);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(349, 153);
            this.panel4.TabIndex = 15;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(792, 253);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputForm";
            this.Text = "WSolver";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.TextBox equationBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox variableBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxDichotomy;
        private System.Windows.Forms.CheckBox checkBoxCloseRoots;
        private System.Windows.Forms.CheckBox smallSegmentsCheckBox;
        private System.Windows.Forms.CheckBox NewtonCheckBox;
        private System.Windows.Forms.CheckBox chordCheckBox;
        private System.Windows.Forms.CheckBox fixedPointCheckBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}