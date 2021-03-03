
namespace WSolver
{
    partial class RootsOutput
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
            this.Equation_label = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Equation_label
            // 
            this.Equation_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Equation_label.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Equation_label.Location = new System.Drawing.Point(0, 9);
            this.Equation_label.Name = "Equation_label";
            this.Equation_label.Size = new System.Drawing.Size(414, 35);
            this.Equation_label.TabIndex = 0;
            this.Equation_label.Text = "Equation";
            this.Equation_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Equation_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listBox1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 28;
            this.listBox1.Location = new System.Drawing.Point(46, 60);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(323, 424);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // RootsOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 531);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Equation_label);
            this.Name = "RootsOutput";
            this.Text = "RootsOutput";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Equation_label;
        private System.Windows.Forms.ListBox listBox1;
    }
}