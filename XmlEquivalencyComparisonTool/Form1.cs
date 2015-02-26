using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
    public partial class MainForm : Form
    {
        private IEnumerable<XmlPreProcessor> _xmlPreProcessors;
        private IEnumerable<StringPreProcessor> _stringPreProcessors;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            //TODO: Load both of these in deterministically based on options chosen in the UI
            _xmlPreProcessors = new List<XmlPreProcessor>
            {
                new RemoveAttributesFromXmlPreProcessor(attributesToIgnore.Items.Cast<string>()),
                new PromoteElementToAttributeXmlPreProcessor(XName.Get("column"), XName.Get("name"))
            };
            _stringPreProcessors = new List<StringPreProcessor>
            {
                new ClearXmlnsAttributeStringPreProcessor()
            };

            var expectedXmlText = tbFirstXml.Text;
            var comparisonXmlText = tbSecondXml.Text;
            foreach (var stringPreProcessor in _stringPreProcessors)
            {
                expectedXmlText = stringPreProcessor.Process(expectedXmlText);
                comparisonXmlText = stringPreProcessor.Process(comparisonXmlText);
            }

            var expectedXmlDoc = XElement.Parse(expectedXmlText);
            var comparisonXmlDoc = XElement.Parse(comparisonXmlText);
            foreach (var xmlPreProcessor in _xmlPreProcessors)
            {
                expectedXmlDoc = xmlPreProcessor.Process(expectedXmlDoc);
                comparisonXmlDoc = xmlPreProcessor.Process(comparisonXmlDoc);
            }

            var rootOne = new ComparisonXmlElement(expectedXmlDoc, new ComparisonConfiguration("expectedDoc"));
            var rootTwo = new ComparisonXmlElement(comparisonXmlDoc, new ComparisonConfiguration("comparisonDoc"));

            var results = rootOne.IsElementEquivalent(rootTwo);
            tbOutput.Text = results.Where(x => !x.Equivalent).Select(x => "- " + x.Reason).Aggregate((x, y) => x + Environment.NewLine + y);
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
