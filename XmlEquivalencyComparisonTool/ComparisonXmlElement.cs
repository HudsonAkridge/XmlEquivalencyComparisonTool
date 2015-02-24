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
                    .ToDictionary(x => x.Name.ToString(), x => new ComparisonXmlElement(x, ParentDocument, this));
        }

        public IList<AreEquivalentResponse> IsElementEquivalent(ComparisonXmlElement toCompare)
        {
            var responses = new List<AreEquivalentResponse>();

            var toCompareElement = toCompare.ActualElement;
            if (ActualElement.Name.ToString() != toCompareElement.Name.ToString()) { responses.Add(new AreEquivalentResponse(false, String.Format("{0}/ Element name incorrect. Expected <{1}>, but was <{2}>", GetFullPath(), ActualElement.Name, toCompareElement.Name))); }

            //Value concatenates all element values. We want to ensure that it's an element at the leaf, without any children elements, then we can do a value check
            if (!ActualElement.HasElements && ActualElement.Value != toCompareElement.Value) { responses.Add(new AreEquivalentResponse(false, String.Format("{0}/ VALUE is incorrect. Expected {1}, but was {2}", GetFullPath(), ActualElement.Value, toCompareElement.Value))); }

            var missingAttributes = toCompare.Attributes.Keys.Except(Attributes.Keys);
            if (missingAttributes.Any()) { responses.Add(new AreEquivalentResponse(false, String.Format("{0}/ Attributes missing: {1}", GetFullPath(), missingAttributes.Aggregate((x, y) => x + ", " + y)))); }

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
            if (missingElements.Any()) { responses.Add(new AreEquivalentResponse(false, String.Format("{0}/ Elements missing from one or the other of the documents: <{1}>", GetFullPath(), missingElements.Aggregate((x, y) => x + ", " + y)))); }

            //Are the elements equivalent?
            foreach (var child in Children)
            {
                var toCompareChild = toCompare.Children[child.Key];
                var response = child.Value.IsElementEquivalent(toCompareChild);

                responses.AddRange(response);
            }

            return responses;
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