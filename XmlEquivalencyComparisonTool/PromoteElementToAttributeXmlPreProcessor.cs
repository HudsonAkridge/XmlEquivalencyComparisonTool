using System.Linq;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
    public class PromoteElementToAttributeXmlPreProcessor : XmlPreProcessor
    {
        private readonly XName _elementToPromote;
        private readonly XName _attributeContainingValue;

        public PromoteElementToAttributeXmlPreProcessor(XName elementToPromote, XName attributeContainingValue)
        {
            _elementToPromote = elementToPromote;
            _attributeContainingValue = attributeContainingValue;
        }

        public override XElement Process(XElement document)
        {
            var result = new XElement(document);
            foreach (var element in result.Elements())
            {
                PromoteChildElementsToAttribute(element);
            }

            return result;
        }

        private void PromoteChildElementsToAttribute(XElement xElement)
        {
            var children = xElement.Elements().ToArray();
            if (!children.Any()) { return; }

            foreach (var child in xElement.Elements())
            {
                PromoteChildElementsToAttribute(child);
            }

            //Promote any columns up
            var matchingChild = xElement.Elements(_elementToPromote).FirstOrDefault();
            if (matchingChild != null)
            {
                PromoteMatchingChild(xElement, matchingChild);
            }
        }

        private void PromoteMatchingChild(XElement xElement, XElement matchingChild)
        {
            var valueOfAttribute = matchingChild.Attribute(_attributeContainingValue);
            xElement.SetAttributeValue(_elementToPromote, valueOfAttribute.Value);
            foreach (var childAttribute in matchingChild.Attributes())
            {
                //Check to see if we've already mapped this explicitly
                if (childAttribute.Name == _attributeContainingValue)
                { continue; }

                xElement.SetAttributeValue(childAttribute.Name, childAttribute.Value);
            }

            matchingChild.Remove();
        }
    }
}
