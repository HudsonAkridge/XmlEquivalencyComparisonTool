using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

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
            var preProcessor = new PromoteElementToAttributeXmlPreProcessor(XName.Get("column"), XName.Get("name"));

            var xmlnsRemover = new ClearXmlnsAttributeStringPreProcessor();
            var firstXml = xmlnsRemover.Process(tbFirstXml.Text);
            var secondXml = xmlnsRemover.Process(tbSecondXml.Text);
            var docOne = XElement.Parse(firstXml);
            var docTwo = XElement.Parse(secondXml);

            var processedDocOne = preProcessor.Process(docOne);
            var processedDocTwo = preProcessor.Process(docTwo);

            //Build element list for each document
            var rootOne = new ComparisonXmlElement(processedDocOne, new DocumentReference("expected"));
            var rootTwo = new ComparisonXmlElement(processedDocTwo, new DocumentReference("comparison"));

            var results = rootOne.IsElementEquivalent(rootTwo);
            tbOutput.Text = results.Where(x => !x.Equivalent).Select(x => "- " + x.Reason).Aggregate((x, y) => x + Environment.NewLine + y);
        }
    }
}
