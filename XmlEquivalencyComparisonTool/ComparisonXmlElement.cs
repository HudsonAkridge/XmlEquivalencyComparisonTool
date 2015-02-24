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

        public IDictionary<string, ComparisonXmlElement> Children { get; set; }

        public IDictionary<string,ComparisonXmlElement> BuildChildren(XElement element)
        {
            return !element.HasElements ?
                new Dictionary<string, ComparisonXmlElement>()
                :  element.Elements()
                    .ToDictionary(x=> x.Name.ToString(), x => new ComparisonXmlElement(x));
        }

        public IList<AreEquivalentResponse> IsElementEquivalent(ComparisonXmlElement toCompare)
        {
            var responses = new List<AreEquivalentResponse>();

            var toCompareElement = toCompare.Element;
            if (Element.Name.ToString() != toCompareElement.Name.ToString()) { responses.Add(new AreEquivalentResponse(false, String.Format("Element name incorrect. Expected {0}, but was {1}", Element.Name, toCompareElement.Name))); }

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
            var missingElements = toCompare.Children.Keys.Except(Children.Keys);
            if (missingElements.Any()) { responses.Add(new AreEquivalentResponse(false, String.Format("Elements missing: {0}", missingElements.Aggregate((x, y) => x + ", " + y)))); }

            //Are the elements equivalent?
            foreach (var child in Children)
            {
                var toCompareChild = toCompare.Children[child.Key];
                var response = child.Value.IsElementEquivalent(toCompareChild);

                responses.AddRange(response);
            }

            return responses;
        }
    }
}