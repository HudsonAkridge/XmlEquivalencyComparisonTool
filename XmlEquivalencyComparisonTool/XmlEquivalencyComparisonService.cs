using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
    public class XmlEquivalencyComparisonService
    {
        private readonly IEnumerable<string> _attributesToIgnore;

        public XmlEquivalencyComparisonService(IEnumerable<string> attributesToIgnore)
        {
            _attributesToIgnore = attributesToIgnore;
        }

        public string Compare(string expectedDocument, string comparisonDocument)
        {
            var expectedXmlText = expectedDocument;
            var comparisonXmlText = comparisonDocument;
            var stringPreProcessors = new List<StringPreProcessor>
            {
                new ClearXmlnsAttributeStringPreProcessor()
            };
            foreach (var stringPreProcessor in stringPreProcessors)
            {
                expectedXmlText = stringPreProcessor.Process(expectedXmlText);
                comparisonXmlText = stringPreProcessor.Process(comparisonXmlText);
            }

            var expectedXmlDoc = XElement.Parse(expectedXmlText);
            var comparisonXmlDoc = XElement.Parse(comparisonXmlText);
            var xmlPreProcessors = new List<XmlPreProcessor>
            {
                new AddSchemaToTableAttributeXmlPreProcessor(),
                new RemoveAttributesFromXmlPreProcessor(_attributesToIgnore),
                new PromoteElementToAttributeXmlPreProcessor(XName.Get("column"), XName.Get("name"))
            };
            foreach (var xmlPreProcessor in xmlPreProcessors)
            {
                expectedXmlDoc = xmlPreProcessor.Process(expectedXmlDoc);
                comparisonXmlDoc = xmlPreProcessor.Process(comparisonXmlDoc);
            }

            var rootOne = new ComparisonXmlElement(expectedXmlDoc, new ComparisonConfiguration("expectedDoc"));
            var rootTwo = new ComparisonXmlElement(comparisonXmlDoc, new ComparisonConfiguration("comparisonDoc"));

            var results = rootOne.IsElementEquivalent(rootTwo);
            return results.Any()
                ? results.Where(x => !x.Equivalent).Select(x => "- " + x.Reason).Aggregate((x, y) => x + Environment.NewLine + y)
                : "No differences detected.";
        }
    }
}
