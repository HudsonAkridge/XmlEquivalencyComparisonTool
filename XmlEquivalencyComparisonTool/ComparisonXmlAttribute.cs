using System;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
    public class ComparisonXmlAttribute
    {
        public XAttribute Attribute { get; set; }
        public ComparisonXmlElement ParentElement { get; set; }
        public DocumentReference ParentDocument { get; set; }

        public ComparisonXmlAttribute(XAttribute attribute, ComparisonXmlElement parentElement, DocumentReference parentDocument)
        {
            Attribute = attribute;
            ParentElement = parentElement;
            ParentDocument = parentDocument;
        }

        public AreEquivalentResponse AreAttributesEquivalent(ComparisonXmlAttribute toCompare)
        {
            var toCompareAttribute = toCompare.Attribute;

            return toCompareAttribute.Value != Attribute.Value
                ? new AreEquivalentResponse(false, String.Format("{0}/@{1}-> attributes are different. Expected: {2}, Actual: {3}", ParentElement.GetFullPath(), Attribute.Name, Attribute.Value, toCompareAttribute.Value))
                : new AreEquivalentResponse(true);
        }
    }
}