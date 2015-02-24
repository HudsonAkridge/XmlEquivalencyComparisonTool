using System;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
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
                ? new AreEquivalentResponse(false, String.Format("Attribute values for {0} are different. Expected: {1}, Actual: {2}", Attribute.Name, Attribute.Value, toCompareAttribute.Value))
                : new AreEquivalentResponse(true);
        }
    }
}