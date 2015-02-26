using System.Linq;
using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
    public class ClearXmlnsAttributePreProcessor : XmlPreProcessor
    {
        private readonly XName _xmlns = XName.Get("xmlns");

        public override XElement Process(XElement document)
        {
            var result = new XElement(document);
            foreach (var element in result.DescendantsAndSelf())
            {
                RemoveXmlnsAttribute(element);
            }

            return result;
        }

        public void RemoveXmlnsAttribute(XElement xElement)
        {
            var namespaceAttributes = xElement.Attributes().Where(x => x.IsNamespaceDeclaration && x.Name.LocalName == _xmlns.LocalName);
            if (!namespaceAttributes.Any()) return;

            foreach (var namespaceAttribute in namespaceAttributes)
            {
                namespaceAttribute.Remove();
            }
        }
    }
}
