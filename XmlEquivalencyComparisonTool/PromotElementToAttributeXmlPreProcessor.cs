using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
    public class PromotElementToAttributeXmlPreProcessor : XmlPreProcessor
    {
        private readonly XName _elementToPromote;
        private readonly XName _attributeContainingValue;
        private string _namespace;

        public PromotElementToAttributeXmlPreProcessor(XName elementToPromote, XName attributeContainingValue)
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

        public void PromoteChildElementsToAttribute(XElement xElement)
        {
            var elementNamespace = xElement.GetDefaultNamespace();
            if (elementNamespace.ToString() == string.Empty)
            {

            }
            var children = xElement.Elements().ToArray();
            if (!children.Any()) { return; }

            //Promote any columns up
            var matchingChildren = xElement.Elements(_elementToPromote).ToArray();
            if (matchingChildren.Any())
            {
                PromoteMatchingChild(xElement, matchingChildren);
            }

            foreach (var child in xElement.Elements())
            {
                PromoteChildElementsToAttribute(child);
            }
        }

        private void PromoteMatchingChild(XElement xElement, XElement[] matchingChildren)
        {
            foreach (var matchingChild in matchingChildren)
            {
                var valueOfAttribute = matchingChild.Attribute(_attributeContainingValue);
                xElement.SetAttributeValue(_elementToPromote, valueOfAttribute.Value);
                foreach (var childAttribute in matchingChild.Attributes())
                {
                    //Check to see if we've already mapped this explicitly
                    if (childAttribute.Name == _attributeContainingValue)
                    {
                        continue;
                    }

                    xElement.SetAttributeValue(childAttribute.Name, childAttribute.Value);
                }

                matchingChild.Remove();
            }
        }
    }
}
