using System;
using System.Collections.Generic;
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
            var docOne = XDocument.Parse(tbFirstXml.Text);
            var docTwo = XDocument.Parse(tbSecondXml.Text);

            //Build element list for each document
            var elements = docOne.Elements();
        }

        public class ComparisonXmlElement
        {
            public XElement Element { get; set; }
            public IDictionary<string, ComparisonXmlAttribute> Attributes { get; set; }

            public ComparisonXmlElement(XElement element)
            {
                Element = element;
                Attributes = element.Attributes().ToDictionary(x => x.Name.ToString().ToLower(), x => new ComparisonXmlAttribute(x));
                Children = BuildChildren(element);
            }

            public List<ComparisonXmlElement> Children { get; set; }

            public List<ComparisonXmlElement> BuildChildren(XElement element)
            {
                return !element.HasElements ?
                    new List<ComparisonXmlElement>()
                    : element.Elements()
                    .Select(x => new ComparisonXmlElement(x))
                    .ToList();
            }

            public IList<AreEquivalentResponse> IsElementEquivalent(ComparisonXmlElement toCompare)
            {
                var missingAttributes = toCompare.Attributes.Keys.Except(Attributes.Keys);
                if (missingAttributes.Any())
                {
                    return new[] { new AreEquivalentResponse(false, string.Format("Attributes missing: {0}", missingAttributes.Aggregate((x, y) => x + ", " + y))) };
                }

                var toCompareAttributes = toCompare.Attributes;

                var responses = new List<AreEquivalentResponse>();
                foreach (var attribute in Attributes)
                {
                    var toCompareAttribute = toCompareAttributes[attribute.Key];
                    var response = attribute.Value.AreAttributesEquivalent(toCompareAttribute);

                    if (response.Equivalent) { continue; }
                    responses.Add(response);
                }

                return responses;
            }
        }

        public class ComparisonXmlAttribute
        {
            public XAttribute Attribute { get; set; }

            public ComparisonXmlAttribute(XAttribute attribute)
            {
                Attribute = attribute;
            }

            public AreEquivalentResponse AreAttributesEquivalent(ComparisonXmlAttribute toCompare)
            {
                var toCompareAttribute = toCompare.Attribute;

                return toCompareAttribute.Value != Attribute.Value
                    ? new AreEquivalentResponse(false, string.Format("Attribute values for {0} are different. Expected: {1}, Actual: {2}", Attribute.Name, Attribute.Value, toCompareAttribute.Value))
                    : new AreEquivalentResponse(true);
            }
        }

        public class AreEquivalentResponse
        {
            public AreEquivalentResponse(bool equivalent, string reason = "", AreEquivalentResponse innerResponse = null)
            {
                Equivalent = equivalent;
                Reason = reason;
                InnerResponse = innerResponse;
            }

            public bool Equivalent { get; set; }
            public string Reason { get; set; }
            public AreEquivalentResponse InnerResponse { get; set; }
        }
    }
}
