using System;
using System.Linq;
using System.Windows.Forms;

namespace XmlEquivalencyComparisonTool
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            Compare();
        }

        private void Compare()
        {
            var comparer = new XmlEquivalencyComparisonService(attributesToIgnore.Items.Cast<string>());
            tbOutput.Text = comparer.Compare(tbFirstXml.Text, tbSecondXml.Text);
        }

        private void btnAddToAttributeIgnoreList_Click(object sender, EventArgs e)
        {
            attributesToIgnore.Items.Add(tbAddIgnoreAttribute.Text);
        }

        private void btnClearAllAttributes_Click(object sender, EventArgs e)
        {
            attributesToIgnore.Items.Clear();
        }

        private void tbAddIgnoreAttribute_Enter(object sender, EventArgs e)
        {
            tbAddIgnoreAttribute.SelectAll();
        }

        private void tbFirstXml_Enter(object sender, EventArgs e)
        {
            tbFirstXml.SelectAll();
        }

        private void tbSecondXml_Enter(object sender, EventArgs e)
        {
            tbSecondXml.SelectAll();
        }

        private void tbOutput_Enter(object sender, EventArgs e)
        {
            tbOutput.SelectAll();
        }
    }
}
