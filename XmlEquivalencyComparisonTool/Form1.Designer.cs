namespace XmlEquivalencyComparisonTool
{
    partial class Form1
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
            this.buttonCompare = new System.Windows.Forms.Button();
            this.tbFirstXml = new System.Windows.Forms.TextBox();
            this.tbSecondXml = new System.Windows.Forms.TextBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(76, 226);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(75, 23);
            this.buttonCompare.TabIndex = 0;
            this.buttonCompare.Text = "Compare";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // tbFirstXml
            // 
            this.tbFirstXml.Location = new System.Drawing.Point(12, 31);
            this.tbFirstXml.Multiline = true;
            this.tbFirstXml.Name = "tbFirstXml";
            this.tbFirstXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFirstXml.Size = new System.Drawing.Size(460, 74);
            this.tbFirstXml.TabIndex = 1;
            this.tbFirstXml.Text = "<Root b=\'2\' a=\'1\'><Child>1</Child></Root>";
            // 
            // tbSecondXml
            // 
            this.tbSecondXml.Location = new System.Drawing.Point(12, 134);
            this.tbSecondXml.Multiline = true;
            this.tbSecondXml.Name = "tbSecondXml";
            this.tbSecondXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSecondXml.Size = new System.Drawing.Size(460, 86);
            this.tbSecondXml.TabIndex = 2;
            this.tbSecondXml.Text = "<Root a=\'1\' b=\'2\'><Child>1</Child></Root>";
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(12, 268);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(460, 170);
            this.tbOutput.TabIndex = 2;
            this.tbOutput.Text = "Output here...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Expected Document";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Comparison Document";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.tbSecondXml);
            this.Controls.Add(this.tbFirstXml);
            this.Controls.Add(this.buttonCompare);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.TextBox tbFirstXml;
        private System.Windows.Forms.TextBox tbSecondXml;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

