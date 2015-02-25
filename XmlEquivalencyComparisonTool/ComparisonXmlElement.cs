using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
    public class ComparisonXmlElement
    {
        public XElement ActualElement { get; set; }
        public IDictionary<string, ComparisonXmlAttribute> Attributes { get; set; }
        public DocumentReference ParentDocument { get; set; }
        public ComparisonXmlElement ParentElement { get; set; }

        public ComparisonXmlElement(XElement actualElement, DocumentReference parentDocument, ComparisonXmlElement parentElement = null)
        {
            ActualElement = actualElement;
            ParentDocument = parentDocument;
            ParentElement = parentElement;

            Attributes = actualElement.Attributes().ToDictionary(x => x.Name.ToString().ToLower(), x => new ComparisonXmlAttribute(x, this, ParentDocument));
            Children = BuildChildren(actualElement);
        }

        public IDictionary<string, ComparisonXmlElement> Children { get; set; }

        public IDictionary<string, ComparisonXmlElement> BuildChildren(XElement element)
        {
            return !element.HasElements ?
                new Dictionary<string, ComparisonXmlElement>()
                : element.Elements()
                    .ToDictionary(GetElementKey, x => new ComparisonXmlElement(x, ParentDocument, this));
        }

        private string GetElementKey(XElement element)
        {
            var nameAttribute = element.Attribute(XName.Get("name"));
            var nameAttributeValue = nameAttribute == null ? string.Empty : nameAttribute.Value;

            return element.Name + nameAttributeValue;
        }

        public IList<AreEquivalentResponse> IsElementEquivalent(ComparisonXmlElement toCompare)
        {
            var responses = new List<AreEquivalentResponse>();
            BuildSelfElementResponses(toCompare, responses);
            BuildAttributeResponses(toCompare, responses);
            BuildChildrenElementResponses(toCompare, responses);

            return responses;
        }

        private void BuildSelfElementResponses(ComparisonXmlElement toCompare, List<AreEquivalentResponse> responses)
        {
            var toCompareElement = toCompare.ActualElement;
            if (ActualElement.Name.ToString() != toCompareElement.Name.ToString())
            {
                responses.Add(new AreEquivalentResponse(false,
                    String.Format("{0}/ Element name incorrect. Expected <{1}>, but was <{2}>", GetFullPath(),
                        ActualElement.Name, toCompareElement.Name)));
            }

            //Value concatenates all element values. We want to ensure that it's an element at the leaf, without any children elements, then we can do a value check
            if (!ActualElement.HasElements && ActualElement.Value != toCompareElement.Value)
            {
                responses.Add(new AreEquivalentResponse(false,
                    String.Format("{0}/ VALUE is incorrect. Expected {1}, but was {2}", GetFullPath(), ActualElement.Value,
                        toCompareElement.Value)));
            }
        }

        private void BuildChildrenElementResponses(ComparisonXmlElement toCompare, List<AreEquivalentResponse> responses)
        {
            //Compare all children elements
            //Are they missing elements?
            var missingElementsOnPrimary = Children.Keys.Except(toCompare.Children.Keys);
            var missingElementsOnComparison = toCompare.Children.Keys.Except(Children.Keys);
            if (missingElementsOnPrimary.Any())
            {
                responses.Add(new AreEquivalentResponse(false,
                    String.Format("{0}/ Elements missing from document: {1}", GetFullPath(),
                        missingElementsOnPrimary.Aggregate((x, y) =>  x + ", " + y ))));
            }
            if (missingElementsOnComparison.Any())
            {
                responses.Add(new AreEquivalentResponse(false,
                    String.Format("{0}/ Elements missing from document: {1}", toCompare.GetFullPath(),
                        missingElementsOnComparison.Aggregate((x, y) => x + ", " + y ))));
            }

            //Are the elements equivalent?
            foreach (var child in Children)
            {
                ComparisonXmlElement toCompareChild;
                toCompare.Children.TryGetValue(child.Key, out toCompareChild);
                if (toCompareChild == null)
                {
                    continue;
                }

                var response = child.Value.IsElementEquivalent(toCompareChild);

                responses.AddRange(response);
            }
        }

        private void BuildAttributeResponses(ComparisonXmlElement toCompare, List<AreEquivalentResponse> responses)
        {
            var missingAttributesOnPrimary = Attributes.Keys.Except(toCompare.Attributes.Keys);
            if (missingAttributesOnPrimary.Any())
            {
                responses.Add(new AreEquivalentResponse(false,
                    String.Format("{0}/ Attributes missing: {1}", GetFullPath(),
                        missingAttributesOnPrimary.Aggregate((x, y) => x + ", " + y))));
            }
            var missingAttributesOnComparison = toCompare.Attributes.Keys.Except(Attributes.Keys);
            if (missingAttributesOnComparison.Any())
            {
                responses.Add(new AreEquivalentResponse(false,
                    String.Format("{0}/ Attributes missing: {1}", toCompare.GetFullPath(),
                        missingAttributesOnComparison.Aggregate((x, y) => x + ", " + y))));
            }

            var toCompareAttributes = toCompare.Attributes;

            foreach (var attribute in Attributes)
            {
                ComparisonXmlAttribute toCompareAttribute;
                toCompareAttributes.TryGetValue(attribute.Key, out toCompareAttribute);
                if (toCompareAttribute == null)
                {
                    continue;
                }

                var response = attribute.Value.AreAttributesEquivalent(toCompareAttribute);

                if (response.Equivalent)
                {
                    continue;
                }
                responses.Add(response);
            }
        }

        internal string GetFullPath()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("/{0}", ActualElement.Name));
            stringBuilder.Insert(0,
                ParentElement == null ?
                    string.Format("{0}", ParentDocument.Name)
                    : ParentElement.GetFullPath());

            return stringBuilder.ToString();
        }
    }
}