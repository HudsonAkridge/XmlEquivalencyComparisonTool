namespace XmlEquivalencyComparisonTool
{
    partial class MainForm
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
            this.attributesToIgnore = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAddIgnoreAttribute = new System.Windows.Forms.TextBox();
            this.btnAddToAttributeIgnoreList = new System.Windows.Forms.Button();
            this.btnClearAllAttributes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCompare
            // 
            this.buttonCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCompare.Location = new System.Drawing.Point(73, 455);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(75, 23);
            this.buttonCompare.TabIndex = 0;
            this.buttonCompare.Text = "Compare";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // tbFirstXml
            // 
            this.tbFirstXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFirstXml.Location = new System.Drawing.Point(12, 31);
            this.tbFirstXml.Multiline = true;
            this.tbFirstXml.Name = "tbFirstXml";
            this.tbFirstXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFirstXml.Size = new System.Drawing.Size(676, 166);
            this.tbFirstXml.TabIndex = 1;
            this.tbFirstXml.Text = "<Root b=\'2\' a=\'1\'><Child>1</Child></Root>";
            this.tbFirstXml.Click += new System.EventHandler(this.tbFirstXml_Enter);
            this.tbFirstXml.Enter += new System.EventHandler(this.tbFirstXml_Enter);
            // 
            // tbSecondXml
            // 
            this.tbSecondXml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSecondXml.Location = new System.Drawing.Point(12, 220);
            this.tbSecondXml.Multiline = true;
            this.tbSecondXml.Name = "tbSecondXml";
            this.tbSecondXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSecondXml.Size = new System.Drawing.Size(676, 224);
            this.tbSecondXml.TabIndex = 2;
            this.tbSecondXml.Text = "<Root a=\'1\' b=\'2\'><Child>1</Child></Root>";
            this.tbSecondXml.Click += new System.EventHandler(this.tbSecondXml_Enter);
            this.tbSecondXml.Enter += new System.EventHandler(this.tbSecondXml_Enter);
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Location = new System.Drawing.Point(12, 492);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(676, 170);
            this.tbOutput.TabIndex = 2;
            this.tbOutput.Text = "Output here...";
            this.tbOutput.Click += new System.EventHandler(this.tbOutput_Enter);
            this.tbOutput.Enter += new System.EventHandler(this.tbOutput_Enter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Expected Document";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Comparison Document";
            // 
            // attributesToIgnore
            // 
            this.attributesToIgnore.FormattingEnabled = true;
            this.attributesToIgnore.Items.AddRange(new object[] {
            "schema",
            "type"});
            this.attributesToIgnore.Location = new System.Drawing.Point(710, 48);
            this.attributesToIgnore.Name = "attributesToIgnore";
            this.attributesToIgnore.Size = new System.Drawing.Size(120, 95);
            this.attributesToIgnore.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(707, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Attributes to Ignore";
            // 
            // tbAddIgnoreAttribute
            // 
            this.tbAddIgnoreAttribute.Location = new System.Drawing.Point(710, 150);
            this.tbAddIgnoreAttribute.Name = "tbAddIgnoreAttribute";
            this.tbAddIgnoreAttribute.Size = new System.Drawing.Size(120, 20);
            this.tbAddIgnoreAttribute.TabIndex = 5;
            this.tbAddIgnoreAttribute.Text = "Att Name...";
            this.tbAddIgnoreAttribute.Click += new System.EventHandler(this.tbAddIgnoreAttribute_Enter);
            this.tbAddIgnoreAttribute.Enter += new System.EventHandler(this.tbAddIgnoreAttribute_Enter);
            // 
            // btnAddToAttributeIgnoreList
            // 
            this.btnAddToAttributeIgnoreList.Location = new System.Drawing.Point(710, 174);
            this.btnAddToAttributeIgnoreList.Name = "btnAddToAttributeIgnoreList";
            this.btnAddToAttributeIgnoreList.Size = new System.Drawing.Size(36, 23);
            this.btnAddToAttributeIgnoreList.TabIndex = 6;
            this.btnAddToAttributeIgnoreList.Text = "Add";
            this.btnAddToAttributeIgnoreList.UseVisualStyleBackColor = true;
            this.btnAddToAttributeIgnoreList.Click += new System.EventHandler(this.btnAddToAttributeIgnoreList_Click);
            // 
            // btnClearAllAttributes
            // 
            this.btnClearAllAttributes.Location = new System.Drawing.Point(752, 174);
            this.btnClearAllAttributes.Name = "btnClearAllAttributes";
            this.btnClearAllAttributes.Size = new System.Drawing.Size(51, 23);
            this.btnClearAllAttributes.TabIndex = 6;
            this.btnClearAllAttributes.Text = "Clear All";
            this.btnClearAllAttributes.UseVisualStyleBackColor = true;
            this.btnClearAllAttributes.Click += new System.EventHandler(this.btnClearAllAttributes_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 674);
            this.Controls.Add(this.btnClearAllAttributes);
            this.Controls.Add(this.btnAddToAttributeIgnoreList);
            this.Controls.Add(this.tbAddIgnoreAttribute);
            this.Controls.Add(this.attributesToIgnore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.tbSecondXml);
            this.Controls.Add(this.tbFirstXml);
            this.Controls.Add(this.buttonCompare);
            this.Name = "MainForm";
            this.Text = "Xml Equivalency Comparison Tool";
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
        private System.Windows.Forms.ListBox attributesToIgnore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAddIgnoreAttribute;
        private System.Windows.Forms.Button btnAddToAttributeIgnoreList;
        private System.Windows.Forms.Button btnClearAllAttributes;
    }
}

