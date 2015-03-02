using System.Linq;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
    public class AddSchemaToTableAttributeXmlPreProcessor : XmlPreProcessor
    {
        private readonly XName _classElementName = XName.Get("class");
        private readonly XName _schemaAttributeName = XName.Get("schema");
        private readonly XName _tableAttributeName = XName.Get("table");

        public override XElement Process(XElement document)
        {
            var classElementWithSchemaAttribute = document.DescendantsAndSelf()
                .FirstOrDefault(x => x.Name == _classElementName && x.Attributes().Any(y => y.Name == _schemaAttributeName));

            if (classElementWithSchemaAttribute == null)
            { return document; }

            var schemaAttribute = classElementWithSchemaAttribute.Attributes().FirstOrDefault(x => x.Name == _schemaAttributeName);
            if (schemaAttribute == null)
            { return document; }

            var elementsWithTableAttribute = document.DescendantsAndSelf()
                .Where(x => x.Attributes().Any(y => y.Name == _tableAttributeName));
            if (!elementsWithTableAttribute.Any())
            { return document; }

            foreach (var tableAttributeContainer in elementsWithTableAttribute)
            {
                var tableAttribute = tableAttributeContainer.Attributes().SingleOrDefault(x => x.Name == _tableAttributeName);
                if (tableAttribute == null) { continue; }

                tableAttribute.SetValue(string.Format("{0}.{1}", schemaAttribute.Value, tableAttribute.Value));
            }

            return document;
        }
    }
}
