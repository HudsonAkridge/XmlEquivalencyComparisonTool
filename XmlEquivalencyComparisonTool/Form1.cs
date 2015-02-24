using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            //TODO: Break into two different lookup files
            var docOne = XDocument.Parse(tbFirstXml.Text);
            var docTwo = XDocument.Parse(tbSecondXml.Text);

            //Build element list for each document
            var rootOne = new ComparisonXmlElement(docOne.Root, new DocumentReference("Document One"));
            var rootTwo = new ComparisonXmlElement(docTwo.Root, new DocumentReference("Document Two"));

            var results = rootOne.IsElementEquivalent(rootTwo);
            tbOutput.Text = results.Where(x => !x.Equivalent).Select(x => x.Reason).Aggregate((x, y) => x + Environment.NewLine + y);
        }
    }
}
