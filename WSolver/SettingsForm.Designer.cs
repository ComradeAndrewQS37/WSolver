
namespace WSolver
{
    partial class SettingsForm
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
            this.outputPrecisionNum = new System.Windows.Forms.NumericUpDown();
            this.leftBorderNum = new System.Windows.Forms.NumericUpDown();
            this.rightBorderNum = new System.Windows.Forms.NumericUpDown();
            this.rootPrecisionNum = new System.Windows.Forms.NumericUpDown();
            this.outputPrecisionlabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.leftBorderLabel = new System.Windows.Forms.Label();
            this.rightBorderLabel = new System.Windows.Forms.Label();
            this.setDefaultButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.outputPrecisionNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBorderNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBorderNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootPrecisionNum)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputPrecisionNum
            // 
            this.outputPrecisionNum.Location = new System.Drawing.Point(346, 12);
            this.outputPrecisionNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.outputPrecisionNum.Name = "outputPrecisionNum";
            this.outputPrecisionNum.Size = new System.Drawing.Size(120, 22);
            this.outputPrecisionNum.TabIndex = 0;
            this.outputPrecisionNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // leftBorderNum
            // 
            this.leftBorderNum.DecimalPlaces = 2;
            this.leftBorderNum.Location = new System.Drawing.Point(220, 91);
            this.leftBorderNum.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.leftBorderNum.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.leftBorderNum.Name = "leftBorderNum";
            this.leftBorderNum.Size = new System.Drawing.Size(120, 22);
            this.leftBorderNum.TabIndex = 1;
            this.leftBorderNum.ThousandsSeparator = true;
            this.leftBorderNum.Value = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            // 
            // rightBorderNum
            // 
            this.rightBorderNum.DecimalPlaces = 2;
            this.rightBorderNum.Location = new System.Drawing.Point(376, 91);
            this.rightBorderNum.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.rightBorderNum.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.rightBorderNum.Name = "rightBorderNum";
            this.rightBorderNum.Size = new System.Drawing.Size(120, 22);
            this.rightBorderNum.TabIndex = 2;
            this.rightBorderNum.ThousandsSeparator = true;
            this.rightBorderNum.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // rootPrecisionNum
            // 
            this.rootPrecisionNum.Location = new System.Drawing.Point(288, 51);
            this.rootPrecisionNum.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.rootPrecisionNum.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.rootPrecisionNum.Name = "rootPrecisionNum";
            this.rootPrecisionNum.Size = new System.Drawing.Size(120, 22);
            this.rootPrecisionNum.TabIndex = 3;
            this.rootPrecisionNum.Value = new decimal(new int[] {
            7,
            0,
            0,
            -2147483648});
            // 
            // outputPrecisionlabel
            // 
            this.outputPrecisionlabel.AutoSize = true;
            this.outputPrecisionlabel.Location = new System.Drawing.Point(42, 14);
            this.outputPrecisionlabel.Name = "outputPrecisionlabel";
            this.outputPrecisionlabel.Size = new System.Drawing.Size(303, 34);
            this.outputPrecisionlabel.TabIndex = 4;
            this.outputPrecisionlabel.Text = "Количество выводимых цифр после запятой\r\n\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Точность нахождения корня: 10^";
            // 
            // leftBorderLabel
            // 
            this.leftBorderLabel.AutoSize = true;
            this.leftBorderLabel.Location = new System.Drawing.Point(12, 91);
            this.leftBorderLabel.Name = "leftBorderLabel";
            this.leftBorderLabel.Size = new System.Drawing.Size(202, 17);
            this.leftBorderLabel.TabIndex = 6;
            this.leftBorderLabel.Text = "Искать корни в диапазоне от";
            // 
            // rightBorderLabel
            // 
            this.rightBorderLabel.AutoSize = true;
            this.rightBorderLabel.Location = new System.Drawing.Point(346, 91);
            this.rightBorderLabel.Name = "rightBorderLabel";
            this.rightBorderLabel.Size = new System.Drawing.Size(24, 17);
            this.rightBorderLabel.TabIndex = 7;
            this.rightBorderLabel.Text = "до";
            // 
            // setDefaultButton
            // 
            this.setDefaultButton.Location = new System.Drawing.Point(15, 29);
            this.setDefaultButton.Name = "setDefaultButton";
            this.setDefaultButton.Size = new System.Drawing.Size(115, 29);
            this.setDefaultButton.TabIndex = 8;
            this.setDefaultButton.Text = "По умолчанию";
            this.setDefaultButton.UseVisualStyleBackColor = true;
            this.setDefaultButton.Click += new System.EventHandler(this.setDefaultButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(136, 29);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(92, 29);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(234, 29);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(92, 30);
            this.applyButton.TabIndex = 10;
            this.applyButton.Text = "Сохранить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.setDefaultButton);
            this.panel1.Controls.Add(this.applyButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Location = new System.Drawing.Point(210, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 69);
            this.panel1.TabIndex = 11;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 245);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rightBorderLabel);
            this.Controls.Add(this.leftBorderLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputPrecisionlabel);
            this.Controls.Add(this.rootPrecisionNum);
            this.Controls.Add(this.rightBorderNum);
            this.Controls.Add(this.leftBorderNum);
            this.Controls.Add(this.outputPrecisionNum);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.outputPrecisionNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBorderNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBorderNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootPrecisionNum)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown outputPrecisionNum;
        private System.Windows.Forms.NumericUpDown leftBorderNum;
        private System.Windows.Forms.NumericUpDown rightBorderNum;
        private System.Windows.Forms.NumericUpDown rootPrecisionNum;
        private System.Windows.Forms.Label outputPrecisionlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label leftBorderLabel;
        private System.Windows.Forms.Label rightBorderLabel;
        private System.Windows.Forms.Button setDefaultButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Panel panel1;
    }
}