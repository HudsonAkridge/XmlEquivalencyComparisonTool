using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
    public class RemoveAttributesFromXmlPreProcessor : XmlPreProcessor
    {
        private readonly IEnumerable<XName> _attributeNames;

        public RemoveAttributesFromXmlPreProcessor(IEnumerable<string> attributeNames)
        {
            _attributeNames = attributeNames == null || !attributeNames.Any()
                ? Enumerable.Empty<XName>()
                : attributeNames.Select(XName.Get);
        }

        public override XElement Process(XElement document)
        {
            var result = new XElement(document);
            foreach (var element in result.DescendantsAndSelf())
            {
                RemoveMatchingAttributes(element);
            }

            return result;
        }

        private void RemoveMatchingAttributes(XElement xElement)
        {
            if (!xElement.HasAttributes)
            { return; }

            var matchingAttributes = xElement.Attributes().Where(x => _attributeNames.Contains(x.Name));
            foreach (var matchingAttribute in matchingAttributes)
            {
                matchingAttribute.Remove();
            }
        }
    }
}
