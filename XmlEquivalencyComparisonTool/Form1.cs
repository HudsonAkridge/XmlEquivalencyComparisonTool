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
            var preProcessor = new PromotElementToAttributeXmlPreProcessor(XName.Get("column"), XName.Get("name"));

            var stringPreProcessor = new ClearXmlnsAttributeStringPreProcessor();
            var firstXml = stringPreProcessor.Process(tbFirstXml.Text);
            var secondXml = stringPreProcessor.Process(tbSecondXml.Text);
            var docOne = XElement.Parse(firstXml);
            var docTwo = XElement.Parse(secondXml);

            var processedDocOne = preProcessor.Process(docOne);
            var processedDocTwo = preProcessor.Process(docTwo);

            //Build element list for each document
            var rootOne = new ComparisonXmlElement(processedDocOne, new DocumentReference("Document One"));
            var rootTwo = new ComparisonXmlElement(processedDocTwo, new DocumentReference("Document Two"));

            var results = rootOne.IsElementEquivalent(rootTwo);
            tbOutput.Text = results.Where(x => !x.Equivalent).Select(x => x.Reason).Aggregate((x, y) => x + Environment.NewLine + y);
        }
    }
}
