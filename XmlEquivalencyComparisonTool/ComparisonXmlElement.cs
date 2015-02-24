using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
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
            var responses = new List<AreEquivalentResponse>();

            var toCompareElement = toCompare.Element;
            if (Element.Name != toCompareElement.Name) { responses.Add(new AreEquivalentResponse(false, String.Format("Element name incorrect. Expected {0}, but was {1}", Element.Name, toCompareElement.Name))); }

            //Value concatenates all element values. We want to ensure that it's an element at the leaf, without any children elements, then we can do a value check
            if (!Element.HasElements && Element.Value != toCompareElement.Value) { responses.Add(new AreEquivalentResponse(false, String.Format("Element {0} value incorrect. Expected {1}, but was {2}", Element.Name, Element.Value, toCompareElement.Value))); }

            var missingAttributes = toCompare.Attributes.Keys.Except(Attributes.Keys);
            if (missingAttributes.Any()) { responses.Add(new AreEquivalentResponse(false, String.Format("Attributes missing: {0}", missingAttributes.Aggregate((x, y) => x + ", " + y)))); }

            var toCompareAttributes = toCompare.Attributes;

            foreach (var attribute in Attributes)
            {
                var toCompareAttribute = toCompareAttributes[attribute.Key];
                var response = attribute.Value.AreAttributesEquivalent(toCompareAttribute);

                if (response.Equivalent) { continue; }
                responses.Add(response);
            }

            //Compare all children elements
            //Are they missing elements?

            //Are the elements equivalent?

            return responses;
        }
    }
}