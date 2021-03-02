
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
            this.solveButton = new System.Windows.Forms.Button();
            this.equationBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.variableBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // solveButton
            // 
            this.solveButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.solveButton.Location = new System.Drawing.Point(531, 104);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(259, 55);
            this.solveButton.TabIndex = 1;
            this.solveButton.Text = "Решить";
            this.solveButton.UseMnemonic = false;
            this.solveButton.UseVisualStyleBackColor = false;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // equationBox
            // 
            this.equationBox.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equationBox.Location = new System.Drawing.Point(248, 38);
            this.equationBox.Name = "equationBox";
            this.equationBox.Size = new System.Drawing.Size(477, 44);
            this.equationBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя переменной\r\n";
            // 
            // variableBox
            // 
            this.variableBox.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variableBox.Location = new System.Drawing.Point(62, 37);
            this.variableBox.Name = "variableBox";
            this.variableBox.Size = new System.Drawing.Size(48, 44);
            this.variableBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(394, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Введите уравнение";
            // 
            // InputForm
            // 
            this.ClientSize = new System.Drawing.Size(804, 170);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.variableBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.equationBox);
            this.Controls.Add(this.solveButton);
            this.Name = "InputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.TextBox equationBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox variableBox;
        private System.Windows.Forms.Label label2;
    }
}