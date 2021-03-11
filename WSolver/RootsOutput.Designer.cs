
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RootsOutput));
            this.Equation_label = new System.Windows.Forms.Label();
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
            // 
            // RootsOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(412, 189);
            this.Controls.Add(this.Equation_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RootsOutput";
            this.Text = "RootsOutput";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Equation_label;
    }
}