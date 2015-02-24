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
            this.SuspendLayout();
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(91, 226);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(75, 23);
            this.buttonCompare.TabIndex = 0;
            this.buttonCompare.Text = "Compare";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // tbFirstXml
            // 
            this.tbFirstXml.Location = new System.Drawing.Point(30, 31);
            this.tbFirstXml.Multiline = true;
            this.tbFirstXml.Name = "tbFirstXml";
            this.tbFirstXml.Size = new System.Drawing.Size(210, 74);
            this.tbFirstXml.TabIndex = 1;
            // 
            // tbSecondXml
            // 
            this.tbSecondXml.Location = new System.Drawing.Point(30, 134);
            this.tbSecondXml.Multiline = true;
            this.tbSecondXml.Name = "tbSecondXml";
            this.tbSecondXml.Size = new System.Drawing.Size(210, 86);
            this.tbSecondXml.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
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
    }
}

